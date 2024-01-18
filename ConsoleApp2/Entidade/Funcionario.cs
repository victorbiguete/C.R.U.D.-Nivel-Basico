using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp2.Exception;

namespace ConsoleApp2.Entities
{
    internal class Funcionario
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Cidade { get; set; }
        public string Endereco { get; set; }
        public int Telefone { get; set; }

        public Funcionario(string name, string cidade, string endereco, int telefone)
        {
            Name = name;
            Cidade = cidade;
            Endereco = endereco;
            Telefone = telefone;
        }

        public override string? ToString()
        {
            return ($"ID:{Id}\nNome:{Name}\nEndereço:{Endereco}\nCidade:{Cidade}\nTelefone:{Telefone}\n");
        }

        public static string VerificarVazio()
        {
            string entrada = null;
            while (string.IsNullOrWhiteSpace(entrada))
            {
                entrada=Console.ReadLine();
                if (string.IsNullOrWhiteSpace(entrada))
                    throw new DomainException("Entrada Invalida. Digite Novamente:");
            }
            return entrada;
        }
    }
}
