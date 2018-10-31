using Microsoft.Extensions.Options;
using TrackingFood.Core.Domain;
using TrackingFood.Core.Domain.Interfaces.Repositories;

namespace TrackingFood.Core.Repository
{
    public class BaseRepository : IBaseRepository
    {
        protected readonly Appsettings _appsettings;
        public BaseRepository(IOptions<Appsettings> appsettings)
        {
            _appsettings = appsettings.Value;
        }
    }
}