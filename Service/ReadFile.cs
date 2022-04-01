using System.Collections.Generic;
using System.IO;
using AndreAirLines_API.Data;
using AndreAirLines_API.Model;
using Newtonsoft.Json;

namespace AndreAirLines_API.Insert
{
    public class ReadFile
    {
        public static List<Voo> GetData(string pathFileVoo)
        {
            StreamReader r = new StreamReader(pathFileVoo);
            string jsonString = r.ReadToEnd();
            var lst = JsonConvert.DeserializeObject<List<Voo>>(jsonString) as List<Voo>;
            if (lst != null)
                return lst;
            return null;
        }
    }
    public class InsertJson
    {
        private readonly AndreAirLines_APIContext _context;

        public InsertJson(AndreAirLines_APIContext context)
        {
            _context = context;
        }
        public void Insertion()
        {
            string pathFileVoo = @"C:\Users\Cesar C Siqueira\OneDrive\Documentos\generated.json";
            var lst = ReadFile.GetData(pathFileVoo);
            foreach (var item in lst)
            {
                _context.Voo.Add(item);
            }
        }
    }
}
