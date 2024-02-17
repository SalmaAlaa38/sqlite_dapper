using Dapper;
using Microsoft.Data.Sqlite;
using var Connection = new SqliteConnection("Data Source=test.db");

SelectAllData();
Console.WriteLine("Insert Data");
Console.Write("Name: ");
var name = Console.ReadLine();
InsertData(name);
SelectAllData();
Console.WriteLine("Update Data");
Console.Write("ID: ");
var Id = int.Parse(Console.ReadLine());
Console.WriteLine("Enter New Name:");
var newName = Console.ReadLine();
UpdateData(Id, newName);
SelectAllData();
Console.WriteLine("Delete Data");
Console.Write("ID: ");
var idToDelete = int.Parse(Console.ReadLine());
DeleteData(idToDelete);
SelectAllData();

void SelectAllData() => Connection.Query<t1>("SELECT * from t1").ToList().ForEach(Console.WriteLine);
void InsertData(string name) => Connection.Execute("INSERT INTO t1 (name) VALUES (@name)", new { name });
void UpdateData(int Id, string name) => Connection.Execute("UPDATE t1 SET name = @name WHERE Id = @Id", new { Id, name });
void DeleteData (int Id) => Connection.Execute("DELETE FROM t1 WHERE Id = @Id", new { Id });

record t1
{
    public int ID { get; init; }
    public string name { get; init; }
}