var authors = new List<(int id, string surname, DateTime? dtimeReward)>();
var books = new List<(int id, string title, DateTime dtimeCreate)>();
var links = new List<(int id, int idAuthor, int idBook)>();

authors.Add((0, "Волчановский", new DateTime(2020, 5, 1)));
authors.Add((1, "Ямбиков", new DateTime(2019, 3, 8)));
authors.Add((2, "Иванов", null));
authors.Add((3, "Осковец", new DateTime(1995, 9, 6)));

books.Add((0, "Баллада о офицере", new DateTime(2021, 7, 14)));
books.Add((1, "Баллада о солдате", new DateTime(1998, 7, 17)));
books.Add((2, "Баллада о матросе", new DateTime(2019, 4, 12)));
books.Add((3, "Музыка для всех", new DateTime(1999, 2, 14)));
books.Add((4, "Программирование", new DateTime(2000, 6, 19)));
books.Add((5, "Русские народные сказки", new DateTime(2021, 3, 5)));
books.Add((6, "Русские народные сказки2", new DateTime(2022, 3, 5)));

links.Add((0, 0, 0));
links.Add((1, 0, 1));
links.Add((2, 1, 2));
links.Add((3, 2, 3));
links.Add((4, 3, 4));
links.Add((5, 2, 5));
links.Add((6, 2, 6));
links.Add((7, 3, 6));
links.Add((8, 1, 6));

var fillteredAuthor = authors.Where(x => x.dtimeReward != null);
var filteredBooks = books.Where(x => x.dtimeCreate >= new DateTime(2000, 1, 1));
var resultBooks = new HashSet<(int id, string title, DateTime dtimeCreate)>();

Console.WriteLine("------Решение 1:---------------------------------");

var res1 = fillteredAuthor.Join(links, a => a.id, l => l.idAuthor, (a, l) => new { l.idBook }).
    Join(filteredBooks, j => j.idBook, b => b.id, (j, b) => new { b.title }).Distinct();

foreach (var item in res1)
{
    Console.WriteLine(item.title);
}


Console.WriteLine("------Решение 2:---------------------------------");
foreach (var item in links)
{
    var oneBook = filteredBooks.Where(x => x.id == item.idBook);
    if ((oneBook.Count() > 0) && fillteredAuthor.Where(x => x.id == item.idAuthor).Count() > 0)
    {
        resultBooks.Add(oneBook.First());
    }
}

foreach (var item in resultBooks)
{
    Console.WriteLine(item.title);
}




