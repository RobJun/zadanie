<script setup lang="ts">
import Table from '@/components/Table.vue';
import type { Employee } from '@/models/employee';
import myModal from '@/components/myModal.vue'
import {Modal} from 'bootstrap'
import axios from 'axios';
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
          <button  type="button" class="btn btn-danger" @click="e=>{}">Vymazať</button>
      </template>
</myModal>
  </main>
</template>

<script lang="ts">
export default { 
    data() {
      return {
        rerenderKey :0,
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
      axios.get('http://localhost:5216/api/Employee/archived')
      .then(res => {
        console.log(res.data)
        this.employees = res.data})
    },
    methods : {
        openModal(data : {id : Number, name : string}){
          this.state.name = data.name
          this.state.modal?.show()
        },
        deletePosition(id : Number){
            //TODO
        }



    }
}
</script>

<style scoped>
  main > .row {
    margin-bottom: 50px;
  }
</style>
