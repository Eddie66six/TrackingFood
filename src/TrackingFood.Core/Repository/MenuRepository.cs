using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using Microsoft.EntityFrameworkCore;
using TrackingFood.Core.Domain.Entities;
using TrackingFood.Core.Domain.Interfaces.Repositories;
using TrackingFood.Core.Repository.Db;
using System.Linq;

namespace TrackingFood.Core.Repository
{
    public class MenuRepository : BaseRepository<Menu>, IMenuRepository
    {
        public MenuRepository(Context context) : base(context)
        {
        }

        public Menu Get(int id)
        {
            return _context.Menus.FirstOrDefault(p=> p.IdMenu == id);
        }

        public bool ExistMenuNameDapper(int idCompanyBranch, string name)
        {
            using (var con = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                return con.QueryFirstOrDefault<bool>("select top 1 1 from Menus m where m.IdCompanyBranch = @idCompanyBranch and m.Name =  @name", new { idCompanyBranch ,name });
            }
        }

        public Menu GetWithItemsDapper(int id)
        {
            using (var con = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                var sql = $"SELECT * from Menus m inner JOIN MenuItems mi on mi.IdMenu = m.IdMenu where m.IdMenu = {id}";
                var menuDictionary = new Dictionary<int, Menu>();
                return con.Query<Menu, MenuItem, Menu>(
                        sql,
                        (menu, menuItem) =>
                        {
                            if (!menuDictionary.TryGetValue(menu.IdMenu, out var outMenu))
                            {
                                outMenu = menu;
                                outMenu.MenuItems = new List<MenuItem>();
                                menuDictionary.Add(outMenu.IdMenu, outMenu);
                            }

                            outMenu.MenuItems.Add(menuItem);
                            return outMenu;
                        },
                        splitOn: "IdMenuItens")
                    .FirstOrDefault();
            }
        }
    }
}