﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myGenericDBEFandWSMovies
{
    public interface IWebAPIAsync<T>
    {
        Task<List<T>> Load();
        Task Create(int key, T obj);
        Task<T> Read(int key);
        Task Update(int key, T obj);
        Task Delete(int key);
    }
}
