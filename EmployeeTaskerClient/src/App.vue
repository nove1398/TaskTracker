<template>
  <div id="app">
    <div class="text-center">
            <h2 class="text-center">{{title}}</h2>
    </div>
    <div class="container">
        <div class="row">
            <div class="col-12">
                <ul class="list-unstyled">
                    <li  class="p-2 text-info"><router-link to='/addEmployee' exact>Add Employee</router-link></li>
                    <li class="p-2 text-info"><router-link to='/listEmployees' exact>List Employees</router-link></li>
                    <li class="p-2 text-info"><router-link to='/addTask' exact>Add Task</router-link></li>
                    <li class="p-2 text-info"><router-link to='/listTasks' exact>List Tasks</router-link></li>
                </ul>
            </div>
            </div>
            <div class="row">
              <div class="col-12">
                <!--Dynamic inner components >
                <components v-bind:is="component"></components-->
                <router-view></router-view>
                <!--End -->
              </div>
        </div>
    </div>
  </div>
</template>

<script>
export default {
  name: 'app',
  data () {
    return {
      title: 'Employee Task Tracker',
      component: 'list-employees'
    }
  },
  methods:{
    
  }
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

h1, h2 {
  font-weight: normal;
}

ul {
  list-style-type: none;
  padding: 0;
}

li {
  display: inline-block;
  margin: 0 10px;
}

a {
  color: #42b983;
}

.router-link-active{
    color: brown;
    font-weight: bold;
    font-size: 1.3em;
}
</style>
