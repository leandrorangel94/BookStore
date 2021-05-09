using BookStore.Context;
using BookStore.Domain;
using BookStore.Repositories.Contracts;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BookStore.Repositories
{
    public class BookRepository : IBookRepository
    {
        private BookStoreDataContext _db = new BookStoreDataContext();

        public bool Create(Livro livro)
        {
            try
            {
                _db.Livros.Add(livro);
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
            var livro = _db.Livros.Find(id);
            _db.Livros.Remove(livro);
            _db.SaveChanges();
        }

        public List<Livro> Get()
        {
            return _db.Livros.ToList();
        }

        public Livro Get(int id)
        {
            return _db.Livros.Find(id);
        }

        public List<Livro> GetByName(string name)
        {
            return _db.Livros
               .Where(x => x.Nome.Contains(name))
               .ToList();
        }

        public bool Update(Livro livro)
        {
            try
            {
                _db.Entry<Livro>(livro).State = EntityState.Modified;
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