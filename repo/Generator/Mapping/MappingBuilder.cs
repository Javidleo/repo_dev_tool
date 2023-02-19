using repo.Generator.Common;

namespace repo.Generator.Mapping
{
    public class MappingBuilder
    {
        private ItemTemplate _template;
        private string newLine = Environment.NewLine;
        private Setup _setup = Setup.Init();

        public MappingBuilder Once(string domainName)
        {
            _template = new ItemTemplate(domainName);
            return this;
        }

        public void BuildOne()
        {
            var stringFile = Write();

            File.WriteAllLines(_setup.MappingSetup.path + $"\\{_template.DomainName}Mapping.cs", stringFile);
        }

        private string[] Write()
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
                $"public class {_template.DomainName}Mapping : IEntityTypeConfiguration<{_template.DomainName}>",
                "{",
                $"   public void Configure(EntityTypeBuilder<{_template.DomainName}> builder)",
                "   {",
                "   }",
                "}",
            });
            return list.ToArray();
        }
    }
}
