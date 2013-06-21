using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace com.github.thelonedevil.RandomArtistCSharp {
    class Program {

        static string path = "artists.txt";
        static List<string> artists = new List<string>();
        static string artist;

        static void Main(string[] args) {
            Console.Title = "Random Artist";
            Load();
            new1();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);

        }
        static void Load() {
            if (File.Exists(path)) {
                using (StreamReader sr = File.OpenText(path)) {
                    string s = "";
                    while ((s = sr.ReadLine()) != null) {
                        artists.Add(s);
                    }
                }
            } else if (!File.Exists(path)) {
                File.Create(path);
            }

        }
        static void Save(string arg) {
            using (StreamWriter sw = File.AppendText(path)) {
                sw.WriteLine(arg);
            }
        }

        static void random() {
            if (artists.Count != 0) {
                artist = artists[(new Random().Next(artists.Count))];
                Console.WriteLine("Your random artist: " + artist);
            } else {
                Console.WriteLine("No artists in the list! Please add some! ");
                new1();
            }

        }

        static void add1() {
            Console.WriteLine("Name of the artist?");
            string add2 = Console.ReadLine();
            if (!artists.Contains(add2)) {
                artists.Add(add2);
                Console.WriteLine("You added " + add2);
                Save(add2);
            } else if (artists.Contains(add2)) {
                Console.WriteLine("This Artist is already in the list");
            }

        }

        static void command() {
            bool i = true;
            while (i) {
                Console.WriteLine("Do you want to add any more artists? y/n");
                string input = Console.ReadLine();
                if (input == ("y")) {
                    i = true;
                    add1();
                } else if (input == ("n")) {
                    i = false;
                } else if (input != ("n") || input != ("y")) {
                    Console.WriteLine("Invalid response!");
                    command();
                }

            }
            random();
        }

        static void new1() {
            Console.WriteLine("Do you want to add Artists? y/n");
            string input = Console.ReadLine();
            if (input == ("y")) {
                add1();
                command();
            } else if (input == ("n")) {
                random();
            } else if (input != ("n") || input != ("y")) {
                Console.WriteLine("Invalid response!");
                new1();
            }

        }
    }
}
