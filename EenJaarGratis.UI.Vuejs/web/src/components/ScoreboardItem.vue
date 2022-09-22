<template>
<div class="scoreboard-cart">
  <div>
    {{index}} {{name}}
  </div>
  <div >
    {{points}}
  </div>
</div>
</template>

<script>
export default {
  name: "ScoreboardItem",
  props:{
    name: String,
    height: Number,
    points: Number,
    index: Number
  }
}
</script>


<style scoped>
.scoreboard-cart{
  display: flex;
  justify-content: space-between;
  align-items:center;
}
</style>