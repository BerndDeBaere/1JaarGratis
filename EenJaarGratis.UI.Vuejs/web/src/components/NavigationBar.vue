<template>
  <n-menu v-model:value="activeKey" mode="horizontal" :options="menuOptions" />
</template>

<script>
import {RouterLink} from "vue-router";
import {NMenu, NIcon} from "naive-ui";
import { h, ref} from "vue";
import {
  PeopleOutline as PlayersIcon,
ChatbubbleOutline as QuestionsIcon
} from "@vicons/ionicons5";

function renderIcon(icon) {
  return () => h(NIcon, null, { default: () => h(icon) });
}

const menuOptions = [
  {
    label: () => h(
        RouterLink,
        {
          to: {
            name: "players"
          }
        },
        { default: () => "Spelers" }
    ),
    key: "go-back-home",
    icon: renderIcon(PlayersIcon)
  },
  {
    label: () => h(
        RouterLink,
        {
          to: {
            name: "about"
          }
        },
        { default: () => "Vragen" }
    ),
    key: "go-back-home",
    icon: renderIcon(QuestionsIcon)
  }
];

export default {
  name: 'NavigationBar',
  components:{
    NMenu
  },
  setup(){
    return {menuOptions,
      activeKey: ref(null)
    };
  }
}
</script>