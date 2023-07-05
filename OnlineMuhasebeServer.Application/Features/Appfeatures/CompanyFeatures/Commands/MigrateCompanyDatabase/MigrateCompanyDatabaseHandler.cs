using MediatR;
using OnlineMuhasebeServer.Application.Services.AppService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMuhasebeServer.Application.Features.Appfeatures.CompanyFeatures.Commands.MigrateCompanyDatabase
{
    public class MigrateCompanyDatabaseHandler : IRequestHandler<MigrateCompanyDatabaseRequest, MigrateCompanyDatabaseResponse>
    {

        private readonly ICompanyService companyService;
        public MigrateCompanyDatabaseHandler(ICompanyService companyService)
        {
            this.companyService = companyService;
        }

        public async Task<MigrateCompanyDatabaseResponse> Handle(MigrateCompanyDatabaseRequest request, CancellationToken cancellationToken)
        {
            await companyService.MigrateDatabase();
            return new();
        }
    }
}
