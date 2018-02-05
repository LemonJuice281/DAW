using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW.Repository
{
    interface IRepository
    {
        T PostObject<T>(T item) where T : class;
        T PutObject<T>(T item) where T : class;
        T DeleteObject<T>(T item) where T : class;
        List<T> GetObjects<T>() where T : class;
    }
}
