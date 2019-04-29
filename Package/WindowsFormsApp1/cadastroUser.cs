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

    public partial class cadastroUser : Form {

        string connection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Aluno\Documents\cadastro.mdf;Integrated Security=True;Connect Timeout=30";
        bool novo;

        public cadastroUser() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            novo = true;
            if(novo) {
                string sql = "INSERT INTO users (nome,pwd,cliente)" +
                    "VALUES('" + user.Text + "','" + "AND pwd=" + pwd.Text + "AND cliente=" + client.Text + "')";
                SqlConnection con = new SqlConnection(connection);
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                try {
                    int i = cmd.ExecuteNonQuery();
                    if(i > 0) {
                        user.Text = "";
                        pwd.Text = "";
                        MessageBox.Show("CADASTRO", "CADASTRO REALIZADO COM SUCESSO");
                        Index index = new Index();
                        index.Show();
                    }
                    else {
                        user.Text = "";
                        pwd.Text = "";
                        MessageBox.Show("Alert!", "Cadastro não efetuado, tente de novo!");
                    }
                }
                catch(Exception error) {
                    MessageBox.Show("Erro de Conexão Motherfucker!" + error.ToString());
                }
                finally {
                    con.Close();
                }
            }
            else {
                string sql = "update users set nome = '" + user.Text + "',pwd=" + pwd.Text 
                    + "'";
                SqlConnection con = new SqlConnection(connection);
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                try {
                    int i = cmd.ExecuteNonQuery();
                    if(i > 0)
                        MessageBox.Show("Inserção realizada com sucesso", "Atualização");
                }
                catch(Exception ex) {
                    MessageBox.Show("Erro" + ex.ToString());
                }
                finally {
                    con.Close();

                }
            }
        }
    }
}
