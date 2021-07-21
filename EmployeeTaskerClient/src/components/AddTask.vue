<template>
    <form class="row g-3">
    <div class="alert alert-info" v-if="message.length > 0">{{message}}</div>
    <div class="col-md-6">
        <label for="inputDate" class="form-label">Due Date</label>
        <input type="date"  class="form-control" id="inputDate" v-model="task.dueDate">
    </div>
    <div class="col-md-6">
        <label for="inputLastName" class="form-label">Description</label>
        <input type="text" class="form-control" id="inputLastName" v-model="task.description">
    </div>
    <div class="col-12">
        <label for="inputStatus" class="form-label">Status</label>
        <select v-model="task.statusId" class="form-control">
                <option v-for="item in statusList" v-bind:value="item.id">{{ item.name }}</option>
        </select>
    </div>

    <div class="col-12" v-if="!isLoading">
        <button  type="submit" class="btn btn-primary" v-on:click="submitForm">Add Task</button>
    </div>
    </form>
</template>


<script>
    export default {
        name: 'add-task',
        data(){
            return{
                 message: '',
                 isLoading : false,
                 statusList: [],
                 task:{
                     statusId: 0,
                     description:'',
                     dueDate: ''
                 }
            }
        },
        mounted: function(){
                this.fetchStatusList()
        },
        methods:{
            fetchStatusList: function(){
                this.isLoading = true;
                this. message = '';
                fetch('http://localhost:5000/api/tasktracker/status')
                .then(response => response.json())
                .then(response => this.statusList = response.data)
                .catch(err => alert(err));
                this.isLoading = false;
            },
            submitForm: function(){
                 if(this.task.description.length < 1){
                    alert('Invalid description');
                    return;
                }

                this.isLoading = true;
                this. message = '';
                 const options = {
                                    method: 'POST',
                                    body: JSON.stringify(this.task),
                                    headers: {
                                        'Content-Type': 'application/json'
                                    }
                                };
                //submit form
                fetch('http://localhost:5000/api/tasktracker/tasks',options)
                .then(response => response.json())
                .then(response => this.message = `Task has been added`)
                .catch(err => this.message = err);
                this.isLoading = false;
               
               
            }
        }
    };
</script>

<style scoped>
</style>