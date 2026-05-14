<script>
import Artist from './components/Artist.vue';
import Performances from './components/Performances.vue';

export default{
  components:{
    Artist,
    Performances
  },
  data(){
    return{
      kivalasztott: null
    }
  }
}
</script>

<template>
  <div class="container-fluid container-lg">
    <div class="row">
        <div class="col-md-4"> 
          <Artist />
        </div>

        
        
        <div class="col-md-8"> 
          <Performances />
        </div>
    </div>
  </div>



  
</template>

<style scoped></style>
