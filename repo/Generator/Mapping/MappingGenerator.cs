using repo.Generator.Common;

namespace repo.Generator.Mapping
{
    public class MappingGenerator 
    {
        private ItemTemplate _template;
        private string newLine = Environment.NewLine;
        private Setup _setup = Setup.Init();
        public MappingGenerator(string domainName, List<ItemInput> inputs)
        {
            _template = new ItemTemplate(domainName, inputs);
        }

        public void Build()
        {
            var stringFile = WriteFile();

            File.WriteAllLines(_setup.MappingSetup.path+$"\\{_template.domainName}Mapping.cs", stringFile);
        }

        public string[] WriteFile()
        {
            var list = new List<string>();

            list.AddRange(new string[]
            {
                "using System;",
                "using System.Collections.Generic;",
                "using System.Linq;",
                "using System.Text;",
                "using System.Threading.Tasks;",
                "using Microsoft.EntityFrameworkCore;",
                "using Microsoft.EntityFrameworkCore.Metadata.Builders;",
                newLine,
                $"namespace {_setup.MappingSetup.mappingNameSpace};",
                newLine,
                $"public class {_template.domainName}Mapping : IEntityTypeConfiguration<{_template.domainName}>",
                "{",
                $"  public void Configure(EntityTypeBuilder<{_template.domainName}> builder)",
                "   {",
                "   }",
                "}",

            });
            return list.ToArray();
        }
    }
}
