namespace POLibrary.Logic
{
    using System;
    using System.Data.SqlClient;

    /// <summary>
    /// Defines the <see cref="SqlReader" />
    /// </summary>
    public class SqlReader
    {
        /// <summary>
        /// The Process
        /// </summary>
        /// <param name="SqlCmd">The SqlCmd<see cref="string"/></param>
        /// <param name="param">The param<see cref="object[,]"/></param>
        /// <param name="conn">The conn<see cref="SqlConnection"/></param>
        /// <returns>The <see cref="SqlDataReader"/></returns>
        public SqlDataReader Process(string SqlCmd, object[,] param, SqlConnection conn)
        {
            SqlCommand comm = new SqlCommand(SqlCmd, conn) { CommandType = System.Data.CommandType.StoredProcedure };

            if (param != null)
            {
                for (int i = 0; i <= param.GetUpperBound(0); i++)
                {
                    comm.Parameters.AddWithValue(param[i, 0].ToString(), param[i, 1]);
                }
            }

            try
            {
                conn.Open();
                return comm.ExecuteReader();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}