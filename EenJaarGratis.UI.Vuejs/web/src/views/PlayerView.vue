<template>
  <b-container :toast="{root: true}">

    <h1 class="text-center text-xl mt-4" v-if='this.isNew && this.player.name === ""'>Nieuwe speler</h1>
    <h1 class="text-center text-xl mt-4" v-if='this.player.name !== ""'>{{ player.name }}</h1>

    <b-form-group>
      <label for="Name">Naam</label>
      <b-form-input placeholder="Naam invullen" v-model=this.player.name></b-form-input>
    </b-form-group>
    <b-form-group>
      <label for="Name">Code</label>
      <b-form-input placeholder="Code inscannen" v-model=this.player.code></b-form-input>
    </b-form-group>

    <b-button-group class="float-end">
      <b-button variant="outline-danger" @click="cancel"><i class="lni lni-cross-circle"></i> Annuleren</b-button>
      <b-button variant="outline-secondary" @click="savePlayer"><i class="lni lni-save"></i> Opslaan</b-button>
    </b-button-group>

    <div class="videoContainer">
      <qrcode-stream @decode="onDecode"></qrcode-stream>
    </div>
  </b-container>
</template>

<style>
.videoContainer {
  width: 100%;
  display: flex;
  justify-content: center;
}

video {
  height: 50vh;
  max-width: 60vw;
}
</style>

<script>
import {useRoute, useRouter} from 'vue-router'
import {mapActions, mapGetters} from 'vuex'
import { QrcodeStream } from 'vue3-qrcode-reader'

let router;
export default ({
  name: "PlayerView",
  mounted() {
    router = useRouter();
    const route = useRoute();
    const id = route.params.id;
    if (id !== undefined) {
      this.player = {...this.players.find(p => p.id === parseInt(id))}
    }
    if (this.player.id === undefined) {
      this.isNew = true;
      this.player.name = ""
      this.player.code = ""
    }
  },
  computed: {
    ...mapGetters({
      players: 'getPlayers',
      toast: "getToast"
    })
  },
  components:{
    QrcodeStream
  },
  methods: {
    ...mapActions({
      postPlayer: "postPlayer",
      putPlayer: "putPlayer"
    }),
    cancel() {
      router.push({name: 'players'})
    },
    onDecode(decodedString){
      this.player.code = decodedString
    },
    savePlayer() {
      if (this.isNew) this.createPlayer();
      else this.updatePlayer();
    },
    async createPlayer() {
      const response = await this.postPlayer(this.player);
      if(response.isSuccess) {
        router.push({name: 'players'});
      }
      else{
        this.showToast(response.data)
      }
    },
    async updatePlayer() {
      const response = await this.putPlayer(this.player);
      if(response.isSuccess) {
        router.push({name: 'players'});
      }
      else{
        this.showToast(response.data)
      }
    },
    showToast(message){
      this.toast.show({
        title: 'Let op!',
        body: message,
      }, {
        variant: 'warning',
        delay: 5000,
        pos: 'bottom-center',
      });
    }
  },
  data() {
    return {
      isNew: false,
      player: {}
    }
  }
});
</script>
