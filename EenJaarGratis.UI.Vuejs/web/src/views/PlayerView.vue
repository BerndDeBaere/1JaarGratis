<template>
  <input :model="test" type="text" placeholder="Naam"/>
</template>

<script>
export default ({
  name: "PlayerView",
  data() {
    return {
      test:"",
      player: {
        name: ""
      }
    }
  }
});
</script>
