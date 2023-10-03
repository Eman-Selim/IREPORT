using System;
using SC3_Alarm_Module.Entity;
using System.Data;
using SC3_Alarm_Module.DAL;
using SC3_Alarm_Module_WS.Code_Files.DBL;

namespace SC3_Alarm_Module.CBL
{
    public class CHK
    {

        #region Check Method 

        /// <summary>
        /// Method Used To Check If The User Is Authorized As An Admin Or Not.
        /// </summary>
        /// <param name="_user"></param>
        /// <returns></returns>
        public bool check_authority( string username, string password)
        {
            
            try
            {
                DBL db = new DBL();

                string[,] us =
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