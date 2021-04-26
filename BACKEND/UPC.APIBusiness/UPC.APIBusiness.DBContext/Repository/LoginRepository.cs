using Dapper;
using DBEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DBContext
{
    public class LoginRepository : BaseRepository, ILoginRepository
    {
        public ResponseBase GetLogin(EntityLogin login)
        {
            var returnEntity = new ResponseBase();
            var loginResponse = new EntityLoginResponse();

            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = @"sp_Validar_Login";
                    var p = new DynamicParameters();
                    p.Add(name: "@NOMBREUSUARIO", value: login.nombreusuario, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@CONTRASENIA", value: login.contrasenia, dbType: DbType.String, direction: ParameterDirection.Input);

                    loginResponse = db.Query<EntityLoginResponse>(sql, param: p, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }

                if(loginResponse != null)
                {
                    returnEntity.issucess = true;
                    returnEntity.errorcode = "0000";
                    returnEntity.errormessage = string.Empty;
                    returnEntity.data = loginResponse;
                }
                else
                {
                    returnEntity.issucess = false;
                    returnEntity.errorcode = "0000";
                    returnEntity.errormessage = string.Empty;
                    returnEntity.data = null;
                }
            }
            catch(Exception ex)
            {
                returnEntity.issucess = false;
                returnEntity.errorcode = "0001";
                returnEntity.errormessage = ex.Message;
                returnEntity.data = null;
            }

            return returnEntity;
        }
    }
}
