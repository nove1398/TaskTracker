<template>
<div class="container">
    <div class="row">
        <div class="table-responsive col-12">
            <div v-if="message.length > 0" role="alert" class="alert-info alert">{{message}}</div>
            <table class="table table-striped w-100">
                <thead>
                    <tr>
                        <th>ID</th>
                        <th>Description</th>
                        <th>Due Date</th>
                        <th>Status</th>
                        <th>Assigned To</th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-if="isLoading">
                        <td colspan="4">
                            Loading data... just a sec :)
                        </td>
                    </tr>
                    <tr v-for="task in tasks" v-if="!isLoading">
                        <td>{{task.id}}</td>
                        <td>{{task.description | to-upperfirst}}</td>
                        <td>{{task.dueDate | to-jmdate}}</td>
                        <td>
                            <span class="text-uppercase">{{task.status}}</span>
                            <br>
                            <ButtonSelect 
                            v-bind:dataList="statusList" 
                            v-bind:taskItem="task"/>
                        </td>
                        <td>
                            <ul class="list-unstyled">
                                <li v-for="emp in task.employees" >
                                    <span>{{emp.firstName | to-upperfirst}} {{emp.lastName | to-upperfirst}}</span>
                                </li>
                            </ul>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
</div>
</template>

<script>
import ButtonSelect from './ButtonSelect.vue';

    export default {
        name: 'update-task',
        components:{ ButtonSelect },
        data(){ return{
                tasks: [],
                page: 1,
                perPage: 30,
                message: '',
                isLoading: false,
                activeTask: {},
                showModal: false,
                statusList: []
        }},
        methods: {
             getData:  function(page,perPage){
                this.isLoading = true;
                this. message = '';
                fetch(`http://localhost:5000/api/tasktracker/tasks?page=${page}&perPage=${perPage}`)
                .then(response => response.json())
                .then(response => {
                    this.tasks = response.data;
                    })
                .catch(err => alert('Oops something went wrong'));
                this.isLoading = false;
               
            },
            fetchStatusList: function(){
                this.isLoading = true;
                fetch('http://localhost:5000/api/tasktracker/status')
                .then(response => response.json())
                .then(response => this.statusList = response.data)
                .catch(err => alert('Oops something went wrong'));
                this.isLoading = false;
            }
        },
        mounted: function(){
                this.getData(1,30);
                this.fetchStatusList();
        }
    };
</script>

<style scoped>
</style>