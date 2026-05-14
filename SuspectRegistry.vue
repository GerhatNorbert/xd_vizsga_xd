<script>
export default {
    data() {
        return {
            suspect: {
                name: "",
                danger_level: ""
            },
            adatok: []


        }
    },
    methods: {
        sus_get() {
            fetch("http://localhost/api/suspects")
                .then(response => response.json())
                .then(data => {
                    console.log(data);
                    this.adatok = data;

                })
        },
        rogzit(adatok) {
            fetch("http://localhost/api/suspects", {
                method: "POST",
                headers: {
                    "Content-type": "application/json",
                    "Accept": "application/json"
                },
                body: JSON.stringify(adatok)
            })
                .then(response => response.json())
                .then(data => {
                    console.log(data)
                    this.sus_get();
                })
        }
    },
    mounted() {
        this.sus_get();
    }
}

</script>

<template>

    <div class="container-lg">
        <h1>Gyanúsítottak nyílvántartása</h1>

        <div class="card my-3" style="width: 100%;">
            <div class="card-body">
                <div class="row">
                    <div class="col-md-4">
                        <input type="text" class="form-control" v-model="suspect.name">

                    </div>

                    <div class="col-md-4">
                        <select name="" id="" class="form-control" v-model="suspect.danger_level">
                            <option value="" disabled selected>Veszélységi szint...</option>
                            <!-- <option v-for="sus in adatok" :key="sus.id" :value="sus.danger_level">
                                {{ sus.danger_level }}
                            </option> -->
                            <option value="Kicsi">Kicsi</option>
                            <option value="Kozepes">Közepes</option>
                            <option value="Nagy">Nagy</option>
                        </select>
                    </div>

                    <div class="col-md-4">
                        <button type="button" class="btn btn-warning" @click="rogzit(suspect)">Rögzítés</button>
                    </div>
                </div>

            </div>
        </div>

        <div>
            <ul class="list-group" >
                <li class="list-group-item gyanus"> ID# ________ NÉV ________ VESZÉLYSÉGI SZINT</li>
                <li class="list-group-item gyanus" v-for="sus in adatok" :key="sus.id" :value="sus.id" >{{ sus.id }}# ________ {{ sus.name }} ________ {{ sus.danger_level }}</li>
            </ul>
        </div>

    </div>

</template>



<style scoped>
.btn {
    width: 100%;
}

.gyanus{
    background-color: rgb(32, 32, 32);
    color: white;
    text-justify: auto;
}
</style>
