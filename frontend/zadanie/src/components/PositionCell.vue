<script setup lang="ts">
import type { Positions } from '@/models/position';
import type { PropType } from 'vue';
</script>


<template>
    <div class="employee_row">
        <h2>{{ position.name }}</h2>
        <button class="btn btn-danger" id="Delete" @click="deletePosition">Delete</button>
    </div>
</template>

<script lang="ts">
export default { 
    props : {
        position : {
            type: Object as PropType<Positions>,
            required: true,
            defaulat: ()=>({})
        }
    },
    methods : {
        deletePosition(){
            this.$emit('delete',{id: this.position.id, name: this.position.name})
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