using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Microsoft.EntityFrameworkCore;
using TrackingFood.Core.Domain.Entities;
using TrackingFood.Core.Domain.Interfaces.Repositories;
using TrackingFood.Core.Repository.Db;

namespace TrackingFood.Core.Repository
{
    public class CompanyRepository : BaseRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(Context context) : base(context)
        {
        }

        public Company Get(int id)
        {
            return _context.Companies.FirstOrDefault(p => p.IdCompany == id);
        }

        public bool ExistCompanyNameDapper(string name)
        {
            using (var con = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                return con.QueryFirstOrDefault<bool>("select top 1 1 from Companies c where c.Name = @name", new { name });
            }
        }
    }
}