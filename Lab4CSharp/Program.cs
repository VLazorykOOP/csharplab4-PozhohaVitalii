// See https://aka.ms/new-console-template for more information
using Lab4CSharp;
/// <summary>
///  Top-level statements 
///  Код програми (оператори)  вищого рівня
/// </summary>
///
Console.WriteLine("Lab4 C# ");
AnyFunc1();

/// <summary>
/// 
///  Top-level statements must precede namespace and type declarations.
/// At the top-level methods/functions can be defined and used
/// На верхньому рівні можна визначати та використовувати методи/функції
/// </summary>
void AnyFunc1()
{
    Console.WriteLine(" Some function in top-level");
    try
    {
        // Creating matrices
        MatrixLong matrix1 = new MatrixLong(3, 3);
        MatrixLong matrix2 = new MatrixLong(3, 3);

        // Initializing matrices
        matrix1.FillMatrixWithRandomValues();
        matrix2.FillMatrixWithRandomValues();

        // Displaying matrices
        Console.WriteLine("Matrix 1:");
        matrix1.DisplayMatrix();

        Console.WriteLine("\nMatrix 2:");
        matrix2.DisplayMatrix();

        // Testing various operations
        Console.WriteLine("\nMatrix addition:");
        MatrixLong additionResult = matrix1 + matrix2;
        additionResult.DisplayMatrix();

        Console.WriteLine("\nMatrix subtraction:");
        MatrixLong subtractionResult = matrix1 - matrix2;
        subtractionResult.DisplayMatrix();

        Console.WriteLine("\nMatrix multiplication:");
        MatrixLong multiplicationResult = matrix1 * matrix2;
        multiplicationResult.DisplayMatrix();

        Console.WriteLine("\nScalar multiplication:");
        MatrixLong scalarMultiplicationResult = matrix1 * 2; // Scalar multiplier
        scalarMultiplicationResult.DisplayMatrix();

        Console.WriteLine("\nMatrix division:");
        MatrixLong divisionResult = matrix1 / matrix2;
        divisionResult.DisplayMatrix();

        Console.WriteLine("\nScalar division:");
        MatrixLong scalarDivisionResult = matrix1 / 2; // Scalar divisor
        scalarDivisionResult.DisplayMatrix();

        Console.WriteLine("\nMatrix modulus operation:");
        MatrixLong modulusResult = matrix1 % matrix2;
        modulusResult.DisplayMatrix();

        // Testing comparisons
        Console.WriteLine($"\nMatrix1 > Matrix2: {matrix1 > matrix2}");
        Console.WriteLine($"Matrix1 >= Matrix2: {matrix1 >= matrix2}");
        Console.WriteLine($"Matrix1 < Matrix2: {matrix1 < matrix2}");
        Console.WriteLine($"Matrix1 <= Matrix2: {matrix1 <= matrix2}");
        Console.WriteLine($"Matrix1 == Matrix2: {matrix1 == matrix2}");
        Console.WriteLine($"Matrix1 != Matrix2: {matrix1 != matrix2}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"An error occurred: {ex.Message}");
    }
}
Console.WriteLine("Problems 1 ");
AnyFunc1();
//  приклад класів
UserClass cl = new UserClass();
cl.Name = " UserClass top-level ";
Lab4CSharp.UserClass cl2 = new Lab4CSharp.UserClass();
cl2.Name = " UserClass namespace Lab4CSharp ";
Console.WriteLine(cl + "   " + cl2 + "   ");



/// <summary>
/// 
/// Top-level statements must precede namespace and type declarations.
/// Оператори верхнього рівня мають передувати оголошенням простору імен і типу.
/// Створення класу(ів) або оголошенням простору імен є закіченням  іструкцій верхнього рівня
/// 
/// </summary>

class UserClass
{
    public string Name { get; set; }
};
