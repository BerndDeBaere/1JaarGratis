<template>
  <div class="container">
    <h1 class="text-center text-xl mt-4">Vragen importeren</h1>
    <article class="mb-3">
      Maak in excel een bestand met 4 kolomen.
      <ol>
        <li>Vraag</li>
        <li>Antwoord1</li>
        <li>Antwoord2</li>
        <li>Antwoord3</li>
      </ol>
      Zorg dat "Antwoord1" altijd het correcte antwoord is.<br>
      Het programma zal de antwoorden in willekeurige volgorde zetten.<br>
      Je kan later altijd nog wijzigingen doen onder het tabblad "Vragen"<br>
      BELANGRIJK: Sla uw excel op als "CSV (utf-8)"
    </article>

    <p class="text-danger">Nog niet functioneel</p>

    <div class="input-group">
      <div class="custom-file">
        <input type="file" class="custom-file-input" accept=".csv">
        <label class="custom-file-label" >CSV uploaden</label>
      </div>
    </div>
    <button class="mt-3 btn btn-block btn-outline-secondary">Vragen importeren</button>

  </div>
</template>

<script>

export default {
  name: 'ImportQuestionsView',
}

</script>
