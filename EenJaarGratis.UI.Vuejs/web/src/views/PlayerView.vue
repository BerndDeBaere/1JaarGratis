<template>
  <div class="container">

    <h1 class="text-center text-xl mt-4" v-if='this.isNew && this.player.name === ""'>Nieuwe speler</h1>
    <h1 class="text-center text-xl mt-4" v-if='this.player.name !== ""'>{{ player.name }}</h1>

    <form>
      <div class="form-group">
        <label for="Name">Naam</label>
        <input type="text" class="form-control" placeholder="Naam invullen" v-model="this.player.name">
      </div>
      <div class="form-group">
        <label for="Name">Code</label>
        <input type="text" class="form-control" placeholder="Code scannen" v-model="this.player.code">
      </div>

      <div class="mb-2 float-right">
        <div class="btn-group" role="group">
          <button type="button" class="btn btn-outline-danger" @click="cancel">
            <i class="lni lni-cross-circle"></i> Annuleren
          </button>
          <button type="button" class="btn btn-outline-secondary" @click="savePlayer">
            <i class="lni lni-save"></i> Opslaan
          </button>
        </div>
      </div>

      <div class="videoContainer">
      <video id="qrVideo"></video>
      </div>
    </form>
  </div>
</template>

<style>
.videoContainer{
  width: 100%;
  display: flex;
  justify-content: center;
}
video{
  height: 50vh;
  max-width: 60vw;
}
</style>

<script>
import {useRoute, useRouter} from 'vue-router'
import {mapGetters, useStore} from 'vuex'
import QrScanner from "qr-scanner"

let store;
let router;
let scanner;
export default ({
  name: "PlayerView",
  mounted() {
    store = useStore();
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

    scanner = new QrScanner(
        document.getElementById("qrVideo"),
        result => {
          this.player.code = result;
        }
    );
    scanner.start();
  },
  computed: {
    ...mapGetters({
      players: 'getPlayers'
    })
  },
  unmounted() {
    scanner.stop();
  },
  methods: {
    cancel(){
      router.push({name: 'players'})
    },
    savePlayer() {
      if (this.isNew) this.createPlayer();
      else this.updatePlayer();
    },
    createPlayer() {
      store.dispatch("addPlayer", this.player);
      router.push({name: 'players'});
    },
    updatePlayer() {
      store.dispatch("updatePlayer", this.player);
      router.push({name: 'players'});
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
