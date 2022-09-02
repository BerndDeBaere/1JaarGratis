<template>
  <n-data-table
      :columns="columns"
      :data="data"
      :pagination="pagination"
      :bordered="false"
  />
</template>


<script>
  const data = [
  { no: 3, title: "Wonderwall", length: "4:18" },
  { no: 4, title: "Don't Look Back in Anger", length: "4:48" },
  { no: 12, title: "Champagne Supernova", length: "7:27" }
  ];

const columns =  [
  {
    title: "No",
    key: "no"
  },
  {
    title: "Title",
    key: "title"
  },
  {
    title: "Length",
    key: "length"
  }
];

export default {
  name: 'PlayersView',
  components: {
  },
  setup(){
    return {
      data,
      columns,
      pagination: false
    };
  }
}
</script>
