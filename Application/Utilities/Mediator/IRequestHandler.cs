using System;
using System.Collections.Generic;
using System.Text;

namespace Practica1.Application.Utilities.Mediator
{
    public interface IRequestHandler<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
    }
    public interface IRequestHandler<TRequest> where TRequest : IRequest
    {
        Task Handle(TRequest request, CancellationToken cancellationToken);
    }
}