using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Ptichki.Domain.Abstractions.Repositories;
using Ptichki.Domain.Models;

namespace Ptichki.Application.Cqrs.Commands
{
    public class AddTodo
    {
        public record Command(string Name) : IRequest<Todo>;

        public class Handler : IRequestHandler<Command, Todo>
        {
            private readonly IRepository<Todo> _repository;

            public Handler(IRepository<Todo> repository)
            {
                _repository = repository;
            }

            public async Task<Todo> Handle(Command command, CancellationToken cancellationToken)
            {
                var todo = await _repository.AddAsync(new Todo { Name = command.Name });
                
                return todo;
            }
        }
    }
}
