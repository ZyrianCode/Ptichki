using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Ptichki.Application.Cqrs.Commands;
using Ptichki.Application.Cqrs.Queries;

namespace Ptichki.Application.Controllers
{
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TodoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> GetTodoById(int id)
        {
            var response = await _mediator.Send(new GetTodoById.Query(id));
            return response == null ? NotFound() : Ok(response);
        }

        public async Task<IActionResult> AddTodo(AddTodo.Command command) =>
            Ok(await _mediator.Send(command));
    }
}
