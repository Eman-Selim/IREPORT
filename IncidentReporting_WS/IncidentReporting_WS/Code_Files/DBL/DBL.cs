using System.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using System.Text.RegularExpressions;
using System.Configuration;

namespace IncidentReporting_WS.Code_Files.DBL
{
    public class DBL
    {
        #region Sql Con.
        SqlConnection sqlServerConnection;

        public DBL()
        {
            sqlServerConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString);
        }

        public DBL(string database_Name)
        {
            string SDS_Remote_DB_Conn_Str = ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString;
            string[] SDS_Remote_DB_Conn_Str_Parts = SDS_Remote_DB_Conn_Str.Split(';');
            string SDS_Remote_DB_Conn_Str_New = "";

            for (int i = 0; i < SDS_Remote_DB_Conn_Str_Parts.Length; i++)
            {
                if (i != 1)
                {
                    SDS_Remote_DB_Conn_Str_New += SDS_Remote_DB_Conn_Str_Parts[i] + "; ";
                }
                else
                {
                    SDS_Remote_DB_Conn_Str_New += "Database=" + database_Name + "; ";
                }
            }
            sqlServerConnection = new SqlConnection(SDS_Remote_DB_Conn_Str_New);
        }

        #endregion

        #region Query/Non-Query Methods

        /// <summary>
        /// Used to Execute NonQuery SQL-Statements Like "Insert","Update","Delete" ,Where command is the Query statement.
        /// </summary>
        /// <param name="command">
        /// is for SQL Query Command.
        /// </param>
        /// <param name="parms">
        /// is an array holds Parameters
        /// </param>
        /// <returns></returns>
        public bool Execute_NonQuery_Method(string command, object[,] parms)
        {
            try
            {
                bool flag = false;

                if (command == null)
                {
                    Exception e = new Exception("Can't accept a null command , Please write a correct query.");
                    throw e;
                }

                if (sqlServerConnection.State == ConnectionState.Closed)
                {
                    sqlServerConnection.Open();
                }

                if (Check_Params_Regax(command, parms) == true)
                {
                    SqlCommand ExecNonQuery = new SqlCommand(command, sqlServerConnection);
                    ExecNonQuery.CommandType = CommandType.Text;

                    for (int i = 0; i < parms.Length - (parms.Length / 2); i++)
                    {
                        ExecNonQuery.Parameters.AddWithValue(parms[i, 0].ToString(), parms[i, 1] == null ? DBNull.Value : (object)parms[i, 1]);
                    }

                    flag = ExecNonQuery.ExecuteNonQuery() > 0 ? true : false;
                    return flag;
                }
                else
                {
                    Exception e = new Exception("Please write enough parameters.");
                    throw e;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (sqlServerConnection.State == ConnectionState.Open)
                {
                    sqlServerConnection.Close();
                }
            }
        }

        public bool Execute_NonQuery_Method(string command)
        {
            try
            {
                bool flag = false;

                if (command == null)
                {
                    Exception e = new Exception("Can't accept a null command , Please write a correct query.");
                    throw e;
                }

                if (sqlServerConnection.State == ConnectionState.Closed)
                {
                    sqlServerConnection.Open();
                }

                SqlCommand ExecNonQuery = new SqlCommand(command, sqlServerConnection);

                flag = ExecNonQuery.ExecuteNonQuery() > 0 ? true : false;
                return flag;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                //if (sqlServerConnection.State == ConnectionState.Open)
                //{
                //    sqlServerConnection.Close();
                //}
            }
        }


        /// <summary>
        /// Execute Query Method used to show stored values returned from database in a datatable through SQL-Queries Like "Select".
        /// </summary>
        /// <param name="command">
        /// is for Query Sql command.
        /// </param>
        /// <param name="parms">
        /// is an array which holds Parameters.
        /// </param>
        /// <returns></returns>
        public DataTable Execute_Query_Show_Values(string command, object[,] parms)
        {
            try
            {
                DataTable result;

                if (command == null)
                {
                    Exception e = new Exception("Can't accept a null command , Please write a correct info.");
                    throw e;
                }

                if (sqlServerConnection.State == ConnectionState.Closed)
                {
                    sqlServerConnection.Open();
                }

                if (parms != null)
                {
                    if (Check_Params_Regax(command, parms) == true)
                    {
                        SqlCommand cmd = new SqlCommand(command, sqlServerConnection);
                        cmd.CommandType = CommandType.Text;

                        for (int i = 0; i < parms.Length - (parms.Length / 2); i++)
                        {
                            cmd.Parameters.AddWithValue(parms[i, 0].ToString(), parms[i, 1] == null ? DBNull.Value : (object)parms[i, 1]);
                        }

                        SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                        result = new DataTable();

                        adapt.Fill(result);
                        return result;
                    }
                    else
                    {
                        Exception e = new Exception("Please write enough parameters.");
                        throw e;
                    }
                }
                else
                {
                    SqlCommand cmd = new SqlCommand(command, sqlServerConnection);
                    SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                    result = new DataTable();

                    adapt.Fill(result);
                    return result;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (sqlServerConnection.State == ConnectionState.Open)
                {
                    sqlServerConnection.Close();
                }
            }
        }


        /// <summary>
        /// Execute one cell through a Sql-Query Statement.
        /// </summary>
        /// <param name="command">
        /// is for Sql Query command.
        /// </param>
        /// <param name="parms">
        /// is an array which holds parameters.
        /// </param>
        /// <returns></returns>
        public object Execute_Query_OneCell(string command, object[,] parms)
        {
            try
            {
                DataTable dt;
                object result = null;

                if (command == null)
                {
                    Exception e = new Exception("Can't accept a null command , Please write a correct info.");
                    throw e;
                }

                if (sqlServerConnection.State == ConnectionState.Closed)
                {
                    sqlServerConnection.Open();
                }

                if (parms != null)
                {
                    if (Check_Params(command, parms) == true)
                    {
                        SqlCommand cmd;
                        SqlDataAdapter adapt;
                        dt = new DataTable();
                        cmd = new SqlCommand(command, sqlServerConnection);
                        cmd.CommandType = CommandType.Text;
                        for (int i = 0; i < parms.Length - (parms.Length / 2); i++)
                        {
                            cmd.Parameters.AddWithValue(parms[i, 0].ToString(), parms[i, 1] == null ? DBNull.Value : (object)parms[i, 1]);
                        }
                        adapt = new SqlDataAdapter(cmd);
                        adapt.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            result = dt.Rows[0][0];
                        }
                    }
                    else
                    {
                        Exception e = new Exception("Please write enough parameters.");
                        throw e;
                    }
                }
                else
                {
                    SqlCommand cmd;
                    SqlDataAdapter adapt;
                    dt = new DataTable();
                    cmd = new SqlCommand(command, sqlServerConnection);

                    adapt = new SqlDataAdapter(cmd);
                    adapt.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        result = dt.Rows[0][0];
                    }
                }
                return result;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (sqlServerConnection.State == ConnectionState.Open)
                {
                    sqlServerConnection.Close();
                }
            }
        }

