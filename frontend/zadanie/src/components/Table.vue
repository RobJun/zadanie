<script setup lang="ts">
import EmployeeCell from './EmployeeCell.vue'
import type {Employee} from '../models/employee'
</script>


<template>
    <ul>
        <li v-for="employee in data">
            <EmployeeCell :employee="employee" @delete="e=>$emit('delete',e)"/>
        </li>
    </ul>
</template>

<script lang="ts">
export default { 
    props : {
        data: Array<Employee>
    }
}
</script>

<style scoped>
    li {
        list-style: none;
    }
</style>