using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace WindowsFormsApp1 {
    public partial class Login : Form {
        string connection = @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=Vix;Integrated Security=True";
        bool novo;
        public Login() {
            InitializeComponent();
        }

        private void bt_log_Click(object sender, EventArgs e) {
            novo = true;
            //conexão
            if(novo) {
                string sql = "SELECT * FROM Usuario WHERE Descricao='" + user.Text + "'AND Senha='" + pwd.Text + "'";
                SqlConnection con = new SqlConnection(connection);
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                SqlDataReader reader;
                con.Open();
                try {
                    reader = cmd.ExecuteReader();
                    if(reader.Read()) {
                        MessageBox.Show("Indo para a página inicial!", "Bem vindo!");
                        user.Text = "";
                        pwd.Text = "";
                        Index index = new Index();
                        index.Show();
                    }
                    else {
                        user.Text = "";
                        pwd.Text = "";
                        MessageBox.Show("Digite suas credenciais novamente...","Cadastro Inválido!");
                    }
                }
                catch(Exception ex) {
                    MessageBox.Show("Erro" + ex.ToString());
                }
                finally {
                    con.Close();
                }
            }
        }

        private void bt_cancel_Click(object sender, EventArgs e) {
            user.Text = "";
            pwd.Text = "";
            user.Focus();
        }

        private void bt_exit_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void login_Load(object sender, EventArgs e)
        {

        }

        private void user_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

