<template>
  <div>
     <nav class="orange darken-4" role="navigation">
      <div class="nav-wrapper container">
        <router-link to='/'> 
          <a class='brand-logo'>
            {{$title}}
          </a>
        </router-link>
        
        <ul class="right hide-on-med-and-down">          
          <li v-for="item in menu" :key='item.title'>            
             <router-link :to="item.to">
                {{item.title}}
              </router-link>
          </li>
        </ul>

        <ul id="nav-mobile" class="sidenav">
          <li v-for="item in menu" :key='item.title'>            
             <router-link :to="item.to">
                {{item.title}}
              </router-link>
          </li>
        </ul>
        <a href="#" data-target="nav-mobile" class="sidenav-trigger"><i class="material-icons">menu</i></a>
      </div>
    </nav>
  
    <div class="container">
      <div class="section">
        <router-view></router-view> 
      </div>
      <br><br>
    </div>

    <!-- <footer class="page-footer light-blue darken-4">      
      <div class="footer-copyright">
        <div class="container">
          MyApp  - 2018
        </div>
      </div>
    </footer> -->
  </div>
</template>

<script>

export default {  
  name: 'App',
  data () {
    return {                    
      menu: [
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
          title: 'Apartamentos',
          to: '/apartamentos'
        },
        {
          icon: 'group',
          title: 'Locatários',
          to: '/locatarios'
        }                 
      ]      
    }
  },  
  mounted(){
    document.addEventListener('DOMContentLoaded', function() {

      var sidenav  = document.querySelector('.sidenav');
      var selects = document.querySelectorAll('select');
            
      // eslint-disable-next-line
      var sidenavInstances = M.Sidenav.init(sidenav);           
      // eslint-disable-next-line
      M.FormSelect.init(selects);      
  
      document.addEventListener('click', function (e) {
          if (e.target.tagName == 'A') {
            sidenavInstances.close();            
          }
      });

    });    
    
  }
}
</script>

<style scoped>
  footer {
    position: absolute;
    bottom: 0;
    width: 100%;
    height: 60px;
  }
</style>

