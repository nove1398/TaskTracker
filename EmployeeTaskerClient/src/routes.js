import AssignTask from './components/AssignTask.vue';
import ListEmployees from './components/ListEmployees.vue';
import AddEmployee from './components/AddEmployee.vue';
import ListTasks from './components/ListTasks.vue';
import AddTasks from './components/AddTask.vue';

export default[
    {path:'/assignments/:id', component: AssignTask},
    {path:'/listEmployees', component: ListEmployees},
    {path:'/listTasks', component: ListTasks},
    {path:'/addTask', component: AddTasks},
    {path:'/addEmployee', component: AddEmployee},
]