<template>
  <NavigationBar/>
  <router-view/>
</template>


<script>
import NavigationBar from "@/components/NavigationBar";
import {useSignalR} from "@dreamonkey/vue-signalr";
import {mapGetters} from "vuex";
import {useToast} from "bootstrap-vue-3";

export default {
  components: {
    NavigationBar
  },
  mounted() {
    this.$store.dispatch("getPlayers")
    this.$store.dispatch("getQuestions")
    this.$store.commit("setSignalR", useSignalR())
    this.$store.commit("setToast", useToast())

    this.signalR.on("ReloadPlayers", () => {
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