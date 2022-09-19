<template>
  <div class="container">
    <h1 class="text-center text-xl mt-4">Spelers</h1>

  <table class="table">
    <thead>
    <tr>
      <th scope="col">Id</th>
      <th scope="col">Name</th>
      <th scope="col">Code</th>
      <th scope="col">Actions</th>
    </tr>
    </thead>
    <tbody>
    <tr v-for='player in players' :key="player.id">
      <th scope="row">{{player.id}}</th>
      <td>{{player.name}}</td>
      <td>{{player.code}}</td>
      <td>
        <div class="btn-group" role="group" aria-label="Basic example">

        <button class="btn btn-outline-secondary btn-sm" @click="editPlayer(player)">Edit</button>
        <button class="btn btn-outline-danger btn-sm" @click="deletePlayer(player)">Delete</button>
        </div>
      </td>
    </tr>
    </tbody>
  </table>
  </div>
</template>

<script>
export default {
  name: 'PlayersView',
  computed: {
    players() {
      return this.$store.state.players;
    }
  },
  methods:{
    deletePlayer(player){
      this.$store.dispatch("deletePlayer", player)
    },
    editPlayer(player){
      this.$store.dispatch("deletePlayer", player)
    }
  }
}

</script>
