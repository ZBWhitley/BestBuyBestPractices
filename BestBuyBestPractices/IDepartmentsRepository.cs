using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestBuyBestPractices
{
    public interface IDepartmentsRepository
    {
        IEnumerable<departments> GetAllDepartments();
        void InsertDepartment(string newDepartmentName);
    }
}
