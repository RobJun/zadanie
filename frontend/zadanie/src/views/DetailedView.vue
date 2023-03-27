<script lang="ts">
export default {
    data() {
        return {
            disabled : true,
            newEmployee : false
        }
    },
    mounted() {
        this.disabled = !this.$route.path.includes('/edit') && !this.$route.path.includes('/create')
        this.newEmployee = this.$route.path.includes('/create')
    }
}

</script>


<template>
    <main class="container">
    <div class="row">
    <div class="col-8">
    <h1>Detail pre: Meno Priezvisko</h1>
    <form>
        <div class="row">
            <div class="col-md-6 form-group">
                <label for="name">Meno</label>
                <input type="text" class="form-control" id="name" :disabled="disabled">
            </div>
            <div class="col-md-6 form-group">
                <label for="lastName">Priezvisko</label>
                <input type="text" class="form-control" id="lastName" :disabled="disabled">
            </div>
        </div>
        <div class="row">
            <div class="form-group">
                <label for="address">Adresa</label>
                <input type="text" class="form-control" id="address" :disabled="disabled">
            </div>
        </div>
        <div class="row">
            <div class="col-md-6 form-group">
                <label for="dateOfBirth">Dátum narodenia</label>
                <input type="date" class="form-control" id="dateOfBirth" :disabled="disabled">
            </div>
            <div class="col-md-6 form-group">
                <label for="startingDate">Deň nástupu</label>
                <input type="date" class="form-control" id="startingDate" :disabled="disabled">
            </div>
        </div>
        <div class="row">
            <div class="col-md-6 form-group">
                <label for="position">Pozícia</label>
                <select class="form-select mb-3" id="position" aria-label=".form-select-lg" :disabled="disabled">
                    <option selected>Open this select menu</option>
                    <option value="1">One</option>
                    <option value="2">Two</option>
                    <option value="3">Three</option>
                </select>
            </div>
            <div class="col-md-6 form-group">
                <label for="salary">Plat</label>
                <input id="salary" type="number" min="0.01" step="any" class="form-control" :disabled="disabled"/>
            </div>
        </div>
        <button v-if="!disabled && !newEmployee" class="btn btn-primary">Uložit zmeny</button>
        <button v-if="!disabled && newEmployee" class="btn btn-primary">Vytvoriť</button>
    </form>
    </div>
    <div v-if="!newEmployee" class="col-4">

    <h2> História poziící</h2>
    <div class="tableView">
        <table class="table">
            <thead>
                <tr>
                    <th scope="col">Pozícia</th>
                    <th scope="col">Od</th>
                    <th scope="col">Do</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td>Programator</td>
                    <td>12.03.2022</td>
                    <td>31.03.2023</td>
                </tr>
                <tr>
                    <td>Programator</td>
                    <td>12.03.2022</td>
                    <td>31.03.2023</td>
                </tr>
                <tr>
                    <td>Programator</td>
                    <td>12.03.2022</td>
                    <td>31.03.2023</td>
                </tr>
                <tr>
                    <td>Programator</td>
                    <td>12.03.2022</td>
                    <td>31.03.2023</td>
                </tr>
                <tr>
                    <td>Programator</td>
                    <td>12.03.2022</td>
                    <td>31.03.2023</td>
                </tr>
                <tr>
                    <td>Programator</td>
                    <td>12.03.2022</td>
                    <td>31.03.2023</td>
                </tr>
                <tr>
                    <td>Programator</td>
                    <td>12.03.2022</td>
                    <td>31.03.2023</td>
                </tr>
                <tr>
                    <td>Programator</td>
                    <td>12.03.2022</td>
                    <td>31.03.2023</td>
                </tr>
                <tr>
                    <td>Programator</td>
                    <td>12.03.2022</td>
                    <td>31.03.2023</td>
                </tr>
                <tr>
                    <td>Programator</td>
                    <td>12.03.2022</td>
                    <td>31.03.2023</td>
                </tr>
                <tr>
                    <td>Programator</td>
                    <td>12.03.2022</td>
                    <td>31.03.2023</td>
                </tr>
                <tr>
                    <td>Programator</td>
                    <td>12.03.2022</td>
                    <td>31.03.2023</td>
                </tr>
                <tr>
                    <td>Programator</td>
                    <td>12.03.2022</td>
                    <td>31.03.2023</td>
                </tr>
                <tr>
                    <td>Programator</td>
                    <td>12.03.2022</td>
                    <td>31.03.2023</td>
                </tr>
                <tr>
                    <td>Programator</td>
                    <td>12.03.2022</td>
                    <td>31.03.2023</td>
                </tr>
                <tr>
                    <td>Programator</td>
                    <td>12.03.2022</td>
                    <td>31.03.2023</td>
                </tr>
                <tr>
                    <td>Programator</td>
                    <td>12.03.2022</td>
                    <td>31.03.2023</td>
                </tr>
                <tr>
                    <td>Programator</td>
                    <td>12.03.2022</td>
                    <td>31.03.2023</td>
                </tr>
                <tr>
                    <td>Programator</td>
                    <td>12.03.2022</td>
                    <td>31.03.2023</td>
                </tr>
            </tbody>
        </table>
    </div>
    </div>
    </div>
</main>
</template>

<style scoped>
    .tableView {
        height: 300px;
        overflow-y: scroll;
    }
    form .row {
        margin-top:20px
    }

    main.container {
        margin-top: 30px;
    }
</style>