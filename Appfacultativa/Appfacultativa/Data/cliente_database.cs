using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Appfacultativa.Models;

namespace Appfacultativa.Data
{
    public class cliente_database
    {
        readonly SQLiteAsyncConnection _database;

        public cliente_database(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<clientes>().Wait();
        }

        public Task<List<clientes>> GetClientesAsync()
        {
            return _database.Table<clientes>().ToListAsync();
        }

        public Task<clientes> GetClientesAsync(int id)
        {
            return _database.Table<clientes>()
                .Where(i => i.ID == id)
                .FirstOrDefaultAsync();
        }

        public Task<int> saveclienteAsync(clientes Clientes)
        {
            if (Clientes.ID != 0)
            {
                return _database.UpdateAsync(Clientes);
            }

            else
            {
                return _database.InsertAsync(Clientes);
            }
        }

        public Task<int> deleteclienteAsync(clientes Clientes)
        {
            return _database.DeleteAsync(Clientes);
        }

    }
}
