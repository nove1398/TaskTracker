<template>
    <div class="row">
        <div class="col-12">
            <div class="bg-light p-3">#{{payload.employeeId}} {{employee.firstName | to-upperfirst}}</div>
        </div>
        <div class="col-12">
            <div><h1>Available Tasks</h1></div>
            <div class="text-left">
                <a href="#" class="btn btn-primary" v-on:click="adjustTasks">Assign selected tasks</a>
                <div role="alert" class="p-3 alert alert-info mt-2" v-if="message.length > 0">
                    <span class="">{{message}}</span>
                </div>
            </div>
            <div class="table-responsive">
                <table class="table table-strpied">
                    <thead>
                        <tr>
                            <th></th>
                            <th>ID</th>
                            <th>Description</th>
                            <th>Status</th>
                            <th>Due Date</th>
                            <th># assigned</th>
                        </tr>
                    </thead>
                    <tbody>
                        <template v-for="task in taskList">
                            <tr>
                                <td>
                                    <input type="checkbox" 
                                    :id="task.id" 
                                    :value="task.id" 
                                    v-model="payload.taskIds" 
                                    class="d-inline" >
                                </td>
                                <td>{{task.id}}</td>
                                <td>{{task.description}}</td>
                                <td>{{task.status}}</td>
                                <td>{{task.dueDate | to-jmdate}}</td>
                                <td>{{task.status}}</td>
                            </tr>
                        </template>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
</template>

<script>
    export default {
        name: 'assign-tasks',
        mounted(){
            this.getData();
            this.getEmployee();

        },
        data(){
            return {
                    taskList:[],
                    isLoading: false,
                    message: '',
                    payload: {
                             taskIds: [],
                            employeeId: this.$route.params.id
                    },
                    employee: {}
            };
        },
        methods:{
            getEmployee: function(){
                 fetch(`http://localhost:5000/api/tasktracker/employees/${this.payload.employeeId}`)
                .then(response => response.json())
                .then(response => {
                        this.employee = response.data;
                    })
                .catch(err => alert('Oops something went wrong'));
            },
             getData:  function(){
                this.isLoading = true;
                this. message = '';
                fetch(`http://localhost:5000/api/tasktracker/tasks`)
                .then(response => response.json())
                .then(response => {
                    this.taskList = response.data;
                     this.taskList.forEach(el =>{
                         if(el.employees.length > 0){

                            el.employees.forEach(emp => {
                                    if(emp.id == this.payload.employeeId){
                                        this.payload.taskIds.push(el.id);
                                    }
                            });
                         }
                     });

                    })
                .catch(err => alert('Oops something went wrong'));
                this.isLoading = false;
               
            },
            adjustTasks: function(){

                this.isLoading = true;
                this. message = '';
                  const options = {
                                    method: 'POST',
                                    body: JSON.stringify(this.payload),
                                    headers: {
                                        'Content-Type': 'application/json'
                                    }
                                };
                fetch(`https://localhost:5001/api/tasktracker/tasks/assign`,options)
                .then(response => response.json())
                .then(response => {
                    this.message = 'Task list updated!'
                    })
                .catch(err => alert('Oops something went wrong'));
                this.isLoading = false;
            }
        }
    };
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
</style>