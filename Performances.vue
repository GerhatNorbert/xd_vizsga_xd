<script>
export default {
    data() {
        return {
            musor: {
                artist_id: 0,
                act_name: ""
            },
            artists: [],
            musorok: []
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
        musor_get() {
            fetch("http://127.0.0.1:8000/api/produkciok")
                .then(response => response.json())
                .then(data => {
                    this.musorok = data;
                })
        },

       musorra_tuz() {
        // generate random duration 5-15
        const duration = Math.floor(Math.random() * 11) + 5;

        // POST the performance
        fetch("http://127.0.0.1:8000/api/produkciok", {
            method: "POST",
            headers: { "Content-Type": "application/json", "Accept": "application/json" },
            body: JSON.stringify({
                artist_id: this.musor.artist_id,
                act_name: this.musor.act_name,
                duration: duration
            })
        })
        .then(r => r.json())
        .then(() => {
            // PUT to update artist is_ready to 0
            fetch(`http://127.0.0.1:8000/api/artistak/${this.musor.artist_id}/produkcio`, {
                method: "PUT",
                headers: { "Content-Type": "application/json", "Accept": "application/json" },
                body: JSON.stringify({ is_ready: 0 })
            })
            .then(() => {
                this.musor_get();
                this.muvesz_get();
            })
        })
    }
    },
    mounted() {
        this.musor_get();
        this.muvesz_get();
    }
}
</script>

<template>

    <div class="my-5">
        <div class="card" style="width: 100%;">
            <div class="card-header">
                GÁLAMŰSOR ÖSSZEÁLLÍTÁSA
            </div>

            <div class="card-body">
                <div class="col-md-4">
                    <label for="">Artista kiválasztása</label>
                    <select name="" id="" class="form-control" v-model="musor.artist_id">
                        <option value="" disabled selected>-- Válassz szabad artistát --</option>
                        <option v-for="muveszek in artists" :key="muveszek.id" :value="muveszek.name">{{ muveszek.name
                            }}</option>
                    </select>
                </div>

                <div class="col-md-4">
                    <label for="">Produkció neve</label>
                    <input type="text" class="form-control" v-model="musor.act_name" placeholder="Pl. Halálugrás">
                </div>

                <div class="col-md-4 my-2">
                    <button type="button" class="btn btn-warning " @click="musorra_tuz()">Műsorra tűz</button>
                </div>
            </div>
        </div>

        <div class="card" style="width: 100%;">
            <div class="card-header">
                AZ ESTI GÁLAMŰSOR PROGRAMJAI
            </div>

            <div class="card-body">
                <ul class="list-group list-group-flush">
                    <li class="list-group-item">Artista ______ Produkció ______ Időtartam</li>
                    <li class="list-group-item" v-if="artists.is_ready == 0" v-for="xd in (musorok, artists)" :key="xd.id" :value="xd.id">{{ xd.name }} ______ {{xd.act_name}} ______ {{ xd.duration }}</li>
                    <li class="list-group-item" v-else>A porond mégüres!</li>
                </ul>
            </div>
        </div>

    </div>

</template>

<style scoped></style>
