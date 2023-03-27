<script setup lang="ts">
import PositionTable from '@/components/PositionTable.vue';
import myModal from '@/components/myModal.vue'
import {Modal} from 'bootstrap'


</script>

<template>
  <main class="container">
    <div class="row">
      <h1 class="col-10">Pozície</h1>
      <button class="btn col-2 btn-primary" @click="openModalCreate">Pridať pozíciu</button>
    </div>
    <PositionTable :data="[{id : 1,name:'progrmator'},{id : 2,name:'progrmator'},{id : 3,name:'progrmator'},{id : 4,name:'progrmator'}]"
                  @delete="openModal" />
    <myModal
      :id="'modal'" 
      :title="state.creating ? 'Vytvorenie ' : 'Vymazanie ' + 'pozície ' + state.name"
    >
      <template #body>
          <p v-if="!state.creating">Naozaj chcete vymazat poziciu {{state.name}}?</p>
          <div v-else class="form-group">
                <label for="name">Názov</label>
                <input type="text" class="form-control" id="name">
            </div>
      </template>
      <template #controls>
          <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Zrušiť</button>
          <button v-if="!state.creating" type="button" class="btn btn-danger" @click="e=>state.onConfirm(e)">Vymazať</button>
          <button v-else type="button" class="btn btn-primary" @click="e=>state.onConfirm(e)">Vytvoriť</button>
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
          creating : false,
          onCancel :  (event : MouseEvent)=>{console.log('default')},
          onConfirm : (event : MouseEvent)=>{console.log('default')}
        }
      }
    },
    mounted() {
      this.state.modal = new Modal('#modal')
    },
    methods : {
        openModalCreate(){
          this.state.name =""
          this.state.creating = true
          this.state.modal?.show()
        },
        openModal(data: {id: Number,name: string}){
          this.state.name = data.name
          this.state.creating = false
          this.state.onConfirm = (event : MouseEvent)=>{
            this.deletePosition(data.id)
            this.state.modal?.hide()
          }
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
