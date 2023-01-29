using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodeHaveD4Quiz.Servis
{
    internal class ShowProgram
    {
        static List<Movie> movieList = new List<Movie>();
        public ShowProgram()
        {
            movieList = new List<Movie>();
        }

        public void Tampilkan()
        {

            while (true)
            {
                Console.WriteLine("Menu Utama");
                Console.WriteLine("1. Daftar Movie");
                Console.WriteLine("2. Tambah Movie");
                Console.WriteLine("3. Exit");

                int menu = Convert.ToInt32(Console.ReadLine());
                if (menu == 1)
                {
                    Console.Clear();
                    ShowMovieList();
                }
                else if (menu == 2)
                {
                    AddMovie();
                }
                else if (menu == 3)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Menu tidak tersedia");
                }
            }
        }

        private void ShowMovieList()
        {
            string stop;

            

            if (movieList.Count == 0)
            {

                Console.Clear();
                Console.WriteLine("Daftar movie tidak tersedia. Silakan tambahkan movie terlebih dahulu.");
                Console.WriteLine("_____________________________________________________________________");
                return;

            }

            Console.WriteLine("Daftar Movie");
            movieList = movieList.OrderByDescending(m => m.Rating).ToList();
            Console.WriteLine("Pringkat. ID--Name Movie--(Ratting)");
            for (int i = 0; i < movieList.Count; i++)
            {
                Console.WriteLine((i + 1) + $".       {movieList[i].ID}     " + movieList[i].Name + "     (" + movieList[i].Rating + ")");
            }
            Console.WriteLine("Mau Vote ? (Y/N)");
            string v = Console.ReadLine().ToLower();
            if (v == "n")
            {
                Console.WriteLine("Yakin mau keluar ? Ketik 'Stop' / enter melanjutkan ");
                stop = Console.ReadLine().ToLower();
                if (stop != "stop") {
                    Console.Clear();
                    ShowMovieList();
                }
                Console.Clear(); return;
                

            }
            Console.WriteLine("Pilih ranking movie untuk memberikan vote:");
            int vote = Convert.ToInt32(Console.ReadLine());


            if (vote < 1 || vote > movieList.Count)
            {
                Console.Clear();
                Console.WriteLine("Nomor movie tidak ditemukan.");

                ShowMovieList();
            }

            movieList[vote - 1].Rating += 0.1m;
            Console.WriteLine("Sukses Vote");
            Console.WriteLine($"Id.{movieList[vote-1].ID}\nJudul: " + movieList[vote - 1].Name + "\nRatting: " + movieList[vote - 1].Rating);

            Console.WriteLine("Mau Vote Rate lagi ? (y/n)");
            string pil = Console.ReadLine().ToLower();
            if (pil == "n")
            {
                Console.WriteLine("Yakin mau keluar ? Ketik 'Stop' / enter melanjutkan Vote ");
                stop = Console.ReadLine().ToLower();
                if (stop != "stop")
                {
                    Console.Clear();
                    ShowMovieList();
                }
                Console.Clear();
                return;
                

            }
            Console.Clear();
            ShowMovieList();

            
        }






        private void AddMovie()
        {
            Console.Clear();
            Console.WriteLine("Masukkan data movie:");
            Console.Write("ID: ");
            int ID = Convert.ToInt32(Console.ReadLine());
            Console.Write("Judul: ");
            string name = Console.ReadLine();
            Console.Write("Rating Awal: ");
            decimal rating = Convert.ToDecimal(Console.ReadLine());

            movieList.Add(new Movie(ID, name, rating));

            Console.WriteLine("Movie berhasil ditambahkan. Apakah ingin menambahkan lagi? (y/n)");
            string again = Console.ReadLine();
            if (again.ToLower() == "n")
            {
                    Console.WriteLine("Yakin mau keluar ? Ketik 'Stop' / enter melanjutkan Add ");
                    string stop = Console.ReadLine().ToLower();
                    if (stop != "stop")
                    {
                        Console.Clear();
                    AddMovie();
                    }
                    Console.Clear();
                    return;

            }
            AddMovie();
        }

        private void Stop()
        {
            Console.WriteLine("Yakin mau keluar ? Ketik 'Stop' / enter melanjutkan ");
            string stop = Console.ReadLine().ToLower();
            if (stop == "stop") { return; }
            
        }
    }
}
