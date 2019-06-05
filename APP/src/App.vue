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

    <v-toolbar app :clipped-left="clipped" tabs>

      <v-toolbar-side-icon @click.stop="drawer = !drawer"></v-toolbar-side-icon>      
      <v-toolbar-title v-text="$title"></v-toolbar-title>    
      
    </v-toolbar>

    <v-content>
      <v-container>
        <router-view></router-view>  
      </v-container>
    </v-content>
    
    <v-footer :fixed="fixed" app>
      <span> &copy; Tiagão Rei do Flip </span>
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
      items: [
        {
          icon: 'home',
          title: 'Início',
          to: '/'
        },
        {
          icon: 'folder_shared',
          title: 'Contratos',
          to: '/contratos'
        },
        {
          icon: 'domain',
          title: 'Imóveis',
          to: '/imoveis'
        }              
      ]      
    }
  }
}
</script>
