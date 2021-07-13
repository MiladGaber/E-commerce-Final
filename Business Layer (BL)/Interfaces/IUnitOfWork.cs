using Business_Layer__BL_.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer__BL_.Interfaces
{
    // created ...mark
    interface IUnitOfWork:IDisposable
    {
        int Commit();

        OrderRepository Order { get; }
        AccountRepository Account { get; }
        RoleRepository Role { get; }

        ProductRepository Product { get; }
        CategoryRepository Category { get; }

    }
}
