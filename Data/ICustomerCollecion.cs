using LINKME.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LINKME.Data
{
    public interface ICustomerCollecion
    {
        Task Insertcustomer(Cuatomer product);
        Task Updatecustomer(Cuatomer product);
        Task Deletecustomer(string id);

        Task<List<Cuatomer>> GetAllcustomer();
        Task<Cuatomer> GetcustomerById(string id);

    }
}
