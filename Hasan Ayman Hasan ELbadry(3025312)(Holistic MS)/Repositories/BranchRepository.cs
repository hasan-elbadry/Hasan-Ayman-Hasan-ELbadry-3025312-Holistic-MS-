
using Hasan_Ayman_Hasan_ELbadry_3025312__Holistic_MS_.Data;
using Hasan_Ayman_Hasan_ELbadry_3025312__Holistic_MS_.Models;
using Microsoft.EntityFrameworkCore;

namespace Hasan_Ayman_Hasan_ELbadry_3025312__Holistic_MS_.Repositories
{
    public class BranchRepository : IBranchRepository
    {
        private readonly ApplicationDbContext _context;

        public BranchRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool AddBranch(CreateBranchWithCustomerDto dto)
        {
            try
            {
                var branch = new Branch
                {
                    Name = dto.Name,
                    Location = dto.Location,
                    Customers = dto.Customers?.Select(x => new Customer
                    {
                        Name = x.Name,
                        PhoneNumber = x.PhoneNumber,
                        Email = x.Email,
                    }).ToList()
                };
                _context.Branches.Add(branch);
                _context.SaveChanges();
                return true;
            }
            catch 
            {
                return false;
            }

        }

        public bool DeleteRepository(int id)
        {
            var branch = _context.Branches.FirstOrDefault(x => x.Id == id);
            if (branch == null)
                return false;
            _context.Remove(branch);
            _context.SaveChanges();
            return true;
        }

        public List<BranchWithCustomerWithAccountDto>? getAll()
        {
            var branches = _context.Branches.Select(x => new BranchWithCustomerWithAccountDto
            {
                Name = x.Name,
                Location = x.Location,
                Customers = x.Customers != null ? x.Customers.Select(x => new Dtos.CustomerDtos.CustomerWithAccount
                {
                    Name = x.Name,
                    Email = x.Email,
                    PhoneNumber = x.PhoneNumber,
                    Accounts = x.Accounts != null ? x.Accounts.Select(x => new CreateAccountDto
                    {
                        AccountNumber = x.AccountNumber,
                        Balance = x.Balance
                    }).ToList() : null
                }).ToList() : null
            }).ToList();
            return branches;
        }

        public (bool,string) UpdateBranch(int id,UpdateBranchWithCustomerIds dto)
        {
            var branch = _context.Branches.Include(x=>x.Customers).FirstOrDefault(x => x.Id == id);
            if (branch == null)
                return (false, "branch not found!");
            if (dto.CustomerIds != null)
            {
                if (!(_context.Customers.Any(x => dto.CustomerIds.Contains(x.Id))))
                    return (false, "customers id does not exist");
                var customers = _context.Customers.Where(x => dto.CustomerIds.Contains(x.Id));
                branch.Customers?.Clear();
                branch.Customers?.AddRange(customers);
            }
            branch.Location = dto.Location;
            branch.Name = dto.Name;
            _context.Update(branch);
            _context.SaveChanges();
            return (true, "data updated successfully!");
        }
    }
}
