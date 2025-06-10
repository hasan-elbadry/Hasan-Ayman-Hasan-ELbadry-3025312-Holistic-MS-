using Hasan_Ayman_Hasan_ELbadry_3025312__Holistic_MS_.Dtos.CustomerDtos;

namespace Hasan_Ayman_Hasan_ELbadry_3025312__Holistic_MS_.Repositories
{
    public interface ICustomerRepository
    {
        bool AddCustomer(CreateCustomerWithBranchWithAccountWithBankCardDto dto);
        CustomerWithBranchesWithBankCard? getById(int id);
    }
}
