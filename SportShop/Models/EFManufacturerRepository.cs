using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportShop.Models
{
    public class EFManufacturerRepository : IManufacturerRepository
    {
        private readonly ApplicationDbContext ctx;
        public EFManufacturerRepository(ApplicationDbContext ctx)
        {
            this.ctx = ctx;
        }
        public IQueryable<Manufacturer> Manufacturers => ctx.Manufacturers;
    }
}
