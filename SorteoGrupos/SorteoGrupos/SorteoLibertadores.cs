using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SorteoGrupos
{
    public class SorteoLibertadores
    {
        private List<List<Equipos.Equipos>> bombos;
        private List<Grupos.Grupos> grupos;

        public SorteoLibertadores(List<List<Equipos.Equipos>> bombos, int cantidadGrupos)
        {
            this.bombos = bombos;
            this.grupos = new List<Grupos.Grupos>();
            for (int i = 1; i <= cantidadGrupos; i++)
            {
                grupos.Add(new Grupos.Grupos($"Grupo {i}"));
            }
        }

        public void RealizarSorteo()
        {
            foreach (var bombo in bombos)
            {
                foreach (var equipo in bombo)
                {
                    AsignarAGrupo(equipo);
                }
            }
            VerificarUltimosGrupos();
        }

        private void AsignarAGrupo(Equipos.Equipos equipo)
        {
            for (int i = 0; i < grupos.Count; i++)
            {
                if (!grupos[i].ListaEquipos.Any(e => e.Pais == equipo.Pais))
                {
                    grupos[i].ListaEquipos.Add(equipo);
                    return;
                }
            }
        }

        private void VerificarUltimosGrupos()
        {
            int penultimo = grupos.Count - 2;
            int ultimo = grupos.Count - 1;
            var equipoPenultimo = grupos[penultimo].ListaEquipos.LastOrDefault();
            var equipoUltimo = grupos[ultimo].ListaEquipos.LastOrDefault();

            if (equipoPenultimo != null && equipoUltimo != null &&
                grupos[ultimo].ListaEquipos.Any(e => e.Pais == equipoUltimo.Pais))
            {
                grupos[ultimo].ListaEquipos.Remove(equipoUltimo);
                grupos[ultimo].ListaEquipos.Add(equipoPenultimo);
                grupos[penultimo].ListaEquipos.Remove(equipoPenultimo);
                grupos[penultimo].ListaEquipos.Add(equipoUltimo);
            }
        }

        public void MostrarGrupos()
        {
            foreach (var grupo in grupos)
            {
                Console.WriteLine($"{grupo.Nombre}:");
                foreach (var equipo in grupo.ListaEquipos)
                {
                    Console.WriteLine($" - {equipo.Nombre} ({equipo.Pais})");
                }
                Console.WriteLine();
            }
        }
    }
}
