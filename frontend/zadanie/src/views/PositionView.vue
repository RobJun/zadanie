<script lang="ts" setup>
import PositionTable from '@/components/PositionTable.vue';
import myModal from '@/components/myModal.vue'


</script>

<script lang="ts">
import {Modal} from 'bootstrap'
import type { Positions } from '@/models/position';
import axios from 'axios';
import { defineComponent } from 'vue'
export default defineComponent({ 
    data() {
      return {
        rerenderKey : 0,
        oldData : false,
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
      axios.get(window.location.origin+'/api/Positions/')
            .then(res => this.positions = res.data)
    },
    updated() {
      if(this.oldData)
      axios.get(window.location.origin+'/api/Positions/')
            .then(res => {
              this.positions = res.data
              this.oldData = false;
            })
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
          axios.delete(window.location.origin+'/api/Positions/'+id)
          .then(res=>{
              this.state.modal.hide()
              this.rerenderKey++
              this.oldData = true})
        },

        createPostion(){
          axios.post(window.location.origin+'/api/Positions/',
          {
            name: this.state.name
          })
            .then(res=>{
              this.state.modal.hide()
              this.rerenderKey++
              this.oldData=true})
        }



    }
})
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



<style scoped>
  main > .row {
    margin-bottom: 50px;
  }
</style>
