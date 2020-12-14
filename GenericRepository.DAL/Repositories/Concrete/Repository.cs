﻿using GenericRepository.DAL.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepository.DAL.Repositories.Concrete
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected DbContext _context;
        private DbSet<T> _dbSet;
        public Repository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Remove(int id)
        {
            _dbSet.Remove(GetById(id));
        }
    }
}
