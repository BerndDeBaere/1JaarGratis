<template>
    <n-menu>
      <n-menu-item></n-menu-item>
    </n-menu>
</template>

<script>
import {RouterLink} from "vue-router";
import {NMenu, NMenuItem} from "naive-ui";
import { h } from "vue";

const menuOptions = [
  {
    label: () => h(
        RouterLink,
        {
          to: {
            name: "home",
            params: {
              lang: "en-US"
            }
          }
        },
        { default: () => "Going Home" }
    ),
    key: "go-back-home",
  }
];

export default {
  name: 'NavigationBar',
  components:{
    NMenu,
    NMenuItem
  },
  setup(){
    return menuOptions;
  }
}
</script>