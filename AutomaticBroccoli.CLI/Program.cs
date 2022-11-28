using System.Text;
using AutomaticBroccoli.CLI;

var openLoopsRepository = new OpenLoopsRepository();
System.Console.WriteLine("what do you disturb"); 

string? note = null;
do
{
    note = Console.ReadLine();
} while (string.IsNullOrWhiteSpace(note));


openLoopsRepository.Add(new OpenLoop
{
    Note = note,
    CreateData = DateTimeOffset.UtcNow
});

{
    var openLoops = openLoopsRepository.Get();

    var group = openLoops.GroupBy(x=> new DateTime(x.CreateData.Year,x.CreateData.Month,x.CreateData.Day));
    foreach (var grouoOfOpenllops in group)
    {
        System.Console.WriteLine($"your disturb for {grouoOfOpenllops.Key:dd.MM.yy}");
        
        foreach (var openLoop in grouoOfOpenllops.ToArray())
        {
             System.Console.WriteLine(openLoop.Note);
        }
       
    }
}
