# nullable enable

using System.Collections.Generic;
using System.Threading;

static async Task<IEnumerable<int>> FetechData(){
    List<int> data = new List<int>();
    for (int i = 0; i <= 10; i++)
    {
        Console.WriteLine("Schedule...");
        await Task.Delay(500);
        data.Add(i);
    }

    await Task.Delay(TimeSpan.FromSeconds(2));
    return data;
}

static IEnumerable<Task<int>> FetechData2(){
    for (int i = 0; i <= 10; i++)
    {
        var task = new Task<int> (() => {
            Thread.Sleep(200);
            return i;
        });
        Console.WriteLine("Schedule...");
        task.Start();
        yield return task;
    }
}

static async IAsyncEnumerable<int> FetechData3(){
    for (int i = 0; i <= 10; i++)
    {
        Console.WriteLine("Schedule...");
        await Task.Delay(500);
        yield return i;
    }
}

await foreach (var item in FetechData3())
{
    Console.WriteLine(item);
}