using System;
using System.Collections.Generic;
using System.Text;

namespace Practica1.Application.Utilities.Mediator
{
    public interface IMediator
    {
        Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default);
        Task Send(IRequest request, CancellationToken cancellationToken = default);
    }
}