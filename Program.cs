using System;

namespace Tvshows
{
    class Program
    {
        static TvShowRepository repository = new TvShowRepository();
        static void Main(string[] args)
        {
            string opt = MenuOption();
            while (opt != "X"){
                switch(opt){
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
                        DeleteShow();
                        break;
                    case "5":
                        DescribeShow();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opt = MenuOption();
            }
            Console.WriteLine("Thanks for choosing us!");
        }

        private static void ListShows()
        {
            Console.WriteLine("Listing Tv Shows");

            var list = repository.List();

            if(list.Count == 0){
                Console.WriteLine("Empty.");
                return;
            }

            foreach(var show in list)
            {
                var deleted = show.returnDeleted();

                Console.WriteLine("#ID {0}: - {1} {2}", show.returnId(), show.returnTitle(), (deleted ? "*deleted*" : "") );
            }
        }

        private static void InsertShow()
        {
            Console.WriteLine("Inserting Show");

            foreach (int i in Enum.GetValues(typeof(Type)))
            {
                Console.WriteLine("#{0}-{1}", i, Enum.GetName(typeof(Type), i));
            }
            Console.Write("Choose the type of the show: ");
            int inpType = int.Parse(Console.ReadLine());

            Console.Write("Write the title of the show: ");
            string inpTitle = Console.ReadLine();

            Console.Write("Write the year of the show: ");
            int inpYear = int.Parse(Console.ReadLine());

            Console.Write("Write the description of the show: ");
            string inpDesc = Console.ReadLine();

            TvShow newShow = new TvShow(id: repository.NextId(),
                                        type: (Type)inpType,
                                        title: inpTitle,
                                        year: inpYear,
                                        description: inpDesc);

            repository.Insert(newShow);

        }

        private static void UpdateShow()
        {
            int idshow = idShowCatcher();

            foreach (int i in Enum.GetValues(typeof(Type)))
            {
                Console.WriteLine("#{0}-{1}", i, Enum.GetName(typeof(Type), i));
            }
            Console.Write("Choose the type of the show: ");
            int inpType = int.Parse(Console.ReadLine());

            Console.Write("Write the title of the show: ");
            string inpTitle = Console.ReadLine();

            Console.Write("Write the year of the show: ");
            int inpYear = int.Parse(Console.ReadLine());

            Console.Write("Write the description of the show: ");
            string inpDesc = Console.ReadLine();

            TvShow updShow = new TvShow(id: idshow,
                                        type: (Type)inpType,
                                        title: inpTitle,
                                        year: inpYear,
                                        description: inpDesc);

            repository.Update(idshow, updShow);

        }
        private static void DeleteShow()
        {
            int idshow = idShowCatcher();

            repository.Delete(idshow);

        }
        private static void DescribeShow(){
            int idshow = idShowCatcher();

            var show = repository.ReturnById(idshow);
            
            Console.WriteLine(show);
        }

        private static int idShowCatcher(){
            Console.WriteLine("Write the id from show: ");
            int idshow = int.Parse(Console.ReadLine());
            return idshow;
        }
        private static string MenuOption()
        {
            Console.WriteLine();
            Console.WriteLine("Tv Show App");
            Console.WriteLine("Choose an option:");

            Console.WriteLine("1 - List the Tv Shows");
            Console.WriteLine("2 - Insert a new Tv Show");
            Console.WriteLine("3 - Update a Tv Show");
            Console.WriteLine("4 - Delete a Tv Show");
            Console.WriteLine("5 - Details of a Tv Show");
            Console.WriteLine("C - Clear Screen");
            Console.WriteLine("X - Close App");
            Console.WriteLine();

            string opt = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opt;
        }
    }
}
