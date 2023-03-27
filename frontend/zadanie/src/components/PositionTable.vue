<script setup lang="ts">
import type { Positions } from '@/models/position';
import PositionCell from './PositionCell.vue';
</script>


<template>
    <ul>
        <li v-for="pos in data">
            <PositionCell :position="pos" @delete="deletePosition"/>
        </li>
    </ul>
</template>

<script lang="ts">
export default {
    props: {
        data: Array<Positions>
    },
    methods:{
        deletePosition(position : {id: Number,name:string}) {
            this.$emit('delete',position)
        }
    }
}
</script>

<style scoped>
    li {
        list-style: none;
    }
</style>