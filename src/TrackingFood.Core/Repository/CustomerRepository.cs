using System.Data.SqlClient;
using Dapper;
using Microsoft.Extensions.Options;
using TrackingFood.Core.Domain;
using TrackingFood.Core.Domain.Entities;
using TrackingFood.Core.Domain.Interfaces.Repositories;

namespace TrackingFood.Core.Repository
{
    public class CustomerRepository : BaseRepository, ICustomerRepository
    {
        public CustomerRepository(IOptions<Appsettings> appsettings) : base(appsettings)
        {
        }
        public void Create()
        {
            using (var conexao = new SqlConnection(
                _appsettings.ConnectionStrings.Dapper))
            {
                //return conexao.QueryFirstOrDefault<LoginColaboradorModel>("SELECT c.IdColaborador,c.Nome FROM dbo.Colaboradores c where c.Usuario = @usuario and c.Senha = @senha", new { usuario = usuario, senha = senha });
            }
        }

        public Customer GetCustomers(int id)
        {
            using (var conexao = new SqlConnection(
                _appsettings.ConnectionStrings.Dapper))
            {
                return conexao.QueryFirstOrDefault<Customer>("select name from Customers where IdCustomer = @id", new { id });
            }
        }
    }
}