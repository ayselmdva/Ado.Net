using System.Data.SqlClient;

namespace Cinema
{
    internal class Program
    {
        private const string CONNECTION_STRING = "Server=DESKTOP-0VMN37K\\SQLEXPRESS01; Database=Cinema; Trusted_Connection=True;";
        static void Main(string[] args)
        {
            int say;
            do
            {
                Console.WriteLine("Hello");
                Console.WriteLine("1-Movies \n2-Actors \n3-Directors \n4-Insert Actor to table \n5-Insert Movie to table \n6-Insert Director to table \n7-Update Actor in table \n8-Update Movie in table \n9-Delete Actor to table \n10-Delete Movie to table \n11-Exit website");
                say = int.Parse(Console.ReadLine());
                switch (say)
                {
                    case 1:
                        List<Movie> result = AllMovies();
                    foreach (var item in result)
                    {
                       Console.WriteLine($"{item.MovieId} - {item.MovieName} - {item.Rating}");
                    }
                        break;
                    case 2:
                        List<Actor> resultA = AllActors();
                        foreach (var item in resultA)
                        {
                            Console.WriteLine($"{item.ActorId} - {item.ActorName} - {item.ActorSurname} - {item.ActorAge}");
                        }
                        break;
                    case 3:
                        List<Direcotor> resultD = AllDirectors();
                        foreach (var item in resultD)
                        {
                            Console.WriteLine($"{item.DirectorId} - {item.DirectorName} - {item.DirectorSurname} - {item.DirectorAge}");
                        }
                        break;
                    case 4:
                        Console.WriteLine("Enter parametrs of actor:(name,surname,age)");
                        string actorName = Console.ReadLine();
                        string actorSurname = Console.ReadLine();
                        int actorage = int.Parse(Console.ReadLine());
                        Insert(actorName, actorSurname, actorage);
                        break;
                    case 5:
                        Console.WriteLine("Enter parametrs of movie:(Movie name, rating)");
                        string movieName = Console.ReadLine();
                        int rating = int.Parse(Console.ReadLine());
                        Insert(movieName, rating);
                        break;
                    case 6:
                        Console.WriteLine("Enter parametrs of director:(name,surname,age)");
                        string directorName = Console.ReadLine();
                        string directorSurname = Console.ReadLine();
                        int directorage = int.Parse(Console.ReadLine());
                        InsertDirector(directorName, directorSurname, directorage);
                        break;
                    case 7:
                        Console.WriteLine("What id number would you like to change the parameters of?");
                        int Id = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter parametrs of actor:(name,surname,age)");
                        string actorNameU = Console.ReadLine();
                        string actorSurnameU = Console.ReadLine();
                        int actorageU = int.Parse(Console.ReadLine());
                        Update(Id, actorNameU, actorSurnameU, actorageU);
                        break;
                    case 8:
                        Console.WriteLine("What id number would you like to change the parameters of?");
                        int Idm = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter parametrs of movie:(Movie name, rating)");
                        string movieNameU = Console.ReadLine();
                        int ratingU = int.Parse(Console.ReadLine());
                        Update(Idm, movieNameU, ratingU);
                        break;
                    case 9:
                        Console.WriteLine("What id number would you like to delete the parameters of?");
                        int Idd = int.Parse(Console.ReadLine());
                        Delete("Actors", Idd);
                        break;
                    case 10:
                        Console.WriteLine("What id number would you like to delete the parameters of?");
                        int Idd2 = int.Parse(Console.ReadLine());
                        Delete("Movies", Idd2);
                        break;
                }
            } while (say == 11);

        }

        static void Insert(string name, string surname, int age)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                string query = $"INSERT Actors VALUES(@name,@surname,@age)";
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@surname", surname);
                cmd.Parameters.AddWithValue("@age", age);

                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    Console.WriteLine("Added new values to table");
                }
                else { Console.WriteLine("Fatal error"); }
            }
        }
        static void InsertDirector(string name, string surname, int age)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                string query = $"INSERT Directors VALUES(@name,@surname,@age)";
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@surname", surname);
                cmd.Parameters.AddWithValue("@age", age);

                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    Console.WriteLine("Added new values to table");
                }
                else { Console.WriteLine("Fatal error"); }
            }
        }

        static void Insert(string name, int rating)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                string query = $"INSERT Movies VALUES(@name,@rating)";
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@rating", rating);

                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    Console.WriteLine("Added new values to table");
                }
                else { Console.WriteLine("Fatal error"); }
            }
        }


        static void Delete(string tName, int Id)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                string query = $"DELETE FROM {tName} WHERE Id=@Id";
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Id", Id);

                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    Console.WriteLine("Vaule Delete from table");
                }
                else { Console.WriteLine("Fatal error"); }
            }
        }

        static void Update(int Id, string name, int rating)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                string query = $"UPDATE Movies SET MovieName=@name Rating=@rating WHERE Id=@Id";
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@rating", rating);
                cmd.Parameters.AddWithValue("@Id", Id);

                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    Console.WriteLine("Update values");
                }
                else { Console.WriteLine("Fatal error"); }
            }
        }

        static void Update(int Id, string name, string surname, int age)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                string query = $"UPDATE Movies SET ActorName=@name ActorSurname=@surname ActorAge=@age WHERE Id=@Id";
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@surname", surname);
                cmd.Parameters.AddWithValue("@age", age);
                cmd.Parameters.AddWithValue("@Id", Id);

                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    Console.WriteLine("Update values");
                }
                else { Console.WriteLine("Fatal error"); }
            }
        }

        static List<Actor> AllActors()
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                string query = $"SELECT * FROM Actors";
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader dr = command.ExecuteReader())
                    {
                        List<Actor> actors = new List<Actor>();

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                actors.Add(new Actor()
                                {
                                    ActorId = int.Parse(dr["ActorId"].ToString()),
                                    ActorName = dr["ActorName"].ToString(),
                                    ActorSurname = dr["ActorSurname"].ToString(),
                                    ActorAge = int.Parse(dr["Age"].ToString())
                                });
                            }
                        }
                        return actors;
                    }
                }
            }
        }

        static List<Movie> AllMovies()
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                string query = $"SELECT * FROM Movies";
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader dr = command.ExecuteReader())
                    {
                        List<Movie> movies = new List<Movie>();

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                movies.Add(new Movie()
                                {
                                    MovieId = int.Parse(dr["MovieId"].ToString()),
                                    MovieName = dr["MovieName"].ToString(),
                                    Rating = int.Parse(dr["Rating"].ToString())
                                });
                            }
                        }
                        return movies;
                    }
                }
            }
        }

        static List<Direcotor> AllDirectors()
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                string query = $"SELECT * FROM Directors";
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader dr = command.ExecuteReader())
                    {
                        List<Direcotor> directors = new List<Direcotor>();

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                directors.Add(new Direcotor()
                                {
                                    DirectorId = int.Parse(dr["DirectorId"].ToString()),
                                    DirectorName = dr["DirectorName"].ToString(),
                                    DirectorSurname = dr["DirectorSurname"].ToString(),
                                    DirectorAge = int.Parse(dr["DirectorAge"].ToString())
                                });
                            }
                        }
                        return directors;
                    }
                }
            }
        }
    }
}
