using EFCorePeliculas.Entitys;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite;
using NetTopologySuite.Geometries;

namespace EFCorePeliculas.Entidades.Seeding
{
    public static class SeedingModuloConsulta
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            var acción = new Genero { Identificador = 1, Name = "Acción" };
            var animación = new Genero { Identificador = 2, Name = "Animación" };
            var comedia = new Genero { Identificador = 3, Name = "Comedia" };
            var cienciaFicción = new Genero { Identificador = 4, Name = "Ciencia ficción" };
            var drama = new Genero { Identificador = 5, Name = "Drama" };

            modelBuilder.Entity<Genero>().HasData(acción, animación, comedia, cienciaFicción, drama);

            var tomHolland = new Actor() { IdActor = 1, Name = "Tom Holland", Born = new DateTime(1996, 6, 1), Bio = "Thomas Stanley Holland (Kingston upon Thames, Londres; 1 de junio de 1996), conocido simplemente como Tom Holland, es un actor, actor de voz y bailarín británico." };
            var samuelJackson = new Actor() { IdActor = 2, Name = "Samuel L. Jackson", Born = new DateTime(1948, 12, 21), Bio = "Samuel Leroy Jackson (Washington D. C., 21 de diciembre de 1948), conocido como Samuel L. Jackson, es un actor y productor de cine, televisión y teatro estadounidense. Ha sido candidato al premio Óscar, a los Globos de Oro y al Premio del Sindicato de Actores, así como ganador de un BAFTA al mejor actor de reparto." };
            var robertDowney = new Actor() { IdActor = 3, Name = "Robert Downey Jr.", Born = new DateTime(1965, 4, 4), Bio = "Robert John Downey Jr. (Nueva York, 4 de abril de 1965) es un actor, actor de voz, productor y cantante estadounidense. Inició su carrera como actor a temprana edad apareciendo en varios filmes dirigidos por su padre, Robert Downey Sr., y en su infancia estudió actuación en varias academias de Nueva York." };
            var chrisEvans = new Actor() { IdActor = 4, Name = "Chris Evans", Born = new DateTime(1981, 06, 13) };
            var laRoca = new Actor() { IdActor = 5, Name = "Dwayne Johnson", Born = new DateTime(1972, 5, 2) };
            var auliCravalho = new Actor() { IdActor = 6, Name = "Auli'i Cravalho", Born = new DateTime(2000, 11, 22) };
            var scarlettJohansson = new Actor() { IdActor = 7, Name = "Scarlett Johansson", Born = new DateTime(1984, 11, 22) };
            var keanuReeves = new Actor() { IdActor = 8, Name = "Keanu Reeves", Born = new DateTime(1964, 9, 2) };

