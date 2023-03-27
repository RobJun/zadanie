

<template>
<div class="modal fade" :id="id" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
      <div class="modal-dialog">
        <div class="modal-content">
          <div class="modal-header">
            <h1 class="modal-title fs-5" id="exampleModalLabel">{{title}}</h1>
            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
          </div>
          <div class="modal-body">
            <slot name="body"></slot>
          </div>
          <div class="modal-footer">
            <slot name="controls"></slot>
          </div>
        </div>
      </div>
    </div>
</template>

<script lang="ts">
export default {
    props : {
        id: {
          type: String,
          required: true
        },
        title : {
          type : String
        },
    }
}
</script>