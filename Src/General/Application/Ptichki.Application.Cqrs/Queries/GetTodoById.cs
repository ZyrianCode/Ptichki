using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Ptichki.Domain.Abstractions.Repositories;
using Ptichki.Domain.Models;

namespace Ptichki.Application.Cqrs.Queries
{
    public class GetTodoById
    {
        public record Query(int Id) : IRequest<Response>;

        internal class Handler : IRequestHandler<Query, Response>
        {
            private readonly IRepository<Todo> _repository;

            public Handler(IRepository<Todo> repository)
            {
                _repository = repository;
            }

            public async Task<Response> Handle(Query query, CancellationToken cancellationToken)
            {
                var todo = await _repository.GetAsync(query.Id);
                return todo == null ? null : new Response(todo.Id, todo.Name);
            }
        }

        public record Response(int Id, string Name);
    }
}
