using System.Data.SqlClient;
using TrackingFood.Core.Domain.Entities;
using TrackingFood.Core.Domain.Interfaces.Repositories;
using TrackingFood.Core.Repository.Db;
using System.Linq;
using Dapper;
using Microsoft.EntityFrameworkCore;
using TrackingFood.Core.Domain.ViewModel;

namespace TrackingFood.Core.Repository
{
    public class MenuItemRepository: BaseRepository<MenuItem>, IMenuItemRepository
    {
        public MenuItemRepository(Context context) : base(context)
        {
        }

        public MenuItem Get(int id)
        {
            return _context.MenuItems.FirstOrDefault(p => p.IdMenuItens == id);
        }

        public bool ExistMenuItemNameDapper(int idMenu, string name)
        {
            using (var con = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                return con.QueryFirstOrDefault<bool>("SELECT top 1 1 from MenuItems where IdMenu = idMenu and Name =  @name", new { idMenu, name });
            }
        }

        public bool ExistMenuItemNameDapper(int idMenu, string[] names)
        {
            using (var con = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                return con.QueryFirstOrDefault<bool>("select top 1 1 from MenuItems where IdMenu = @idMenu and Name in @names", new { idMenu, names });
            }
        }

        public MenuItem[] CreateRange(MenuItem[] menuItems)
        {
            _context.MenuItems.AddRange(menuItems);
            return menuItems;
        }

        public SearchMenuItemViewModel[] SearchForNameOrValue(string strSearch, decimal? inicialValue = null, decimal? finalValue = null)
        {
            if (string.IsNullOrEmpty(strSearch) && inicialValue == null) return null;
            var query = @"select cb.IdCompanyBranch, cb.Name as NameCompanyBranch, a.Latitude, a.Longitude,mi.Name as NameMenuItem, mi.Value
                from MenuItems mi inner join Menus m on m.IdMenu = mi.IdMenu
	                inner join CompanyBranches cb on cb.IdCompanyBranch = m.IdCompanyBranch
	                inner join Addresses a on a.IdAddress = cb.IdAddress";
            if (!string.IsNullOrEmpty(strSearch))
                query += " where mi.Name like '%' + @strSearch + '%' or mi.Description like '%' + @strSearch + '%'";
            if (inicialValue != null)
            {
                finalValue = finalValue.GetValueOrDefault(inicialValue.Value);
                query += " where mi.Value >= @inicialValue and mi.Value <= @finalValue";
            }

            using (var con = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                return con.Query<SearchMenuItemViewModel>(query, new { strSearch, inicialValue, finalValue }).ToArray();
            }
        }
    }
}