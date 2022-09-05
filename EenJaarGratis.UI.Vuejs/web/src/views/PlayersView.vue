<template>
  <n-data-table
      :columns="columns"
      :data="players"
      :pagination="pagination"
      :bordered="false"
  />
</template>

<script>
const createColumns = () => {
  return [
    {
      title: "Id",
      key: "id"
    },
    {
      title: "Naam",
      key: "name"
    }
  ];
};

export default {
  name: 'PlayersView',
  setup(){
    console.log("api: " + process.env.VUE_APP_TITLE)
    return {
      columns: createColumns(),
      pagination: false
    };
  },
  computed:{
    players(){
      return this.$store.state.players;
    }
  }
}

</script>