            modelBuilder.Entity<Actor>().HasData(tomHolland, samuelJackson,
                            robertDowney, chrisEvans, laRoca, auliCravalho, scarlettJohansson, keanuReeves);
            var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);

            var agora = new Cine() { CineId = 1, NombreCine = "Agora Mall", MyProperty = geometryFactory.CreatePoint(new Coordinate(-69.9388777, 18.4839233)) };
            var sambil = new Cine() { CineId = 2, NombreCine = "Sambil", MyProperty = geometryFactory.CreatePoint(new Coordinate(-69.911582, 18.482455)) };
            var megacentro = new Cine() { CineId = 3, NombreCine = "Megacentro", MyProperty = geometryFactory.CreatePoint(new Coordinate(-69.856309, 18.506662)) };
            var acropolis = new Cine() { CineId = 4, NombreCine = "Acropolis", MyProperty = geometryFactory.CreatePoint(new Coordinate(-69.939248, 18.469649)) };

            var agoraCineOferta = new CineOferta { Id = 1, CineId = agora.CineId, FechaInicio = DateTime.Today, FechaFin = DateTime.Today.AddDays(7), PorcentajeDescuento = 10 };

            var salaDeCine2DAgora = new SalaDeCine()
            {
                SalaId = 1,
                CineId = agora.CineId,
                Precio = 220,
                TipoSala = TipoSala.DosDimensiones
            };
            var salaDeCine3DAgora = new SalaDeCine()
            {
                SalaId = 2,
                CineId = agora.CineId,
                Precio = 320,
                TipoSala = TipoSala.TresDimensiones
            };

            var salaDeCine2DSambil = new SalaDeCine()
            {
                SalaId = 3,
                CineId = sambil.CineId,
                Precio = 200,
                TipoSala = TipoSala.DosDimensiones
            };
            var salaDeCine3DSambil = new SalaDeCine()
            {
                SalaId = 4,
                CineId = sambil.CineId,
                Precio = 290,
                TipoSala = TipoSala.TresDimensiones
            };


            var salaDeCine2DMegacentro = new SalaDeCine()
            {
                SalaId = 5,
                CineId = megacentro.CineId,
                Precio = 250,
                TipoSala = TipoSala.DosDimensiones
            };
            var salaDeCine3DMegacentro = new SalaDeCine()
            {
                SalaId = 6,
                CineId = megacentro.CineId,
                Precio = 330,
                TipoSala = TipoSala.TresDimensiones
            };
            var salaDeCineCXCMegacentro = new SalaDeCine()
            {
                SalaId = 7,
                CineId = megacentro.CineId,
                Precio = 450,
                TipoSala = TipoSala.CXC
            };

            var salaDeCine2DAcropolis = new SalaDeCine()
            {
                SalaId = 8,
                CineId = acropolis.CineId,
                Precio = 250,
                TipoSala = TipoSala.DosDimensiones
            };

            var acropolisCineOferta = new CineOferta { Id = 2, CineId = acropolis.CineId, FechaInicio = DateTime.Today, FechaFin = DateTime.Today.AddDays(5), PorcentajeDescuento = 15 };

            modelBuilder.Entity<Cine>().HasData(acropolis, sambil, megacentro, agora);
            modelBuilder.Entity<CineOferta>().HasData(acropolisCineOferta, agoraCineOferta);
            modelBuilder.Entity<SalaDeCine>().HasData(salaDeCine2DMegacentro, salaDeCine3DMegacentro, salaDeCineCXCMegacentro, salaDeCine2DAcropolis, salaDeCine2DAgora, salaDeCine3DAgora, salaDeCine2DSambil, salaDeCine3DSambil);


            var avengers = new Pelicula()
            {
                PeliculaId = 1,
                Titulo = "Avengers",
                EnCartelera = false,
                FechaEstreno = new DateTime(2012, 4, 11),
                PosterURL = "https://upload.wikimedia.org/wikipedia/en/8/8a/The_Avengers_%282012_film%29_poster.jpg",
            };

            var entidadGeneroPelicula = "GeneroPelicula";
            var generoIdPropiedad = "GenerosIdentificador";
            var peliculaIdPropiedad = "PeliculasId";

            var entidadSalaDeCinePelicula = "PeliculaSalaDeCine";
            var salaDeCineIdPropiedad = "SalasDeCineId";

            modelBuilder.Entity(entidadGeneroPelicula).HasData(
                new Dictionary<string, object> { [generoIdPropiedad] = acción.Identificador, [peliculaIdPropiedad] = avengers.PeliculaId },
                new Dictionary<string, object> { [generoIdPropiedad] = cienciaFicción.Identificador, [peliculaIdPropiedad] = avengers.PeliculaId }
            );

            var coco = new Pelicula()
            {
                PeliculaId = 2,
                Titulo = "Coco",
                EnCartelera = false,
                FechaEstreno = new DateTime(2017, 11, 22),
                PosterURL = "https://upload.wikimedia.org/wikipedia/en/9/98/Coco_%282017_film%29_poster.jpg"
            };

            modelBuilder.Entity(entidadGeneroPelicula).HasData(
               new Dictionary<string, object> { [generoIdPropiedad] = animación.Identificador, [peliculaIdPropiedad] = coco.PeliculaId }
           );

            var noWayHome = new Pelicula()
            {
                PeliculaId = 3,
                Titulo = "Spider-Man: No way home",
                EnCartelera = false,
                FechaEstreno = new DateTime(2021, 12, 17),
                PosterURL = "https://upload.wikimedia.org/wikipedia/en/0/00/Spider-Man_No_Way_Home_poster.jpg"
            };

            modelBuilder.Entity(entidadGeneroPelicula).HasData(
               new Dictionary<string, object> { [generoIdPropiedad] = cienciaFicción.Identificador, [peliculaIdPropiedad] = noWayHome.PeliculaId },
               new Dictionary<string, object> { [generoIdPropiedad] = acción.Identificador, [peliculaIdPropiedad] = noWayHome.PeliculaId },
               new Dictionary<string, object> { [generoIdPropiedad] = comedia.Identificador, [peliculaIdPropiedad] = noWayHome.PeliculaId }
           );

            var farFromHome = new Pelicula()
            {
                PeliculaId = 4,
                Titulo = "Spider-Man: Far From Home",
                EnCartelera = false,
                FechaEstreno = new DateTime(2019, 7, 2),
                PosterURL = "https://upload.wikimedia.org/wikipedia/en/0/00/Spider-Man_No_Way_Home_poster.jpg"
            };

            modelBuilder.Entity(entidadGeneroPelicula).HasData(
               new Dictionary<string, object> { [generoIdPropiedad] = cienciaFicción.Identificador, [peliculaIdPropiedad] = farFromHome.PeliculaId },
               new Dictionary<string, object> { [generoIdPropiedad] = acción.Identificador, [peliculaIdPropiedad] = farFromHome.PeliculaId },
               new Dictionary<string, object> { [generoIdPropiedad] = comedia.Identificador, [peliculaIdPropiedad] = farFromHome.PeliculaId }
           );

            // Para matrix pongo la fecha en el futuro

            var theMatrixResurrections = new Pelicula()
            {
                PeliculaId = 5,
                Titulo = "The Matrix Resurrections",
                EnCartelera = true,
                FechaEstreno = new DateTime(2100, 1, 1),
                PosterURL = "https://upload.wikimedia.org/wikipedia/en/5/50/The_Matrix_Resurrections.jpg",
            };

            modelBuilder.Entity(entidadGeneroPelicula).HasData(
              new Dictionary<string, object> { [generoIdPropiedad] = cienciaFicción.Identificador, [peliculaIdPropiedad] = theMatrixResurrections.PeliculaId },
              new Dictionary<string, object> { [generoIdPropiedad] = acción.Identificador, [peliculaIdPropiedad] = theMatrixResurrections.PeliculaId },
              new Dictionary<string, object> { [generoIdPropiedad] = drama.Identificador, [peliculaIdPropiedad] = theMatrixResurrections.PeliculaId }
          );

            modelBuilder.Entity(entidadSalaDeCinePelicula).HasData(
             new Dictionary<string, object> { [salaDeCineIdPropiedad] = salaDeCine2DSambil.SalaId, [peliculaIdPropiedad] = theMatrixResurrections.PeliculaId },
             new Dictionary<string, object> { [salaDeCineIdPropiedad] = salaDeCine3DSambil.SalaId, [peliculaIdPropiedad] = theMatrixResurrections.PeliculaId },
             new Dictionary<string, object> { [salaDeCineIdPropiedad] = salaDeCine2DAgora.SalaId, [peliculaIdPropiedad] = theMatrixResurrections.PeliculaId },
             new Dictionary<string, object> { [salaDeCineIdPropiedad] = salaDeCine3DAgora.SalaId, [peliculaIdPropiedad] = theMatrixResurrections.PeliculaId },
             new Dictionary<string, object> { [salaDeCineIdPropiedad] = salaDeCine2DMegacentro.SalaId, [peliculaIdPropiedad] = theMatrixResurrections.PeliculaId },
             new Dictionary<string, object> { [salaDeCineIdPropiedad] = salaDeCine3DMegacentro.SalaId, [peliculaIdPropiedad] = theMatrixResurrections.PeliculaId },
             new Dictionary<string, object> { [salaDeCineIdPropiedad] = salaDeCineCXCMegacentro.SalaId, [peliculaIdPropiedad] = theMatrixResurrections.PeliculaId }
         );


            var keanuReevesMatrix = new PeliculaActor
            {
                ActorId = keanuReeves.IdActor,
                PeliculaId = theMatrixResurrections.PeliculaId,
                Orden = 1,
                Personaje = "Neo"
            };

            var avengersChrisEvans = new PeliculaActor
            {
                ActorId = chrisEvans.IdActor,
                PeliculaId = avengers.PeliculaId,
                Orden = 1,
                Personaje = "Capitán América"
            };

            var avengersRobertDowney = new PeliculaActor
            {
                ActorId = robertDowney.IdActor,
                PeliculaId = avengers.PeliculaId,
                Orden = 2,
                Personaje = "Iron Man"
            };

            var avengersScarlettJohansson = new PeliculaActor
            {
                ActorId = scarlettJohansson.IdActor,
                PeliculaId = avengers.PeliculaId,
                Orden = 3,
                Personaje = "Black Widow"
            };

            var tomHollandFFH = new PeliculaActor
            {
                ActorId = tomHolland.IdActor,
                PeliculaId = farFromHome.PeliculaId,
                Orden = 1,
                Personaje = "Peter Parker"
            };

            var tomHollandNWH = new PeliculaActor
            {
                ActorId = tomHolland.IdActor,
                PeliculaId = noWayHome.PeliculaId,
                Orden = 1,
                Personaje = "Peter Parker"
            };

            var samuelJacksonFFH = new PeliculaActor
            {
                ActorId = samuelJackson.IdActor,
                PeliculaId = farFromHome.PeliculaId,
                Orden = 2,
                Personaje = "Samuel L. Jackson"
            };

            modelBuilder.Entity<Pelicula>().HasData(avengers, coco, noWayHome, farFromHome, theMatrixResurrections);
            modelBuilder.Entity<PeliculaActor>().HasData(samuelJacksonFFH, tomHollandFFH, tomHollandNWH, avengersRobertDowney, avengersScarlettJohansson,
                avengersChrisEvans, keanuReevesMatrix);

        }
    }
}
