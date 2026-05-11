using System;
using System.Collections.Generic;
using System.Text;

namespace Practica1.Application.Utilities.Mediator
{
    public class SimpleMediator
    {
        private readonly Dictionary<Type, Func<object, object>> _handlers = new();
        public void Register<TRequest, TResponse>(Func<TRequest, TResponse> handler)
        {
            _handlers[typeof(TRequest)] = request => handler((TRequest)request);
        }
        public TResponse Send<TRequest, TResponse>(TRequest request)
        {
            if (_handlers.TryGetValue(typeof(TRequest), out var handler))
            {
                return (TResponse)handler(request);
            }
            throw new InvalidOperationException($"No hay un manejador registrado para {typeof(TRequest).Name}");
        }
    }
}