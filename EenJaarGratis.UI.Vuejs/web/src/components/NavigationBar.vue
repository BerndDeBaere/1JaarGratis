<template>
  <nav class="navbar navbar-expand-lg navbar-light bg-light">
    <a class="navbar-brand" href="#">
      <img src="https://kljwaregem.be/Assets/klj_logo_waregem.png" width="30" height="30" class="d-inline-block align-top" alt="">
      1 Jaar gratis
    </a>
    <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
      <span class="navbar-toggler-icon"></span>
    </button>

    <div class="collapse navbar-collapse" id="navbarSupportedContent">
      <ul class="navbar-nav mr-auto">
        <li class="nav-item">
          <router-link :to="{name:'questions'}" class="nav-link" active-class="active">Vragen</router-link>
        </li>
        <li class="nav-item">
          <router-link :to="{name:'players'}" class="nav-link" active-class="active">Spelers</router-link>
        </li>
        <li class="nav-item">
          <router-link :to="{name:'scoreboard'}" class="nav-link" active-class="active">Scoreboard</router-link>
        </li>
      </ul>
    </div>
  </nav>

</template>

<script>
export default {
  name: "NavBar",
};
</script>