using myproject.Contexts;
using myproject.Models.Entities;

namespace myproject.Helpers.Repositories
{
    public class AddressRepo : GeneralRepo<AddressEntity>
    {
        public AddressRepo(DataContext context) : base(context)
        {}
    }
}