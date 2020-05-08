using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace Common.Domain
{
    public interface IDataManager
    {
        public IDataManager WithConnString(String connString);

        public IDataManager WithQuery(String query);

        public IEnumerable<T> ExecuteReader<T>(DbParameter[] parameters, String query = default(String)) where T : new();

        public IEnumerable<T> ExecuteReader<T>(String query = default(String)) where T : new();

        public Int32 ExecuteNonQuery(String query = default(String));

        public Int32 ExecuteNonQuery(DbParameter[] parameters, String query = default(String));

        public T ExecuteScalar<T>(String query = default(String));

        public T ExecuteScalar<T>(DbParameter[] parameters, String query = default(String));
    }
}
