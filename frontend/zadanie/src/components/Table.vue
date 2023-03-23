<script setup lang="ts">
import EmployeeCell from './EmployeeCell.vue'
import type {Employee} from '../objects/employee'
</script>


<template>
    <ul>
        <li v-for="employee in data">
            <EmployeeCell :employee="employee"/>
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