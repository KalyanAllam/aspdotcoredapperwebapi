public interface ICompanyRepository
{
    public Task<IEnumerable<Company>> GetCompanies();
}