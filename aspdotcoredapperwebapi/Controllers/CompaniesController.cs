using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

[Microsoft.AspNetCore.Mvc.Route("api/companies")]
[ApiController]
public class CompaniesController : ControllerBase
{
    private readonly ICompanyRepository _companyRepo;
    public CompaniesController(ICompanyRepository companyRepo)
    {
        _companyRepo = companyRepo;
    }
    [HttpGet]
    public async Task<IActionResult> GetCompanies()
    {
        try
        {
            var companies = await _companyRepo.GetCompanies();
            return Ok(companies);
        }
        catch (Exception ex)
        {
            //log error
            return StatusCode(500, ex.Message);
        }
    }
}