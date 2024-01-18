using ConsoleApp2.Entities;
using ConsoleApp2.Exception;
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
            bool flag;
            do
            {
                flag = false;
                try
                {
                    int telefone;
                    Console.WriteLine("Digite o nome do Funcionario:");
                    string nome = Funcionario.VerificarVazio();

                    Console.WriteLine("Digite o Endereço:");
                    string endereco = Funcionario.VerificarVazio();

                    Console.WriteLine("Digite a Cidade:");
                    string cidade = Funcionario.VerificarVazio();

                    Console.WriteLine("Digite o Telefone:");
                    while (!int.TryParse(Console.ReadLine(), out telefone))
                        throw new DomainException("Telefone Invalido, Digite Novamente");

                    Funcionario funcionario = new Funcionario(nome, cidade, endereco, telefone);

                    if (Lista.Count == 0)
                        funcionario.Id = 1;
                    else
                        funcionario.Id = Lista[Lista.Count - 1].Id + 1;
                    Console.WriteLine("Cadastro Concluido");

                    Lista.Add(funcionario);
                }
                catch (DomainException e)
                {
                    Console.WriteLine(e.Message);
                    flag = true;
                }
            } while (flag == true);

            Console.WriteLine("Aperte Qualquer Tecla para Sair");
            Console.ReadLine();
        }

        private void Alterar()
        {
            bool flag;
            int id;
            do
            {
                flag = false;
                try
                {
                    Console.WriteLine("Digite o ID do Funcionario que deseja alterar os dados:");
                    while (int.TryParse(Console.ReadLine(), out id))
                        throw new DomainException("Formatação de entrada incorreta, digite apenas numeros");

                    Funcionario? auxiliar = Lista.FirstOrDefault(x => x.Id == id);

                    if (auxiliar == null)
                        throw new DomainException("Funcionario não encontrado, digite novamente");

                    Console.WriteLine(auxiliar.ToString() +
                                      $"Desejar alterar os dados ?[S/N]\n" +
                                      $"Opção: ");

                    string opcao = Funcionario.VerificarVazio().ToUpper();

                    if (opcao.Equals("S"))
                    {
                        string nome, endereco, cidade;
                        int telefone;

                        do
                        {
                            Console.WriteLine("\n\nDigite o nome do Funcionario:");
                            nome = Funcionario.VerificarVazio();

                            Console.WriteLine("Digite o Endereço:");
                            endereco = Funcionario.VerificarVazio();

                            Console.WriteLine("Digite a Cidade:");
                            cidade = Funcionario.VerificarVazio();

                            Console.WriteLine("Digite o Telefone:");
                            while (!int.TryParse(Console.ReadLine(), out telefone))
                                throw new DomainException("Telefone Invalido, Digite Novamente");

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
                catch (DomainException ex)
                {
                    flag = true;
                    Console.WriteLine(ex.Message);
                }
            } while (flag == true);

            Console.WriteLine("Aperte qualquer tecla para sair");

            Console.ReadLine();
        }
        private void Excluir()
        {
            bool flag;
            int id;
            do
            {
                flag = false;
                try
                {
                    Console.WriteLine("Digite o ID do Funcionario que deseja excluir os dados:");
                    while (int.TryParse(Console.ReadLine(), out id))
                        throw new DomainException("ID invalido, digite novamente");

                    Funcionario? auxiliar = Lista.FirstOrDefault(x => x.Id == id);

                    Console.WriteLine(auxiliar.ToString() +
                                      $"Desejar excluir os dados ?[S/N]\n" +
                                      $"Opção: ");

                    string opcao = Funcionario.VerificarVazio().ToUpper();

                    if (opcao.Equals("S"))
                    {
                        Lista.Remove(auxiliar);
                        Console.Write("Remoção bem sucedida");
                        Console.ReadLine();
                    }
                }
                catch (DomainException ex)
                {
                    Console.WriteLine(ex.ToString());
                    flag = true;
                }
            } while (flag == true);

            Console.WriteLine("Aperte qualquer tecla para sair");

            Console.ReadLine();
        }

        private void ExibirLetra()
        {
            bool flag;
            do
            {
                flag = false;
                try
                {
                    if (Lista.Count == 0)
                        throw new DomainException("Lista Vazia");

                    Console.Write("Buscar funcionario que tenha a letra: ");
                    string letra = Funcionario.VerificarVazio(); ;

                    List<Funcionario> listaBusca = Lista.Where(x => x.Name.Contains(letra)).ToList();

                    if (listaBusca.Count == 0)
                        throw new DomainException("Nenhum dado encontrado");

                    foreach (var lista in listaBusca)
                        Console.WriteLine(lista.ToString());
                }
                catch (DomainException e)
                {
                    Console.WriteLine(e.Message);
                    flag = true;
                }
            } while (flag == true && Lista.Count > 0);

            Console.WriteLine("Aperte qualquer tecla para sair");

            Console.ReadLine();
        }

        private void ExibirNome()
        {
            bool flag;

            
            do
            {
                flag = false;

                if (Lista.Count == 0)
                    throw new DomainException("Lista Vazia.\n");
                try
                {
                    Console.Write("Buscar funcionario que tenha o Nome: ");
                    string Nome = Funcionario.VerificarVazio();

                    List<Funcionario> listaBusca = Lista.Where(x => x.Name.Equals(Nome, StringComparison.OrdinalIgnoreCase)).ToList();

                    if (listaBusca.Count == 0)
                        throw new DomainException("Nenhum dado encontrado.\nPressione qualquer tecla para sair");

                    foreach (var lista in listaBusca)
                        Console.WriteLine(lista.ToString());
                }
                catch (DomainException e)
                {
                    Console.WriteLine(e.Message);
                    flag = true;
                }
            } while (flag == true && Lista.Count>0);

            Console.WriteLine("Aperte qualquer tecla para sair");

            Console.ReadLine();
        }
        private void ExibirTodos()
        {
            try
            {
                if (Lista.Count == 0)
                    throw new DomainException("Lista vazia");

                foreach (var lista in Lista)
                    Console.WriteLine(lista.ToString());
            }
            catch (DomainException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("Aperte qualquer tecla para sair");
            Console.ReadLine();
        }

        private void ExibirID()
        {
            try
            {
                int Id;
                if (Lista.Count == 0)
                    throw new DomainException("Lista Vazia.");


                Console.Write("Buscar funcionario que tenha o ID:");
                while (!int.TryParse(Console.ReadLine(), out Id))
                    throw new DomainException("ID invalido, digita novamente");

                Funcionario? busca = Lista.FirstOrDefault(x => x.Id == Id);

                if (busca == null)
                    throw new DomainException("Nenhum dado encontrado.");

                Console.WriteLine(busca.ToString());
            }
            catch (DomainException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("Aperte qualquer tecla para sair");
            Console.ReadLine();
        }
    }

}
