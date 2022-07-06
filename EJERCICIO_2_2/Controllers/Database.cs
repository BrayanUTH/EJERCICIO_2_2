using EJERCICIO_2_2.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EJERCICIO_2_2.Controllers
{
    public class Database
    {
        readonly SQLiteAsyncConnection dbase;

        public Database(string dbPath)
        {
            dbase = new SQLiteAsyncConnection(dbPath);

            dbase.CreateTableAsync<Signature>();
        }

        public Task<int> createOrUpdateSignature(Signature signature)
        {
            if (signature.id != 0)
            {
                return dbase.UpdateAsync(signature);
            }
            else
            {
                return dbase.InsertAsync(signature);
            }
        }

        public Task<List<Signature>> getAllSignature()
        {
            return dbase.Table<Signature>().ToListAsync();
        }
    }
}
