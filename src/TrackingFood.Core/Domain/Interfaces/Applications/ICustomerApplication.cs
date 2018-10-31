using System;

namespace TrackingFood.Core.Domain.Interfaces.Applications
{
    public interface ICustomerApplication : IDisposable, IBaseApplication
    {
        void Create(string name);
    }
}