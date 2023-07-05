using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMuhasebeServer.Application.Features.Appfeatures.CompanyFeatures.Commands.MigrateCompanyDatabase
{
    public class MigrateCompanyDatabaseRequest:IRequest<MigrateCompanyDatabaseResponse>
    {
    }
}
