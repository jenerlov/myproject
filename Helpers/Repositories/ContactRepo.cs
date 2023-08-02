using myproject.Contexts;
using myproject.Models.Entities;

namespace myproject.Helpers.Repositories
{
    public class ContactRepo : GeneralRepo<ContactFormEntity>
    {
        public ContactRepo(DataContext context) : base(context)
        {
            
        }
    }
}