<template>
  <div class="fullPage">
    <ScoreboardItem v-for="(player, index) in this.scoreboard" :key="player.id"
                    :height=height :name=player.name :points = player.points :index = (index+1)></ScoreboardItem>
  </div>
</template>

<script>
import {mapGetters, useStore} from "vuex";
import ScoreboardItem from "@/components/ScoreboardItem";
let store;
export default {
  name: 'ScoreboardView',
  setup(){
    store = useStore();
  },
  components:{
    ScoreboardItem
  },
  mounted() {
    store.dispatch("fetchScoreboard");
  },
  computed:{
    ...mapGetters({
      scoreboard: "getScoreboard"
    })
  },
  data(){
    return {
      height: 5
    }
  }
}

</script>