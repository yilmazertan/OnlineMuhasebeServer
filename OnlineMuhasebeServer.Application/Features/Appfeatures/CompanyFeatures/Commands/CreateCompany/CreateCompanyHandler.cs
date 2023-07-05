using MediatR;
using OnlineMuhasebeServer.Application.Services.AppService;
using OnlineMuhasebeServer.Domain.AppEntities;

namespace OnlineMuhasebeServer.Application.Features.Appfeatures.CompanyFeatures.Commands.CreateCompany
{
    public sealed class CreateCompanyHandler : IRequestHandler<CreateCompanyRequest, CreateCompanyResponse>
    {
        private readonly ICompanyService _companyService;

        public CreateCompanyHandler(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        public async Task<CreateCompanyResponse> Handle(CreateCompanyRequest request, CancellationToken cancellationToken)
        {
            //bu şirket adı daha önce kullanılmış mı kontrol et
            Company company = await _companyService.GetCompanyByName(request.Name);
            if (company != null)  throw new Exception("Bu şirket adı daha önce kullanılmıştır.");

            await _companyService.CreateCompany(request);
            return new();
        }
    }
}
