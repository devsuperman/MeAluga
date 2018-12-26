<template>
  <div>

     <nav class="orange darken-4" role="navigation">
      <div class="nav-wrapper container">
        <router-link to='/'> 
          <a class='brand-logo'>
            My App
          </a>
        </router-link>
        
        <ul class="right hide-on-med-and-down">          
          <li v-for="item in items" :key='item.title'>            
             <router-link :to="item.to">
                {{item.title}}
              </router-link>
          </li>
        </ul>

        <ul id="nav-mobile" class="sidenav">
          <li><a href="#">Navbar Link</a></li>
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

    <footer class="page-footer blue">
      <div class="container">
        <div class="row">
          <div class="col l6 s12">
            <h5 class="white-text">Company Bio</h5>
            <p class="grey-text text-lighten-4">We are a team of college students working on this project like it's our full time job. Any amount would help support and continue development on this project and is greatly appreciated.</p>


          </div>
          <div class="col l3 s12">
            <h5 class="white-text">Settings</h5>
            <ul>
              <li><a class="white-text" href="#!">Link 1</a></li>
              <li><a class="white-text" href="#!">Link 2</a></li>
              <li><a class="white-text" href="#!">Link 3</a></li>
              <li><a class="white-text" href="#!">Link 4</a></li>
            </ul>
          </div>
          <div class="col l3 s12">
            <h5 class="white-text">Connect</h5>
            <ul>
              <li><a class="white-text" href="#!">Link 1</a></li>
              <li><a class="white-text" href="#!">Link 2</a></li>
              <li><a class="white-text" href="#!">Link 3</a></li>
              <li><a class="white-text" href="#!">Link 4</a></li>
            </ul>
          </div>
        </div>
      </div>
      <div class="footer-copyright">
        <div class="container">
        Made by <a class="orange-text text-lighten-3" href="http://materializecss.com">Materialize</a>
        </div>
      </div>
    </footer>
  </div>
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
        },
        {
          icon: 'group',
          title: 'Locatários',
          to: '/locatarios'
        }                 
      ]      
    }
  },mounted: () => {
      document.addEventListener('DOMContentLoaded', function() {
      var elems = document.querySelectorAll('.sidenav');
      var instances = M.Sidenav.init(elems);
  });
  }
}
</script>
