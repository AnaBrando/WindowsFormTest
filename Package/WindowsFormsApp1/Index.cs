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
    public partial class Index : Form {
        public Index() {
            InitializeComponent();
        }

        private void index_Load(object sender, EventArgs e) {
            // TODO: esta linha de código carrega dados na tabela 'cadastroDataSet2.cliente'. Você pode movê-la ou removê-la conforme necessário.
            this.clienteTableAdapter1.Fill(this.cadastroDataSet2.cliente);
            // TODO: esta linha de código carrega dados na tabela 'cadastroDataSet1.users'. Você pode movê-la ou removê-la conforme necessário.
     
            // TODO: esta linha de código carrega dados na tabela 'cadastroDataSet.cliente'. Você pode movê-la ou removê-la conforme necessário.
            this.clienteTableAdapter.Fill(this.cadastroDataSet.cliente);

        }

    
        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            Application.Exit();
        }

      
    }
}
