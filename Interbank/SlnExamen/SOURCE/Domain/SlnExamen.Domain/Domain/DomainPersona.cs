using System;
using System.Collections.Generic;
using System.Text;
using SlnExamen.Repository;
using SlnExamen.Beans;
using System.Linq;

namespace SlnExamen.Domain
{
    public class DomainPersona: IDomainPersona
    {
        public IRepositoryPersona _oData { get; private set; }
        public DomainPersona(string connectionString)
        {
            _oData = new RepositoryPersona(connectionString);
        }
        public BeansResponse InsPersonaDomain(BeansPersonaR oPersona)
        {
            BeansPersona oPerson = new BeansPersona();
            BeansResponse oData = new BeansResponse();
            oData.bStatus = true;oData.vResponse = "La información registrada ya existe";
            IEnumerable<BeansPersona> oListPersona = _oData.GetListPersonaRepository();

            int nExiste = oListPersona.Where(p =>p.Nombres.TrimEnd().ToUpper() ==oPersona.Nombres.TrimEnd().ToUpper() && p.Apellidos.TrimEnd().ToUpper() == oPersona.Apellidos.TrimEnd().ToUpper()).Count();
            if (nExiste == 0)
                return _oData.InsPersonaResponse(oPersona);
            else
                
               oPerson = oListPersona.Where(p => p.Nombres.TrimEnd().ToUpper() == oPersona.Nombres.TrimEnd().ToUpper() && p.Apellidos.TrimEnd().ToUpper() == oPersona.Apellidos.TrimEnd().ToUpper()).First();
                return _oData.UpdPersonaResponse(oPersona, oPerson.Id);
        }

        public BeansKPI GetKPIDomain()
        {
            BeansKPI oDataResponse = new BeansKPI();
            IEnumerable<BeansPersona> oData = _oData.GetListPersonaRepository();

             decimal nTotal = 0; decimal nSuma = 0; decimal dPromedio = 0;
            try
            {
                nTotal = oData.Count();
                nSuma = oData.Where(p => p.Edad > 0).Sum(p => p.Edad);               
                dPromedio = (nSuma/nTotal) ;
                oDataResponse.DesviacionStandar = CalcularVarianza(oData, nTotal, dPromedio);
                oDataResponse.Promedio = dPromedio;
            }
            catch (Exception)
            {

                throw;
            }

            return oDataResponse;
        }
        //public static int ToAgeString(this DateTime dob)
        //{
        //    DateTime today = DateTime.Today;

        //    int months = today.Month - dob.Month;
        //    int years = today.Year - dob.Year;

        //    if (today.Day < dob.Day)
        //    {
        //        months--;
        //    }

        //    if (months < 0)
        //    {
        //        years--;
        //        months += 12;
        //    }

        //    int days = (today - dob.AddMonths((years * 12) + months)).Days;

        //    return days;
        //}
        private decimal CalcularVarianza(IEnumerable<BeansPersona> data , decimal nTotal , decimal dcPromedio)
        {
             double nSumatoria = 0; double nResultado = 0;
            try
            {
                foreach (var iten in data)
                {
                    double nResto = 0; double nCalcular = 0;
                    nCalcular =Convert.ToDouble(iten.Edad - dcPromedio);
                    nResto = Math.Pow(nCalcular, 2);
                    nSumatoria += nResto;
                }

                nResultado = Math.Sqrt(nSumatoria / Convert.ToDouble(nTotal));
            }
            catch (Exception)
            {

                nResultado = 0;
            }
            return Convert.ToDecimal(nResultado);
        }

        public IEnumerable<BeansPersona> GetListPersonaDomain()
        {
            return _oData.GetListPersonaRepository();
        }

    }
}
