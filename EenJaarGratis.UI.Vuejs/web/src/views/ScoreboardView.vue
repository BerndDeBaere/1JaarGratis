<template>
  <div class="fullPage ">
    <div class="row mx-0 fullHeight">
      <div class="col fullHeight" v-for="(column, columnIndex) in this.scoreboard" :key=columnIndex>
        <div class="row" :style="{'height': (100/this.maxInColumn)+'%'}" v-for="(player, playerIndex) in column"
             :key=playerIndex>

          <ScoreboardItem :player=player :selectedPlayers=this.selectedPlayers
                          :index=(playerIndex+1+columnIndex*this.maxInColumn)></ScoreboardItem>
        </div>
      </div>
    </div>

    <b-modal id="modalQuestion" content-class="bg-gradent" v-model="this.showQuestion" hide-footer hide-header centered size="xl"
             :title="question.question">
        <p>
          A) {{ this.question.answer1 }}
        </p>
        <p>
          B) {{ this.question.answer2 }}
        </p>
        <p>
          C) {{ this.question.answer3 }}
        </p>
    </b-modal>


  </div>
</template>

<style>
.fullHeight {
  height: 100%;
}

.bg-gradent{
  font-size: 5rem;
  background: radial-gradient(circle at 33% 33%, #B24931 5%, #942F2C 80%, #631F1B 100%);
}
.bg-gradent p{
  color: white;
}

.fullPage {
  overflow: hidden;
  background: radial-gradient(circle at 33% 33%, #B24931 5%, #942F2C 80%, #631F1B 100%);
  height: 100vh;
  position: absolute;
  top: 0;
  left: 0;
  padding: 2.5vw;
  width: 100vw;
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


    await this.signalR.on("SelectRandomPlayers", async () => {
      await this.selectRandomPlayers();
    });
    await this.signalR.on("ReloadPlayers", async () => {
      await this.updateScoreboard()
    });
    this.signalR.on("ShowQuestion", async (question) => {
      this.question = JSON.parse(question);
      this.showQuestion = true;
    });
    await this.signalR.on("HideQuestion", async () => {
      this.question = {};
      this.showQuestion = false;
    });
    await this.signalR.on("ReloadScoreboard", async () => {
      await this.updateScoreboard()
    });

  },
  async unmounted() {
    this.signalR.off("UpdatePlayers")
    this.signalR.off("ReloadScoreboard")
  },
  methods: {
    async selectRandomPlayers(){
      const response = await Gateway.Players.getRandom();
      if(response.isSuccess) {
        this.selectedPlayers = response.data;
      }
    },
    async updateScoreboard() {
      const response = await Gateway.Players.getScoreboard();
      if (response.isSuccess) {
        let fullList = response.data.sort((a, b) => b.points - a.points);
        let columns = []
        while (fullList.length)
          columns.push(fullList.splice(0, this.maxInColumn))
        this.scoreboard = columns;
      }
    },
  },
  computed: {
    ...mapGetters({
      signalR: "getSignalR"
    })
  },
  data() {
    return {
      scoreboard: [],
      question: {},
      selectedPlayers:[],
      showQuestion: false,
      maxInColumn: 10
    }
  }
}
</script>