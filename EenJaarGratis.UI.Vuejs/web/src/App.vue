<template>
    <NavigationBar/>
    <router-view/>
</template>


<script>
import NavigationBar from "@/components/NavigationBar";

export default {
  components: {
    NavigationBar
  },
  mounted() {
    this.$store.dispatch("fetchPlayers")
    this.$store.dispatch("fetchQuestions")
  }
}
</script>