<script setup lang="ts">
import Table from '@/components/Table.vue';
import { Employee } from '@/objects/employee';
</script>

<template>
  <main class="container">
    <div class="row">
      <h1 class="col-10">Zamestnaci</h1>
      <button class="btn col-2 btn-primary">Pridať zamestnanca</button>
    </div>
    <Table :data="[new Employee(1,'ahoj','feddo',2323,'23.23.23','programator'),
                  new Employee(1,'ahoj','feddo',2323,'23.23.23','programator'),
                  new Employee(1,'ahoj','feddo',2323,'23.23.23','programator'),
                  new Employee(1,'ahoj','feddo',2323,'23.23.23','programator'),
                  new Employee(1,'ahoj','feddo',2323,'23.23.23','programator'),]" />
  </main>
</template>

<style scoped>
  main > .row {
    margin-bottom: 50px;
  }
</style>
