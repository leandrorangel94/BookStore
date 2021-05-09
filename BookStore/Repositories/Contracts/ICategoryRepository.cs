using BookStore.Domain;
using System;
using System.Collections.Generic;

namespace BookStore.Repositories.Contracts
{
    public interface ICategoryRepository : IDisposable
    {
        List<Categoria> Get();
        Categoria Get(int id);
        List<Categoria> GetByName(string name);
        bool Create(Categoria categoria);
        bool Update(Categoria categoria);
        void Delete(int id);
    }
}