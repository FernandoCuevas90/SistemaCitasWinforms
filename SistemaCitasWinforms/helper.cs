using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.IO;

namespace SistemaCitasWinforms
{
    public class Helper
    {
        //Método para guardar
        public static void GuardarEnJson(List<Cita>listaCitas)
        {
            string json = JsonSerializer.Serialize(listaCitas);
            File.WriteAllText("citas.json", json);
        }
        //Método para cargar
        public static List<Cita> CargarDesdeJson()
        {
            if(File.Exists("citas.json"))
            {
                string json = File.ReadAllText("citas.json");
                return JsonSerializer.Deserialize<List<Cita>>(json) ?? new List<Cita>();
            }

            return new List<Cita>();
        }
    }
}
