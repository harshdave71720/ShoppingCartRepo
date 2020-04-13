using ShoppingCartDataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartDataLayer.Factories
{
    public interface IRepositoryFactory<T>
    {
        T GetInstance();
    }
}
