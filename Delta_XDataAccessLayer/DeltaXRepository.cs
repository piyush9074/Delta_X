
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Delta_XDataAccessLayer.Models;

namespace Delta_XDAL
{
    public class DeltaXRepository
    {
        delta_xContext context;

        public DeltaXRepository()
        {
            context = new delta_xContext();
        }

        public List<AddMovieWithActorList> GetAllMovies()
        {
            List<AddMovieWithActorList> t = new List<AddMovieWithActorList>();
            var movieList = (from mov in context.Movie
                             orderby mov.Id
                             select mov).ToList();
            //var actorlist = (from act in context.movieactordetails
            //                 where act.fkactorid = mov)
            foreach (Movie m in movieList)
            {
                t.Add(new AddMovieWithActorList
                {
                    Id = m.Id,
                    Name = m.Name,
                    DateOfRelease = m.DateOfRelease,
                    FkProducer = m.FkProducer,
                    Plot = m.Plot,
                    Actors = GetActorsListByMovie(m.Name)
                }) ;
            }
            
            return t;
        }

        public List<string>GetActorsListByMovie(string moviename)
        {
            var ret = (from act in context.MovieActor
                       where act.MovieName == moviename
                       select act.ActorName).ToList();
            return ret;
        }

        public List<Actor> GetAllActors()
        {
            var actorList = (from act in context.Actor
                             orderby act.Id
                             select act).ToList();
            return actorList;
        }

        public List<Producer> GetAllProducer()
        {
            var producerList = (from pro in context.Producer
                                orderby pro.Id
                                select pro).ToList();
            return producerList;
        }

        public bool AddMovie(Movie mo, List<string> actors)
        {
            bool status = false;
           try
            {

                context.Movie.Add(mo);
                context.SaveChanges();
                
                foreach (string a in actors)
                {
                    context.MovieActor.Add(new MovieActor
                    {
                        ActorName = a,
                        MovieName = mo.Name
                    }
                ) ;
                    context.SaveChanges();
                }
                status = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                status = false;
            }
            return status;
        }
        public bool EditMovie(int id,Movie mo, List<string> actors)
        {
            bool status = false;
            Movie m = context.Movie.Find(id);
            //if (m != null) { Console.WriteLine("Movie Found: " + m.Name); };
            //if (m == null) { Console.WriteLine("Movie not Found: "); };
            try
            {
                if (m != null)
                {
                    List<MovieActor> ma = context.MovieActor.Where(p => p.MovieName == m.Name).ToList();
                    if (ma != null) { context.MovieActor.RemoveRange(ma); }
                    context.Movie.Remove(m);
                    context.SaveChanges();
                    Movie nmov = new Movie();
                    nmov.Name = mo.Name;
                    nmov.FkProducer = mo.FkProducer;
                    nmov.DateOfRelease = mo.DateOfRelease;
                    nmov.Plot = mo.Plot;
                    context.Movie.Add(nmov);
                    context.SaveChanges();
                    foreach (string a in actors)
                    {
                        context.MovieActor.Add(new MovieActor
                        {
                            ActorName = a,
                            MovieName = mo.Name
                        }
                    );
                        context.SaveChanges();
                    }
                    status = true;
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e);
            }
            return status;
        }

        public bool AddMovieActor(MovieActor ma)
        {
            bool status = false;

            try
            {
                //context.Categories.Add(category);
                context.MovieActor.Add(ma);
                context.SaveChanges();
                status = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                status = false;
            }
            return status;
        }


        public bool AddActor(Actor act)
        {
            bool status = false;

            try
            {
                //context.Categories.Add(category);
                context.Actor.Add(act);
                context.SaveChanges();
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }


        public bool AddProducer(Producer pro)
        {
            bool status = false;

            try
            {
                //context.Categories.Add(category);
                context.Producer.Add(pro);
                context.SaveChanges();
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }

       



    }
}
