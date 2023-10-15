<script lang="ts" setup>
import Table from '@/components/Table.vue';
import myModal from '@/components/myModal.vue'


</script>
<script lang="ts">
import type { Employee } from '@/models/employee';
import {Modal} from 'bootstrap'
import axios from 'axios';
import { defineComponent } from 'vue'

export default defineComponent({ 
    data() {
      return {
        rerenderKey :0,
        oldData: false,
        state : {
          modal : {} as Modal,
          name : "",
          onCancel :  (event : MouseEvent)=>{console.log('default')},
          onConfirm : (event : MouseEvent)=>{console.log('default')}
        },
        employees : [] as any[]
      }
    },
    mounted() {
      this.state.modal = new Modal('#modal')
      axios.get(window.location.origin+'/api/Employee/archived')
      .then(res => {
        console.log(res.data)
        this.employees = res.data})
    },
    updated() {
      if(this.oldData)
        axios.get(window.location.origin+'/api/Employee/archived')
      .then(res => {
        console.log(res.data)
        this.employees = res.data
        this.oldData = false})
    },
    methods : {
        openModal(data : {id : Number, name : string}){
          this.state.name = data.name
          this.state.modal?.show()
          this.state.onConfirm = (e : MouseEvent) => {
            this.deleteEmployee(data.id)
          }
        },
        deleteEmployee(id : Number){
            axios.delete(window.location.origin+'/api/Employee/'+id)
            .then(
              res=>{
                this.state.modal.hide()
                this.rerenderKey++
                this.oldData=true
              }
            )
        }



    }
})
</script>

<template>
  <main class="container">
    <div class="row">
      <h1 class="col-10">Archiv Zamestnancov</h1>
    </div>
    <Table :key="rerenderKey" :data="employees"
                  @delete="openModal" />

<myModal
  :id="'modal'"
  :title="'Vymazanie archivovaného zamestanca'"
  >
  <template #body>
          <p>Vymazať zamestanca na trvalo?</p>
  </template>
      <template #controls>
          <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Zrušiť</button>
          <button  type="button" class="btn btn-danger" @click="state.onConfirm">Vymazať</button>
      </template>
</myModal>
  </main>
</template>



<style scoped>
  main > .row {
    margin-bottom: 50px;
  }
</style>
