using Dapper;
using DBEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DBContext
{
    public class ProyectoRepository : BaseRepository, IProyectosRepository
    {
        public ResponseBase GetProyectos()
        {
            var  returnEntity = new ResponseBase();
            var listProyectos = new List<EntityProyectos>();

            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = @"sp_Listar_Proyectos";

                   listProyectos = db.Query<EntityProyectos>(sql, commandType: CommandType.StoredProcedure).ToList();

                   if(listProyectos.Count > 0)
                   {
                        returnEntity.issucess = true;
                        returnEntity.errorcode = "0000";
                        returnEntity.errormessage = string.Empty;
                        returnEntity.data = listProyectos;
                    }
                    else
                    {
                        returnEntity.issucess = false;
                        returnEntity.errorcode = "0000";
                        returnEntity.errormessage = string.Empty;
                        returnEntity.data = null;
                    }
                }
            }
            catch(Exception ex)
            {
                returnEntity.issucess = false;
                returnEntity.errorcode = "0000";
                returnEntity.errormessage = ex.Message;
                returnEntity.data = null;
            }

            return returnEntity;
        }
    }
}
