using ConsoleApp2.Entities;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ConsoleApp2
{
    public class Projeto
    {
        private List<Funcionario> Lista = new List<Funcionario>();

        public static void Main()
        {
            string opcao;
            Projeto projeto = new Projeto();
            do
            {
                opcao = Menu();

                switch (opcao)
                {
                    case "0":
                        break;
                    case "1":
                        projeto.Cadastrar();
                        break;

                    case "2":
                        projeto.Alterar();
                        break;

                    case "3":
                        projeto.Excluir();
                        break;

                    case "4":
                        projeto.ExibirNome();
                        break;

                    case "5":
                        projeto.ExibirLetra();
                        break;

                    case "6":
                        projeto.ExibirTodos();
                        break;

                    case "7":
                        projeto.ExibirID();
                        break;
                    default:
                        Console.WriteLine("Opção Invalida !");
                        Console.ReadLine();
                        break;
                }
                Console.Clear();
            } while (opcao != "0");
        }

        private static string Menu()
        {
            Console.Write("[1] - Cadastrar Funcionario\n" +
                          "[2] - Alterar Funcionario\n" +
                          "[3] - Excluir Funcionario\n" +
                          "[4] - Exibir Funcionario por Nome\n" +
                          "[5] - Exibir Funcionario por Letra\n" +
                          "[6] - Exibir Todos os Funcionarios\n" +
                          "[7] - Exibir por ID\n" +
                          "[0] - Sair\n" +
                          "Opção: ");

            string opcao = Console.ReadLine();
            Console.Clear();
            return opcao;
        }

        private void Cadastrar()
        {
            Console.WriteLine("Digite o nome do Funcionario:");
            string nome = Console.ReadLine();

            Console.WriteLine("Digite o Endereço:");
            string endereco = Console.ReadLine();

            Console.WriteLine("Digite a Cidade:");
            string cidade = Console.ReadLine();

            Console.WriteLine("Digite o Telefone:");
            int telefone = int.Parse(Console.ReadLine());

            Funcionario funcionario = new Funcionario(nome, cidade, endereco, telefone);

            if (Lista.Count == 0)
                funcionario.Id = 1;
            else
                funcionario.Id = Lista[Lista.Count - 1].Id + 1;

            Lista.Add(funcionario);
        }

        private void Alterar()
        {
            try
            {
                Console.WriteLine("Digite o ID do Funcionario que deseja alterar os dados:");
                int id = int.Parse(Console.ReadLine());

                Funcionario auxiliar = Lista.FirstOrDefault(x => x.Id == id);

                Console.WriteLine(auxiliar.ToString() +
                                  $"Desejar alterar os dados ?[S/N]\n" +
                                  $"Opção: ");

                string opcao = Console.ReadLine().ToUpper();

                if (opcao.Equals("S"))
                {
                    string nome, endereco, cidade;
                    int telefone;

                    do
                    {
                        Console.WriteLine("\n\nDigite o nome do Funcionario:");
                        nome = Console.ReadLine();

                        Console.WriteLine("Digite o Endereço:");
                        endereco = Console.ReadLine();

                        Console.WriteLine("Digite a Cidade:");
                        cidade = Console.ReadLine();

                        Console.WriteLine("Digite o Telefone:");
                        telefone = int.Parse(Console.ReadLine());

                        Console.WriteLine($"Nome:{nome}\n" +
                                      $"Endereço:{endereco}\n" +
                                      $"Cidade:{cidade}\n" +
                                      $"Telefone:{telefone}\n\n" +
                                      $"Confirma os novos dados?[S/N]\n" +
                                      $"Opção");

                        opcao = Console.ReadLine().ToUpper();

                    } while (opcao == "N");

                    auxiliar.Name = nome;
                    auxiliar.Endereco = endereco;
                    auxiliar.Cidade = cidade;
                    auxiliar.Telefone = telefone;

                    Console.WriteLine("Dados alterados com Sucesso");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        private void Excluir()
        {
            try
            {
                Console.WriteLine("Digite o ID do Funcionario que deseja excluir os dados:");
                int id = int.Parse(Console.ReadLine());

                Funcionario auxiliar = Lista.FirstOrDefault(x => x.Id == id);

                Console.WriteLine(auxiliar.ToString() +
                                  $"Desejar excluir os dados ?[S/N]\n" +
                                  $"Opção: ");

                string opcao = Console.ReadLine().ToUpper();

                if (opcao.Equals("S"))
                {
                    Lista.Remove(auxiliar);
                    Console.Write("Remoção bem sucedida");
                    Console.ReadLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void ExibirLetra()
        {
            if (Lista.Count == 0)
                throw new Exception("Lista Vazia");

            Console.Write("Buscar funcionario que tenha a letra: ");
            string letra = Console.ReadLine();

            List<Funcionario> listaBusca = Lista.Where(x => x.Name.Contains(letra)).ToList();

            if (listaBusca.Count == 0)
                throw new Exception("Nenhum dado encontrado");

            foreach (var lista in listaBusca)
                Console.WriteLine(lista.ToString());

            Console.WriteLine("Aperte qualquer tecla para sair");

            Console.ReadLine();
        }

        private void ExibirNome()
        {
            if (Lista.Count == 0)
                throw new Exception("Lista Vazia.\n");

            Console.Write("Buscar funcionario que tenha o Nome: ");
            string Nome = Console.ReadLine();

            List<Funcionario> listaBusca = Lista.Where(x => x.Name.Equals(Nome, StringComparison.OrdinalIgnoreCase)).ToList();

            if (listaBusca.Count == 0)
                throw new Exception("Nenhum dado encontrado.\nPressione qualquer tecla para sair");

            foreach (var lista in listaBusca)
                Console.WriteLine(lista.ToString());

            Console.WriteLine("Aperte qualquer tecla para sair");

            Console.ReadLine();
        }
        private void ExibirTodos()
        {
            if (Lista.Count == 0)
                throw new Exception("Lista vazia");

            foreach (var lista in Lista)
                Console.WriteLine(lista.ToString());

            Console.WriteLine("Aperte qualquer tecla para sair");
            Console.ReadLine();
        }

        private void ExibirID()
        {
            if (Lista.Count == 0)
                throw new Exception("Lista Vazia.");

            Console.Write("Buscar funcionario que tenha o ID: ");
            int Id = int.Parse(Console.ReadLine());

            Funcionario busca = Lista.FirstOrDefault(x => x.Id == Id);

            if (busca == null)
                throw new Exception("Nenhum dado encontrado.");

            Console.WriteLine(busca.ToString());

            Console.WriteLine("Aperte qualquer tecla para sair");

            Console.ReadLine();
        }
    }

}
