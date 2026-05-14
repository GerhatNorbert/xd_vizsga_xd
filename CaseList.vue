<script>
export default {
    data() {
        return {
            cases: []
        }
    },
    methods: {
        aktak() {
            fetch("http://localhost/api/cases")
                .then(response => response.json())
                .then(data => {
                    console.log(data);
                    this.cases = data;
                })
        },
        lezaras(id) {
            fetch(`http://localhost/api/cases?id=${id}`, {
                method: "PUT",
                headers: {
                    "Content-type": "application/json",
                    "Accept": "application/json"
                },
                body: JSON.stringify({ is_solved: 1 })
            })
                .then(response => response.json())
                .then(data => {
                    console.log(data)
                    this.aktak();
                })
        },
        torol(id) {
            fetch(`http://localhost/api/cases?id=${id}`, {
                method: "DELETE"
            })
                .then(() => {
                    this.cases = this.cases.filter(a => a.id !== id)    
                })
                .catch(err => console.log(err));
        }
    },
    mounted() {
        this.aktak();
    }
}

</script>

<template>

    <div class="container-lg">
        <h1>Folyamtabn lévő bűnügyi akták</h1>
        <div class="row">
            <div class="col-md-4" v-for="aktak in cases" :key="aktak.id" :value="aktak.id">

                <div class="card my-3" style="width: 100%;">
                    <div class="card-body">
                        <h4>{{ aktak.title }}</h4>
                        <p>{{ aktak.description }}</p>

                        <button type="button" class="btn btn-warning d-flex ms-auto" v-if="aktak.is_solved == 0"
                            @click="lezaras(aktak.id)">Ügy lezárása</button>
                        <button type="button" class="btn btn-success d-flex ms-auto" v-else="aktak.is_solved == 1"
                            @click="torol(aktak.id)">Ügy lezárva</button>

                    </div>
                </div>

            </div>
        </div>


    </div>


</template>



<style scoped></style>
