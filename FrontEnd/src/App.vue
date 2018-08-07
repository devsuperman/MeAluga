<template>
  <div id="app">
    <img src="./assets/logo.png">      
    
    <h1> My App </h1>
    <router-link to="/"> Início </router-link> |
    <router-link to="/imoveis"> Imóveis </router-link> |
    <router-link to="/locatarios"> Locatários </router-link> 
      
    <router-view>

    </router-view>
  </div>
</template>

<script>

export default {
  name: 'app'  
}
</script>

<style>
#app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
