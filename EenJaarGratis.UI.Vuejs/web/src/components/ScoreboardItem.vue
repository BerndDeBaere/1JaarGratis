<template>
<div class="scoreboard-cart" :style="{'height':height+'%', 'font-size':height-3+'vh'}">
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
  border: black solid 1px;
  padding: 0.75rem;
  margin:0.25rem;
  border-radius: 1rem;
}
</style>