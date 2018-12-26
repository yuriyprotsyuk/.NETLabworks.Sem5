using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.ProtsyukIS63.V6
{
    class Program
    {
        /// <summary>
        /// Клас виконавця
        /// </summary>
        public class Singer
        {
            /// <summary>
            /// Код виконавця
            /// </summary>
            public int id;
            /// <summary>
            /// Ім`я артиста
            /// </summary>
            public string name;
            /// <summary>
            /// Країна
            /// </summary>
            public string country;

            /// <summary>
            /// Конструктор з параметрами
            /// </summary>
            /// <param name="i"></param>
            /// <param name="n"></param>
            /// <param name="c"></param>
            public Singer(int i, string n, string c)
            {
                this.id = i;
                this.name = n;
                this.country = c;
            }
            /// <summary>
            /// Переозначення метода приведення до рядка
            /// </summary>
            /// <returns></returns>
            public override string ToString()            {                return "(id=" + this.id.ToString()+ "; name=" + this.name + "; country=" + this.country + ")";
            }
        }
        /// <summary>
        /// Клас Альбом (музичний)
        /// </summary>
        public class Album
        {
            /// <summary>
            /// Код альбому
            /// </summary>
            public int id;
            /// <summary>
            /// Назва альбому
            /// </summary>
            public string name;
            /// <summary>
            /// Код виконавця
            /// </summary>
            public int singerID;
            /// <summary>
            /// Жанр альбому
            /// </summary>
            public string genre;
            public Singer Singer { get; set; }
            /// <summary>
            /// /Конструктор з параметрами
            /// </summary>
            /// <param name="i"></param>
            /// <param name="n"></param>
            /// <param name="s"></param>
            /// <param name="g"></param>
            public Album(int i, string n, int s, string g)
            {
                this.id = i;
                this.name = n;
                this.singerID = s;
                this.genre = g;
            }
            /// <summary>
            /// Переозначання методу приведення до рядка
            /// </summary>
            /// <returns></returns>
            public override string ToString()
            {
                return "(id=" + this.id.ToString() + "; name=" + this.name + "; singerID=" + this.singerID.ToString() + "; genre=" + this.genre +")";
            }
        }
        /// <summary>
        /// Клас пісня
        /// </summary>
        public class Song
        {
            /// <summary>
            /// Код пісні
            /// </summary>
            public int id;
            /// <summary>
            /// Назва
            /// </summary>
            public string name;
            /// <summary>
            /// Код альбому
            /// </summary>
            public int albumID;
            /// <summary>
            /// Мова пісні
            /// </summary>
            public string language;
            /// <summary>
            /// Тривалість пісні
            /// </summary>
            public int duration;
            /// <summary>
            /// Конструктор з параметрами
            /// </summary>
            /// <param name="i"></param>
            /// <param name="n"></param>
            /// <param name="a"></param>
            /// <param name="l"></param>
            /// <param name="d"></param>
            public Song (int i, string n, int a, string l, int d)
            {
                this.id = i;
                this.name = n;
                this.albumID = a;
                this.language = l;
                this.duration = d;
            }
            /// <summary>
            /// Переозначення методу приведення до рядка
            /// </summary>
            /// <returns></returns>
            public override string ToString()
            {
                return "(id=" + this.id.ToString() + "; name=" + this.name + "; albumID=" + this.albumID.ToString() + "; language=" + this.language + "; duration=" + this.duration + ")";
            }
        }
        /// <summary>
        /// Список виконавців 1
        /// </summary>
        static List<Singer> s1 = new List<Singer>()
        {
            new Singer(1, "Madonna" , "USA"),
            new Singer(2, "Jamala", "Ukraine"),
            new Singer(3, "Michael Jackson", "USA"),
            new Singer(4, "The Beatles", "UK"),
            new Singer(5, "Dalida", "France"),
            new Singer(6, "Andrea Bocelli", "Italy")

        };
        /// <summary>
        /// Список виконавців 2
        /// </summary>
        static List<Singer> s3 = new List<Singer>()
        {
            new Singer(1, "Madonna" , "USA"),
            new Singer(8,"Britney Spears", "USA" ), 
            new Singer(9, "Lara Fabian", "France")
        };
        /// <summary>
        /// Список альбомів
        /// </summary>
        static List<Album> a1 = new List<Album>()
        {
            new Album(11, "True Blue", 1 , "pop"),
            new Album(12, "Music", 1 , "pop"),
            new Album(13, "Thriller", 3 , "pop"),
            new Album(14, "Bad", 3 , "pop"),
            new Album(15, "1944", 2 , "electro"),
            new Album(16, "Крила", 2 , "pop"),
            new Album(17, "Yesterday and Today", 4 , "rock"),
            new Album(18, "Le suis malade", 5 , "chanson"),
            new Album(19, "Bocelli", 6 , "classic")
        };
        /// <summary>
        /// Список пісень
        /// </summary>
        static List<Song> s2 = new List<Song>()
        {
            new Song(111, "Music", 12, "English", 180),
            new Song(112, "Live to Tell", 11, "English",215),
            new Song(113, "True Blue", 11, "English",214),
            new Song(114, "Billie Jean", 13, "English",205),
            new Song(115, "Beat It", 13, "English",187),
            new Song(116, "Thriller", 13, "English",196),
            new Song(117, "Bad", 14, "English",195),
            new Song(118, "Dirty Diana", 14, "English",197),
            new Song(119, "1944", 15, "English",184),
            new Song(120, "Крила", 16, "Ukrainian",225),
            new Song(121, "Yesterday", 17, "English",210),
            new Song(122, "Je suis malade", 18, "French",200),
            new Song(123, "Per Amore", 19, "Italian",214),
            new Song(124, "Romanza", 19, "Italian",214),
            new Song(125, "Happiness", 16, "English",201)
        };
        /// <summary>
        /// Точка входу в програму
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("Лабораторна робота №4. Процюк Юрiй. IС-63. Варiант-15");
            Console.WriteLine();
            Console.WriteLine("Усi наявнi артисти");
            var q1 = from x in s1
                     select x;
            foreach (var x in q1)
                Console.WriteLine(x);
            Console.WriteLine();

            Console.WriteLine("Усi iмена артистiв");
            var q2 = from x in s1
                     select x.name;
            foreach (var x in q2)
                Console.WriteLine(x);
            Console.WriteLine();

            Console.WriteLine("Альбом i його виконавець");
            var q3 = from x in s1
                     join y in a1 on x.id equals y.singerID
                     select new { AlbumName = y.name, SingerName = x.name };
            foreach (var x in q3)
                Console.WriteLine(x);
            Console.WriteLine();

            Console.WriteLine("Сортування пiсень за тривалiстю");
            var q4 = from x in s2
                     orderby x.duration
                     select new { x.name, x.language, x.duration };
            foreach (var x in q4)
                Console.WriteLine(x);
            Console.WriteLine();

            Console.WriteLine("Артисти i їх пiснi англiйською мовою (Фiльтрування)");
            var q5 = from x in s1
                     join y in a1 on x.id equals y.singerID
                     join z in s2 on y.id equals z.albumID
                     where z.language == "English"
                     select new {SingerName = x.name , SongName = z.name};
            foreach (var u in q5)
                Console.WriteLine(u);
            Console.WriteLine();

            Console.WriteLine("Групування альбомiв за артистами");
            var q6 = from z in
                         (from x in s1
                          join y in a1 on x.id equals y.singerID
                          select new { AlbumName = y.name, SingerName = x.name })
                    orderby z.SingerName
                     group z by z.SingerName;
            foreach (var x in q6)
            {
                Console.WriteLine(x.Key + ":");
                foreach (var s in x)
                    Console.WriteLine("{0,20}", s.AlbumName);
            }
            Console.WriteLine();

            Console.WriteLine("Середня довжина пiснi виконавця (Об`єднання таблиць i агрегатна функцiя середнього значення)");
            var q7 = (from x in s1
                      join y in a1 on x.id equals y.singerID
                      join z in s2 on y.id equals z.albumID
                      select new { SingerName = x.name, SongName = z.name, Duration = z.duration }).GroupBy(u => u.SingerName)
                          .Select(g => new { SingerName = g.Key, AvarageSongDuration = g.Average(u => u.Duration) });
            foreach (var x in q7)
                Console.WriteLine(x);
            Console.WriteLine();

            Console.WriteLine("Об`єднання 2 спискiв без виключення спiльних елементiв");
            foreach (var x in s1.Concat(s3))
                Console.WriteLine(x);
            Console.WriteLine();

            Console.WriteLine("Вибiр артистiв, що спiвають англiйської (з застосуванням фiльтра Distinct)");
            var q8 = (from x in s1
                      join y in a1 on x.id equals y.singerID
                      join z in s2 on y.id equals z.albumID
                      where z.language == "English"
                      select new { x.name }).Distinct();
            foreach (var x in q8)
                Console.WriteLine(x);
            Console.WriteLine();
                            
            Console.ReadLine();
        }
    }   
} 


