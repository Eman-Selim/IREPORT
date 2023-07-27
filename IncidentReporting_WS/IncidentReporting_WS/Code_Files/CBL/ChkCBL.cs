using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace IncidentReporting_WS.Code_Files.CBL
{
    public class ChkCBL
    {
        #region Check Method 

        /// <summary>
        /// Method Used To Check If The User Is Authorized As An Admin Or Not.
        /// </summary>
        /// <param name="_user"></param>
        /// <returns></returns>
        public bool check_authority(string username, string password)
        {

            try
            {
                DBL.DBL db = new DBL.DBL();

                object[,] us =
                {
                {"@username",username},
                {"@password",password}
                };

                DataTable dt = db.Execute_Stored_Procedure_Show_Values("Users_Select", us);

                if (dt.Rows.Count.Equals(0))
                {
                    return false;

                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion 
    }
}