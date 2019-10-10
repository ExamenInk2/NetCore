using SlnExamen.Beans;
using System;
using System.Collections.Generic;
using System.Text;

namespace SlnExamen.Domain
{
    public interface IDomainPersona
    {
        BeansResponse  InsPersonaDomain(BeansPersonaR oPersona);
        BeansKPI GetKPIDomain();
        IEnumerable<BeansPersona> GetListPersonaDomain();
    }
}
