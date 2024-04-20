namespace Interfocus
{
    public class Metodos
    {
        public static void IsPar(int numero)
        {
            if (numero % 2 == 0)
            {
                Console.WriteLine("{0} é par", numero);
            }
            else
            {
                Console.WriteLine("{0} é ímpar", numero);
            }
        }

        public void PrintLista(List<string> lista) {
            int a = 0;

            foreach (var item in lista)
            {
                a++;
                Console.WriteLine($"{item}");
            }
        }
    }
}