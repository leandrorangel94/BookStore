using BookStore.Context;
using BookStore.Domain;
using BookStore.Repositories.Contracts;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BookStore.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private BookStoreDataContext _db = new BookStoreDataContext();

        public bool Create(Categoria categoria)
        {
            try
            {
                _db.Categorias.Add(categoria);
                _db.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public void Delete(int id)
        {
            var categoria = _db.Categorias.Find(id);
            _db.Categorias.Remove(categoria);
            _db.SaveChanges();
        }

        public List<Categoria> Get()
        {
            return _db.Categorias.ToList();
        }

        public Categoria Get(int id)
        {
            return _db.Categorias.Find(id);
        }

        public List<Categoria> GetByName(string name)
        {
            return _db.Categorias
               .Where(x => x.Nome.Contains(name))
               .ToList();
        }

        public bool Update(Categoria categoria)
        {
            try
            {
                _db.Entry<Categoria>(categoria).State = EntityState.Modified;
                _db.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}