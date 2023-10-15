<script lang="ts">
import type { Employee } from '@/models/employee'
import type { Positions } from '@/models/position'
import { defineComponent } from 'vue'
import axios from 'axios'
export default defineComponent({
    data() {
        return {
            disabled : true,
            newEmployee : false,
            employee : {} as Employee,
            currentPosition : {} as Positions,
            positions : [] as any[],
            form : {
                name: "",
                lastName: "",
                address: "",
                dateOfBirth: "",
                startingDate: "",
                salary: 0,
                positionId : -1
            }
        }
    },
    mounted() {
        this.disabled = !this.$route.path.includes('/edit') && !this.$route.path.includes('/create')
        this.newEmployee = this.$route.path.includes('/create')

        if(!this.newEmployee){
            axios.get(window.location.origin+'/api/Employee/'+this.$route.params.id)
            .then(res => {
                this.employee = res.data
                this.form.name = res.data.name
                this.form.lastName = res.data.lastName
                this.form.address = res.data.address
                this.form.dateOfBirth = res.data.dateOfBirth
                this.form.startingDate = res.data.startingDate
                this.form.salary = res.data.salary
                this.currentPosition = this.employee.positions.filter(x=> {
                    return x.end === null
                })[0].position
                this.form.positionId = this.currentPosition.id;
            })
        }
        
            axios.get(window.location.origin+'/api/Positions/')
            .then(res => {
                    this.positions = res.data
                    console.log(this.positions)
                })
    },
    methods : {
        getCurrentDay(offset : number){
            const date = new Date()
            let year = ''+date.getFullYear()
            let month = '' + (date.getMonth()+1)
            let day = '' + (date.getDate()+offset)

            month = month.length < 2 ? '0'+month : month
            day = day.length < 2 ? '0'+day : day
            return year+'-'+month+'-'+day
            
        },

        saveChanges(){
            console.log(this.form)
            axios.put(window.location.origin+'/api/Employee/'+this.$route.params.id,this.form)
            .then(res=> this.$router.back())

        },

        createEmployee(){
            axios.post(window.location.origin+'/api/Employee/',this.form)
            .then(res=> this.$router.back())
        }
    }
})

</script>


<template>
    <main class="container">
    <div class="row">
    <div class="col-8">
    <h1 v-if="!newEmployee">Detail pre: {{ employee.name }} {{ employee.lastName }}</h1>
    <h1 v-else>Vytvorenie noveho zamestanca</h1>
    <form @submit.prevent="'submit'">
        <div class="row">
            <div class="col-md-6 form-group">
                <label for="name">Meno</label>
                <input type="text" 
                        class="form-control"
                        id="name" 
                        :disabled="disabled" 
                        v-model="form.name" 
                        required>
            </div>
            <div class="col-md-6 form-group">
                <label for="lastName">Priezvisko</label>
                <input type="text" 
                        class="form-control" 
                        id="lastName" 
                        :disabled="disabled" 
                        v-model="form.lastName" 
                        required>
            </div>
        </div>
        <div class="row">
            <div class="form-group">
                <label for="address">Adresa</label>
                <input type="text" 
                        class="form-control" 
                        id="address" 
                        :disabled="disabled" 
                        v-model="form.address" >
            </div>
        </div>
        <div class="row">
            <div class="col-md-6 form-group">
                <label for="dateOfBirth">Dátum narodenia</label>
                <input type="date"
                        class="form-control"
                        id="dateOfBirth" 
                        :disabled="disabled"
                        v-model="form.dateOfBirth"
                        :max="getCurrentDay(-1)"
                        required>
            </div>
            <div class="col-md-6 form-group">
                <label for="startingDate">Deň nástupu</label>
                <input type="date"
                        class="form-control" 
                        id="startingDate" 
                        :disabled="disabled" 
                        v-model="form.startingDate"
                        :min="getCurrentDay(0)"
                        required>
            </div>
        </div>
        <div class="row">
            <div class="col-md-6 form-group">
                <label for="position">Pozícia</label>
                <select class="form-select mb-3"
                         id="position"
                        aria-label=".form-select-lg" 
                        :disabled="disabled" 
                        v-model="form.positionId"
                        required>
                    <option v-for="option in positions" 
                            :value="option.id"
                            :selected="option.id===currentPosition.id"
                            >{{ option.name }}</option>
                </select>
            </div>
            <div class="col-md-6 form-group">
                <label for="salary">Plat</label>
                <input id="salary" 
                        type="number"
                        min="0.01" 
                        step="any" 
                        class="form-control"
                        :disabled="disabled"
                        v-model="form.salary"
                        required/>
            </div>
        </div>
        <button v-if="!disabled && !newEmployee" class="btn btn-primary" @click="saveChanges" >Uložit zmeny</button>
        <button v-if="!disabled && newEmployee" class="btn btn-primary" @click="createEmployee">Vytvoriť</button>
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
                <tr v-for="position in employee.positions">
                    <td>{{ position.position.name }}</td>
                    <td>{{ position.start }}</td>
                    <td>{{ position.end === null ? "--" :  position.end}}</td>
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