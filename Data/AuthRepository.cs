using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TECHMarket.Data
{
    public class AuthRepository
    {
        private readonly DataContext _context;
        public AuthRepository(DataContext context)
        {
            _context = context;
        }

    }
}
