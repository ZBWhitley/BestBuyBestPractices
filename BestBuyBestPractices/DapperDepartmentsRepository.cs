using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Dapper;

namespace BestBuyBestPractices
{
    public class DapperDepartmentsRepository : IDepartmentsRepository
    {
        private readonly IDbConnection _connection;

        public DapperDepartmentsRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<departments> GetAllDepartments()
        {            
            var depos = _connection.Query<departments>("Select * from departments");
            return depos;
        }

        public void InsertDepartment(string newDepartmentName)
        {
            _connection.Execute("INSERT INTO DEPARTMENTS (Name) VALUES (@departmentName);",
            new { departmentName = newDepartmentName });
        }

    }
}