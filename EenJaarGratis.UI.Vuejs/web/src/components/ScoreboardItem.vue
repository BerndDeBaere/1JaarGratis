<template>
  <div class="scoreboard-cart-outer">
    <div class="scoreboard-cart-inner">
      <div>
        {{ index }}) {{ name }}
      </div>
      <div>
        {{ points }}
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "ScoreboardItem",
  props: {
    name: String,
    height: Number,
    points: Number,
    index: Number
  }
}
</script>


<style scoped>
.scoreboard-cart-outer {
  display: flex;
  align-items: center;
  padding: 0.75rem;
}

.scoreboard-cart-inner {
  display: flex;
  align-items: center;
  justify-content: space-between;

  font-size: 2rem;

  background-color: #631F1B20;
  color: white;
  border-radius: 1rem;
  padding:1rem;
  height: 100%;
  width: 100%;
}
</style>