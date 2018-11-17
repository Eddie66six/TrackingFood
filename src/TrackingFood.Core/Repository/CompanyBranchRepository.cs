using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Microsoft.EntityFrameworkCore;
using TrackingFood.Core.Domain.Entities;
using TrackingFood.Core.Domain.Interfaces.Repositories;
using TrackingFood.Core.Domain.ViewModel;
using TrackingFood.Core.Repository.Db;

namespace TrackingFood.Core.Repository
{
    public class CompanyBranchRepository: BaseRepository<CompanyBranch>, ICompanyBranchRepository
    {
        public CompanyBranchRepository(Context context) : base(context)
        {
        }

        public CompanyBranch Get(int id, string[] includes = null)
        {
            var query = _context.CompanyBranches.Where(p => p.IdCompanyBranch == id);
            if (includes == null)
                return query.FirstOrDefault();
            query = includes.Aggregate(query, (current, include) => current.Include(include));
            return query.FirstOrDefault();
        }

        public bool ExistCompanyNameDapper(string name)
        {
            using (var con = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                return con.QueryFirstOrDefault<bool>("select top 1 1 from CompanyBranches c where c.Name = @name", new { name });
            }
        }

        public SearchCompanyBranchViewModel[] SearchForName(string strSearch)
        {
            using (var con = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                return con.Query<SearchCompanyBranchViewModel>(@"select cb.IdCompanyBranch, cb.Name as NameCompanyBranch, a.Latitude, a.Longitude from CompanyBranches cb inner join Addresses a on a.IdAddress = cb.IdAddress
                    where cb.Name like '%' + @strSearch + '%'", new { strSearch }).ToArray();
            }
        }
    }
}