        #endregion

        #region Stored Procedure Methods

        /// <summary>
        /// Used to Execute Stored Procedure Query Statement With additional Parameters stored in array.
        /// </summary>
        /// <param name="Stored_Procedure">
        /// is for the Stored Procedure Text
        /// </param>
        /// <param name="parms">
        /// is for the parameters should be added in an array
        /// </param>
        public bool Execute_Update_Delete_Stored_Procedure(string Stored_Procedure, object[,] parms)
        {
            try
            {
                bool flag = false;

                if (Stored_Procedure == null)
                {
                    Exception e = new Exception("Can't accept null , Please write a correct info.");
                    throw e;
                }

                if (sqlServerConnection.State == ConnectionState.Closed)
                {
                    sqlServerConnection.Open();
                }

                if (Check_Parms_StP(Stored_Procedure, parms) == true)
                {
                    SqlCommand sqlCmd = new SqlCommand(Stored_Procedure, sqlServerConnection);
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    for (int i = 0; i < parms.Length - (parms.Length / 2); i++)
                    {
                        object obj = new object();
                        if (parms[i, 1] == null || parms[i, 1].ToString() == "" || parms[i, 1].ToString() == "0")
                        {
                            obj = DBNull.Value;
                        }
                        else
                        {
                            obj = (object)parms[i, 1];
                        }

                        sqlCmd.Parameters.AddWithValue(parms[i, 0].ToString(), obj);
                    }
                    int k = sqlCmd.ExecuteNonQuery();

                    flag = k > 0 ? true : false;

                    return flag;
                }
                else
                {
                    Exception e = new Exception("Please write enough parameters.");
                    throw e;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (sqlServerConnection.State == ConnectionState.Open)
                {
                    sqlServerConnection.Close();
                }
            }
        }


        /// <summary>
        /// Used to Execute Stored Procedure Query Statement With additional Parameters stored in array.
        /// </summary>
        /// <param name="Stored_Procedure">
        /// is for the Stored Procedure Text
        /// </param>
        /// <param name="parms">
        /// is for the parameters should be added in an array
        /// </param>
        public int Execute_Insert_Stored_Procedure(string Stored_Procedure, object[,] parms)
        {
            try
            {
                if (Stored_Procedure == null)
                {
                    Exception e = new Exception("Can't accept null , Please write a correct info.");
                    throw e;
                }

                if (sqlServerConnection.State == ConnectionState.Closed)
                {
                    sqlServerConnection.Open();
                }

                if (Check_Parms_StP(Stored_Procedure, parms) == true)
                {
                    SqlCommand sqlCmd = new SqlCommand(Stored_Procedure, sqlServerConnection);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    for (int i = 0; i < parms.Length - (parms.Length / 2); i++)
                    {
                        object obj = new object();
                        if (parms[i, 1] == null || parms[i, 1].ToString() == "" || parms[i, 1].ToString() == "0")
                        {
                            obj = DBNull.Value;
                        }
                        else
                        {
                            obj = (object)parms[i, 1];
                        }
                        sqlCmd.Parameters.AddWithValue(parms[i, 0].ToString(), obj);
                    }
                    int id = int.Parse(sqlCmd.ExecuteScalar().ToString());

                    return id;
                }
                else
                {
                    Exception e = new Exception("Please write enough parameters.");
                    throw e;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (sqlServerConnection.State == ConnectionState.Open)
                {
                    sqlServerConnection.Close();
                }
            }
        }


        /// <summary>
        /// Used to execute Stored Procedure command with paramaters and Store values from a data source in dataTable 
        /// </summary>
        /// <param name="command">
        /// is the text query
        /// </param>
        /// <param name="parms">
        /// is the array where the parameters should be added 
        /// </param>
        /// <returns></returns>
        public DataTable Execute_Stored_Procedure_Show_Values(string Stored_Procedure, object[,] parms)
        {

            try
            {
                DataTable result;

                if (Stored_Procedure == null)
                {
                    Exception e = new Exception("Can't accept a null command , Please write a correct info.");
                    throw e;
                }

                if (sqlServerConnection.State == ConnectionState.Closed)
                {
                    sqlServerConnection.Open();
                }

                if (Check_Parms_StP(Stored_Procedure, parms) == true)
                {
                    SqlCommand cmd = new SqlCommand(Stored_Procedure, sqlServerConnection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    for (int i = 0; i < parms.Length - (parms.Length / 2); i++)
                    {
                        cmd.Parameters.AddWithValue(parms[i, 0].ToString(), parms[i, 1] == null ? DBNull.Value : (object)parms[i, 1]);
                    }

                    SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                    result = new DataTable();
                    adapt.Fill(result);

                    return result;
                }
                else
                {
                    Exception e = new Exception("Please write enough parameters.");
                    throw e;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (sqlServerConnection.State == ConnectionState.Open)
                {
                    sqlServerConnection.Close();
                }
            }
        }


        /// <summary>
        /// Execute one cell through a Stored Procedure Statement with additional parameters in array.
        /// </summary>
        /// <param name="command">
        /// is for the query text
        /// </param>
        /// <param name="parms">
        /// is an array to put inside it parameters that should be added.
        /// </param>
        /// <returns></returns>
        public object Execute_Stored_Procedure_OneCell(string Stored_Procedure, object[,] parms)
        {
            try
            {
                object result = null;

                if (Stored_Procedure == null)
                {
                    Exception e = new Exception("Can't accept a null command , Please write a correct info.");
                    throw e;
                }

                if (sqlServerConnection.State == ConnectionState.Closed)
                {
                    sqlServerConnection.Open();
                }

                if (Check_Parms_StP(Stored_Procedure, parms) == true)
                {
                    SqlCommand cmd;
                    SqlDataAdapter da;
                    DataTable dt = new DataTable();

                    cmd = new SqlCommand(Stored_Procedure, sqlServerConnection);

                    cmd.CommandType = CommandType.StoredProcedure;

                    for (int i = 0; i < parms.Length - (parms.Length / 2); i++)
                    {
                        cmd.Parameters.AddWithValue(parms[i, 0].ToString(), parms[i, 1] == null ? DBNull.Value : (object)parms[i, 1]);
                    }

                    da = new SqlDataAdapter(cmd);
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        result = dt.Rows[0][0];
                    }

                    return result;
                }
                else
                {
                    Exception e = new Exception("Please write enough parameters.");
                    throw e;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (sqlServerConnection.State == ConnectionState.Open)
                {
                    sqlServerConnection.Close();
                }
            }
        }

        #endregion

        #region Check parameters normal method

        /// <summary>
        /// Method Used to Check for SQL parameters of the SQL command.
        /// </summary>
        /// <param name="command">
        /// is the SQL command.
        /// </param>
        /// <param name="parms">
        /// array of parameters.
        /// </param>
        /// <returns></returns>

        public bool Check_Params(string command, object[,] parms)
        {
            try
            {
                bool flag = false;
                ArrayList L1 = new ArrayList();

                foreach (var element in parms)
                {
                    if (element.ToString().StartsWith("@"))
                    {
                        L1.Add(element.ToString().Substring(1).ToLower());
                    }
                }

                ArrayList L2 = new ArrayList();
                ArrayList L3 = new ArrayList();


                if (command[0] == 'i' || command[0] == 'I')
                {
                    if (command.Contains("("))
                    {
                        command = command.Replace("(", null);

                    }
                    if (command.Contains(')'))
                    {
                        command = command.Replace(")", null);
                        string[] words2 = command.Split('=', ' ', ',');
                        foreach (var word in words2)
                        {
                            if (word.StartsWith("@"))
                            {
                                L2.Add(word.Substring(1).ToLower());
                            }
                        }
                        if (L2.ToArray().SequenceEqual(L1.ToArray()))
                        {
                            flag = true;
                            return flag;
                        }
                        else
                        {

                            return flag;
                        }
                    }

                }
                else
                {
                    string[] words = command.Split('=', ' ');
                    foreach (var word in words)
                    {
                        if (word.StartsWith("@"))
                        {
                            L3.Add(word.Substring(1).ToLower());
                        }
                    }
                    if (L3.ToArray().SequenceEqual(L1.ToArray()))
                    {

                        flag = true;
                        return flag;
                    }
                    else
                    {
                        return flag;
                    }

                }
                return flag;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        #endregion

        #region Check parameters ReGx Method

        /// <summary>
        /// Method Used to Check Parameters by using Regular Expression.
        /// </summary>
        /// <param name="command">
        /// is for SQL command.
        /// </param>
        /// <param name="parms">
        /// array of parameters.
        /// </param>
        /// <returns></returns>

        public bool Check_Params_Regax(string command, object[,] parms)
        {
            try
            {
                bool flag = false;
                ArrayList l1 = new ArrayList();
                ArrayList l2 = new ArrayList();
                List<string> words = new List<string>();
                try
                {
                    words = Regex.Matches(command, @"\@\w+").Cast<Match>().Select(m => m.Value).ToList();
                }
                catch (Exception e)
                {
                    throw e;
                }
                foreach (var word in words)
                {
                    if (word[0] == '@')
                    {
                        l1.Add(word.Substring(1).ToLower());
                    }
                }

                try
                {
                    foreach (var element in parms)
                    {
                        if (element.ToString()[0] == '@')
                        {
                            l2.Add(element.ToString().Substring(1).ToLower());
                        }
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
                if (l1.ToArray().SequenceEqual(l2.ToArray()))
                {
                    flag = true;
                    return flag;
                }
                else
                {
                    return flag;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        #endregion

        #region check parameters Stored procedure

        /// <summary>
        /// Used to check parameters of the Stored Procedure.
        /// </summary>
        /// <param name="Stored_Pro"></param>
        /// <param name="parms"></param>
        /// <returns></returns>

        public bool Check_Parms_StP(string Stored_Pro, object[,] parms)
        {
            try
            {
                bool flag = false;
                ArrayList L1 = new ArrayList();
                ArrayList L2 = new ArrayList();

                SqlCommand cmd = new SqlCommand(Stored_Pro, sqlServerConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlCommandBuilder.DeriveParameters(cmd);
                if (cmd.Parameters.Contains("@RETURN_VALUE"))
                {
                    cmd.Parameters.RemoveAt("@RETURN_VALUE");
                }
                foreach (SqlParameter p in cmd.Parameters)
                {
                    L1.Add(p.ParameterName.Substring(1).ToLower());

                }

                for (int i = 0; i < parms.GetLength(0); i++)
                {
                    if (parms[i, 1] == null)
                    {
                        parms[i, 1] = DBNull.Value.ToString();
                    }
                }

                for (int i = 0; i < parms.GetLength(0); i++)
                {
                    if (parms[i, 0].ToString().StartsWith("@"))
                    {
                        L2.Add(parms[i, 0].ToString().Substring(1).ToLower());
                    }
                }

                //return true;
                object[] X = L2.ToArray();
                if (L1.ToArray().SequenceEqual(L2.ToArray()))
                {
                    flag = true;
                    return flag;
                }
                else
                {
                    return flag;
                }

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        #endregion
    }
}