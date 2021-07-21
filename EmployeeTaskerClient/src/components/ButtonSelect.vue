<template>
<div>
    <div class="btn btn-primary btn-sm" v-on:click="showSelect = true" v-if="!showSelect"> Update Status </div>
    <div v-if="showSelect">
        <select v-model="statusId" class="form-control" >
            <option value="-1">Select new status</option>
                <option v-for="item in dataList" v-bind:value="item.id">{{ item.name }}</option>
            </select>
        <div class="col-12 mt-3" v-if="!isLoading">
            <button  type="submit" class="btn btn-success" v-on:click="submitForm">Save</button>
        </div>
    </div>
</div>
</template>

<script>
    export default {
        name: 'home',
        props: {
            dataList: [],
            taskItem:{}
        },
        mounted(){
            
        },
        data(){
            return{
                showSelect: false,
                statusId: -1,
                isLoading: false
            }
        },
        methods:{
            submit:() =>{
                this.action();
                ///:selected="item.id == task.statusId"
            },
            submitForm: function(){
                this. message = '';
                 const options = {
                                    method: 'PUT',
                                    body: JSON.stringify({newStatusId:this.statusId}),
                                    headers: {
                                        'Content-Type': 'application/json'
                                    }
                                };
                //submit form
                this.isLoading = true;
                fetch(`http://localhost:5000/api/tasktracker/tasks/${this.taskItem.id}`,options)
                .then(response => response.json())
                .then(response => {
                    this.showSelect = false;
                    this.taskItem.status = response.data.status;
                    })
                .catch(err => alert('oops, something went wrong'));
                this.isLoading = false;
            }
        }
    };
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
</style>