using System;
using TrackingFood.Core.Domain.ViewModel.Request;

namespace TrackingFood.Core.Domain.Interfaces.Applications
{
    public interface ICustomerApplication : IDisposable, IBaseApplication
    {
        int? Create(CreateCustomerViewModel customer);
        void Update(UpdateCustomerViewModel customer);
    }
}