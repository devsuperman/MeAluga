<template>
  <v-app>
    <v-navigation-drawer
      persistent
      :mini-variant="miniVariant"
      :clipped="clipped"
      v-model="drawer"
      enable-resize-watcher
      fixed
      app
    >
      <v-list>
        <v-list-tile
          value="true"
          v-for="(item, i) in items"
          :key="i"
          :to="item.to"
        >
          <v-list-tile-action>
            <v-icon v-html="item.icon"></v-icon>
          </v-list-tile-action>
          <v-list-tile-content>
            <v-list-tile-title v-text="item.title"></v-list-tile-title>
          </v-list-tile-content>
        </v-list-tile>
      </v-list>
    </v-navigation-drawer>
    <v-toolbar app :clipped-left="clipped">
      <v-toolbar-side-icon @click.stop="drawer = !drawer"></v-toolbar-side-icon>      
      <v-toolbar-title v-text="title"></v-toolbar-title>            
    </v-toolbar>
    <v-content>

    <router-view></router-view>  

    </v-content>
    
    <v-footer :fixed="fixed" app>
      <span>&copy; 2018</span>
    </v-footer>
  </v-app>
</template>

<script>

export default {
  name: 'App',
  data () {
    return {
      clipped: true,
      drawer: true,
      fixed: false,
      miniVariant: false,      
      title: 'Vuetify.js',
      items: [
        {
          icon: 'home',
          title: 'Início',
          to: '/'
        },
        {
          icon: 'domain',
          title: 'Imóveis',
          to: '/imoveis'
        },
        {
          icon: 'group',
          title: 'Locatários',
          to: '/locatarios'
        }      
      ]      
    }
  }
}
</script>
