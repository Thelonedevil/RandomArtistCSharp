using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace com.github.thelonedevil.RandomArtistc# {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        static List<string> artists = new List<string>();
        static string artist = "test";
        static string path = "artists.txt";
        // static Process process = new Process();

        static void Main(string[] args) {
            Console.WriteLine("test");
            Load();
            bool h = false;
            /* if (args.Length != 0 && args[0] == ("-h")) {
                 h = true;
             }

              if (process.MainWindowHandle != IntPtr.Zero  && !h) {
                  Application.EnableVisualStyles();
                  Application.SetCompatibleTextRenderingDefault(false);
                  Application.Run(new Form1());
              } else if (process.MainWindowHandle == IntPtr.Zero || h) {
             new1();*/

            //}
        }


        static void Load() {
            if (File.Exists(path)) {
                using (StreamReader sr = File.OpenText(path)) {
                    string s = "";
                    while ((s = sr.ReadLine()) != null) {
                        Console.WriteLine(s);
                    }
                }
            } else if (!File.Exists(path)) {
                File.Create(path);
            }

        }

        static void Save(string arg) {
            if (!File.Exists(path)) {
                using (StreamWriter sw = File.CreateText(path)) {
                    sw.WriteLine(arg);

                }
            }
        }

        static void random() {
            artist = artists.ElementAt(new Random().Next(artists.Capacity));
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

