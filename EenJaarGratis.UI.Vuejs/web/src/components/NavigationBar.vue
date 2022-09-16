<template>
  <nav class="bg-white border-gray-200 px-2 sm:px-4 py-2.5 rounded">
    <div class="container flex flex-wrap justify-between items-center mx-auto">
      <router-link :to="{name:'home'}" class="flex items-center">
        <img src="https://kljwaregem.be/Assets/klj_logo_waregem.png" class="mr-3 h-6 sm:h-9" alt="KLJ Logo" />
        <span class="self-center text-xl font-semibold whitespace-nowrap">1 Jaar gratis</span>
      </router-link>
      <div class="hidden w-full md:block md:w-auto" id="navbar-default">
        <ul class="flex flex-col p-4 mt-4 border border-gray-100 md:flex-row md:space-x-8 md:mt-0 md:text-sm md:text-gray-700 md:font-medium md:border-0 md:bg-white">
          <li>
            <router-link :to="{name:'scoreboard'}" class="py-2 px-2" active-class="text-blue-700">Scoreboard</router-link>
          </li>
          <li>
            <router-link :to="{name:'players'}" class="py-2 px-2" active-class="text-blue-700">Spelers</router-link>
          </li>
          <li>
            <router-link :to="{name:'questions'}" class="py-2 px-2" active-class="text-blue-700">Vragen</router-link>
          </li>
        </ul>
      </div>
    </div>
  </nav>


</template>

<script>
export default {
  name: "NavBar",
};
</script>