using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Threading.Tasks;
using SQLite;
using SQLitePCL;
using EXAMENPROGRAMACION.Models;

namespace EXAMENPROGRAMACION.Controles
{
    public class LocalizacionControles
    {
        readonly SQLiteAsyncConnection _connection;
        public LocalizacionControles(string DBpath)
        {
            _connection = new SQLiteAsyncConnection(DBpath);
            _connection.CreateTableAsync<Models.Localizacion>();
        }
        public Task<int> saveubi(Models.Localizacion ubica)
        {
            if (ubica.id != 0)
                return _connection.UpdateAsync(ubica);

            else
                return _connection.InsertAsync(ubica);

        }

        public Task<Models.Localizacion> GetLocalizacion(int pid)
        {
            return _connection.Table<Models.Localizacion>()
                .Where(i => i.id == pid)
                .FirstOrDefaultAsync();
        }
        public Task<List<Models.Localizacion>> Getlisubica()
        {
            return _connection.Table<Models.Localizacion>().ToListAsync();

        }

        internal Task<int> Deleteubi(List<Localizacion> ubica)
        {
            throw new NotImplementedException();
        }

        public Task<int> Deleteubi(Models.Localizacion ubica)
        {
            return _connection.DeleteAsync(ubica);

        }

        internal Task Deleteubi()
        {
            throw new NotImplementedException();
        }
    }
}
