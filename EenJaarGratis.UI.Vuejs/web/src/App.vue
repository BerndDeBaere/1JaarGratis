<template>
  <AppProvider>
  <NavigationBar/>
  <router-view/>
  </AppProvider>
</template>

<style lang="scss">
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}

nav {
  padding: 30px;

  a {
    font-weight: bold;
    color: #2c3e50;

    &.router-link-exact-active {
      color: #42b983;
    }
  }
}
</style>
<script>
import NavigationBar from "@/components/NavigationBar";
import AppProvider from "@/components/AppProvider";

export default {
  components: {
    AppProvider, NavigationBar
  },
  mounted() {
    console.log("mount")
    this.$store.dispatch("fetchPlayers")
  }
}
</script>