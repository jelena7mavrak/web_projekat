using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApp.Models;

namespace WebApp.Persistence.Repository
{
    public class CoefficientsRepository : Repository<Coefficients, int>, ICoefficientsRepository
    {
        public CoefficientsRepository(DbContext context) : base(context)
        {
        }
    }
}