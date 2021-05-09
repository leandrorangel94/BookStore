using BookStore.Domain;
using System;
using System.Collections.Generic;

namespace BookStore.Repositories.Contracts
{
    public interface IBookRepository : IDisposable
    {
        List<Livro> Get();
        Livro Get(int id);
        List<Livro> GetByName(string name);
        bool Create(Livro livro);
        bool Update(Livro livro);
        void Delete(int id);
    }
}