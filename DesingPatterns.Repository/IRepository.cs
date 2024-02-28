using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesingPatterns.Repository
{
    public interface IRepository<TEntity>
    {
        //Tenemos metodos con clases genericas las cuales despues implementaremos 
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);
        void Insert(TEntity entity);
        void Delete(int id);
        void Update(TEntity entity);
        void Save();
    }
}
