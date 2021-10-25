using System.Runtime.CompilerServices;

#nullable enable

Person?[] items = {
    new Person("Шеин", default),
    new Person("Петров", default),
    default};


Assign();

public void Assign(){

    ref var p = ref FindFreePlace();
    p = ref items[0];

    ref Person FindFreePlace([CallerFilePath] string? sourceFilePath = default){
        WriteLine($"Source file {sourceFilePath}");
        return ref Find(items)!;

        static ref T Find<T>(T[] source){
            for(var i = 0; i < source.Length; i++)
            {
                if(source[i] is null){
                    return ref source[i];
                }
            }
            throw new InvalidOperationException(nameof(Find));
        }

    }

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