using FiapSmartCity.Models;
using System.Data.SqlClient;
using System.Data;
using System.Reflection.PortableExecutable;

namespace FiapSmartCity.Repository
{
    public class PessoaRepository
    {
        public IList<Pessoa> Listar()
        {
            IList<Pessoa> lista = new List<Pessoa>();

            var connectionString = new ConfigurationBuilder()
                                        .SetBasePath(Directory.GetCurrentDirectory())
                                        .AddJsonFile("appsettings.json")
                                        .Build().GetConnectionString("FiapSmartCityConnection");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                String query =
                    "SELECT IDPESSOA, NOMEPESSOA, ENDERECOPESSOA FROM PESSOA  ";

                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    // Recupera os dados
                    Pessoa pessoa = new Pessoa();
                    pessoa.IdPessoa = Convert.ToInt32(dataReader["IDPESSOA"]);
                    pessoa.NomePessoa = dataReader["NOMEPESSOA"].ToString();
                    pessoa.EnderecoPessoa = dataReader["ENDERECOPESSOA"].ToString();

                    // Adiciona o modelo da lista
                    lista.Add(pessoa);
                }

                connection.Close();

            } // Finaliza o objeto connection

            // Retorna a lista
            return lista;
        }

        public Pessoa Consultar(int id)
        {

            Pessoa pessoa = new Pessoa();

            var connectionString = new ConfigurationBuilder()
                                        .SetBasePath(Directory.GetCurrentDirectory())
                                        .AddJsonFile("appsettings.json")
                                        .Build().GetConnectionString("FiapSmartCityConnection");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                String query =
                    "SELECT IDPESSOA, NOMEPESSOA, ENDERECOPESSOA FROM PESSOA WHERE IDPESSOA = @IDPESSOA ";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.Add("@IDPESSOA", SqlDbType.Int);
                command.Parameters["@IDPESSOA"].Value = id;
                connection.Open();

                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    // Recupera os dados
                    pessoa.IdPessoa = Convert.ToInt32(dataReader["IDPESSOA"]);
                    pessoa.NomePessoa = dataReader["NOMEPESSOA"].ToString();
                    pessoa.EnderecoPessoa = dataReader["ENDERECOPESSOA"].ToString();
                }

                connection.Close();

            } // Finaliza o objeto connection

            // Retorna a lista
            return pessoa;
        }

        public void Inserir(Pessoa pessoa)
        {
            var connectionString = new ConfigurationBuilder()
                                        .SetBasePath(Directory.GetCurrentDirectory())
                                        .AddJsonFile("appsettings.json")
                                        .Build().GetConnectionString("FiapSmartCityConnection");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                String query =
                    "INSERT INTO PESSOA ( NOMEPESSOA, ENDERECOPESSOA ) VALUES ( @nomepessoa, @enderecopessoa ) ";

                SqlCommand command = new SqlCommand(query, connection);

                // Adicionando o valor ao comando
                command.Parameters.Add("@nomepessoa", SqlDbType.Text);
                command.Parameters["@nomepessoa"].Value = pessoa.NomePessoa;
                command.Parameters.Add("@enderecopessoa", SqlDbType.Text);
                command.Parameters["@enderecopessoa"].Value = pessoa.EnderecoPessoa;

                // Abrindo a conexão com  o Banco
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

            }
        }

        public void Alterar(Pessoa pessoa)
        {
            var connectionString = new ConfigurationBuilder()
                                        .SetBasePath(Directory.GetCurrentDirectory())
                                        .AddJsonFile("appsettings.json")
                                        .Build().GetConnectionString("FiapSmartCityConnection");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                String query =
                    "UPDATE PESSOA SET NOMEPESSOA = @nomepessoa , ENDERECOPESSOA = @enderecopessoa WHERE IDPESSOA = @idpessoa  ";

                SqlCommand command = new SqlCommand(query, connection);

                // Adicionando o valor ao comando
                command.Parameters.Add("@nomepessoa", SqlDbType.Text);
                command.Parameters.Add("@enderecopessoa", SqlDbType.Text);
                command.Parameters.Add("@idpessoa", SqlDbType.Int);
                command.Parameters["@nomepessoa"].Value = pessoa.NomePessoa;
                command.Parameters["@enderecopessoa"].Value = pessoa.EnderecoPessoa;
                command.Parameters["@idpessoa"].Value = pessoa.IdPessoa;

                // Abrindo a conexão com  o Banco
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

            }
        }

        public void Excluir(int id)
        {
            var connectionString = new ConfigurationBuilder()
                                        .SetBasePath(Directory.GetCurrentDirectory())
                                        .AddJsonFile("appsettings.json")
                                        .Build().GetConnectionString("FiapSmartCityConnection");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                String query =
                    "DELETE PESSOA WHERE IDPESSOA = @idpessoa  ";

                SqlCommand command = new SqlCommand(query, connection);

                // Adicionando o valor ao comando
                command.Parameters.Add("@idpessoa", SqlDbType.Int);
                command.Parameters["@idpessoa"].Value = id;

                // Abrindo a conexão com  o Banco
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }

        }
    }
}
