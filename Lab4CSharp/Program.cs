// See https://aka.ms/new-console-template for more information
using Lab4CSharp;
/// <summary>
///  Top-level statements 
///  Код програми (оператори)  вищого рівня
/// </summary>
///
Console.WriteLine("Lab4 C# ");


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
void AnyFunc2()
{
  
        // Create an instance of the Money class
        Money money = new Money(10, 5);

        // Display information about the money
        Console.WriteLine("Initial Money Information:");
        money.DisplayInfo();
        Console.WriteLine($"Total Amount: {money.TotalAmount}");
        Console.WriteLine($"Is Enough Money: {Money.IsEnoughMoney(50)}");

        // Accessing money using indexers
        Console.WriteLine("\nAccessing Money Using Indexers:");
        Console.WriteLine($"First: {money[0]}, Second: {money[1]}");

        // Modifying money using indexers
        money[0] = 3;
        money[1] = 7;

        Console.WriteLine("Money After Modifying Using Indexers:");
        money.DisplayInfo();

        // Increment and Decrement operators
        Console.WriteLine("\nIncrement and Decrement Operators:");
        money++;
        money.DisplayInfo();

        money--;
        money.DisplayInfo();

        // Logical NOT operator
        Console.WriteLine($"\nLogical NOT Operator: {!money}");

        // Adding money
        Console.WriteLine("\nAdding Money:");
        Money newMoney = money + 2.5;
        Console.WriteLine("Money After Adding:");
        newMoney.DisplayInfo();

        // Changing nominal and num properties
        Console.WriteLine("\nChanging Nominal and Num Properties:");
        money.Nominal = 20;
        money.Num = 3;
        Console.WriteLine("Money After Changing Properties:");
        money.DisplayInfo();
        Console.WriteLine($"Total Amount: {money.TotalAmount}");

        // Calculate items to buy
        Console.WriteLine($"\nCalculating Items to Buy for Amount 60: {Money.CalculateItemsToBuy(60)}");

        // Check if there is enough money for a specific amount
        Console.WriteLine($"Is Enough Money for Amount 25: {money.IsEnoughMoneyThis(25)}");

        // Display the final count
        Console.WriteLine($"\nFinal Count: {Money.Count}");
    


}

void AnyFunc3()
{
    try
    {
        // Creating vectors
        VectorLong vector1 = new VectorLong(5);
        VectorLong vector2 = new VectorLong(5);

        // Initializing vectors
        vector1.FillVectorWithRandomValues();
        vector2.FillVectorWithRandomValues();

        // Displaying vectors
        Console.WriteLine("Vector 1:");
        vector1.DisplayVector();

        Console.WriteLine("\nVector 2:");
        vector2.DisplayVector();

        // Testing various operations
        Console.WriteLine("\nVector addition:");
        VectorLong additionResult = vector1 + vector2;
        additionResult.DisplayVector();

        Console.WriteLine("\nVector subtraction:");
        VectorLong subtractionResult = vector1 - vector2;
        subtractionResult.DisplayVector();

        Console.WriteLine("\nVector multiplication:");
        VectorLong multiplicationResult = vector1 * vector2;
        multiplicationResult.DisplayVector();

        Console.WriteLine("\nScalar multiplication:");
        VectorLong scalarMultiplicationResult = vector1 * 2; // Scalar multiplier
        scalarMultiplicationResult.DisplayVector();

        Console.WriteLine("\nVector division:");
        VectorLong divisionResult = vector1 / vector2;
        divisionResult.DisplayVector();

        Console.WriteLine("\nScalar division:");
        VectorLong scalarDivisionResult = vector1 / 2; // Scalar divisor
        scalarDivisionResult.DisplayVector();

        Console.WriteLine("\nVector modulus operation:");
        VectorLong modulusResult = vector1 % vector2;
        modulusResult.DisplayVector();

        // Testing comparisons
        Console.WriteLine($"\nVector1 > Vector2: {vector1 > vector2}");
        Console.WriteLine($"Vector1 >= Vector2: {vector1 >= vector2}");
        Console.WriteLine($"Vector1 < Vector2: {vector1 < vector2}");
        Console.WriteLine($"Vector1 <= Vector2: {vector1 <= vector2}");
        Console.WriteLine($"Vector1 == Vector2: {vector1 == vector2}");
        Console.WriteLine($"Vector1 != Vector2: {vector1 != vector2}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"An error occurred: {ex.Message}");
    }
}
Console.WriteLine("Problems 1 ");
AnyFunc3();
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
