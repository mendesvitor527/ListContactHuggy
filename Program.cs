using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

class Program
{
    public class Contact
    {
        public string id { get; set; }
        public string name { get; set; }
        public string email {get; set; }
    }

    public static async Task Main(string[] args)
    {
        //Chama o método para fazer a requisição e obter os contatos
        List<Contact> contacts = await GetContactsFromHuggyApi();

        // Exibe o ID e o Nome de cada contato
        if (contacts != null)
        {
            foreach (var contact in contacts)
            {
                Console.WriteLine($"ID: {contact.id}, Name: {contact.name}");
            }
        }
       
    }

    public static async Task<List<Contact>> GetContactsFromHuggyApi()
    {
        // URL da API Huggy
        string url = "https://api.huggy.app/v3/contacts";

        List<Contact> emptyContact = new List<Contact>();

        // Access Token (Bearer)
        string accessToken = "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsImp0aSI6IjkxZTg0OGI0NDNkNzdmODM3YmM2NTE2NTk3ZWRmYjViYTkxMWU3MmM3ZjVjMWFhMmM0NjdlZjU5ZjAxYzUzODRjOWYzNGVhMzRhYTg3MDRhIn0.eyJhdWQiOiJBUFAtYmViNzU1YmItZTEyMi00YTRmLWFiM2QtNDEzN2IxN2YzMWIwIiwianRpIjoiOTFlODQ4YjQ0M2Q3N2Y4MzdiYzY1MTY1OTdlZGZiNWJhOTExZTcyYzdmNWMxYWEyYzQ2N2VmNTlmMDFjNTM4NGM5ZjM0ZWEzNGFhODcwNGEiLCJpYXQiOjE3Mjk2MzQ4MTEsIm5iZiI6MTcyOTYzNDgxMSwiZXhwIjoxNzYxMTcwODExLCJzdWIiOiIxNTQxMjIiLCJzY29wZXMiOlsiaW5zdGFsbF9hcHAiLCJyZWFkX2FnZW50X3Byb2ZpbGUiXX0.wMAOZaiidfKPF3to2qUkYxbIWQMOooB0s0og_xOElPHIBzjGRVSGH2cEm28dvR9ikx4LxBXmE9ie9WnMCK7UVm6GhiiendpCs3D2YCoQ2x-4k3R9YP8HFGFwiHp2ZU1WyDG4WG92WAS5750blrSe_EnWEhdGKxIHScu2IZDgnlQ";

        using (HttpClient client = new HttpClient())
        {
            // Adiciona o cabeçalho de autorização (Bearer Token)
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);

            // Adiciona o cabeçalho de Cookie (opcional, depende da necessidade)
            client.DefaultRequestHeaders.Add("Cookie", "app_powerzap=useus0iqvo8uf72809n3b9bib1");

            try
            {
                // Faz a requisição GET
                HttpResponseMessage response = await client.GetAsync(url);

                // Verifica se a resposta foi bem-sucedida
                if (response.IsSuccessStatusCode)
                {
                    // Lê o conteúdo da resposta como string
                    string responseBody = await response.Content.ReadAsStringAsync();

                    // Desserializa o JSON e armazena apenas os campos "id" e "name"
                    var contacts = JsonConvert.DeserializeObject<List<Contact>>(responseBody);

                    return contacts;
                }
                else
                {
                    Console.WriteLine($"Falha na requisição. Status Code: {response.StatusCode}");
                    return emptyContact;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exceção capturada: {ex.Message}");
                return emptyContact;
            }
        }
    }
}
