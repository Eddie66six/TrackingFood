using System.Data.SqlClient;
using TrackingFood.Core.Domain.Entities;
using TrackingFood.Core.Domain.Interfaces.Repositories;
using TrackingFood.Core.Repository.Db;
using System.Linq;
using Dapper;
using Microsoft.EntityFrameworkCore;

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
    }
}