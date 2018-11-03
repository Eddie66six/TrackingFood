using System;
using TrackingFood.Core.Domain.ViewModel.Request;

namespace TrackingFood.Core.Domain.Interfaces.Applications
{
    public interface ICustomerApplication : IDisposable, IBaseApplication
    {
        void Create(CreateCustomerViewModel customer);
    }
}