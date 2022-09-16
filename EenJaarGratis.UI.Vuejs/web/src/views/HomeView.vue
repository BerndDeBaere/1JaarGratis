<template>
  <router-link :to="{name:'players'}">Spelers</router-link>
  <router-link :to="{name:'questions'}">Vragen</router-link>
  <router-link :to="{name:'scoreboard'}">Scorebord</router-link>
</template>

<script>
export default {
  name: 'PlayersView',
  setup() {
    return {
      columns: [
        {
          title: "Id",
          key: "id"
        },
        {
          title: "Naam",
          key: "name"
        }
      ],
      pagination: false
    };
  },
  mounted() {
    this.$store.dispatch("fetchPlayers")
  },
  computed: {
    players() {
      return this.$store.state.players;
    }
  }
}

</script>
