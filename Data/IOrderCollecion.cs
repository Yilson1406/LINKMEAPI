using LINKME.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LINKME.Data
{
    public interface IOrderCollecion
    {
        Task Insertorder(Order order);
        Task Updateorder(Order order);

        Task<List<Order>> GetAllorder();
        Task<Order> GetorderById(string id);

    }
}
