using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Tools.Generator
{
    public class Generator
    {

        public List<string> Content { get; set; }
        public string Path { get; set;}
        public TypeFormat TypeFormat { get; set; }
        public TypeCharacter TypeCharacter { get; set; }

        public void Save()
        {
            string result = "";
            result = TypeFormat.Json == TypeFormat ? GetJson() : GetPipe();

            if(TypeCharacter == TypeCharacter.UpperCase) result = result.ToUpper();
            if (TypeCharacter == TypeCharacter.LowerCase) result = result.ToLower();

            File.WriteAllText(Path, result);
        }

        private string GetJson() => JsonSerializer.Serialize(Content);

        private string GetPipe() => Content.Aggregate((accum, current) => accum + "|" + current);
    }
}
