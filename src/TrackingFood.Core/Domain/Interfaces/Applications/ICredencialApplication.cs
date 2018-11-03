using System;
using TrackingFood.Core.Domain.ViewModel.Request;

namespace TrackingFood.Core.Domain.Interfaces.Applications
{
    public interface ICredencialApplication : IDisposable, IBaseApplication
    {
        void Update(UpdateCredencialViewModel credencial);
    }
}