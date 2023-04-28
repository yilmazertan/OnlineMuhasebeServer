using OnlineMuhasebeServer.Domain.Abstract;

namespace OnlineMuhasebeServer.Domain.CompanyEntities
{
    public sealed class UniformChartOfAccount : EntityBase
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public char Type { get; set; }
    }
}
