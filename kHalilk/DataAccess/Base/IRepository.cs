﻿using Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Base
{
    public interface IRepository<T> where T : IEntity
    {
        T Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        T Get(Predicate<T> filter = null);
        List<T> GetAll(Predicate<T> filter = null);
    }
}
