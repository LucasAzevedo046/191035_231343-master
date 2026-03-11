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
    public class Cidade                                                                       
    {
        public int id { get; set; } 
        public string nome { get; set; }
        public string uf { get; set; }

        // função responsavel pela inclusao de cidades no  banco de dados
        public void Incluir()
        {
            try
            {
                Banco.AbrirConexao();
                Banco.Comando = new MySqlCommand("INSERT INTO CIDADES (NOME, UF) VALUES (@NOME, @UF)", Banco.Conexao);
                Banco.Comando.Parameters.AddWithValue("@NOME", nome);
                Banco.Comando.Parameters.AddWithValue("@UF", uf);
                Banco.Comando.ExecuteNonQuery();
                Banco.FecharConexao();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Alterar()
        {
            try
            {
                // Abre a conexão com o banco
                Banco.AbrirConexao();
                // Alimenta o método Command com a instrução desejada e indica conexão utilizada
                Banco.Comando = new MySqlCommand("UPDATE CIDADES SET NOME = @NOME, UF = @UF WHERE ID = @ID", Banco.Conexao);
                // Cria parâmetros utilizados com seus respectivos conteúdos
                Banco.Comando.Parameters.AddWithValue("@NOME", nome);
                Banco.Comando.Parameters.AddWithValue("@UF", uf);
                Banco.Comando.Parameters.AddWithValue("@ID", id);
                // Executa o comando
                Banco.Comando.ExecuteNonQuery();
                // Fecha conexão
                Banco.FecharConexao();


            }
            catch (Exception e) 
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Excluir()
        {
            try
            {
                // Abre a conexão com o banco
                Banco.AbrirConexao();
                Banco.Comando = new MySqlCommand("delete from cidades where id = @id", Banco.Conexao);
                Banco.Comando.Parameters.AddWithValue("@id", id);
                Banco.Comando.ExecuteNonQuery();
                Banco.FecharConexao();
            }
            catch ( Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
          

        }


        public DataTable Consultar()
        {
            try
            {
                Banco.AbrirConexao();
                Banco.Comando = new MySqlCommand("SELECT * FROM CIDADES " +
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
