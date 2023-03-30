<script lang="ts" setup>
import PositionCell from './PositionCell.vue';
</script>
<script lang="ts">
import type { Positions } from '@/models/position';
import { defineComponent } from 'vue'
export default defineComponent({
    props: {
        data: Array<Positions>
    },
    methods:{
        deletePosition(position : {id: Number,name:string}) {
            this.$emit('delete',position)
        }
    }
})
</script>

<template>
    <ul>
        <li v-for="pos in data">
            <PositionCell :position="pos" @delete="deletePosition"/>
        </li>
    </ul>
</template>


<style scoped>
    li {
        list-style: none;
    }
</style>