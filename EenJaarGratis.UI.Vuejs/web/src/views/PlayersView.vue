<template>
  <div class="container">
    <h1 class="text-center text-xl mt-4">Spelers</h1>
    <b-button-group class="float-end">
      <b-button variant="outline-secondary" @click=newPlayer><i class="lni lni-circle-plus"></i> Nieuwe speler
      </b-button>
    </b-button-group>
    <b-table striped hover :items=players :fields=fields>
      <template #cell(actions)="row">
        <b-button-group>
          <b-button size="sm" @click="editPlayer(row.item)" variant="outline-secondary">
            <i class="lni lni-pencil"></i> Bewerken
          </b-button>
          <b-button size="sm" @click="deletePlayer(row.item)" variant="outline-danger">
            <i class="lni lni-trash-can"></i>
          </b-button>
        </b-button-group>
      </template>
    </b-table>
  </div>
</template>

<script>
import {useRouter} from 'vue-router'
import {mapGetters, useStore} from 'vuex';

let router;
let store;
export default {
  name: 'PlayersView',
  setup() {
    store = useStore();
    router = useRouter();
  },
  data() {
    return {
      fields: [
        {
          key: 'name',
          label: 'Naam',
        },
        {
          key: 'code',
          label: 'Code'
        },
        {
          key: 'actions',
          label: 'Actions',
          class: 'col-2'
        }
      ]
    }
  },
  computed: {
    ...mapGetters({
      players: 'getPlayers'
    })
  },
  methods: {
    newPlayer() {
      router.push({name: 'newPlayer'})
    },
    deletePlayer(player) {
      store.dispatch("deletePlayer", player)
    },
    editPlayer(player) {
      router.push({name: 'editPlayer', params: {id: player.id}})
    }
  }
}

</script>
