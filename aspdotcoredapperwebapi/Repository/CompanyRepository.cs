using Dapper;
//https://code-maze.com/using-dapper-with-asp-net-core-web-api/
public class CompanyRepository : ICompanyRepository
{
    private readonly DapperContext _context;
    private object _companyRepo;

    public CompanyRepository(DapperContext context)
    {
        _context = context;
    }


    public async Task<IEnumerable<Company>> GetCompanies()
    {
        var query = "SELECT * FROM Companies";
        using (var connection = _context.CreateConnection())
        {
            var companies = await connection.QueryAsync<Company>(query);
            return companies.ToList();
        }
    }

    public async Task<Company> GetCompany(int id)
    {
        var query = "SELECT * FROM Companies WHERE Id = @Id";
        using (var connection = _context.CreateConnection())
        {
            var company = await connection.QuerySingleOrDefaultAsync<Company>(query, new { id });
            return company;
        }
    }
}