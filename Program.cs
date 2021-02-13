using System;

namespace DIO.Series
{
    class Program
    {
        static ShowRepository showRepository = new ShowRepository();
        static MovieRepository movieRepository = new MovieRepository();
        static void Main(string[] args)
        {
            string userInput = GetInput();

            while (userInput.ToUpper() != "X")
            {
                switch (userInput)
                {
                    case "1":
                        ListShows();
                        break;
                    case "2":
                        InsertShow();
                        break;
                    case "3":
                        UpdateShow();
                        break;
                    case "4":
                        RemoveShow();
                        break;
                    case "5":
                        ViewShow();
                        break;
                    case "6":
                        ListMovies();
                        break;
                    case "7":
                        InsertMovie();
                        break;
                    case "8":
                        UpdateMovie();
                        break;
                    case "9":
                        RemoveMovie();
                        break;
                    case "0":
                        ViewMovie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                userInput = GetInput();
            }
            Console.WriteLine("Obrigado por utilizar nossos serviços!");
            Console.ReadLine();
        }

        //Show methods
        private static void ViewShow(){
            Console.WriteLine("Digite o ID da série: ");
            int showIndex = int.Parse(Console.ReadLine());
            
            Console.WriteLine();
            var show = showRepository.returnById(showIndex);

            Console.WriteLine(show);
        }
        private static void RemoveShow(){
            Console.WriteLine("Digite o ID da série: ");
            int showIndex = int.Parse(Console.ReadLine());
            
            var show = showRepository.returnById(showIndex);
            Console.WriteLine("Tem certeza de que deseja remover a série {0}?", show.returnTitle());
            Console.WriteLine("Y - Sim");
            Console.WriteLine("N - Não");
            string confirmationInput = Console.ReadLine();
            switch(confirmationInput.ToUpper()){
                case "Y":
                    showRepository.Remove(showIndex);
                    Console.WriteLine("A série {0} foi removida", show.returnTitle());
                    break;
                case "N":
                    Console.WriteLine("Ação cancelada");
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        private static void UpdateShow(){
            Console.WriteLine("Digite o ID da série: ");
            int showIndex = int.Parse(Console.ReadLine());

            foreach(int i in Enum.GetValues(typeof(Genre))){
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genre), i));
            }
            Console.Write("Escolha um dos gêneros acima: ");
            int genreInput = int.Parse(Console.ReadLine());

            Console.Write("Digite o nome da série: ");
            string titleInput = Console.ReadLine();

            Console.Write("Digite o ano de lançamento da série: ");
            int yearInput = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição da série: ");
            string descInput = Console.ReadLine();

            Show updateShow = new Show(id: showIndex,
                                    genre: (Genre)genreInput,
                                    title: titleInput,
                                    year: yearInput,
                                    description: descInput);
            showRepository.Update(showIndex, updateShow);
        }
        private static void InsertShow(){
            Console.WriteLine("Inserir nova série");

            foreach(int i in Enum.GetValues(typeof(Genre))){
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genre), i));
            }
            Console.Write("Escolha um dos gêneros acima: ");
            int genreInput = int.Parse(Console.ReadLine());

            Console.Write("Digite o nome da série: ");
            string titleInput = Console.ReadLine();

            Console.Write("Digite o ano de lançamento da série: ");
            int yearInput = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição da série: ");
            string descInput = Console.ReadLine();

            Show newShow = new Show(id: showRepository.NextId(),
                                    genre: (Genre)genreInput,
                                    title: titleInput,
                                    year: yearInput,
                                    description: descInput);
            showRepository.Insert(newShow);
        }
        private static void ListShows(){
            Console.WriteLine("Listar séries");

            var list = showRepository.List();

            if(list.Count == 0){
                Console.WriteLine("Nenhuma série registrada");
                return;
            }

            foreach(var show in list){
                var isRemoved = show.returnRemoved();

                Console.WriteLine("#ID {0}: - {1} {2}", show.returnId(), show.returnTitle(), (isRemoved ? "*Removido*" : ""));
            }
        }

        //Movie methods
        private static void ViewMovie(){
            Console.WriteLine("Digite o ID do filme: ");
            int movieIndex = int.Parse(Console.ReadLine());
            
            Console.WriteLine();
            var movie = movieRepository.returnById(movieIndex);

            Console.WriteLine(movie);
        }
        private static void RemoveMovie(){
            Console.WriteLine("Digite o ID do filme: ");
            int movieIndex = int.Parse(Console.ReadLine());
            
            var movie = movieRepository.returnById(movieIndex);
            Console.WriteLine("Tem certeza de que deseja remover o filme {0}?", movie.returnTitle());
            Console.WriteLine("Y - Sim");
            Console.WriteLine("N - Não");
            string confirmationInput = Console.ReadLine();
            switch(confirmationInput.ToUpper()){
                case "Y":
                    movieRepository.Remove(movieIndex);
                    Console.WriteLine("O filme {0} foi removido", movie.returnTitle());
                    break;
                case "N":
                    Console.WriteLine("Ação cancelada");
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        private static void UpdateMovie(){
            Console.WriteLine("Digite o ID do filme: ");
            int movieIndex = int.Parse(Console.ReadLine());

            foreach(int i in Enum.GetValues(typeof(Genre))){
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genre), i));
            }
            Console.Write("Escolha um dos gêneros acima: ");
            int genreInput = int.Parse(Console.ReadLine());

            Console.Write("Digite o nome do filme: ");
            string titleInput = Console.ReadLine();

            Console.Write("Digite o ano de lançamento do filme: ");
            int yearInput = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição do filme: ");
            string descInput = Console.ReadLine();

            Movie updateMovie = new Movie(id: movieIndex,
                                    genre: (Genre)genreInput,
                                    title: titleInput,
                                    year: yearInput,
                                    description: descInput);
            movieRepository.Update(movieIndex, updateMovie);
        }
        private static void InsertMovie(){
            Console.WriteLine("Inserir novo filme");

            foreach(int i in Enum.GetValues(typeof(Genre))){
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genre), i));
            }
            Console.Write("Escolha um dos gêneros acima: ");
            int genreInput = int.Parse(Console.ReadLine());

            Console.Write("Digite o nome do filme: ");
            string titleInput = Console.ReadLine();

            Console.Write("Digite o ano de lançamento do filme: ");
            int yearInput = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição do filme: ");
            string descInput = Console.ReadLine();

            Movie newMovie = new Movie(id: movieRepository.NextId(),
                                    genre: (Genre)genreInput,
                                    title: titleInput,
                                    year: yearInput,
                                    description: descInput);
            movieRepository.Insert(newMovie);
        }
        private static void ListMovies(){
            Console.WriteLine("Listar filmes");

            var list = movieRepository.List();

            if(list.Count == 0){
                Console.WriteLine("Nenhuma filme registrada");
                return;
            }

            foreach(var movie in list){
                var isRemoved = movie.returnRemoved();

                Console.WriteLine("#ID {0}: - {1} {2}", movie.returnId(), movie.returnTitle(), (isRemoved ? "*Removido*" : ""));
            }
        }

        //Input methods

        private static string GetInput(){
            Console.WriteLine();
            Console.WriteLine("DIO Séries & Filmes a seu dispor!!!");
            Console.WriteLine();
            Console.WriteLine("Digite a opção desejada:");
            
            Console.WriteLine("Séries:");
            Console.WriteLine("1 - Listar séries");
            Console.WriteLine("2 - Inserir nova série");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Remover série");
            Console.WriteLine("5 - Visualizar série");
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("Filmes:");
            Console.WriteLine("6 - Listar filmes");
            Console.WriteLine("7 - Inserir novo filme");
            Console.WriteLine("8 - Atualizar filme");
            Console.WriteLine("9 - Remover filme");
            Console.WriteLine("0 - Visualizar filme");
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("B - Voltar para o menu principal");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string input = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return input;
        }
    }
}
