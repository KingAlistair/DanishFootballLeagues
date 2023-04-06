 - Type system
     League.cs - Line 3, Line 4,

- Null handling
    LeagueProcessor.cs - Line 90,

- String interpolation
    LeagueProcessor.cs - Line 102;

- Pattern Matching


- Classes, structs and enums
    Standing.cs - Line 1,3,

- Properties
    Standing.cs - Line 3

- Named & optional parameters


- Tupples, deconstruction


- Exception
    CSVReader.cs - Line 54-64


- Attributes and DataValidation


- Arrays / Collections
    Program.cs - Line 15

- Ranges
     int[] mySubset = myArray[1..4]; // [2, 3, 4]

- Generics

public class MyGenericClass<T>
{
    private T myProperty;
    public MyGenericClass(T value)
    {
        myProperty = value;
    }
}
MyGenericClass<string> myStringClass = new MyGenericClass<string>("Hello, world!");