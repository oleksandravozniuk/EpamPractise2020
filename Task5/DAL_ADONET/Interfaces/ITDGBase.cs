﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DAL_ADONET.Interfaces
{
    public interface ITDGBase<T> where T : class
    {
        void Add(T value);
        void Update(T value);
        void Delete(int value);
        IEnumerable<T> GetAll();
        T GetById(int id);

    }
}
