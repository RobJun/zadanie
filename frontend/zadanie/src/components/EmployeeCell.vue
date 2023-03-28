<script setup lang="ts">
import { Employee } from '@/models/employee';
import type { PropType } from 'vue';


</script>


<template>
    <div class="employee_row">
        <h2><RouterLink :to="`/employee/${employee.id}`" class="nav-link">{{employee.name}} {{employee.lastName}}</RouterLink></h2>
        <p v-if="!$route.path.includes('/archive')">{{ employee.positions.filter(x=>{return x.end === null})[0].position.name }}</p>
        <p v-else>{{ employee.positions.sort((x,y) => x.end < y.end ? 1 : -1)[0].position.name }}</p>
        <button v-if="!$route.path.includes('/archive')" class="btn btn-info" id="Edit" @click="$router.push({path:`/employee/${employee.id}/edit`})">Upraviť</button>
        <p v-else id="Edit">{{ employee.positions.sort((x,y) => x.end < y.end ? 1 : -1)[0].end }}</p>
        <button class="btn btn-danger" id="Delete" @click="$emit('delete',{id: employee.id, name: employee.name + ' ' +employee.lastName})">Vymazať</button>
    </div>
</template>

<script lang="ts">
export default { 
    props : {
        employee : {
            type: Employee,
            required: true,
            default: ()=>({})
        }
    }
}
</script>

<style lang="scss" scoped>
    .employee_row {
        display: grid;
        grid-template-columns: 40% 20% 20% 20%;
        padding-bottom: 5px;
        margin-bottom: 5px;
        border-bottom: 1px solid black;
    }

    .employee_row > h2 {
        grid-column: 1;
        font-size: 1rem;
    }

    .employee_row > p {
        grid-column: 2;
    }


    .employee_row > button {
        width: fit-content;
    }

    .employee_row > #Edit {
        grid-column: 3;
    }

    .employee_row > #Delete {
        grid-column: 4;
    }
</style>