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
    public partial class FrmUsuarios : Form
    {
        Usuario u;
        public FrmUsuarios()
        {
            InitializeComponent();
        }
        void limpaControles()
        {
            txtID.Clear();
            txtNome.Clear();
            txtFuncao.Clear();
            txtLogin.Clear();
            txtSenha.Clear();
            txtPesquisa.Clear();
        }

        void carregarGrid(string pesquisa)
        {
            u = new Usuario()
            {
                nome = pesquisa
            };
            dgvUsuarios.DataSource = u.Consultar();
        }

        private void FrmUsuarios_Load(object sender, EventArgs e)
        {
            limpaControles();
            carregarGrid("");
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
