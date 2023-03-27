<script setup lang="ts">
import Table from '@/components/Table.vue';
import { Employee } from '@/models/employee';
import myModal from '@/components/myModal.vue'
import {Modal} from 'bootstrap'
</script>

<template>
  <main class="container">
    <div class="row">
      <h1 class="col-10">Archiv Zamestnancov</h1>
    </div>
    <Table :data="[new Employee(1,'ahoj','feddo',2323,'23.23.23','programator'),
                  new Employee(1,'ahoj','feddo',2323,'23.23.23','programator'),
                  new Employee(1,'ahoj','feddo',2323,'23.23.23','programator'),
                  new Employee(1,'ahoj','feddo',2323,'23.23.23','programator'),
                  new Employee(1,'ahoj','feddo',2323,'23.23.23','programator'),]"
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
        state : {
          modal : null,
          name : "",
          onCancel :  (event : MouseEvent)=>{console.log('default')},
          onConfirm : (event : MouseEvent)=>{console.log('default')}
        }
      }
    },
    mounted() {
      this.state.modal = new Modal('#modal')
    },
    methods : {
        openModal(data : {id : Number, name : string}){
          this.state.name = data.name
          this.state.modal?.show()
        },
        deletePosition(id : Number){
          console.log(id)
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
