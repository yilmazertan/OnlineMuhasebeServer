using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineMuhasebeServer.Application.Features.Appfeatures.CompanyFeatures.Commands.CreateCompany;
using OnlineMuhasebeServer.Application.Services.AppService;
using OnlineMuhasebeServer.Domain.AppEntities;
using OnlineMuhasebeServer.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMuhasebeServer.Persistance.Services.AppService
{
    public sealed class CompanyService : ICompanyService
    {
        //aynı isimde şirket varmı kontrol et var ise o şirketi geri döndür
        private static readonly Func<AppDbContext,string,Task<Company?>>
            GetCompanyByNameCompiled=EF.CompileAsyncQuery((AppDbContext context,string name)=>
            context.Set<Company>().FirstOrDefault(p=>p.Name==name));

        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CompanyService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateCompany(CreateCompanyRequest request)
        {
            Company company = _mapper.Map<Company>(request);
           company.Id= Guid.NewGuid().ToString();
            await _context.Set<Company>().AddAsync(company);
            await _context.SaveChangesAsync();

        }

        public async Task<Company?> GetCompanyByName(string name)
        {
            return await GetCompanyByNameCompiled(_context, name);
        }

        public async Task MigrateDatabase()
        {
           var companies=await _context.Set<Company>().ToListAsync();

            foreach (var company in companies)
            {
                var db=new CompanyDbContext(company);
               await db.Database.MigrateAsync();
            }
        }
    }
}
