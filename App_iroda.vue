<script>
import CaseList from './components/CaseList.vue';
import SuspectRegistry from './components/SuspectRegistry.vue';

export default {
  components:{
    CaseList,
    SuspectRegistry
  },
  data() {
    return {
      aktualisOldal: "CaseList"
    }
  }
}

</script>

<template>
  <nav class="navbar navbar-expand-lg navbar-dark bg-dark">
    <div class="container-fluid container-lg">
      <a class="navbar-brand" href="#">NOIR NYOMOZÓ IRODA</a>
      <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav"
        aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
        <span class="navbar-toggler-icon"></span>
      </button>
      <div class="collapse navbar-collapse ms-auto" id="navbarNav">
        <ul class="navbar-nav d-flex ms-auto">

          <li class="nav-item">
            <button class="nav-link btn" @click="aktualisOldal = 'CaseList'">Akták</button>
          </li>

          <li class="nav-item">
            <button class="nav-link btn" @click="aktualisOldal = 'SuspectRegistry'">Gyanúsítottak</button>
          </li>

        </ul>
      </div>
    </div>
  </nav>

  <component :is="aktualisOldal"/>

</template>



<style>
body{
  background-color: black;
}

h1,h2,h3,h4{
  color: orange;
}

p{
  color: white;
}

.card{
  background-color: rgb(44, 43, 43);
}

.form-control{
  background-color: rgb(32, 32, 32);
  color: white;
}
</style>
