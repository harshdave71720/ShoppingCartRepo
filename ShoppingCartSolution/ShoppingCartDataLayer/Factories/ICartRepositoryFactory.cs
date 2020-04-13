using ShoppingCartDataLayer.Repositories;

namespace ShoppingCartDataLayer.Factories
{
    public interface ICartRepositoryFactory : IRepositoryFactory<ICartRepository>
    {
    }
}