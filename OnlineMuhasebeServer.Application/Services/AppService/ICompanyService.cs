using OnlineMuhasebeServer.Application.Features.Appfeatures.CompanyFeatures.Commands.CreateCompany;
using OnlineMuhasebeServer.Domain.AppEntities;

namespace OnlineMuhasebeServer.Application.Services.AppService
{
    public interface ICompanyService
    {
        Task CreateCompany(CreateCompanyRequest request);
        Task MigrateDatabase();
        Task<Company> GetCompanyByName(string name);
    }
}
