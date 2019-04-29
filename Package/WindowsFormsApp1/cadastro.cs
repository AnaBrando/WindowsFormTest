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
    public partial class cadastro : Form {
        string connection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Aluno\Documents\cadastro.mdf;Integrated Security=True;Connect Timeout=30";
        bool novo;
        public cadastro() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            novo = true;
            if(novo) {
                string sql = "insert into cliente (Nome,Endereco,CEP,Bairro,Cidade,UF,TELEFONE)" +
                    "values('" + textBox1 + "','" + textBox2.Text + "','"
                    + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "')";
             

                SqlConnection con = new SqlConnection(connection);
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                try {
                    int i = cmd.ExecuteNonQuery();
                    if(i > 0)
                        MessageBox.Show("Cadastro Inserido com Sucesso", "Cadastro");

                }
                catch(Exception ex) {
                    MessageBox.Show("Erro" + ex.ToString());
                }
                finally {
                    con.Close();
                    Index index = new Index();
                    index.Show();
                }
            }
            else {
                string sql = "update cliente set Nome = '" + textBox1.Text + "',Endereco=" + textBox2.Text + "',CEP='" +
                    textBox3.Text + "',Bairro=" + textBox4.Text + "',Cidade='" + textBox5.Text
                    + "',UF=" + textBox6.Text + "',TELEFONE=" + textBox7.Text + "'where Id = '" + "'";

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
