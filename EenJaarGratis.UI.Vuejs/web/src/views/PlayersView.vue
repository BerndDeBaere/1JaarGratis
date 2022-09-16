<template>
    <h1 class="text-center text-xl mt-4">Spelers</h1>

  <table class="table-auto">
    <thead>
    <tr>
      <th>Song</th>
      <th>Artist</th>
      <th>Year</th>
    </tr>
    </thead>
    <tbody>
    <tr>
      <td>The Sliding Mr. Bones (Next Stop, Pottersville)</td>
      <td>Malcolm Lockyer</td>
      <td>1961</td>
    </tr>
    <tr>
      <td>Witchy Woman</td>
      <td>The Eagles</td>
      <td>1972</td>
    </tr>
    <tr>
      <td>Shining Star</td>
      <td>Earth, Wind, and Fire</td>
      <td>1975</td>
    </tr>
    </tbody>
  </table>
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
