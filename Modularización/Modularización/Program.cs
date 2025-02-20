using System;

class Program
{
    static void Main()
    {
        MenuPrincipal();
    }

    static void MenuPrincipal()
    {
        int opcion;
        do
        {
            Console.WriteLine("===== MENÚ PRINCIPAL =====");
            Console.WriteLine("1) Calculadora");
            Console.WriteLine("2) Validación de contraseña");
            Console.WriteLine("3) Numeros primos");
            Console.WriteLine("4) Suma de numeros pares");
            Console.WriteLine("5) Conversion de temperatura");
            Console.WriteLine("6) Contador de vocales");
            Console.WriteLine("7) Cálculo de factorial");
            Console.WriteLine("8) Juego de adivinanza:");
            Console.WriteLine("9) Paso por referencia:");
            Console.WriteLine("10) Tabla de multiplicar:");
            Console.WriteLine("11) Salir");

            opcion = PedirOpcion(1, 11);

            switch (opcion)
            {
                case 1:
                    Calculadora();
                    break;
                case 2:
                    Validacion();
                    break;
                case 3:
                    Numprimos();
                    break;
                case 4:
                    Numpares();
                    break;
                case 5:
                    Conversioncf();
                    break;
                case 6:
                    ContarVocales();
                    break;
                case 7:
                    Factoriales();
                    break;
                case 8:
                    Adivinanza();
                    break;
                case 9:
                    Referencia();
                    break;
                case 10:
                    Configuracion();
                    break;
                case 11:
                    Console.WriteLine("Saliendo del programa...");
                    break;
            }
        } while (opcion != 11);
    }

    static void Calculadora() { 

       


            double num1 = PedirNumero("Ingrese el primer numero:");
            double num2 = PedirNumero("Ingrese el segundo numero:");

            Console.WriteLine("Elija una operación: 1) Suma 2) Resta 3) Multiplicación 4) División");
            int opcion;
            while (!int.TryParse(Console.ReadLine(), out opcion) || opcion < 1 || opcion > 4)
            {
                Console.WriteLine("Opción no válida. Intente de nuevo:");
            }

            if (opcion == 4)
            {
                while (num2 == 0)
                {
                    Console.WriteLine("Error: No se puede dividir por cero. Ingrese un número distinto de cero:");
                    num2 = PedirNumero("Ingrese un número distinto de cero:");
                }
            }

            double resultado = opcion switch
            {
                1 => Sumar(num1, num2),
                2 => Restar(num1, num2),
                3 => Multiplicar(num1, num2),
                4 => Dividir(num1, num2),
            };

            Console.WriteLine($"El resultado es: {resultado}");
        }

        static double PedirNumero(string mensaje)
        {
            double numero;
            Console.WriteLine(mensaje);
            while (!double.TryParse(Console.ReadLine(), out numero))
            {
                Console.WriteLine("Número no válido. Intente de nuevo:");
            }
            return numero;
        }

        static double Sumar(double a, double b) => a + b;
        static double Restar(double a, double b) => a - b;
        static double Multiplicar(double a, double b) => a * b;
        static double Dividir(double a, double b) => a / b;
    





    static void Validacion() { 

      
            string contraseña;
            do
            {
                Console.Write("Ingrese la contraseña: ");
                contraseña = Console.ReadLine();
                if (contraseña != "1234")
                {
                    Console.WriteLine("Contraseña incorrecta. Intentelo de nuevo.");
                }
            } while (contraseña != "1234");

            Console.WriteLine("Acceso concedido.\n");
        




    }
    static void Numpares() { 
        int suma = 0, numero;
        Console.WriteLine("Ingrese números enteros (0 para terminar):");
        while (int.TryParse(Console.ReadLine(), out numero) && numero != 0)
        {
            if (numero % 2 == 0)
                suma += numero;
        }
        Console.WriteLine($"La suma de los números pares ingresados es: {suma}\n");



    }
    static void Conversioncf() {

        Console.WriteLine("Seleccione la conversión: 1. Celsius a Fahrenheit | 2. Fahrenheit a Celsius");
        string opcion = Console.ReadLine();

        Console.Write("Ingrese la temperatura: ");
        if (double.TryParse(Console.ReadLine(), out double temp))
        {
            double resultado = opcion == "1" ? (temp * 9 / 5) + 32 : (temp - 32) * 5 / 9;
            Console.WriteLine($"Resultado: {resultado}");
        }
        else
        {
            Console.WriteLine("Entrada no válida.");
        }
    


}
    static void Numprimos() { 

        Console.Write("Ingrese un número entero: ");
        if (int.TryParse(Console.ReadLine(), out int numero))
        {
            if (EsPrimo(numero))
                Console.WriteLine($"{numero} es un número primo.");
            else
                Console.WriteLine($"{numero} no es un número primo.");
        }
        else
        {
            Console.WriteLine("Entrada no válida. Intente de nuevo.");
        }
    }

