using Hasan_Ayman_Hasan_ELbadry_3025312__Holistic_MS_.Data;
using Hasan_Ayman_Hasan_ELbadry_3025312__Holistic_MS_.Dtos.CustomerDtos;
using Hasan_Ayman_Hasan_ELbadry_3025312__Holistic_MS_.Models;
using Microsoft.EntityFrameworkCore;

namespace Hasan_Ayman_Hasan_ELbadry_3025312__Holistic_MS_.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _context;

        public CustomerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool AddCustomer(CreateCustomerWithBranchWithAccountWithBankCardDto dto)
        {
            try
            {
                var customer = new Customer
                {
                    Name = dto.Name,
                    Email = dto.Email,
                    PhoneNumber = dto.PhoneNumber,
                    Accounts = dto.Accounts?.Select(x => new Account
                    {
                        AccountNumber = x.AccountNumber,
                        Balance = x.Balance,

                    }).ToList(),
                    Branches = dto.Branches?.Select(x => new Branch
                    {
                        Name = x.Name,
                        Location = x.Location

                    }).ToList(),
                    BankCard = dto.BankCard != null ? new BankCard
                    {
                        CardNumber = dto.BankCard.CardNumber,
                        ExpiryDate = dto.BankCard.ExpiryDate
                    } : null
                };

                _context.Add(customer);
                _context.SaveChanges();
                return true;

            }
            catch
            {
                return false;
            }
          
        }

        public CustomerWithBranchesWithBankCard? getById(int id)
        {
            var customer = _context.Customers.Include(x=>x.BankCard).Include(x=>x.Branches).FirstOrDefault(x=>x.Id == id);
            if (customer == null)
                return null;
            return new CustomerWithBranchesWithBankCard
            {
                Name = customer.Name,
                Email = customer.Email,
                PhoneNumber = customer.PhoneNumber,
                Branches = customer.Branches?.Select(x => new CreateBranchDto
                {
                    Name = x.Name,
                    Location = x.Location
                }).ToList(),
                BankCard = customer.BankCard != null ? new CreateBankCardDto
                {
                    CardNumber = customer.BankCard.CardNumber,
                    ExpiryDate = customer.BankCard.ExpiryDate
                } : null
            };
        }
    }
}
