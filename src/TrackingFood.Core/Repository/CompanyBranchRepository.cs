using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Microsoft.EntityFrameworkCore;
using TrackingFood.Core.Domain.Entities;
using TrackingFood.Core.Domain.Interfaces.Repositories;
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
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return query.FirstOrDefault();
        }

        public bool ExistCompanyNameDapper(string name)
        {
            using (var con = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                return con.QueryFirstOrDefault<bool>("select top 1 1 from CompanyBranches c where c.Name = @name", new { name });
            }
        }
    }
}