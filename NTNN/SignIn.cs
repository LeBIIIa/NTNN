using GNS3_API.Helpers;

using log4net.Core;

using NTNN.Helpers;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NTNN
{
    public partial class SignIn : Form
    {

        public SignIn()
        {
            InitializeComponent();
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            var login = txtLogin.Text;
            var pass = txtPass.Text;
            var val = SearchUser(login, pass);
            if (val == true)
            {
                Form1 form = new Form1();
                this.Hide();
                form.ShowDialog();
                this.Close();
            }
            else if (val == false)
            {
                MessageBox.Show("Login or password is incorrect!");
            }
        }

        private bool? SearchUser(string login, string password)
        {
            try
            {
                SqlCommand sql = new SqlCommand("SELECT [Login], [Password] FROM Users WHERE [Login] = @Login");
                sql.Parameters.AddWithValue("@Login", login);
                using (var reader = DAL.DataAccess.ExecuteReader(sql, CommandBehavior.SingleRow | CommandBehavior.CloseConnection))
                {
                    if (reader.Read())
                    {
                        string userPass = ValidationHelper.GetString(reader["Password"], null);
                        if (userPass == password)
                            return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Internal error occur {ex.Message}");
                LoggingHelper.LogEntry(SystemCategories.GeneralError, $"{ex.Message} {ex.StackTrace}");
                return null;
            }
            return false;
        }
    }
}
