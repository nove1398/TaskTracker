<template>
 <div class="table-responsive">
                <div v-if="message.length > 0" role="alert" class="alert-info alert">{{message}}</div>
                <table class="table table-striped w-100">
                    <thead>
                        <tr>
                            <th>ID</th>
                            <th>First Name</th>
                            <th>Last Name</th>
                            <th>Department</th>
                            <th></th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr v-if="isLoading">
                            <td colspan="4">
                                Loading data... just a sec :)
                            </td>
                        </tr>
                        <tr v-for="employee in employees">
                            <td>{{employee.id}}</td>
                            <td>{{employee.firstName | to-upperfirst}}</td>
                            <td>{{employee.lastName | to-upperfirst}}</td>
                            <td>{{employee.department || 'N/A'}}</td>
                            <td>
                                <router-link :to="'/assignments/'+employee.id" exact >Edit</router-link>
                            </td>
                        </tr>
                    </tbody>
                </table>
    </div>
</template>

<script>
    import AssignTask from "./AssignTask.vue";
    export default {
        name: 'list-employees',
        components: {AssignTask},
        mounted:  function(){
                 this.getData(1,30);
        },
        data(){
            return{
                employees: [],
                page: 1,
                perPage: 30,
                message: '',
                isLoading: false,
                editMode: false
            }
        },
        methods: {
            getData:  function(page,perPage){
                this.isLoading = true;
                fetch(`http://localhost:5000/api/tasktracker/employees?page=${page}&perPage=${perPage}`)
                .then(response => response.json())
                .then(response => this.employees = response.data)
                .catch(err => alert(err));
                this.isLoading = false;
               
            }
        }
    };
</script>

<style scoped>
</style>