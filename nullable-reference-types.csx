using System;
using System.Diagnostics.CodeAnalysis;

// Включаем поддержку Nullable reference types
#nullable enable

// default - передача значения по умолчанию для типа
var person = new Person("Eugene", default);

// Результат вывода Eugene так как LastName is null 
Console.WriteLine(person.ShortName);

// Результат Last name is empty
if(string.IsNullOrEmpty(person.LastName)){
    Console.WriteLine("Last name is empty");
}
else {
    Console.WriteLine($"Last name is not empty ({person.LastName})");
}

// Условие не выполняется
if(person.LastName is {Length: > 0} name){
    Console.WriteLine($"Last name is {name}");
}

if(TryGetName(out var firstName)){
    Console.WriteLine($"Try first name is {firstName}");
}

Console.WriteLine($"Try first name length is {firstName!.Length}");

bool TryGetName([NotNullWhen(true)] out string? name){
    name = "Eugene";
    return true;
}

public class Person
{
    public Person(string firstName, string? lastName) => 
        (FirstName, LastName) = (firstName, lastName);

    public string FirstName { get; set; }

    // Nullable reference
    public string? LastName { get; set; }

    public string ShortName => $"{FirstName} {LastName?[0]}";
}