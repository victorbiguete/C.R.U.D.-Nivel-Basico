using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Entities
{
    internal class Funcionario
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Cidade { get; set; }
        public string? Endereco { get; set; }
        public int? Telefone { get; set; }

        public Funcionario(string? name, string? cidade, string? endereco, int? telefone)
        {
            Name = name;
            Cidade = cidade;
            Endereco = endereco;
            Telefone = telefone;
        }
    }
}
