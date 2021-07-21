<template>
<form class="row g-3">
   <div v-if="message.length > 0" class="alert alert-info">{{message}}</div>
  <div class="col-md-6">
    <label for="inpuFirstName" class="form-label">First Name</label>
    <input type="text" class="form-control" id="inputEmail4" v-model="employee.firstName">
  </div>
  <div class="col-md-6">
    <label for="inputLastName" class="form-label">Last Name</label>
    <input type="text" class="form-control" id="inputLastName" v-model="employee.lastName">
  </div>
  <div class="col-12">
    <label for="inputDepartment" class="form-label">Department</label>
    <input type="text" class="form-control" id="inputDepartment"  v-model="employee.department">
  </div>

  <div class="col-12">
    <button type="submit" class="btn btn-primary" v-on:click="submitForm">Add Employee</button>
  </div>
</form>
</template>


<script>
    export default {
        name: 'add-employee',
        data(){
            return{
                    message: '',
                    employee:{
                        firstName:'',
                        lastName:'',
                        department:''
                    }
            }
        },
        methods:{
            submitForm: function(){
                if(this.employee.firstName.length < 1){
                    alert('Invalid first name');
                    return;
                }
                if(this.employee.lastName.length < 1){
                    alert('Invalid first name');
                    return;
                }
                const options = {
                                    method: 'POST',
                                    body: JSON.stringify(this.employee),
                                    headers: {
                                        'Content-Type': 'application/json'
                                    }
                                };
                //submit form
                fetch('http://localhost:5000/api/tasktracker/employees',options) 
                .then(response => response.json())
                .then(response => this.message = `'${this.employee.firstName } ${this.employee.lastName }' has been added`)
                .catch(err => this.message= err);
            }
        }
    };
</script>