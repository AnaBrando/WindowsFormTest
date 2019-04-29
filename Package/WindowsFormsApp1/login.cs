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
    public partial class login : Form {
        string connection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Aluno\Desktop\Anaex\WindowsFormsApp1\WindowsFormsApp1\cadastro.mdf;Integrated Security=True;Connect Timeout=30";
        bool novo;
        public login() {
            InitializeComponent();
        }

        private void bt_log_Click(object sender, EventArgs e) {
            novo = true;
            //conexão
            if(novo) {
                string sql = "SELECT * FROM users WHERE nome='" + user.Text + "'AND pwd='" + pwd.Text + "'";

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
    }
}

