using _191035_231343.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _191035_231343.Views
{
    public partial class FrmCidades : Form
    {
        Cidade c;
        public FrmCidades()
        {
            InitializeComponent();
        }

        //Function to clear controls
        void limpaControles()
        {
            txtID.Clear();
            txtNome.Clear();
            txtUF.Clear();
            txtPesquisa.Clear();
        }

        void carregarGrid(string pesquisa)
        {
            c = new Cidade()
            {
                nome = pesquisa
            };
            dgvCidades.DataSource = c.Consultar();
        }

        private void FrmCidades_Load(object sender, EventArgs e)
        {
            limpaControles();
            carregarGrid("");
        }

        // This lines code add values to the Frm Cidades
        private void btnIncluir_Click(object sender, EventArgs e)
        {
            // 
            if (txtNome.Text == String.Empty) return;
                 c = new Cidade()
                {
                    nome = txtNome.Text,
                    uf = txtUF.Text,    
                };
               c.Incluir();

             limpaControles();
             carregarGrid("");
        }


        private void dgvCidades_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCidades.Rows.Count > 0)
            {
                // Is take the values on grid and put in the text boxes
                // é pego o valor selecionado no grid e os colocam nas caixas de texto
                txtID.Text = dgvCidades.CurrentRow.Cells["id"].Value.ToString();
                txtNome.Text = dgvCidades.CurrentRow.Cells["nome"].Value.ToString();
                txtUF.Text = dgvCidades.CurrentRow.Cells["uf"].Value.ToString();
            }
        }

        // line code closes the Frm Cidades
        private void btnFechar_Click(object sender, EventArgs e)
        {
            // this is a command to close 
            Close();
        }

        // Command to alter values on grid
        //Comando para alterar valores do grid
        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (txtID.Text == String.Empty) return;

            c = new Cidade()
            {
                id = int.Parse(txtID.Text),
                nome = txtNome.Text,
                uf = txtUF.Text,
            };
            c.Alterar();

            limpaControles();
            carregarGrid("");

            
        }


        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "") return;

            if (MessageBox.Show("Deseja excluir a cidade?", "Exlusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                c = new Cidade()
                {
                    id = int.Parse(txtID.Text), 
                };
            c.Excluir();

            limpaControles();
            carregarGrid("");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

            limpaControles();
            carregarGrid("");
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            carregarGrid(txtPesquisa.Text);
        }
    }
}
