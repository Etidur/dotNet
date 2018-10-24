using System;
using System.Linq;
using System.Collections.Generic;
using TP2Console.Models.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace TP2Console
{
    class Program
    {

        static void Main(string[] args)
        {
            //Exo2Q1();
            //Exo2Q2();
            //Exo2Q3();
            //Exo2Q4();
            //Exo2Q5();
            //Exo2Q6();
            //Exo2Q7();
            //Exo2Q8();
            //Exo2Q9();
            //Exo3Q1();
            Exo3Q2();
        }

        private static void Exo3Q3()
        {
/*            var ctx = new FilmsDBContext();

            var film = ctx.Film.Where(f => f.Nom.Equals("L'armee des douze singes")).First();

            var avis = ctx.Avis
                .Include(a => a.Film)
                .Where(f => f.Film.Equals(film.Id)).ToList();
                /
            Console.WriteLine(avis);
/*
            ctx.Avis.RemoveRange(avis);
            ctx.Film.Remove(film);
            ctx.SaveChanges();
            */
            //Console.ReadKey();
        }

        private static void Exo3Q2()
        {
            var ctx = new FilmsDBContext();

            var film = ctx.Film.Where(f => f.Nom.Equals("L'armee des douze singes")).First();
            var categorie = ctx.Categorie.Where(c => c.Nom.Equals("Drame")).First();

            film.Description = "Il y a des singes";
            film.Categorie = categorie.Id;
            ctx.SaveChanges();

            Console.WriteLine(film);
            Console.ReadKey();
        }
        

        private static void Exo3Q1()
        {
            var ctx = new FilmsDBContext();

            var usr = new Utilisateur()
            {
                Login = "Etidur",
                Email = "e@e.fr",
                Pwd = "1234"
            };

            ctx.Utilisateur.Add(usr);
            ctx.SaveChanges();
            Console.WriteLine("User " + usr.Login + " rajouté");

            Console.ReadKey();
        }
        

        private static void Exo2Q9()
        {
            var ctx = new FilmsDBContext();
            
            var utilisateur = ctx.Utilisateur
                .Include(u => u.Avis)
                .OrderByDescending(u => u.Avis.Max(a => a.Note)).First();

            Console.WriteLine(utilisateur.Login);

            Console.ReadKey();
        }

        private static void Exo2Q8()
        {
            var ctx = new FilmsDBContext();
            var filmPulpFiction = ctx.Film
                .Include(f => f.Avis)
                .First(f => f.Nom.ToLower().Equals("pulp fiction"));

            Console.WriteLine(filmPulpFiction.Avis.Average(a => a.Note));

            Console.ReadKey();
        }

        private static void Exo2Q7()
        {
            var ctx = new FilmsDBContext();

            foreach (var film in ctx.Film.Where(f => f.Nom.StartsWith("ve")))
            {
                Console.WriteLine(film);
            }
            
            Console.ReadKey();
        }

        private static void Exo2Q6()
        {
            var ctx = new FilmsDBContext();
            
            Console.WriteLine(ctx.Avis.Min(a => a.Note));

            Console.ReadKey();
        }
        

        private static void Exo2Q5()
        {
            var ctx = new FilmsDBContext();
            
            Console.WriteLine(ctx.Categorie.Count());

            Console.ReadKey();
        }

        private static void Exo2Q4()
        {
            var ctx = new FilmsDBContext();
            var categorieAction = ctx.Categorie
                .Include(c => c.Film)
                .First(c => c.Nom == "Action");
            
            foreach (var film in categorieAction.Film)
            {
                Console.WriteLine(film.Id + " : " + film.Nom);
            }

            Console.ReadKey();
        }

        private static void Exo2Q3()
        {
            var ctx = new FilmsDBContext();

            foreach (var utilisateur in ctx.Utilisateur.OrderBy(c => c.Login))
            {
                Console.WriteLine(utilisateur.Login);
            }

            Console.ReadKey();
        }
        

        private static void Exo2Q2()
        {
            var ctx = new FilmsDBContext();

            foreach (var utilisateur in ctx.Utilisateur)
            {
                Console.WriteLine("Email : " + utilisateur.Email);
            }

            Console.ReadKey();
        }


        public static void Exo2Q1()
        {
            var ctx = new FilmsDBContext();
            foreach (var film in ctx.Film)
            {
                Console.WriteLine(film.ToString());
            }
            Console.ReadKey();
        }
        //Autre possibilité :
        public static void Exo2Q1Bis()
        {
            var ctx = new FilmsDBContext();
            //Pour que cela marche, il faut que la requête envoie les mêmes noms de que les classes c#.
            var films = ctx.Film.FromSql("SELECT * FROM film");

            foreach (var film in films)
            {
                Console.WriteLine(film.ToString());
            }
            Console.ReadKey();
        }

        static void Main5(string[] args)
        {
            // Chargement explicite à la main
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            int count = 0;
            double sum = 0;
            string dummy = "";
            using (var ctx = new FilmsDBContext())
            {
                foreach (var u in ctx.Utilisateur)
                {
                    foreach (var a in u.Avis)
                    {
                        count++;
                        sum += a.Note;
                        dummy += a.FilmNavigation.Nom.Substring(0, 2);
                    }
                }
            }
            stopwatch.Stop();
            int mean = (int)((sum / count) * 5);
            Console.WriteLine("Chargement explicite à la main - Calcul de la moyenne en {0}", stopwatch.Elapsed);
            // Chargement explicite
            stopwatch = new Stopwatch();
            stopwatch.Start();
            count = 0;
            sum = 0;
            dummy = "";
            using (var ctx = new FilmsDBContext())
            {
                foreach (var u in ctx.Utilisateur)
                {
                    //1 Utilisateur a plusieurs avis => Collection
                    ctx.Entry(u).Collection(util => util.Avis).Load();
                    foreach (var a in u.Avis)
                    {
                        // 1 avis a 1 film => Reference
                        ctx.Entry(a).Reference(f => f.FilmNavigation).Load();
                        count++;
                        sum += a.Note;
                        dummy += a.FilmNavigation.Nom.Substring(0, 2);
                    }
                }
            }

            stopwatch.Stop();
            mean = (int)((sum / count) * 5);
            Console.WriteLine("Chargement explicite avec Reference et Collection - Calcul de la moyenne en {0}", stopwatch.Elapsed);
            // Chargement hatif
            stopwatch = new Stopwatch();
            stopwatch.Start();
            count = 0;
            sum = 0;
            dummy = "";
            using (var ctx = new FilmsDBContext())
            {
                foreach (var u in
               ctx.Utilisateur.Include(u => u.Avis).ThenInclude(a => a.FilmNavigation).ToList())
                {
                    foreach (var a in u.Avis)
                    {
                        count++;
                        sum += a.Note;
                        dummy += a.FilmNavigation.Nom.Substring(0, 2);
                    }
                }
            }
            stopwatch.Stop();
            mean = (int)((sum / count) * 5);
            Console.WriteLine("Chargement Hatif - Calcul de la moyenne en {0}",
           stopwatch.Elapsed);
            Console.ReadKey();
        }
        static void Main4(string[] args)
        {
            using (var ctx = new FilmsDBContext())
            {
                //Chargement de la catégorie Action et des films de cette catégorie
                Categorie categorieAction = ctx.Categorie
                 .Include(c => c.Film)
                 .First(c => c.Nom == "Action");
                Console.WriteLine("Categorie : " + categorieAction.ToString());
                Console.WriteLine("Films : ");
                foreach (var film in categorieAction.Film)
                {
                    Console.WriteLine(film.ToString());
                }
            }

            Console.ReadKey();
        }

        static void Main3bis(string[] args)
        {
            using (var ctx = new FilmsDBContext())
            {
                Categorie categorieAction = ctx.Categorie.First(c => c.Nom == "Action");
                Console.WriteLine("Categorie : " + categorieAction.ToString());
                //Chargement des films dans categorieAction
                ctx.Entry(categorieAction).Collection(c => c.Film).Load();
                Console.WriteLine("Films : ");
                foreach (var film in categorieAction.Film)
                {
                    Console.WriteLine(film.ToString());
                }
            }

            Console.ReadKey();
        }

        static void Main3(string[] args)
        {
            using (var ctx = new FilmsDBContext())
            {
                //Chargement de la catégorie Action
                Categorie categorieAction = ctx.Categorie.First(c => c.Nom == "Action");
                Console.WriteLine("Categorie : " + categorieAction.ToString());
                Console.WriteLine("Films : ");
                //Chargement des films de la catégorie Action.
                foreach (var film in ctx.Film.Where(f => f.CategorieNavigation.Nom ==
                categorieAction.Nom).ToList())
                {
                    Console.WriteLine(film.ToString());
                }
            }

            Console.ReadKey();
        }

        static void Main2bis(string[] args)
        {
            using (var ctx = new FilmsDBContext())
            {
                //Select
                Categorie categorieAction = ctx.Categorie.AsNoTracking().First(c => c.Nom == "Action");

                //Modification
                categorieAction.Description = "Nouvelle description des films d'action. Date :" + DateTime.Now;

                //Sauvegarde du contexte
                int nbChanges = ctx.SaveChanges();

                Console.WriteLine("Nombre d'enregistrements modifiés : " + nbChanges);
            }

            Console.ReadKey();
        }

        static void Main2(string[] args)
        {
            using (var ctx = new FilmsDBContext())
            {
                ctx.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
                //Select
                Categorie categorieAction = ctx.Categorie.First(c => c.Nom == "Action");

                //Modification
                categorieAction.Description = "Nouvelle description des films d'action. Date :" + DateTime.Now;

                //Sauvegarde du contexte
                int nbChanges = ctx.SaveChanges();

                Console.WriteLine("Nombre d'enregistrements modifiés : " + nbChanges);
            }

            Console.ReadKey();
        }

        static void Main1(string[] args)
        {
            using (var ctx = new FilmsDBContext())
            {
                //Select
                Categorie categorieAction = ctx.Categorie.First(c => c.Nom == "Action");

                //Modification
                categorieAction.Description = "Nouvelle description des films d'action. Date :" + DateTime.Now;

                //Sauvegarde du contexte
                int nbChanges = ctx.SaveChanges();

                Console.WriteLine("Nombre d'enregistrements modifiés : " + nbChanges);
            }

            Console.ReadKey();
        }
    }
}
