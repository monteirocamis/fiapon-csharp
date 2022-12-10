using FiapSmartCityMVC.Models;
using FiapSmartCityMVC.Properties.Repository;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Metadata.Ecma335;

namespace FiapSmartCityMVC.Properties.Repository
{
    public class PetRepository
    {
        public IList<Pet> Listar()
        {

            IList<Pet> lista = new List<Pet>();

            var connectionString = new ConfigurationBuilder()
                                        .SetBasePath(Directory.GetCurrentDirectory())
                                        .AddJsonFile("appsettings.json")
                                        .Build().GetConnectionString("FiapSmartCityConnection");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                String query =
                " SELECT IDPET, NOMEPET FROM PET";

                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read()) 
                {
                    //recuperar dados

                    Pet pet = new Pet();
                    pet.IdPet = Convert.ToInt32(dataReader["IDPET"]);
                    pet.NomePet = dataRead["NOMEPET"].ToString();

                    //adicionar modelo da lista
                    lista.Add(pet);
                }
            //fecha objeto connection
                connection.Close();
            } 


            return lista
}







        public Pet Consultar(int id)
        {
            Pet pet = new Pet();

            var connectionString = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build().GetConnectionString("FiapSmartCityConnection");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                String query =
               " SELECT IDPET, NOMEPET FROM PET WHERE IDPET = @IDPET";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.Add("@IDPET", SqlDbType.Int);
                command.Parameters["@IDPET"].Value = id;
                connection.Open();

                SqlDataReader dataReader = command.ExecuteReader();


                while (dataReader.Read())
                {
                    //recuperar dados
                    pet.IdPet = Convert.ToInt32(dataReader["IDPET"]);
                    pet.NomePet = dataReader["NOMEPET"].ToString();
                }
                connection.Close();
            }
            //retorna lista
            return pet;
        }






        public void Inserir(Pet pet)
        {
            var connectionString = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build().GetConnectionString("FiapSmartCityConnection");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                String query =
               " INSERT INTO PET ( NOMEPET ) VALUES (@nomepet)";

                SqlCommand command = new SqlCommand(query, connection);

                //add valor ao comando
                command.Parameters.Add("@nomepet", SqlDbType.Text);
                command.Parameters["@nomepet"].Value = pet.NomePet;

                //abre conexao com db
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }







        public void Alterar(Pet pet)
        {
            var connectionString = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build().GetConnectionString("FiapSmartCityConnection");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                String query =
               " UPDATE PET SET NOMEPET = @nomepet WHERE IDPET = @idPet";

                SqlCommand command = new SqlCommand(query, connection);

                //add valor ao comando
                command.Parameters.Add("@nomepet", SqlDbType.Text);
                command.Parameters.Add("@idpet", SqlDbType.Text);

                command.Parameters["@nomepet"].Value = pet.NomePet;
                command.Parameters["@idpet"].Value = pet.IdPet;

                //abre conexao com db
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
               " DELETE PET WHERE IDPET = @idPet";

                SqlCommand command = new SqlCommand(query, connection);

                //add valor ao comando
                command.Parameters.Add("@idpet", SqlDbType.Int);
                command.Parameters["@idpet"].Value = id;

                //abre conexao com db
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
