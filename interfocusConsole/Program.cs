/*bool b = true;
double d = 1.25;

var lista = new List<string>();
lista.Add("Item 1");
lista.Add("1235");

var lista2 = lista;

lista2.Add("grfds");

Console.WriteLine($"Lista: {lista.Count} Lista 2: {lista2.Count}");


var x = 5;
var y = x;
var soma = x + y;

var maiorQueDez = soma > 10;
var impar = soma % 2 == 1;

var comb = maiorQueDez && impar;

if (comb)
{
    Console.WriteLine("é maior que dez e impar");
} else if (x == 5)
{
    Console.WriteLine("ele é 5");
} else
{
    Console.WriteLine("grz");
}



for (int i = 0; i <= 10; i++)
{
    Console.WriteLine("{0:C}", i);
}

var data = new DateTime(2024, 4, 20, 10, 44, 12);
Console.WriteLine("{0}", data);

*/


// CHATBOT

using Interfocus;

Console.Clear();

var lista = new List<string>();
var objeto = new Metodos();

while (true)
{
    Console.WriteLine("Digite uma opção: ");
    Console.WriteLine("1 - Verificar número par");
    Console.WriteLine("2 - Adicionar item lista");
    Console.WriteLine("3 - Printar lista");
    Console.WriteLine("4 - Buscar na lista");
    Console.WriteLine("5 - Remover um item da lista");
    Console.WriteLine("0 - Sair");
    var inputValido = int.TryParse(Console.ReadLine(), out int opcao);

    if (!inputValido)
    {
        Console.WriteLine("Input inválido!");
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
            Console.WriteLine("Digite o indice do item: ");
            var index = int.Parse(Console.ReadLine());
            var removido = lista[index - 1];
            Console.WriteLine("Removendo: {0}", removido);

            lista.RemoveAt(index - 1);
            break;
    }
}
