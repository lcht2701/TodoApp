using BusinessObject.DTOs.ToDoItems;
using CoreApiResponse;
using DataAccess.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoItemController : BaseController
    {
        private readonly IToDoItemService _toDoItemService;
        private readonly ILogger<ToDoItemController> _logger;

        public ToDoItemController(IToDoItemService toDoItemService, ILogger<ToDoItemController> logger)
        {
            _toDoItemService = toDoItemService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _toDoItemService.GetList();
            return CustomResult("Get To Do List Successfully", result, HttpStatusCode.OK);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var result = await _toDoItemService.GetById(id);
                return CustomResult(result, HttpStatusCode.OK);
            }
            catch (KeyNotFoundException)
            {
                return CustomResult("Item is not found", HttpStatusCode.NotFound);
            }
            catch (Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateToDoItemRequest request)
        {
            try
            {
                var result = await _toDoItemService.Add(request);
                return CustomResult("To-do item created successfully", result, HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateToDoItemRequest request)
        {
            try
            {
                var result = await _toDoItemService.Update(id, request);
                return CustomResult("To-do item updated successfully", result, HttpStatusCode.OK);
            }
            catch (KeyNotFoundException)
            {
                return CustomResult("Item is not found", HttpStatusCode.NotFound);
            }
            catch (Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }

        [HttpPatch("{id}/is-done")]
        public async Task<IActionResult> CheckIsDone(Guid id)
        {
            try
            {
                var result = await _toDoItemService.CheckIsDone(id);
                return CustomResult("To-do item updated successfully", result, HttpStatusCode.OK);
            }
            catch (KeyNotFoundException)
            {
                return CustomResult("Item is not found", HttpStatusCode.NotFound);
            }
            catch (Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _toDoItemService.Remove(id);
                return CustomResult("To-do item removed successfully", HttpStatusCode.OK);
            }
            catch (KeyNotFoundException)
            {
                return CustomResult("Item is not found", HttpStatusCode.NotFound);
            }
            catch (Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }
    }
}
