<template>
  <div class="scoreboard-cart-outer" >
    <div class="scoreboard-cart-inner" :class="{'selected': isSelected}">
      <div>
        {{ index }}) {{ player.name }}
      </div>
      <div>
        {{ player.points }}
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "ScoreboardItem",
  props: {
    selectedPlayers: Array,
    player:{},
    height: Number,
    index: Number
  },
  computed:{
    isSelected(){
      console.log(this.selectedPlayers.find(sp => sp.id === this.player.id))
      return this.selectedPlayers.find(sp => sp.id === this.player.id) !== undefined
    }
  }
}
</script>


<style scoped>
.scoreboard-cart-outer {
  display: flex;
  align-items: center;
  padding: 0.75rem;
}

.selected{
  text-decoration: underline;
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