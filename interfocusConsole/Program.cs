// See https://aka.ms/new-console-template for more information

using Interfocus;
using InterfocusConsole;
using System.Linq.Expressions;

Console.WriteLine("Hello, World!");

int x11 = 5;
var y = 5;
var soma = x11 + y;

var maiorQueDez = soma > 10;
var impar = soma % 2 == 1;

var comb = maiorQueDez && impar;

if (comb)
{
    Console.WriteLine("é maior que dez e impar");
}
else if (5 == 5)
{
    Console.WriteLine("ele é 5");
}
else
{
    Console.WriteLine("grz");
}



for (int i = 0; i <= 10; i++)
{
    Console.WriteLine("{0:C}", i);
}

var data = new DateTime(2024, 4, 20, 10, 44, 12);
Console.WriteLine("{0}", data);

// CHATBOT ---------------------------------------

//Console.Clear();
//
//
//
//var objeto = new Metodos();
//
// var a1 = new Aluno
//{
//    Nome = "Allan",
//    DataNascimento = new DateTime(2000, 1, 1),
//    Codigo = 1001
//};
//
////chamando o set
//a1.Email = "allanshinhamabelo@gmail.com";
//
////chamando o get
//Console.WriteLine(a1.Email);
//
//var a2 = new Aluno();
//
//Console.WriteLine("Aluno 1: {0}", a1.Nome);
//Console.WriteLine("Aluno 2: {0}", a2.Nome);
//
//Aluno a3 = null;
//
//var b1 = new Bolsista
//{
//    Nome = "Bolsista 1",
//    Codigo = 1002,
//    Desconto = 0.5
//};

//Console.WriteLine("Aluno 3: {0}", a3?.Nome);

Console.Clear();

var alunos = new List<Aluno>();
var lista = new List<string>();
var objeto = new Metodos();

string Input(string message)
{
    Console.WriteLine(message);
    return Console.ReadLine();
}

int codigo = 1000;

while (true)
{
    Console.WriteLine("Digite uma opção: ");
    Console.WriteLine("1 - Verificar número par");
    Console.WriteLine("2 - Adicionar item lista");
    Console.WriteLine("3 - Printar lista");
    Console.WriteLine("4 - Buscar na lista");
    Console.WriteLine("5 - Cadastrar aluno");
    Console.WriteLine("6 - Listar alunos");
    Console.WriteLine("7 - Buscar alunos");
    Console.WriteLine("8 - Excluir aluno");
    Console.WriteLine("0 - Sair");
    var inputValido = int.TryParse(Console.ReadLine(), out int opcao);

    if (!inputValido)
    {
        Console.WriteLine("Input inválido!\n");
        Console.ReadKey();
        continue;
    }

    if (opcao == 0)
    {
        break;
    }

    switch (opcao)
    {
        case 1:
            Console.WriteLine("Digite um num: ");
            var numero = int.Parse(Console.ReadLine());
            Metodos.IsPar(numero);
            break;
        case 2:
            Console.WriteLine("Digite um item: ");
            var item = Console.ReadLine();
            lista.Add(item);
            break;
        case 3:
            objeto.PrintLista(lista);
            break;
        case 4:
            Console.WriteLine("Digite algo para buscar: ");
            var busca = Console.ReadLine();

            var resultado = lista.Where(itemLista => itemLista.Contains(busca)).OrderByDescending(x => x).Select(x => x.ToUpper()).ToList();

            // var sintatico = from a in lista where a.Contains(busca) orderby a descending select a;

            objeto.PrintLista(resultado);
            break;
        case 5:
            var resposta = Input("Aluno bolsista?");

            if (resposta == "S")
            {
                var novoAluno = new Bolsista
                {
                    Nome = Input("Digite o nome do aluno: "),
                    Email = Input("Digite o email do aluno: "),
                    DataNascimento = DateTime.Parse(Input("Digite as data de nascimento: ")),
                    Desconto = double.Parse(Input("Porcentagem de desconto: ")),
                    Codigo = codigo++
                };
                alunos.Add(novoAluno);
            }
            else
            {
                var novoAluno = new Aluno
                {
                    Nome = Input("Digite o nome do aluno: "),
                    Email = Input("Digite o email do aluno: "),
                    DataNascimento = DateTime.Parse(Input("Digite as data de nascimento: ")),
                    Codigo = codigo++
                };
                AlunoService.CriarAluno(novoAluno);
            }
            break;
        case 6:
            foreach (var aluno in AlunoService.Listar())
            {
                aluno.PrintDados();
            }
            break;
        case 7:
            var buscaAluno = Input("Digite a busca: ");
            foreach (var aluno in AlunoService.Listar(buscaAluno))
            {
                aluno.PrintDados();
            }
            break;
        case 8:
            try
            {
                var codigoAluno = int.Parse(Input("Digite o codigo do aluno: "));
                var removido = AlunoService.Remover(codigoAluno);
                if (removido != null)
                {
                    removido.PrintDados();
                }
            }
            catch (FormatException e)
            {
                Console.WriteLine("Digite um valor válido!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Deu ruim {0}", e.Message);
            }
            break;
        default:
            Console.WriteLine("Opção inválida");
            break; 
    }
    Console.ReadKey();
    if (opcao == 1)
    {
        
    }
}
