using System;
using System.Collections.Generic;
using System.Text;
using SlnExamen.Beans;

namespace SlnExamen.Repository
{
    public interface IRepositoryPersona
    {
        BeansResponse UpdPersonaResponse(BeansPersonaR oPersona, int nId);
        IEnumerable<BeansPersona> GetListPersonaRepository();
        BeansResponse InsPersonaResponse(BeansPersonaR oPersona);
    }
}
