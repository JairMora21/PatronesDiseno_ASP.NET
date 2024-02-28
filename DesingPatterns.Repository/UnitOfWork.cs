using DesingPatterns.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesingPatterns.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DesingPatternsContext _context;

        //Esto guarda si el obbjeto ya fue creado o no
        public IRepository<Beer> _beers;
        public IRepository<Brand> _brands;

        public UnitOfWork(DesingPatternsContext context)
        {
            _context = context;
        }
        public IRepository<Beer> Beers
        {
            get
            {
                if (_beers == null)
                {
                    _beers = new Repository<Beer>(_context);
                }
                return _beers;
            }
        }

        public IRepository<Brand> Brands
        {
            get
            {
                if (_brands == null)
                {
                    _brands = new Repository<Brand>(_context);
                }
                return _brands;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
