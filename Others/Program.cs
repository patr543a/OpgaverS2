using System.Text.RegularExpressions;

var r = Reg();

var m = r.Match("AOZ-270");

Console.WriteLine($"Matched? {m.Success}");

partial class Program
{
    [GeneratedRegex("^[A-Z]{3}\\-[1-9][0-9]{2}$")]
    private static partial Regex Reg();
}