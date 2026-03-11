using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace _191035_231343.Models
{
    public class Usuario
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string login { get; set; }
        public string senha { get; set; }
        public string funcao { get; set; }

        public DataTable Consultar()
        {
            try
            {
                Banco.AbrirConexao();
                Banco.Comando = new MySqlCommand("SELECT * FROM USUARIOS " +
                                                "WHERE NOME LIKE @NOME " +
                                                "ORDER BY NOME", Banco.Conexao);
                Banco.Comando.Parameters.AddWithValue("@NOME", nome + "%");

                Banco.Adaptador = new MySqlDataAdapter(Banco.Comando);
                Banco.datTabela = new DataTable();
                Banco.Adaptador.Fill(Banco.datTabela);
                Banco.FecharConexao();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return Banco.datTabela;
        }


    }
}
