using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace _191035_231343
{
    public class Banco
    {
        // classe responsável pela conexão com o banco
        // Connection responsável conexão com MySQL
        public static MySqlConnection Conexao;
        // Command responsável instruções SQL a serem executadas
        public static MySqlCommand Comando;
        // Adapter insere dados em um dataTable
        public static MySqlDataAdapter Adaptador;
        // DataTable liga o banco em controles com a propriedade DataSource
        public static DataTable datTabela;

        public static void AbrirConexao()
        {
            try
            {
                // Estabelece conexão com o banco de dados
                //Conexao = new MySqlConnection("server=localhost;port=3307;uid=root;pwd=etecjau");
                Conexao = new MySqlConnection("server=localhost;port=3307;uid=root;pwd=");

                // Abre conexão com o banco
                Conexao.Open();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void FecharConexao()
        {
            try
            { 
                // Fecha conexão com o banco
                Conexao.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void CriarBanco()
        {
            try
            {
                // Chama a função para abertura de conexão com o banco
                AbrirConexao();

                // Informa a instrução SQL  
                Comando = new MySqlCommand("CREATE DATABASE IF NOT EXISTS vendas; USE vendas", Conexao);

                // Executa a Query  no MySQL (Raio do Workbench)
                Comando.ExecuteNonQuery();
                
                //Cria tabela de cidades
                Comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS Cidades " +
                                           "(id integer auto_increment primary key, " +
                                           "nome char(40), " +
                                           "uf char(02))", Conexao);
                Comando.ExecuteNonQuery();

                // Cria tabela usuários
                Comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS USUARIOS " +
                                           "(id integer auto_increment primary key, " +
                                           "nome varchar(50), " +
                                           "login varchar(30), " +
                                           "senha varchar(20), " +
                                           "funcao varchar(50))", Conexao);
                Comando.ExecuteNonQuery();

              

                // Cria tabela de Clientes
                Comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS Clientes " +
                                              "(id integer auto_increment primary key, " +
                                              "nome varchar(40), " +
                                              "idCidade integer, " +
                                              "dataNasc date, " +
                                              "renda decimal(10,2), " +
                                              "cpf char(14), " +
                                              "foto varchar(40), " +
                                              "venda boolean) ", Conexao);
                Comando.ExecuteNonQuery();

                //Comando = new MySqlCommand("create table if not exits Categorias" +
                //    "(id integer auto_increment primary key, " +
                //    "categoria char(20)", Conexao);




                // Chama a função para fechar a conexão com o banco
                FecharConexao();
            }

            catch (Exception e) 
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
