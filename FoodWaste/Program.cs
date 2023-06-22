using FoodWaste;
using Newtonsoft.Json;

using (var client = new HttpClient())
{
    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", "e67702cc-c101-4ad5-83b4-0244e15be504");
    var response = await client.GetAsync("https://api.sallinggroup.com/v1/food-waste/?zip=6000");
    if (response.IsSuccessStatusCode)
    {
        var content = await response.Content.ReadAsStringAsync();
        Class1[] model = JsonConvert.DeserializeObject < Class1[]>(content);
        foreach (var item in model)
        {
            Console.WriteLine(item.store.name);
            foreach(var clearance in item.clearances)
            {
                Console.WriteLine($"- {clearance.product.description} ({clearance.offer.newPrice})");
            }
        }
    }
    else
    {
        Console.WriteLine("Error: " + response.StatusCode);
        Console.WriteLine("Error: " + response.Content);
    }
   
}