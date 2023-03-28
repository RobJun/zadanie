<script setup lang="ts">
import PositionTable from '@/components/PositionTable.vue';
import myModal from '@/components/myModal.vue'
import {Modal} from 'bootstrap'
import type { Positions } from '@/models/position';
import axios from 'axios';


</script>

<template>
  <main class="container">
    <div class="row">
      <h1 class="col-10">Pozície</h1>
      <button class="btn col-2 btn-primary" @click="openModalCreate">Pridať pozíciu</button>
    </div>
    <PositionTable :data="positions"
                  @delete="openModal"
                  :key="rerenderKey" />
    <myModal
      :id="'modal'" 
      :title="state.creating ? 'Vytvorenie ' : 'Vymazanie ' + 'pozície ' + state.name"
    >
      <template #body>
          <p v-if="!state.creating">Naozaj chcete vymazat poziciu {{state.name}}?</p>
          <div v-else class="form-group">
                <label for="name">Názov</label>
                <input type="text" class="form-control" id="name" v-model="state.name">
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
        rerenderKey : 0,
        state : {
          modal : {} as Modal,
          name : "",
          creating : false,
          onConfirm : (event : MouseEvent)=>{console.log('default')}
        },
        positions : [] as Positions[]
      }
    },
    mounted() {
      this.state.modal = new Modal('#modal')
      axios.get('http://localhost:5216/api/Positions/')
            .then(res => this.positions = res.data)
    },
    updated() {
      axios.get('http://localhost:5216/api/Positions/')
            .then(res => this.positions = res.data)
    },
    methods : {
        openModalCreate(){
          this.state.name =""
          this.state.creating = true
          this.state.onConfirm = this.createPostion
          this.state.modal?.show()
        },
        openModal(data: {id: Number,name: string}){
          this.state.name = data.name
          this.state.creating = false
          this.state.onConfirm = (event : MouseEvent)=>{
            this.deletePosition(data.id)
          }
          this.state.modal?.show()
        },
        deletePosition(id : Number){
          axios.delete('http://localhost:5216/api/Positions/'+id)
          .then(res=>{
              this.state.modal.hide()
              this.rerenderKey++})
        },

        createPostion(){
          axios.post('http://localhost:5216/api/Positions/',
          {
            name: this.state.name
          })
            .then(res=>{
              this.state.modal.hide()
              this.rerenderKey++})
        }



    }
}
</script>

<style scoped>
  main > .row {
    margin-bottom: 50px;
  }
</style>
