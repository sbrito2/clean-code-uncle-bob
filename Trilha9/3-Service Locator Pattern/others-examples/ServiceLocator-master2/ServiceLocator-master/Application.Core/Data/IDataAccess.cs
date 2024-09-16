using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Core.Data
{
    public interface IDataAccess
    {
        void BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();
        object Execute(string query);   
        T Execute<T>(string query);
    }
}
