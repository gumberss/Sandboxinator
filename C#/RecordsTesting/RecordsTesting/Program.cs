// See https://aka.ms/new-console-template for more information
using RecordsTesting.logic;
using RecordsTesting.models;

Console.WriteLine("Hello, World!");


var p = new Person
{
    Name = "",
    Age = 12,
    Cpf = "123"
};

var m = new Machine
{
    Name = "Printer",
    Mark = "Some"
};

var m2 = NameChanger.ChangeNameRecord(m, "Other Name Machine");
var p2 = NameChanger.ChangeNameRecord(m, "Other Name Person");

Console.WriteLine(m2.Name);
Console.WriteLine(p2.Name);

