//A pizza chain wants to know which topping combinations are most popular for Build
//Your Own pizzas.

//Given the sample of orders at [http://files.olo.com/pizzas.json], write an application
//(in C# or JavaScript) to output the top 20 most frequently ordered pizza configurations,
//listing the toppings for each along with the number of times that pizza configuration
//has been ordered.

//Check this link [to read a JSON file] (https://www.newtonsoft.com/json/help/html/DeserializeWithJsonSerializerFromFile.htm)
//in c#. You'll need to install the Newtonsoft.Json nuget package, and create a class
//that represents the pizzas.

//// read file into a string and deserialize JSON to a type
using FavoritePizzaToppings;
using Newtonsoft.Json;

//Movie movie1 = JsonConvert.DeserializeObject<Movie>(File.ReadAllText(@"c:\movie.json"));
List<Pizza> pizzas = JsonConvert.DeserializeObject<List<Pizza>>(File.ReadAllText("C:\\Users\\sarah\\workspace\\c#-collections-linq\\FavoritePizzaToppings\\FavoritePizzaToppings\\pizzas.json"));

Dictionary<string, int> toppingsCounter = new Dictionary<string, int>();

pizzas.ForEach(pizza =>
{
    string toppingsAsString = String.Join(",", pizza.Toppings.OrderByDescending(x => x));
    if (!toppingsCounter.ContainsKey(toppingsAsString))
    {
        toppingsCounter[toppingsAsString] = 1;
    }
    else
    {
        toppingsCounter[toppingsAsString]++;
    };
});

var mostPopularPizzaToppings = toppingsCounter.OrderByDescending(toppingCombo => toppingCombo.Value).Take(1).FirstOrDefault();
var mostTimesOrdered = toppingsCounter.Max(item => item.Value);
Console.WriteLine($"The most popular pizza was ordered {mostTimesOrdered} times.");
Console.WriteLine($"The most popular pizza is {mostPopularPizzaToppings.Key}, and it was ordered {mostPopularPizzaToppings.Value} times.");

/*
Dictionary<Pizza, int> result = new Dictionary<Pizza, int>();

foreach(Pizza pizza in pizzas)
{
    if (result.ContainsKey(pizza))
    {
        result[pizza]++;
    } else
    {
        result.Add(pizza, 1);
    }
}

var groups =
    from p in pizzas
    group p by p into g
    select new
    {
        Topping = g.Key,
        Count = g.Count()
    };

var dictionary = groups.ToDictionary(g => g.Topping, g => g.Count);


var sortedDictionary = dictionary.OrderByDescending(u => u.Value).ToDictionary(z => z.Key, y => y.Value);

for(int i = 0; i < 20; i++)
{
    KeyValuePair<Pizza, int> topping = sortedDictionary.ElementAt(i);
    Console.WriteLine($"{topping.Key}: {topping.Value}");
}

//foreach (var item in keyvalue.OrderByDescending(key => key.Value)){


// deserialize JSON directly from a file
//using (StreamReader file = File.OpenText(@"c:\movie.json"))
//{
//    JsonSerializer serializer = new JsonSerializer();
//    Movie movie2 = (Movie)serializer.Deserialize(file, typeof(Movie));
//}
*/
Console.ReadLine();