    static bool EsPrimo(int num)
    {
        if (num < 2) return false;
        for (int i = 2; i * i <= num; i++)
        {
            if (num % i == 0)
                return false;
        }
        return true;





    }
    static void ContarVocales() { 
        Console.Write("Ingrese una frase: ");
        string frase = Console.ReadLine();

        int numeroVocales = ContarVocales(frase);
        Console.WriteLine($"Número de vocales: {numeroVocales}");
    }

    static int ContarVocales(string texto)
    {
        int contador = 0;
        foreach (char c in texto.ToLower())
        {
            if ("aeiou".Contains(c))
            {
                contador++;
            }
        }
        return contador;
    }
 
    static void Factoriales() { 

        Console.Write("Ingrese un número entero: ");
        if (int.TryParse(Console.ReadLine(), out int numero))
        {
            Console.WriteLine($"El factorial de {numero} es {Factorial(numero)}");
        }
        else
        {
            Console.WriteLine("Entrada no valida. Intente de nuevo.");
        }
    }

    static long Factorial(int num)
    {
        long resultado = 1;
        for (int i = 2; i <= num; i++)
        {
            resultado *= i;
        }
        return resultado;

    }
    static void Adivinanza() {

        Random random = new Random();
        int numeroAleatorio = random.Next(1, 101);
        int intento;

        Console.WriteLine("Adivina el número entre 1 y 100:");

        do
        {
            Console.Write("Ingrese su intento: ");
            if (!int.TryParse(Console.ReadLine(), out intento))
            {
                Console.WriteLine("Entrada no válida. Intente de nuevo.");
                continue;
            }

            if (intento > numeroAleatorio)
                Console.WriteLine("Demasiado alto. Intente nuevamente.");
            else if (intento < numeroAleatorio)
                Console.WriteLine("Demasiado bajo. Intente nuevamente.");
        } while (intento != numeroAleatorio);

        Console.WriteLine("¡Felicidades! Has adivinado el número.");

    }
    static void Referencia() { 

        Console.Write("Ingrese el primer número: ");
        int.TryParse(Console.ReadLine(), out int num1);

        Console.Write("Ingrese el segundo número: ");
        int.TryParse(Console.ReadLine(), out int num2);

        Console.WriteLine($"Valores originales: num1 = {num1}, num2 = {num2}");

        Intercambiar(ref num1, ref num2);

        Console.WriteLine($"Valores intercambiados: num1 = {num1}, num2 = {num2}");
    }

    static void Intercambiar(ref int a, ref int b)
    {
        int temp = a;
        a = b;
        b = temp;
    }
    static void Configuracion() { 

        Console.Write("Ingrese un número para ver su tabla de multiplicar: ");
        if (int.TryParse(Console.ReadLine(), out int numero))
        {
            int[] tabla = GenerarTablaMultiplicar(numero);
            MostrarTablaMultiplicar(numero, tabla);
        }
        else
        {
            Console.WriteLine("Entrada no válida. Por favor, ingrese un número entero.");
        }
    }

    static int[] GenerarTablaMultiplicar(int num)
    {
        int[] tabla = new int[10];
        for (int i = 0; i < 10; i++)
        {
            tabla[i] = num * (i + 1);
        }
        return tabla;
    }

    static void MostrarTablaMultiplicar(int num, int[] tabla)
    {
        Console.WriteLine($"Tabla de multiplicar del {num}:");
        for (int i = 0; i < tabla.Length; i++)
        {
            Console.WriteLine($"{num} x {i + 1} = {tabla[i]}");
        }


    }

    static int PedirOpcion(int min, int max)
    {
        int opcion;
        while (!int.TryParse(Console.ReadLine(), out opcion) || opcion < min || opcion > max)
        {
            Console.WriteLine("Opción no válida. Intente de nuevo:");
        }
        return opcion;
    }
}
