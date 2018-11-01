using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore.Internal;

namespace TrackingFood.Core.Domain
{
    public class DomainEvent : IDomainEvent, IDisposable
    {
        private static List<DomainEventContainer> _domainEventContainer;

        public void AddError(string message, [CallerMemberName] string callerMemberName = null)
        {
            if (_domainEventContainer == null) _domainEventContainer = new List<DomainEventContainer>();
            _domainEventContainer.Add(new DomainEventContainer(message, callerMemberName));
        }

        public void Dispose()
        {
            _domainEventContainer = new List<DomainEventContainer>();
            GC.SuppressFinalize(this);
        }

        public DomainEventContainer[] GetErrorMessages()
        {
            return _domainEventContainer.ToArray();
        }

        public bool IsError()
        {
            return _domainEventContainer?.Any() ?? false;
        }
    }

    public class DomainEventContainer
    {
        public DomainEventContainer(string message, string method)
        {
            Message = message;
            Method = method;
        }
        public string Message { get; }
        public string Method { get; }
    }
}