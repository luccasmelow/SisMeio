using System;
using System.Collections.Generic;
using System.Text;
using Sismeio.Base;

namespace Sismeio.Models
{
    class AbstractDAO<T>
    {
        protected Conexao conn = new Conexao();

        public virtual void Delete(T t)
        {
            throw new NotImplementedException();
        }

        public virtual T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public virtual void Insert(T t)
        {
            throw new NotImplementedException();
        }

        public virtual List<T> List()
        {
            throw new NotImplementedException();
        }

        public virtual void Update(T t)
        {
            throw new NotImplementedException();
        }
    }
}
