using DAL.Entity;

namespace DAL.Repository
{
    public interface IGuestRepository : IRepository<Guest>
    {
        Guest FindByLogin(string login);
        void RemoveByLogin(string login);
    }
}