<script setup lang="ts">
import Table from '@/components/Table.vue';
import { Employee } from '@/objects/employee';
</script>

<template>
  <main>
    <h1>Zamestnaci</h1>
    <Table :data="[new Employee(1,'ahoj','feddo',2323,'23.23.23','programator'),
                  new Employee(1,'ahoj','feddo',2323,'23.23.23','programator'),
                  new Employee(1,'ahoj','feddo',2323,'23.23.23','programator'),
                  new Employee(1,'ahoj','feddo',2323,'23.23.23','programator'),
                  new Employee(1,'ahoj','feddo',2323,'23.23.23','programator'),]" />
  </main>
</template>
