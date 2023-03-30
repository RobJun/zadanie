<script setup lang="ts">
import { RouterLink, RouterView } from 'vue-router'
import { defineComponent } from 'vue'
</script>

<template>
  <header class="navbar navbar-expand-lg bg-light">
    <nav class="container-fluid">
      <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbar" aria-controls="navbar" aria-expanded="false" aria-label="Toggle navigation">
        <span class="navbar-toggler-icon"></span>
      </button>
      <div class="collapse navbar-collapse" id="navbar">
        <ul class="navbar-nav me-auto mb-2 mb-lg-0">
          <li class="nav-item">
          <RouterLink to="/" class="nav-link">Zamestnaci</RouterLink>
          </li>
          <li class="nav-item">
          <RouterLink to="/archive" class="nav-link">Archiv</RouterLink>
          </li>
          <li class="nav-item">
          <RouterLink to="/positions" class="nav-link">Pozicie</RouterLink>
          </li>
        </ul>
      </div>
    </nav>
  </header>
  

  <RouterView />
</template>

<style scoped>
</style>
