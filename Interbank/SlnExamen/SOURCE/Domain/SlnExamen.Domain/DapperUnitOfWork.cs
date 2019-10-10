using System;
using System.Collections.Generic;
using System.Text;

namespace SlnExamen.Domain
{
    public class DapperUnitOfWork : IUnitOfWork
    {
        public DapperUnitOfWork(string CadenaConexion)
        {
            PersonaDomain = new DomainPersona(CadenaConexion);
        }

        public IDomainPersona PersonaDomain { get; private set; }
    }
}
