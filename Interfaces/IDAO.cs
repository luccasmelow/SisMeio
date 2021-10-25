using System;
using System.Collections.Generic;
using System.Text;

namespace Sismeio.Interfaces
{

    /// <summary>
    /// Interface (contrato) para classe DAO
    /// </summary>
    /// < typeparam nam ="T"> </typeparam>
    interface IDAO<T>
    {
        void Insert(T t);

        void Update(T t);

        void Delet(T t);

        List<T> List();

        T GetById(int codigo);
    }
}