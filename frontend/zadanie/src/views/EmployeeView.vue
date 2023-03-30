<script lang="ts" setup>
import Table from '@/components/Table.vue';
import myModal from '@/components/myModal.vue'


</script>

<script lang="ts">
import type { Employee } from '@/models/employee';
import {Modal} from 'bootstrap'
import axios from 'axios'
import { defineComponent } from 'vue'
export default defineComponent({ 
    data() {
      return {
        rerenderKey: 0,
        oldData:false,
        state : {
          modal : {} as Modal,
          name : "",
          onArchive :  (event : MouseEvent)=>{console.log('default')},
          onDelete : (event : MouseEvent)=>{console.log('default')}
        },
        employees : [] as any[]
      }
    },
    mounted() {
      console.log(process.env.VUE_APP_API_ENDPOINTS)
      this.state.modal = new Modal('#modal')
      axios.get(process.env.VUE_APP_API_ENDPOINTS+ '/api/Employee/actual')
      .then(res => {
        this.employees = res.data as Employee[]
      })
    },
    updated() {
      if(this.oldData)
      axios.get(process.env.VUE_APP_API_ENDPOINTS+'/api/Employee/actual')
      .then(res => {
        this.employees = res.data as Employee[]
        this.oldData=false
      })
    },
    methods : {
        openModal(data : {id : Number, name : string}){
          this.state.name = data.name
          this.state.modal?.show()
          this.state.onArchive = (e: MouseEvent)=>{
            this.archiveEmployee(data.id)
          }
          this.state.onDelete = (e : MouseEvent)=>{
            this.deleteEmployee(data.id)
          }
        },
        archiveEmployee(id : Number){
          axios.put(process.env.VUE_APP_API_ENDPOINTS+'/api/Employee/'+id+'/archive')
            .then(res=> { 
              this.state.modal?.hide()
              this.rerenderKey++
              this.oldData=true
            })
        },
        deleteEmployee(id : Number){
          axios.delete(process.env.VUE_APP_API_ENDPOINTS+'/api/Employee/'+id)
            .then(res=> {
              this.state.modal?.hide()
              this.rerenderKey++
              this.oldData=true
            })
        }



    }
})
</script>

<template>
  <main class="container">
    <div class="row">
      <h1 class="col-10">Zamestnaci</h1>
      <button class="btn col-2 btn-primary" @click="$router.push({path:'/employee/create'})">Pridať zamestnanca</button>
    </div>
    <Table :key="rerenderKey" :data="employees"
                  @delete="openModal" />
  <myModal
  :id="'modal'"
  :title="'Vymazanie zamestanca'"
  >
  <template #body>
          <p>Prajete si archivovat zamestnaca: {{state.name}}?</p>
  </template>
      <template #controls>
          <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Zrušiť</button>
          <button  type="button" class="btn btn-danger" @click="">Vymazať</button>
          <button  type="button" class="btn btn-warning" @click="">Archivovať</button>
      </template>
</myModal>
  </main>
</template>



<style scoped>
  main > .row {
    margin-bottom: 50px;
  }
</style>
