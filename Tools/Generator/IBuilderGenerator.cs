using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.Generator
{
    public enum TypeFormat
    {
        Json,
        Pipes
    }

    public enum TypeCharacter
    {
        Normal,
        UpperCase,
        LowerCase
    }

    public interface IBuilderGenerator
    {
        public void Reset();
        
        //Recibiremos el contenido por una lista de strings
        public void SetContent(List<string> content);
        //Esto es donde vamos a guardar el archivo
        public void SetPath(string path);
        //Formato del archivo
        public void SetTypeFormat(TypeFormat typeFormat);
        //Tipo de caracter
        public void SetTypeCharacter(TypeCharacter typeCharacter = TypeCharacter.Normal);
    }
}
