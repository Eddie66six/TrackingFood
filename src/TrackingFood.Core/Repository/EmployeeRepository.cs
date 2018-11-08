using Dapper;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using TrackingFood.Core.Domain.Entities;
using TrackingFood.Core.Domain.Interfaces.Repositories;
using TrackingFood.Core.Repository.Db;
using System.Linq;

namespace TrackingFood.Core.Repository
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(Context context) : base(context)
        {
        }

        public Employee[] GetDapper(int idCompanyBranch)
        {
            using (var con = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                return con.Query<Employee>("select * from Employees where IdCompanyBranch = @idCompanyBranch", new { idCompanyBranch }).ToArray();
            }
        }
    }
}