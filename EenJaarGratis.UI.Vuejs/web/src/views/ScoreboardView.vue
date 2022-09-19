<template>
  <div class="grid grid-cols-2">
    <div class="flow">
      <div v-for="index in 10" :key="index">{{index}}</div>
    </div>
    <div class="flow">
      <div v-for="index in 10" :key="index">{{index}}</div>
    </div>
  </div>
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
  },
  computed: {
    players() {
      return this.$store.state.players;
    }
  }
}

</script>
