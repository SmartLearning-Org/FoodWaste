using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

///
/// Du skal først bruge denne fil i opgavens anden del
/// 

namespace FoodWaste
{
    public class ChatGptService
    {        
        private Task<string> PromptGpt4Async(string prompt)
        {
            var messages = new Message[]
            {
                    new Message()
                    {
                        role = "user",
                        content = prompt
                    }
            };

            return PromptGpt4Async(messages);

        }

        private async Task<string> PromptGpt4Async(Message[] messages)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage();

            request.Method = HttpMethod.Post;
            request.RequestUri = new Uri("https://smartopenaiproxy.azurewebsites.net/api/OpenAIProxy?key=Jeger1studerende@smartlearning");

            var json = JsonConvert.SerializeObject(new ChatRequest()
            {
                model = "gpt-3.5-turbo",
                messages = messages,
            });

            request.Content = new StringContent(json, Encoding.UTF8, "application/json");
            client.Timeout = TimeSpan.FromSeconds(240);
            var response = await client.SendAsync(request);
            var responseText = await response.Content.ReadAsStringAsync();

            ChatResponse chatResponse = JsonConvert.DeserializeObject<ChatResponse>(responseText);


            string text = chatResponse.choices[0].message.content;
            return text;
        }

        public string GetRecipies()
        {
            var prompt = GetPrompt();
            var response = PromptGpt4Async(prompt).Result;
            return response;
        }
        protected virtual string GetPrompt()
        {

            return "Antag at jeg altid har disse ingredienser i mit køkken: mel, sukker, salt, peber, æg, mælk, smør, kartofler, løg, hvidløg, olivenolie eller solsikkeolie, gær. Giv mig så 3 forskelligeartede opskrifter på retter jeg kan lave ved også at tilføje disse ingredienser: KYLLINGETERN, PISKEFLØDE 38% KAROLINES, HUMMUS ØGO";
        }
    }

    #region Interface til OpenAI

    public class ChatRequest
    {
        public string model { get; set; }
        public Message[] messages { get; set; }
    }

    public class Message
    {
        public string role { get; set; }
        public string content { get; set; }
    }

    public class ChatResponse
    {
        public string id { get; set; }
        public string _object { get; set; }
        public int created { get; set; }
        public string model { get; set; }
        public Usage usage { get; set; }
        public Choice[] choices { get; set; }
    }

    public class Usage
    {
        public int prompt_tokens { get; set; }
        public int completion_tokens { get; set; }
        public int total_tokens { get; set; }
    }

    public class Choice
    {
        public Message message { get; set; }
        public string finish_reason { get; set; }
        public int index { get; set; }
    }

    #endregion
}
