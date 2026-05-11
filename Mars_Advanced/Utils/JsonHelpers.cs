using Mars_Advanced.TestData;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars_Advanced.Utils
{
    public class JsonHelpers
    {
        public string ReadJson(string filename)
        {
            string currentDir = Directory.GetCurrentDirectory();
            string profilePath = Path.Combine(currentDir, "TestData", filename);

            string json = File.ReadAllText(profilePath);

            return json;
        }
    }
}