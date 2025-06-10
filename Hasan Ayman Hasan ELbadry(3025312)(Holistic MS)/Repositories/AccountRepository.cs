
using Hasan_Ayman_Hasan_ELbadry_3025312__Holistic_MS_.Data;
using Hasan_Ayman_Hasan_ELbadry_3025312__Holistic_MS_.Models;

namespace Hasan_Ayman_Hasan_ELbadry_3025312__Holistic_MS_.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ApplicationDbContext _context;

        public AccountRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool AddAccount(CreateAccountWithCustomer dto)
        {
            try
            {
                var Account = new Account
                {
                    AccountNumber = dto.AccountNumber,
                    Balance = dto.Balance,
                    CustomerId = dto.CustomerId
                };
                _context.Add(Account);
                _context.SaveChanges();
                return true;
            }
            catch 
            {
                return false;
            }
        }
    }
}
