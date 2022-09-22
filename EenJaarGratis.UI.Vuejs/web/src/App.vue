<template>
  <NavigationBar/>
  <router-view/>
</template>


<script>
import NavigationBar from "@/components/NavigationBar";
import {useSignalR} from "@dreamonkey/vue-signalr";
import {mapGetters} from "vuex";

export default {
  components: {
    NavigationBar
  },
  mounted() {
    this.$store.dispatch("getPlayers")
    this.$store.dispatch("getQuestions")
    this.$store.commit("setSignalR", useSignalR())

    this.signalR.on("UpdatePlayers", () => {
      this.$store.dispatch("getPlayers")
    })

  },
  computed:{
    ...mapGetters({
      signalR: "getSignalR"
    })
  }
}
</script>