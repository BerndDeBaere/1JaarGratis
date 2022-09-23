<template>
  <div class="container">
    <h1 class="text-center text-xl mt-4">Vragen</h1>

    <b-button-group class="float-end">
      <b-button variant="outline-secondary" @click=newQuestion><i class="lni lni-circle-plus"></i> Nieuwe vraag</b-button>
      <b-dropdown variant="outline-secondary" text="Extra opties">
        <b-dropdown-item-button @click=uploadExcel>Upload excel</b-dropdown-item-button>
      </b-dropdown>
    </b-button-group>

    <b-table striped hover :fields=fields :items=questions>
      <template #cell(posiblities)="row">
          <ul>
            <li :class="{correct: (row.item.correctAnswer === 0)}">{{ row.item.answer1 }}</li>
            <li :class="{correct: (row.item.correctAnswer === 1)}">{{ row.item.answer2 }}</li>
            <li :class="{correct: (row.item.correctAnswer === 2)}">{{ row.item.answer3 }}</li>
          </ul>
      </template>
      <template #cell(actions)="row">
        <b-button-group>
          <b-button @click="editQuestion(row.item)" variant="outline-secondary"><i class="lni lni-pencil"></i> Bewerken
          </b-button>
          <b-button @click="removeQuestion(row.item)" variant="outline-danger"><i class="lni lni-trash-can"></i>
          </b-button>
        </b-button-group>
      </template>
    </b-table>
  </div>
</template>

<style scoped>
.correct {
  color: green;
}
</style>

<script>
import {mapActions, mapGetters} from "vuex";
import {useRouter} from "vue-router";

let router;
export default {
  name: 'QuestionsView',
  setup() {
    router = useRouter();
  },
  data() {
    return {
      fields: [
        {
          key: 'question',
          label: 'Vraag',
        },
        {
          key: 'posiblities',
          label: 'Antwoorden'
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
      questions: 'getQuestions',
    })
  },
  methods: {
    ...mapActions({
      deleteQuestion: "deleteQuestion"
    }),
    uploadExcel() {
      router.push({name: 'importQuestions'})
    },
    newQuestion() {
      router.push({name: 'newQuestion'})
    },
    removeQuestion(player) {
      this.deleteQuestion(player)
    },
    editQuestion(player) {
      router.push({name: 'editQuestion', params: {id: player.id}})
    }
  }
}

</script>
