<template>
  <b-container>
    <img :src="'https://api.qrserver.com/v1/create-qr-code/?data=' + url" alt="qrCode">
    <br>
    {{url}}
  </b-container>
</template>

<script>
export default {
  name: 'PlayersView',
  setup() {
    return {
      url: window.location
    };
  },
}

</script>
