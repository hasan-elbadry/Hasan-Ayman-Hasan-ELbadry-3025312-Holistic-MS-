namespace Hasan_Ayman_Hasan_ELbadry_3025312__Holistic_MS_.Repositories
{
    public interface IBranchRepository
    {
        bool AddBranch(CreateBranchWithCustomerDto dto);
        (bool, string) UpdateBranch(int id, UpdateBranchWithCustomerIds dto);
        List<BranchWithCustomerWithAccountDto> getAll();
        bool DeleteRepository(int id);
    }
}
