using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace _191035_231343.Models
{
    public class Cliente
    {
        public int id { get; set; }
        public string nome { get; set; }
        public  int idCidade { get; set; }
        public DateTime dataNasc { get; set; }
        public double renda { get; set; }
        public string cpf { get; set; }
        public string foto { get; set; }
        public bool venda {  get; set; }

        public DataTable Consultar()
        {
            try
            {
                Banco.Comando = new MySqlCommand("SELECT cl.*, ci.nome cidade, " +
                        "ci.uf FROM CLientes cl inner join Cidades ci on (ci.id = cl.idCidade) " +
                        "where cl.nome like ?Nome order by cl.nome", Banco.Conexao);
                Banco.Comando.Parameters.AddWithValue("@Nome", nome + "%");
                Banco.Adaptador = new MySqlDataAdapter(Banco.Comando);
                Banco.datTabela = new DataTable();
                Banco.Adaptador.Fill(Banco.datTabela);
                return Banco.datTabela;
         
            }


            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

        }

        public void Incluir()
        {
            try
            {
                Banco.Conexao.Open();
                Banco.Comando = new MySqlCommand(
                    "INSERT into clientes (nome, idCidade, datNasc, renda, cpf, foto, venda)" +
                    "values (@nome, @idCidade, @dataNasc, @renda, @cpf, @foto, @venda)", Banco.Conexao);
                Banco.Comando.Parameters.AddWithValue("@nome", nome);
                Banco.Comando.Parameters.AddWithValue("@idCidade", idCidade);
                Banco.Comando.Parameters.AddWithValue("@dataNasc", dataNasc);
                Banco.Comando.Parameters.AddWithValue("@renda", renda);
                Banco.Comando.Parameters.AddWithValue("@cpf", cpf);
                Banco.Comando.Parameters.AddWithValue("@foto", foto);
                Banco.Comando.Parameters.AddWithValue("@venda", venda);
                Banco.Comando.Parameters.AddWithValue("@id", id);

                Banco.Comando.ExecuteNonQuery();
                Banco.Conexao.Close();

            }

            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ALterar()
        {
            try
            {
                Banco.Conexao.Open();
                Banco.Comando = new MySqlCommand(
                    "UPDATE clientes SET nome = @nome,  idCidade = @idCidade, dataNasc = @dataNasc, " +
                    "renda = @renda, cpf = @cpf, foto = @foto, venda = @venda WHERE id = @id", Banco.Conexao);
                Banco.Comando.Parameters.AddWithValue("@nome", nome);
                Banco.Comando.Parameters.AddWithValue("@idCidade", idCidade);
                Banco.Comando.Parameters.AddWithValue("@dataNasc", dataNasc);
                Banco.Comando.Parameters.AddWithValue("@renda", renda);
                Banco.Comando.Parameters.AddWithValue("@cpf", cpf);
                Banco.Comando.Parameters.AddWithValue("@foto", foto);
                Banco.Comando.Parameters.AddWithValue("@venda", venda);
                Banco.Comando.Parameters.AddWithValue("@id", id);

                Banco.Comando.ExecuteNonQuery();
                Banco.Conexao.Close();

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
                Banco.Conexao.Open();
                Banco.Comando = new MySqlCommand("DELETE FROM clientes WHERE id = @id", Banco.Conexao);
                Banco.Comando.Parameters.AddWithValue("@id", id);

                Banco.Comando.ExecuteNonQuery();
                Banco.Conexao.Close();


            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
