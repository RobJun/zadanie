<script setup lang="ts">

</script>


<template>
    <div class="employee_row">
        <h2><RouterLink :to="`/employee/${employee.id}`" class="nav-link">{{employee.name}} {{employee.lastName}}</RouterLink></h2>
        <p>{{ employee.actPosition }}</p>
        <button class="btn btn-info" id="Edit" @click="$router.push({path:`/employee/${employee.id}`, hash: '#edit'})">Edit</button>
        <button class="btn btn-danger" id="Delete">Delete</button>
    </div>
</template>

<script lang="ts">
export default { 
    props : {
        employee : {
            type: Object,
            required: true,
            defaulat: ()=>({})
        }
    }
}
</script>

<style lang="scss" scoped>
    .employee_row {
        display: grid;
        grid-template-columns: 40% 40% 10% 10%;
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