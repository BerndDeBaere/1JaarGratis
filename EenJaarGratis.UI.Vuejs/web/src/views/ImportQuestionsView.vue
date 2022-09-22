<template>
  <div class="container">
    <h1 class="text-center text-xl mt-4">Vragen importeren</h1>
    <article class="mb-3">
      <ol>
        <li>Maak je vragen in Excel met 4 kolomen. In de eerste rij gebruik je deze teksten
          <ol>
            <li>Vraag </li>
            <li>Antwoord1</li>
            <li>Antwoord2</li>
            <li>Antwoord3</li>
          </ol>
        </li>
        <li>
          Zorg dat de 2e kolom (Antwoord2) altijd het juiste antwoord bevat (dit wordt door het programma gerandomiseerd)
        </li>
        <li>Sla het document op als csv</li>
        <li>Open het document met notepad en plak alles in het veld hieronder</li>
        <li>Klik op Vragen importeren</li>
        <li>De website zal de antwoorden per vraag randomiseren</li>
        <li>Je kan achteraf altijd alle vragen nog aanpassen op de site</li>
      </ol>
    </article>

    <b-form-textarea rows="10" v-model="this.csvText"></b-form-textarea>
    <button class="mt-3 btn btn-block btn-outline-secondary" @click="importQuestions">Vragen importeren</button>

  </div>
</template>

<script>

import Gateway from "@/service/gateway";

export default {
  name: 'ImportQuestionsView',
  data(){
    return {
      csvText : ""
    }
  },
  methods:{
    importQuestions()
    {
      console.log(this.csvText)
      Gateway.Questions.postImportQuestions(this.csvText)
    }
  }
}

</script>
