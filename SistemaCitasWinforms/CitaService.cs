using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Text;

namespace SistemaCitasWinforms
{
    public class CitaService
    {
        private List<Cita> listaCitas;

        public CitaService(List<Cita> lista)
        {
            listaCitas = lista;
        }

        public bool EsIdDuplicado(int id, int indiceActual)
        {
            for (int i = 0; i < listaCitas.Count; i++)
            {
                if (i != indiceActual && listaCitas[i].Id == id)
                {
                    return true;
                }
            }
            return false;
        }
        public bool EsIdDuplicado(int id)
        {
            foreach (Cita c in listaCitas)
            {
                if (c.Id == id)
                {
                    return true;
                }
            }
            return false;
        }

        public int BuscarIndicePorId(int id)
        {
            for (int i = 0; i < listaCitas.Count; i++)
            {
                if (listaCitas[i].Id == id)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
