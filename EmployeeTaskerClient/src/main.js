import Vue from 'vue'
import App from './App.vue'
import VueRouter from 'vue-router'
import AddEmployee from './components/AddEmployee.vue'
import ListEmployees from './components/ListEmployees.vue'
import AddTask from './components/AddTask.vue'
import ListTasks from './components/ListTasks.vue'
import AssignTask from './components/AssignTask.vue'
import Routes from './routes.js'

//Dependencies
Vue.use(VueRouter);

const router = new VueRouter({
    routes: Routes,
    mode: 'history'
});

//Register components
Vue.component('add-employee',AddEmployee);
Vue.component('list-employees',ListEmployees);
Vue.component('add-task',AddTask);
Vue.component('list-tasks',ListTasks);
Vue.component('assign-task',AssignTask);

//Register filters
Vue.filter('to-upperfirst',e =>{
    var firstCharacter = e.substring(0, 1);
    var restString = e.substring(1);

    return firstCharacter.toUpperCase() + restString;
});
Vue.filter('to-uppercase',e =>{
  return e.toUpperCase();
});
Vue.filter('to-short',e =>{
  return e.slice(0,20) + "...";
});
Vue.filter('to-jmdate',e =>{
    let m = new Date(e);
    return m.getDate() +"/"+ (m.getMonth()+1) +"/"+  m.getFullYear();
});


new Vue({
  el: '#app',
  render: h => h(App),
  router: router
})
