<script lang="ts" setup>
import EmployeeCell from './EmployeeCell.vue'
</script>

<script lang="ts">
import type {Employee} from '../models/employee'
import { defineComponent } from 'vue'

export default defineComponent({ 
    props : {
        data: Array<Employee>
    }
})
</script>


<template>
    <ul>
        <li v-for="employee in data">
            <EmployeeCell :employee="employee" @delete="(e:any)=>$emit('delete',e)"/>
        </li>
    </ul>
</template>

<style scoped>
    li {
        list-style: none;
    }
</style>