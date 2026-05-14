<script>
export default {
    data() {
        return {
            muvesz: {
                name: "",
                specialty: ""
            },

            artists: [],

            urlapLatszik: true,
        }
    },
    methods: {
        muvesz_get() {
            fetch("http://127.0.0.1:8000/api/artistak")
                .then(response => response.json())
                .then(data => {
                    this.artists = data;
                })
        },

        muvesz_post(muvesz) {
            fetch("http://127.0.0.1:8000/api/artistak", {
                method: "POST",
                headers: {
                    "Content-Type": "application/json",
                    "Accept": "application/json"
                },
                body: JSON.stringify(muvesz)
            })
                .then(response => response.json())
                .then(data => {
                    console.log(data)
                    this.muvesz_get();
                })
        }
    },
    mounted() {
        this.muvesz_get();
    }
}
</script>

<template>
    <div>
        <button @click="urlapLatszik = !urlapLatszik" class="btn btn-warning my-3">
            {{ urlapLatszik ? 'Űrlap elrejtése' : 'Űrlap megjelenítése' }}
        </button>


        <div class="card" v-show="urlapLatszik" style="width: 100%;">
            <div class="card-header">
                ÚJ TÁRSULATI TAG
            </div>
            <div class="card-body">
                <label for="">Művésznév</label>
                <input type="text" class="form-control" v-model="muvesz.name">

                <label for="">Specialitás</label>
                <select name="" id="" class="form-control" v-model="muvesz.specialty">
                    <option value="Zsonglőr">Zsonglőr</option>
                    <option value="Artista">Artista</option>
                    <option value="Bűvész">Bűvész</option>
                    <option value="Erőművész">Erőművész</option>
                </select>

                <button type="button" class="btn btn-warning my-1" @click="muvesz_post(muvesz)">Szerződtetés</button>
            </div>
        </div>


        <div class="card my-3" style="width: 100%;">
            <div class="card-header">
                TÁRSULATUNK TAGJAI
            </div>
            <ul class="list-group list-group-flush">
                <li v-for="art in artists" :key="art.id" class="list-group-item">
                    {{ art.name }} - {{ art.specialty }} <br>
                    <span v-if="art.is_ready == 1">Szabad a porondra</span>
                    <span v-else>Épp fellépése van</span>
                </li>

            </ul>
        </div>
    </div>
</template>

<style scoped></style>
