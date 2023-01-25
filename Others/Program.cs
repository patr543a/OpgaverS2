using System.Text.RegularExpressions;

var r = Reg();

var m = r.Match("AOÅ-270");

Console.WriteLine($"Matched? {m.Success}");

partial class Program
{
    [GeneratedRegex("^[A-Å]{3}\\-[1-9][0-9]{2}$")]
    private static partial Regex Reg();
}