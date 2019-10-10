using SlnExamen.Beans;
using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data;
using Dapper;
using System.Globalization;

namespace SlnExamen.Repository
{
    public class RepositoryPersona : IRepositoryPersona
    {
        protected readonly string _connectionString;
        public RepositoryPersona(string connectionString)
        {
            _connectionString = connectionString;
        }

        public BeansResponse UpdPersonaResponse(BeansPersonaR oPersona , int nId)
        {
            string[] dteFecha = oPersona.FechaNacimiento.ToShortDateString().Split('/');

            BeansResponse oResponse = new BeansResponse();
            try
            {
                using (var connection = new MySql.Data.MySqlClient.MySqlConnection(_connectionString))
                {
                    var parameter = new DynamicParameters();
                    connection.Open();
                    try
                    {
                        //parameter.Add("@Nombres", oPersona.Nombres);
                        //parameter.Add("@Apellido", oPersona.Apellidos);
                        //parameter.Add("@Edad", oPersona.Edad);
                        //parameter.Add("@FechaNacimiento", oPersona.FechaNacimiento);

                        string sql = "update Personas set  nEdad =@Edad , dteFechaNacimiento =@FechaNacimiento where nId=@nId";
                        sql = sql.Replace("@nId", nId.ToString()).Replace("@Apellido", '"' + oPersona.Apellidos + '"').Replace("@Edad", oPersona.Edad.ToString()).Replace("@FechaNacimiento", '"' + dteFecha[2] + "-" + dteFecha[1] + "-" + dteFecha[0] + '"');
                          
                        //var data = connection.Query<BeansPersona>("examen.InsPersona", param: parameter, commandType: System.Data.CommandType.StoredProcedure);
                        var data = connection.Query<BeansPersona>(sql, commandType: System.Data.CommandType.Text);
                        oResponse.bStatus = true;
                        oResponse.vResponse = "Se actualizo correctamente";
                    }
                    catch (Exception ex)
                    {
                        oResponse.bStatus = false;
                        oResponse.vResponse = "No se pudo actualizar";
                        throw ex;
                    }
                    finally
                    {
                        connection.Dispose();
                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return oResponse;
        }

        public  BeansResponse InsPersonaResponse(BeansPersonaR oPersona)
        {
            string[] dteFecha = oPersona.FechaNacimiento.ToShortDateString().Split('/');

            BeansResponse oResponse = new BeansResponse();
            try
            {
                using (var connection = new MySql.Data.MySqlClient.MySqlConnection(_connectionString))
                {
                    var parameter = new DynamicParameters();
                    connection.Open();
                    try
                    {
                        //parameter.Add("@Nombres", oPersona.Nombres);
                        //parameter.Add("@Apellido", oPersona.Apellidos);
                        //parameter.Add("@Edad", oPersona.Edad);
                        //parameter.Add("@FechaNacimiento", oPersona.FechaNacimiento);

                        string sql = "Insert into Personas (vNombres  , vApellidos  , nEdad  , dteFechaNacimiento ) values(@Nombres,@Apellido,@Edad,@FechaNacimiento)";
                        sql = sql.Replace("@Nombres", '"'+oPersona.Nombres + '"').Replace("@Apellido", '"' + oPersona.Apellidos + '"').Replace("@Edad", oPersona.Edad.ToString()).Replace("@FechaNacimiento", '"' + dteFecha[2]+"-"+ dteFecha[1]+"-"+ dteFecha[0] + '"');
                        //var data = connection.Query<BeansPersona>("examen.InsPersona", param: parameter, commandType: System.Data.CommandType.StoredProcedure);
                        var data = connection.Query<BeansPersona>(sql, commandType: System.Data.CommandType.Text);
                        oResponse.bStatus = true;
                        oResponse.vResponse = "Se registro correctamente";
                    }
                    catch (Exception ex)
                    {
                        oResponse.bStatus = false;
                        oResponse.vResponse = "No se pudo registrar";
                        throw ex;
                    }
                    finally
                    {
                        connection.Dispose();
                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return oResponse;
        }
        public IEnumerable<BeansPersona> GetListPersonaRepository()
        {
            IEnumerable<BeansPersona> oData= null;
            using (var connection = new MySql.Data.MySqlClient.MySqlConnection(_connectionString))
            {
                
                connection.Open();
                try
                {
                    //oData = connection.Query<BeansPersona>("ppanana.mysql.database.azure.com.examen.SP_GetPersona", commandType: System.Data.CommandType.StoredProcedure);
                    oData = connection.Query<BeansPersona>("SELECT nId ID , vNombres Nombres , vApellidos Apellidos , nEdad Edad , dteFechaNacimiento FechaNacimiento FROM personas", System.Data.CommandType.Text);
                }
                catch (Exception ex)
                {

                    throw ex;
                }
                finally
                {
                    connection.Dispose();
                    connection.Close();
                }
            }

            return oData;
        }
    }
}
