// See https://aka.ms/new-console-template for more information
Console.WriteLine("Qual o salário? ");
double salario = double.Parse(Console.ReadLine());
Console.WriteLine(" o salario é: " + salario);

double salarioReajustado = salario * 1.1;
Console.WriteLine(" o salario é: " + salarioReajustado);