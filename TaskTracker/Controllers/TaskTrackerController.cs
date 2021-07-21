using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskTracker.Dto;
using TaskTracker.Mappers;
using TaskTracker.Services;

namespace TaskTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskTrackerController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly ITaskService _taskService;

        public TaskTrackerController(IEmployeeService employeeService, ITaskService taskService)
        {
            _employeeService = employeeService;
            _taskService = taskService;
        }

        [HttpGet("employees/{id:int}")]
        public async Task<IActionResult> GetEmployee(int id)
        {
            var response = new ApiResponse<EmployeeDto>();
            var employee = await _employeeService.GetEmployee(id);

            if (employee == null)
            {
                return NotFound($"Employee '{id}' was not found");
            }

            response.Data = employee.ToDto();

            return Ok(response);
        }

        [HttpGet("tasks/{id:int}")]
        public async Task<IActionResult> GetTask(int id)
        {
            var response = new ApiResponse<TaskDto>();
            var task = await _taskService.GetTask(id);
            if (task == null)
            {
                return NotFound($"Task '{id}' was not found");
            }
            response.Data = task.ToDto();

            return Ok(response);
        }

        [HttpGet("status")]
        public async Task<IActionResult> GetEmployees()
        {
            var statusList = await _taskService.GetAllStatus();
            var response = new ApiResponse<List<StatusDto>>
            {
                Data = statusList.ToDto()
            };
            return Ok(response);
        }

        [HttpGet("employees")]
        public async Task<IActionResult> GetEmployees([FromQuery] int page = 1, [FromQuery] int pageSize = 30)
        {
            var employees = await _employeeService.GetEmployees(page, pageSize);
            var response = new ApiResponse<List<EmployeeDto>>
            {
                Data = employees.ToDto()
            };
            return Ok(response);
        }

        [HttpGet("tasks")]
        public async Task<IActionResult> GetTasks([FromQuery] int page = 1, [FromQuery] int pageSize = 30)
        {
            var tasks = await _taskService.GetAllTasks(page, pageSize);
            var response = new ApiResponse<List<TaskDto>>
            {
                Data = tasks.ToDto()
            };
            return Ok(response);
        }

        [HttpPost("employees")]
        public async Task<IActionResult> CreateEmployee([FromBody] CreateEmployeeDto request)
        {
            var newEmployee = await _employeeService.CreateEmployee(request);
            if (newEmployee == null)
            {
                return BadRequest($"Invalid characters sent");
            }
            var response = new ApiResponse<EmployeeDto>
            {
                Data = newEmployee.ToDto()
            };
            return Ok(response);
        }

        [HttpPost("tasks")]
        public async Task<IActionResult> CreateTask([FromBody] CreateTaskDto request)
        {
            var newTask = await _taskService.CreateTask(request);
            var response = new ApiResponse<TaskDto>
            {
                Data = newTask.ToDto()
            };
            return Ok(response);
        }

        [HttpPost("tasks/assign")]
        public async Task<IActionResult> AssignTask([FromBody] AssignTaskDto request)
        {
            var taskAssigned = await _taskService.AssignTask(request);
            if (!taskAssigned)
            {
                return BadRequest($"Invalid Task:'{request.TaskIds.ToArray()}' or Employee:'{request.EmployeeId}' sent");
            }

            return Ok(taskAssigned);
        }

        [HttpPut("tasks/{taskId:int}")]
        public async Task<IActionResult> UpdateTaskStatus(int taskId, [FromBody] UpdateTaskStatusDto request)
        {
            var task = await _taskService.ChangeTaskStatus(taskId, request);
            if (task == null)
            {
                return BadRequest("Invalid data requested for updated");
            }

            var response = new ApiResponse<TaskDto>
            {
                Data = task.ToDto()
            };
            return Ok(response);
        }
    }
}