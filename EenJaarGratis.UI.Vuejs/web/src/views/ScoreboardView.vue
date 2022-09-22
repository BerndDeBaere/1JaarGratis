<template>
  <div class="fullPage ">
    <div class="row mx-0 fullHeight">
      <div class="col fullHeight" v-for="(column, columnIndex) in this.scoreboard" :key=columnIndex>
        <div class="row" :style="{'height': (100/this.maxInColumn)+'%'}" v-for="(player, playerIndex) in column" :key=playerIndex>
          <ScoreboardItem :name=player.name :points=player.points :index=(playerIndex+1+columnIndex*this.maxInColumn)></ScoreboardItem>
        </div>
      </div>
    </div>


  </div>
</template>

<style>
.fullHeight{
  height: 100%;
}
.fullPage{

background : radial-gradient(circle at 33% 33%, #B24931 5%, #942F2C 80%, #631F1B 100%);
  height: 100vh;
  position: absolute;
  top:0;
  left:0;
  width: 100vw;
}
.row{
}
</style>

<script>
import ScoreboardItem from "@/components/ScoreboardItem";
import Gateway from "@/service/gateway";
import {mapGetters} from "vuex";

export default {
  name: 'ScoreboardView',
  components: {
    ScoreboardItem
  },

  async mounted() {
    await this.updateScoreboard()

    await this.signalR.on("UpdatePlayers", async () => {
      await this.updateScoreboard()
    })
    await this.signalR.on("ReloadScoreboard", async () => {
      await this.updateScoreboard()
    })

  },
  async unmounted() {
    this.signalR.off("UpdatePlayers")
    this.signalR.off("ReloadScoreboard")
  },
  methods: {
    async updateScoreboard() {
      const response = await Gateway.Players.getScoreboard();
      if (response.isSuccess) {
        let fullList = response.data.sort((a, b) => b.points - a.points);
        let columns = []
        while(fullList.length)
        columns.push(fullList.splice(0, this.maxInColumn))
        this.scoreboard = columns;
      }
    }
  },
  computed: {
    ...mapGetters({
      signalR: "getSignalR"
    })
  },
  data() {
    return {
      scoreboard: [],
      maxInColumn: 6
    }
  }
}

</script>