using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.Generator
{
    public class GeneratorConcreteBuilder : IBuilderGenerator
    {

        private Generator _generator;

        public GeneratorConcreteBuilder()
        {
            Reset();
        }

        public void Reset() => _generator = new Generator();

        public void SetContent(List<string> content) => _generator.Content = content;


        public void SetPath(string path) => _generator.Path = path;

        public void SetTypeFormat(TypeFormat typeFormat) => _generator.TypeFormat = typeFormat;

        public void SetTypeCharacter(TypeCharacter typeCharacter) => _generator.TypeCharacter = typeCharacter;

        public Generator GetGenerator() => _generator;
    }
}