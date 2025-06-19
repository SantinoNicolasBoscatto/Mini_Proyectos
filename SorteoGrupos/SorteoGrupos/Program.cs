
using SorteoGrupos;
using SorteoGrupos.Equipos;
using SorteoGrupos.Grupos;
using System.Text.RegularExpressions;


var listaGrupos = new List<Grupos>();
for (int i = 0; i < 8; i++)
    listaGrupos.Add(new Grupos($"Grupo {(i + 1)}"));
void SortearBombo(List<Equipos> bombo)
{
    var contador = 0;
    while (bombo.Count > 0)
    {
        contador++;
        var random = new Random();
        int numero = random.Next(0, bombo.Count);

        var equipoBolilla = bombo[numero];
        var bd = false;
        var contaGrupos = contador;
        do
        {
            var contaInterno = 0;
            foreach (var equiposGrupo in listaGrupos[contaGrupos - 1].ListaEquipos)
            {
                if (equipoBolilla.Pais == equiposGrupo.Pais)
                {
                    bd = true;
                    contaGrupos++;
                    break;
                }
                contaInterno++;

            }
            if (bd == true && contaInterno == listaGrupos[contaGrupos - 1].ListaEquipos.Count) bd = false;
        } while (bd);

        listaGrupos[contaGrupos - 1].ListaEquipos.Add(equipoBolilla);
        bombo.Remove(equipoBolilla);
    }
}
var bombo1 = new List<Equipos>
{
    new Equipos
    {
        Id = 1,
        Nombre = "Botafogo",
        Pais = "BRA"
    },
    new Equipos
    {
        Id = 2,
        Nombre = "River",
        Pais = "ARG"
    },
    new Equipos
    {
        Id = 3,
        Nombre = "Palmeiras",
        Pais = "BRA"
    },
    new Equipos
    {
        Id = 4,
        Nombre = "Flamengo",
        Pais = "BRA"
    },
    new Equipos
    {
        Id = 5,
        Nombre = "Peñarol",
        Pais = "URU"
    },
    new Equipos
    {
        Id = 6,
        Nombre = "Nacional",
        Pais = "URU"
    },
    new Equipos
    {
        Id = 7,
        Nombre = "Sao Paulo",
        Pais = "BRA"
    },
    new Equipos
    {
        Id = 8,
        Nombre = "Racing",
        Pais = "ARG"
    }
};
var bombo2 = new List<Equipos>
{
    new Equipos
    {
        Id = 9,
        Nombre = "Olimpia",
        Pais = "PAR"
    },
    new Equipos
    {
        Id = 10,
        Nombre = "Liga de Quito",
        Pais = "ECU"
    },
    new Equipos
    {
        Id = 11,
        Nombre = "Internacionale",
        Pais = "BRA"
    },
    new Equipos
    {
        Id = 12,
        Nombre = "Libertad",
        Pais = "PAR"
    },
    new Equipos
    {
        Id = 13,
        Nombre = "IDV",
        Pais = "ECU"
    },
    new Equipos
    {
        Id = 14,
        Nombre = "Colo-Colo",
        Pais = "CHI"
    },
    new Equipos
    {
        Id = 15,
        Nombre = "Estudiantes",
        Pais = "ARG"
    },
    new Equipos
    {
        Id = 16,
        Nombre = "Bolivar",
        Pais = "BOL"
    }
};
var bombo3 = new List<Equipos>
{
    new Equipos
    {
        Id = 17,
        Nombre = "Velez",
        Pais = "ARG"
    },
    new Equipos
    {
        Id = 18,
        Nombre = "SP Cristal",
        Pais = "PER"
    },
    new Equipos
    {
        Id = 19,
        Nombre = "Fortaleza",
        Pais = "BRA"
    },
    new Equipos
    {
        Id = 20,
        Nombre = "Universidad",
        Pais = "PER"
    },
    new Equipos
    {
        Id = 21,
        Nombre = "Talleres",
        Pais = "ARG"
    },
    new Equipos
    {
        Id = 22,
        Nombre = "ATL Nacional",
        Pais = "COL"
    },
    new Equipos
    {
        Id = 23,
        Nombre = "Deportivo Tachira",
        Pais = "VEN"
    },
    new Equipos
    {
        Id = 24,
        Nombre = "U de Chile",
        Pais = "CHI"
    }
};
var bombo4 = new List<Equipos>
{
    new Equipos
    {
        Id = 25,
        Nombre = "Carabobo",
        Pais = "VEN"
    },
    new Equipos
    {
        Id = 26,
        Nombre = "Bucaramanga",
        Pais = "COL"
    },
    new Equipos
    {
        Id = 27,
        Nombre = "San Antonio Bulo Bulo",
        Pais = "BOL"
    },
    new Equipos
    {
        Id = 28,
        Nombre = "Central Cordoba",
        Pais = "ARG"
    },
    new Equipos
    {
        Id = 29,
        Nombre = "Alianza Lima",
        Pais = "PER"
    },
    new Equipos
    {
        Id = 30,
        Nombre = "Bahia",
        Pais = "BRA"
    },
    new Equipos
    {
        Id = 31,
        Nombre = "Cerro Porteño",
        Pais = "PAR"
    },
    new Equipos
    {
        Id = 32,
        Nombre = "Barcelona",
        Pais = "ECU"
    }
};






List<List<Equipos>> bombos = new List<List<Equipos>> { bombo1, bombo2, bombo3, bombo4 };
SorteoLibertadores sorteo = new SorteoLibertadores(bombos, 4);
sorteo.RealizarSorteo();
sorteo.MostrarGrupos();
