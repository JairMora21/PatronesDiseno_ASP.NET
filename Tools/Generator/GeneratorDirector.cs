﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.Generator
{
    public  class GeneratorDirector
    {
        private IBuilderGenerator _builder;
        public GeneratorDirector(IBuilderGenerator builder)
        {
            SetBuilder(builder);
        }
        public void SetBuilder(IBuilderGenerator builder)
        {
            _builder = builder;
        }
        public void CreateSimpleJsonGenerator(List<string> content, string path)
        {
            _builder.Reset();
            _builder.SetContent(content);
            _builder.SetPath(path);
            _builder.SetTypeFormat(TypeFormat.Json);
        }
        public void CreateSimplePipeGenerator(List<string> content, string path)
        {
            _builder.Reset();
            _builder.SetContent(content);
            _builder.SetPath(path);
            _builder.SetTypeFormat(TypeFormat.Pipes);
            _builder.SetTypeCharacter(TypeCharacter.UpperCase);
        }
    }
}
