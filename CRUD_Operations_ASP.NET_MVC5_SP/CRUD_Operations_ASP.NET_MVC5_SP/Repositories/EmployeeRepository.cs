using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CRUD_Operations.Models;

namespace CRUD_Operations.Repositories
{
    public class EmployeeRepository : ConnectionDataBase
    {
        public int RegisterEmployee(EmployeeModel EmployeeData)
        {
            int Result = -1;

            using (ConnectionSQL = new SqlConnection(ConnectionDB))
            {
                using (CmdSQL = new SqlCommand("RegisterEmployee", ConnectionSQL))
                {
                    CmdSQL.CommandType = CommandType.StoredProcedure;
                    CmdSQL.Parameters.Add("@Username", SqlDbType.NVarChar, 20).Value = EmployeeData.Username;
                    CmdSQL.Parameters.Add("@UserPassword", SqlDbType.NVarChar, 20).Value = EmployeeData.UserPassword;
                    CmdSQL.Parameters.Add("@EmployeeName", SqlDbType.NVarChar, 20).Value = EmployeeData.EmployeeName;
                    CmdSQL.Parameters.Add("@EmployeeFamilyName", SqlDbType.NVarChar, 40).Value = EmployeeData.EmployeeFamilyName;
                    CmdSQL.Parameters.Add("@DateOfBirth", SqlDbType.Date).Value = EmployeeData.DateOfBirth;
                    CmdSQL.Parameters.Add("@Age", SqlDbType.Int).Value = EmployeeData.Age;
                    CmdSQL.Parameters.Add("@EmailAddress", SqlDbType.NVarChar, 100).Value = EmployeeData.EmailAddress;
                    CmdSQL.Connection.Open();

                    Result = CmdSQL.ExecuteNonQuery();
                }
            }

        return Result;
        }

        public List<EmployeeModel> SearchEmployee()
        {
            List<EmployeeModel> Employees = new List<EmployeeModel>();

            using (ConnectionSQL = new SqlConnection(ConnectionDB))
            {
                using (CmdSQL = new SqlCommand("SearchEmployee", ConnectionSQL))
                {
                    CmdSQL.CommandType = CommandType.StoredProcedure;
                    CmdSQL.Connection.Open();
                    AdapterSQL = new SqlDataAdapter(CmdSQL);
                    TablesSQL = new DataTable();
                    AdapterSQL.Fill(TablesSQL);

                    ReaderSQL = CmdSQL.ExecuteReader();

                    while (ReaderSQL.Read())
                    {
                        EmployeeModel EmployeeData = new EmployeeModel
                        {
                            IdEmployee = (int)ReaderSQL["Id Employee"],
                            Username = ReaderSQL["Username"].ToString(),
                            UserPassword = ReaderSQL["User Password"].ToString(),
                            EmployeeName = ReaderSQL["Employee Name"].ToString(),
                            EmployeeFamilyName = ReaderSQL["Employee Family Name"].ToString(),
                            DateOfBirth = (DateTime)ReaderSQL["Date Of Birth"],
                            Age = (int)ReaderSQL["Age"],
                            EmailAddress = ReaderSQL["Email Address"].ToString()
                        };

                    Employees.Add(EmployeeData);
                    }
                }
            }

        return Employees;
        }

        public int UpdateEmployee(EmployeeModel EmployeeData)
        {
            int Result = -1;

            using (ConnectionSQL = new SqlConnection(ConnectionDB))
            {
                using (CmdSQL = new SqlCommand("UpdateEmployee", ConnectionSQL))
                {
                    CmdSQL.CommandType = CommandType.StoredProcedure;
                    CmdSQL.Parameters.Add("@IdEmployee", SqlDbType.Int).Value = EmployeeData.IdEmployee;
                    CmdSQL.Parameters.Add("@Username", SqlDbType.NVarChar, 20).Value = EmployeeData.Username;
                    CmdSQL.Parameters.Add("@UserPassword", SqlDbType.NVarChar, 20).Value = EmployeeData.UserPassword;
                    CmdSQL.Parameters.Add("@EmailAddress", SqlDbType.NVarChar, 100).Value = EmployeeData.EmailAddress;
                    CmdSQL.Connection.Open();

                    Result = CmdSQL.ExecuteNonQuery();
                }
            }

        return Result;
        }

        public int DeleteEmployee(int IdEmployee)
        {
            int Result = -1;

            using (ConnectionSQL = new SqlConnection(ConnectionDB))
            {
                using (CmdSQL = new SqlCommand("DeleteEmployee", ConnectionSQL))
                {
                    CmdSQL.CommandType = CommandType.StoredProcedure;
                    CmdSQL.Parameters.Add("@IdEmployee", SqlDbType.Int).Value = IdEmployee;
                    CmdSQL.Connection.Open();

                    Result = CmdSQL.ExecuteNonQuery();
                }
            }

        return Result;
        }
    }
}