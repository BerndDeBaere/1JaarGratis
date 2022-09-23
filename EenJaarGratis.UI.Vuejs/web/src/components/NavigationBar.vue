<template>
  <b-navbar toggleable="lg">
    <b-navbar-brand href="#">
      <img src="@/assets/klj_logo.png" width="30" height="30" class="d-inline-block align-top" alt="KLJ"/>
      <router-link :to="{name: 'home'}"> 1 Jaar gratis</router-link>
    </b-navbar-brand>
    <b-navbar-toggle target="nav-collapse"></b-navbar-toggle>
    <b-collapse id="nav-collapse" is-nav>
      <b-navbar-nav>
        <b-nav-item :to="{name:'questions'}">Vragen</b-nav-item>
        <b-nav-item :to="{name:'players'}">Spelers</b-nav-item>
        <b-nav-item :to="{name:'scoreboard'}">Scorebord</b-nav-item>
        <b-nav-item :to="{name:'quizmaster'}">Quiz</b-nav-item>
      </b-navbar-nav>
    </b-collapse>
  </b-navbar>
</template>

<script>
export default {
  name: "NavBar"
};
</script>
<style>
a{
  text-decoration: none;
  color: black;
}
</style>