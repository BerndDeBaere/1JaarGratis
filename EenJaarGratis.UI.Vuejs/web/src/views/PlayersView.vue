<template>
  <div class="container">
    <h1 class="text-center text-xl mt-4">Spelers</h1>
    <div class="mb-2 float-right">
      <div class="btn-group" role="group" aria-label="Basic example">
        <button class="btn btn-outline-secondary" @click="newPlayer"><i class="lni lni-circle-plus"></i></button>
      </div>
    </div>
    <br>

    <table class="table">
      <thead>
      <tr>
        <th scope="col">Name</th>
        <th scope="col">Code</th>
        <th class="col-2" scope="col">Actions</th>
      </tr>
      </thead>
      <tbody>
      <tr v-for='player in players' :key="player.id">
        <td>{{ player.name }}</td>
        <td>{{ player.code }}</td>
        <td>
          <div class="btn-group" role="group" aria-label="Basic example">
            <button class="btn btn-outline-secondary btn-sm" @click="editPlayer(player)"><i class="lni lni-pencil"></i> Bewerken
            </button>
            <button class="btn btn-outline-danger btn-sm" @click="deletePlayer(player)"><i
                class="lni lni-trash-can"></i></button>
          </div>
        </td>
      </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
import {useRouter} from 'vue-router'
import {mapGetters, useStore} from 'vuex';

let router;
let store;
export default {
  name: 'PlayersView',
  setup() {
    store = useStore();
    router = useRouter();
  },
  computed: {
    ...mapGetters({
      players: 'getPlayers'
    })
  },
  methods: {
    newPlayer() {
      router.push({name: 'newPlayer'})
    },
    deletePlayer(player) {
      store.dispatch("deletePlayer", player)
    },
    editPlayer(player) {
      router.push({name: 'editPlayer', params: {id: player.id}})
    }
  }
}

</script>
