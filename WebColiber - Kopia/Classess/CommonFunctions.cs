using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Web.Services;
using System.Web.Script.Services;

namespace WebColiber
{
    public class CommonFunctions
    {
        public static bool WriteData(SqlCommand Command, ref SqlConnection Connection)
        {
            SqlTransaction Transaction = null;

            try
            {
                if (Connection.State != ConnectionState.Open)
                    Connection.Open();

                Transaction = Connection.BeginTransaction("Trans");

                Command.Connection = Connection;
                Command.Transaction = Transaction;

                Command.ExecuteNonQuery();

                Transaction.Commit();

                return true;
            }
            catch (SqlException Ex)
            {
                try
                {
                    if (Transaction != null)
                        Transaction.Rollback();
                }
                catch (Exception Ex2)
                {
                    //MessageBox.Show(Ex2.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                /*foreach (SqlError a in Ex.Errors)
                {
                    if (a.State.ToString() == "28000")
                    {
                        MessageBox.Show("Nie posiadasz uprawnień do łączenia się z bazą.", "Brak uprawnień",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                    else if (a.State.ToString() == "08001")
                    {
                        MessageBox.Show("Brak dostępu do serwera bazy danych.", "Brak dostępu", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        return false;
                    }
                }

                MessageBox.Show(Ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Information);*/
                return false;
            }
            catch (Exception Ex)
            {
                try
                {
                    if (Transaction != null)
                        Transaction.Rollback();
                }
                catch (Exception Ex2)
                {
                   // MessageBox.Show(Ex2.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                //MessageBox.Show(Ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return false;
            }

            return false;
        }
        
        public static bool WriteData(ref SqlCommand Command, ref SqlConnection Connection)
        {
            SqlTransaction Transaction = null;

            try
            {
                if (Connection.State != ConnectionState.Open)
                    Connection.Open();

                Transaction = Connection.BeginTransaction("Trans");

                Command.Connection = Connection;
                Command.Transaction = Transaction;

                Command.ExecuteNonQuery();

                Transaction.Commit();

                return true;
            }
            catch (SqlException Ex)
            {
                try
                {
                    if (Transaction != null)
                        Transaction.Rollback();
                }
                catch (Exception Ex2)
                {
                   // MessageBox.Show(Ex2.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                /*foreach (SqlError a in Ex.Errors)
                {
                    if (a.State.ToString() == "28000")
                    {
                        MessageBox.Show("Nie posiadasz uprawnień do łączenia się z bazą.", "Brak uprawnień", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                    else if (a.State.ToString() == "08001")
                    {
                        MessageBox.Show("Brak dostępu do serwera bazy danych.", "Brak dostępu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                }

                MessageBox.Show(Ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Information);*/
                return false;
            }
            catch (Exception Ex)
            {                
                try
                {
                    if (Transaction != null)
                        Transaction.Rollback();
                }
                catch (Exception Ex2)
                {
                    //MessageBox.Show(Ex2.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                //MessageBox.Show(Ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return false;
            }

            return false;
        }

        public static DataTable ReadData(SqlCommand Command, ref SqlConnection Connection)
        {
            DataTable Dt = new DataTable();
            SqlDataReader Reader = null;

            try
            {
                if (Connection.State != ConnectionState.Open)
                    Connection.Open();

                Command.Connection = Connection;

                Reader = Command.ExecuteReader();

                Dt.Load(Reader);

                Reader.Close();
            }
            catch (SqlException Ex)
            {
                throw;

                /*foreach (SqlError a in Ex.Errors)
                {
                    if (a.State.ToString() == "28000")
                    {
                        //MessageBox.Show("Nie posiadasz uprawnień do łączenia się z bazą.", "Brak uprawnień", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //return false;
                    }
                    else if (a.State.ToString() == "08001")
                    {
                        //MessageBox.Show("Brak dostępu do serwera bazy danych.", "Brak dostępu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //return false;
                    }
                }

                // MessageBox.Show(Ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 */
            }
            catch (Exception ex)
            {
                throw;
                // MessageBox.Show(ex.Message);
            }
            finally
            {
                if (Reader != null && Reader.IsClosed != true)
                    Reader.Close();
                Connection.Close();
            }

            return Dt;
        }
    }
}