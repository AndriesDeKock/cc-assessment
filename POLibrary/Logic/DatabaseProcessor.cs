namespace POLibrary.Logic
{
    using POLibrary.Model;
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;

    /// <summary>
    /// Defines the <see cref="DatabaseProcessor" />
    /// </summary>
    public class DatabaseProcessor : SqlReader
    {
        /// <summary>
        /// Gets the DatabaseConnectionString
        /// </summary>
        public static string DatabaseConnectionString => "Data Source=ditto,1433;MultipleActiveResultSets=True;Initial Catalog=CC_PO;User ID=sa;Password=Access10";

        /// <summary>
        /// The RetrieveSuppliers
        /// </summary>
        /// <param name="SqlCmd">The SqlCmd<see cref="string"/></param>
        /// <returns>The <see cref="List{SupplierModel}"/></returns>
        public List<SupplierModel> RetrieveSuppliers(string SqlCmd)
        {

            var output = new List<SupplierModel>();

            using (SqlConnection conn = new SqlConnection(DatabaseConnectionString))
            {
                using (SqlCommand comm = new SqlCommand(SqlCmd, conn) { CommandType = System.Data.CommandType.StoredProcedure })
                {
                    try
                    {
                        conn.Open();

                        try
                        {
                            using (SqlDataReader reader = comm.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    var objValidateString = new ValidateReaderString();

                                    while (reader.Read())
                                    {
                                        output.Add(new SupplierModel()
                                        {
                                            Id = reader.GetInt32(0),
                                            Name = objValidateString.Validate(reader.GetValue(1)),
                                            Error = string.Empty
                                        });
                                    }
                                }
                                else
                                {
                                    output.Add(new SupplierModel()
                                    {
                                        Id = 0,
                                        Error = reader.GetString(0)
                                    });
                                }

                                return output;
                            }
                        }
                        catch (Exception ex)
                        {

                            output.Add(new SupplierModel()
                            {
                                Id = 0,
                                Error = ex.Message.ToString()
                            });

                            return output;
                        }
                    }
                    catch (Exception ex)
                    {

                        output.Add(new SupplierModel()
                        {
                            Id = 0,
                            Error = ex.Message.ToString()
                        });

                        return output;
                    }
                    finally
                    {
                        if (conn.State != System.Data.ConnectionState.Closed)
                        {
                            conn.Close();
                        }
                    }
                }
            }
        }

        public List<ProductModel> RetrieveProducts(string SqlCmd) {

            var output = new List<ProductModel>();

            using (SqlConnection conn = new SqlConnection(DatabaseConnectionString))
            {
                using (SqlCommand comm = new SqlCommand(SqlCmd, conn) { CommandType = System.Data.CommandType.StoredProcedure })
                {
                    try
                    {
                        conn.Open();

                        try
                        {
                            using (SqlDataReader reader = comm.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    var objValidateString = new ValidateReaderString();

                                    while (reader.Read())
                                    {
                                        output.Add(new ProductModel()
                                        {
                                            Id = reader.GetInt32(0),
                                            Description = objValidateString.Validate(reader.GetValue(1)),
                                            Code = objValidateString.Validate(reader.GetValue(2)),
                                            Amount = (double)reader.GetValue(3),
                                            SupplierId = reader.GetInt32(4),
                                            SupplierName =  objValidateString.Validate( reader.GetValue(5)),
                                            Error = string.Empty
                                        });
                                    }
                                }
                                else
                                {
                                    output.Add(new ProductModel()
                                    {
                                        Id = 0,
                                        Error = reader.GetString(0)
                                    });
                                }

                                return output;
                            }
                        }
                        catch (Exception ex)
                        {

                            output.Add(new ProductModel()
                            {
                                Id = 0,
                                Error = ex.Message.ToString()
                            });

                            return output;
                        }
                    }
                    catch (Exception ex)
                    {

                        output.Add(new ProductModel()
                        {
                            Id = 0,
                            Error = ex.Message.ToString()
                        });

                        return output;
                    }
                    finally
                    {
                        if (conn.State != System.Data.ConnectionState.Closed)
                        {
                            conn.Close();
                        }
                    }
                }
            }

        }
    }
}
