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
      console.log(window.location.origin)
      this.state.modal = new Modal('#modal')
      axios.get(window.location.origin+ '/api/Employee/actual')
      .then(res => {
        this.employees = res.data as Employee[]
      })
    },
    updated() {
      if(this.oldData)
      axios.get(window.location.origin+'/api/Employee/actual')
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
            console.log(data.id)
            this.archiveEmployee(data.id)
          }
          this.state.onDelete = (e : MouseEvent)=>{
            console.log(data.id)
            this.deleteEmployee(data.id)
          }
        },
        archiveEmployee(id : Number){
          axios.put(window.location.origin+'/api/Employee/'+id+'/archive')
            .then(res=> { 
              this.state.modal?.hide()
              this.rerenderKey++
              this.oldData=true
            })
        },
        deleteEmployee(id : Number){
          axios.delete(window.location.origin+'/api/Employee/'+id)
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
          <button  type="button" class="btn btn-danger" @click="state.onDelete">Vymazať</button>
          <button  type="button" class="btn btn-warning" @click="state.onArchive">Archivovať</button>
      </template>
</myModal>
  </main>
</template>



<style scoped>
  main > .row {
    margin-bottom: 50px;
  }
</style>
