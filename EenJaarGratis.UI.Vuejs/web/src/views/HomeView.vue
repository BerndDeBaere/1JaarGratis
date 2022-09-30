<template>
  <b-container>
    <img :src="'https://api.qrserver.com/v1/create-qr-code/?data=' + url_1" alt="qrCode">
    <br>
    {{url_1}}

    <a :href="url_2">API</a>

    <a></a>
  </b-container>
</template>

<script>
export default {
  name: 'PlayersView',
  setup() {
    return {
      url_1: window.location.protocol + '//' + window.location.host,
      url_2: window.location.protocol + '//' + window.location.host.replace("8080","10000") + "/Player",
    };
  },
}

</script>
