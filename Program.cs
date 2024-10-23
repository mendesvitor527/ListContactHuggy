// using System;
// using System.Collections.Generic;
// using System.Net.Http;
// using System.Threading.Tasks;
// using Newtonsoft.Json;

// class Program
// {
//     public class Contact
//     {
//         public string id { get; set; }
//         public string name { get; set; }
//         public string email {get; set; }
//     }

//     public static async Task Main(string[] args)
//     {
//         // Chama o método para fazer a requisição e obter os contatos
//         // List<Contact> contacts = await GetContactsFromHuggyApi();

//         // // Exibe o ID e o Nome de cada contato
//         // if (contacts != null)
//         // {
//         //     foreach (var contact in contacts)
//         //     {
//         //         Console.WriteLine($"ID: {contact.id}, Name: {contact.name}");
//         //     }
//         // }
//         // Captura o nome e o email do usuário via console
//         Console.Write("Informe o nome do contato: ");
//         string name = Console.ReadLine();

//         Console.Write("Informe o email do contato: ");
//         string email = Console.ReadLine();

//         // Cria o contato na API Huggy
//         await CreateContact(name, email);
//     }

//     public static async Task<List<Contact>> GetContactsFromHuggyApi()
//     {
//         // URL da API Huggy
//         string url = "https://api.huggy.app/v3/contacts";

//         // Access Token (Bearer)
//         string accessToken = "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsImp0aSI6IjkxZTg0OGI0NDNkNzdmODM3YmM2NTE2NTk3ZWRmYjViYTkxMWU3MmM3ZjVjMWFhMmM0NjdlZjU5ZjAxYzUzODRjOWYzNGVhMzRhYTg3MDRhIn0.eyJhdWQiOiJBUFAtYmViNzU1YmItZTEyMi00YTRmLWFiM2QtNDEzN2IxN2YzMWIwIiwianRpIjoiOTFlODQ4YjQ0M2Q3N2Y4MzdiYzY1MTY1OTdlZGZiNWJhOTExZTcyYzdmNWMxYWEyYzQ2N2VmNTlmMDFjNTM4NGM5ZjM0ZWEzNGFhODcwNGEiLCJpYXQiOjE3Mjk2MzQ4MTEsIm5iZiI6MTcyOTYzNDgxMSwiZXhwIjoxNzYxMTcwODExLCJzdWIiOiIxNTQxMjIiLCJzY29wZXMiOlsiaW5zdGFsbF9hcHAiLCJyZWFkX2FnZW50X3Byb2ZpbGUiXX0.wMAOZaiidfKPF3to2qUkYxbIWQMOooB0s0og_xOElPHIBzjGRVSGH2cEm28dvR9ikx4LxBXmE9ie9WnMCK7UVm6GhiiendpCs3D2YCoQ2x-4k3R9YP8HFGFwiHp2ZU1WyDG4WG92WAS5750blrSe_EnWEhdGKxIHScu2IZDgnlQ";

//         using (HttpClient client = new HttpClient())
//         {
//             // Adiciona o cabeçalho de autorização (Bearer Token)
//             client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);

//             // Adiciona o cabeçalho de Cookie (opcional, depende da necessidade)
//             client.DefaultRequestHeaders.Add("Cookie", "app_powerzap=useus0iqvo8uf72809n3b9bib1");

//             try
//             {
//                 // Faz a requisição GET
//                 HttpResponseMessage response = await client.GetAsync(url);

//                 // Verifica se a resposta foi bem-sucedida
//                 if (response.IsSuccessStatusCode)
//                 {
//                     // Lê o conteúdo da resposta como string
//                     string responseBody = await response.Content.ReadAsStringAsync();

//                     // Desserializa o JSON e armazena apenas os campos "id" e "name"
//                     var contacts = JsonConvert.DeserializeObject<List<Contact>>(responseBody);

//                     return contacts;
//                 }
//                 else
//                 {
//                     Console.WriteLine($"Falha na requisição. Status Code: {response.StatusCode}");
//                     return null;
//                 }
//             }
//             catch (Exception ex)
//             {
//                 Console.WriteLine($"Exceção capturada: {ex.Message}");
//                 return null;
//             }
//         }
//     }

//     public static async Task CreateContact(string name, string email)
//     {
//         // URL da API Huggy
//         string url = "https://api.huggy.app/v3/contacts";

//         // Access Token (Bearer)
//         string accessToken = "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsImp0aSI6IjkxZTg0OGI0NDNkNzdmODM3YmM2NTE2NTk3ZWRmYjViYTkxMWU3MmM3ZjVjMWFhMmM0NjdlZjU5ZjAxYzUzODRjOWYzNGVhMzRhYTg3MDRhIn0.eyJhdWQiOiJBUFAtYmViNzU1YmItZTEyMi00YTRmLWFiM2QtNDEzN2IxN2YzMWIwIiwianRpIjoiOTFlODQ4YjQ0M2Q3N2Y4MzdiYzY1MTY1OTdlZGZiNWJhOTExZTcyYzdmNWMxYWEyYzQ2N2VmNTlmMDFjNTM4NGM5ZjM0ZWEzNGFhODcwNGEiLCJpYXQiOjE3Mjk2MzQ4MTEsIm5iZiI6MTcyOTYzNDgxMSwiZXhwIjoxNzYxMTcwODExLCJzdWIiOiIxNTQxMjIiLCJzY29wZXMiOlsiaW5zdGFsbF9hcHAiLCJyZWFkX2FnZW50X3Byb2ZpbGUiXX0.wMAOZaiidfKPF3to2qUkYxbIWQMOooB0s0og_xOElPHIBzjGRVSGH2cEm28dvR9ikx4LxBXmE9ie9WnMCK7UVm6GhiiendpCs3D2YCoQ2x-4k3R9YP8HFGFwiHp2ZU1WyDG4WG92WAS5750blrSe_EnWEhdGKxIHScu2IZDgnlQ";

//         using (HttpClient client = new HttpClient())
//         {
//             // Adiciona o cabeçalho de autorização (Bearer Token)
//             client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);

//             // Adiciona o cabeçalho de Content-Type para JSON
//             client.DefaultRequestHeaders.Add("Content-Type", "application/json");

//             // Adiciona o cabeçalho de Cookie (opcional, depende da necessidade)
//             client.DefaultRequestHeaders.Add("Cookie", "app_powerzap=useus0iqvo8uf72809n3b9bib1");

//             // Cria o objeto para enviar no corpo da requisição
//             var contactData = new
//             {
//                 name = name,
//                 email = email
//             };

//             // Serializa o objeto para JSON
//             string jsonData = JsonConvert.SerializeObject(contactData);

//             // Converte os dados para StringContent
//             StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

//             try
//             {
//                 // Faz a requisição POST para criar o contato
//                 HttpResponseMessage response = await client.PostAsync(url, content);

//                 // Lê o conteúdo da resposta
//                 string responseBody = await response.Content.ReadAsStringAsync();

//                 if (response.IsSuccessStatusCode)
//                 {
//                     Console.WriteLine("Contato criado com sucesso:");
//                     Console.WriteLine(responseBody);
//                 }
//                 else
//                 {
//                     Console.WriteLine($"Falha ao criar contato. Status Code: {response.StatusCode}");
//                     Console.WriteLine(responseBody);
//                 }
//             }
//             catch (Exception ex)
//             {
//                 Console.WriteLine($"Exceção capturada: {ex.Message}");
//             }
//         }
//     }
// }






// /*
// Access Token def50200d95947fd7d3d75a150772d224585de8187f31816935d61c4db44dec99e9d652df78a147394cf715ee8d1ea6fd29a26e0d6809366a8fbfc5ddfecdbf94b6d76274be570d49778c9c455726a14beedbfd921283d9749f610751e7d34a1f0bc14cd41ca81005b73d94850ea547c0b66ae91fe93db47f65635040aa031cfb14d0ec45472ac93a323933a5288a410c307842c9f2572c9aa52ee310307f201e87a32641ca29daa30f732b1749e57f015887b7512ee975dd9134a5d335625e2a086100c469792a2fbbe1c3fe8c82bda3e18e8ba82c4bea7b2bab37546f901b228410519c4e68a76fdf44b5c80d9833a885165daafb8a8c17292773bd8f65bda13f707a1c6b4e5c782f0ed25173d88b8375542855a8d34cff4476a9078380ece5ee57901354694564dd3bd36288b2a5f20ddc0eba9c3aa98e2350181bf8eb1a376d4e7405e2c1b99b589a460b01fed87aa4b1e1f159360fba9fddcd7085197b93ee3533863e3cb5125ad0188214d707b358ef4b3b19f938d06d2f56eea9cf4eeb2f115b0f1dc311bd992dfde1ef8e82ec743415970f8cacf688a16459c6b1cb8055582ea034069
// &client_id={APP-beb755bb-e122-4a4f-ab3d-4137b17f31b0
// // https://auth.huggy.app/oauth/authorize?scope=install_app%20read_agent_profile&response_type=code&redirect_uri={https://www.kabum.com.br
// */
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

class Program
{
    public static async Task Main(string[] args)
    {
        // Captura o nome e o email do usuário via console
        Console.Write("Informe o nome do contato: ");
        string name = Console.ReadLine();

        Console.Write("Informe o email do contato: ");
        string email = Console.ReadLine();

        // Cria o contato na API Huggy
        await CreateContact(name, email);
    }

    public static async Task CreateContact(string name, string email)
    {
        // URL da API Huggy
        string url = "https://api.huggy.app/v3/contacts";

        // Access Token (Bearer)
        string accessToken = "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsImp0aSI6IjkxZTg0OGI0NDNkNzdmODM3YmM2NTE2NTk3ZWRmYjViYTkxMWU3MmM3ZjVjMWFhMmM0NjdlZjU5ZjAxYzUzODRjOWYzNGVhMzRhYTg3MDRhIn0.eyJhdWQiOiJBUFAtYmViNzU1YmItZTEyMi00YTRmLWFiM2QtNDEzN2IxN2YzMWIwIiwianRpIjoiOTFlODQ4YjQ0M2Q3N2Y4MzdiYzY1MTY1OTdlZGZiNWJhOTExZTcyYzdmNWMxYWEyYzQ2N2VmNTlmMDFjNTM4NGM5ZjM0ZWEzNGFhODcwNGEiLCJpYXQiOjE3Mjk2MzQ4MTEsIm5iZiI6MTcyOTYzNDgxMSwiZXhwIjoxNzYxMTcwODExLCJzdWIiOiIxNTQxMjIiLCJzY29wZXMiOlsiaW5zdGFsbF9hcHAiLCJyZWFkX2FnZW50X3Byb2ZpbGUiXX0.wMAOZaiidfKPF3to2qUkYxbIWQMOooB0s0og_xOElPHIBzjGRVSGH2cEm28dvR9ikx4LxBXmE9ie9WnMCK7UVm6GhiiendpCs3D2YCoQ2x-4k3R9YP8HFGFwiHp2ZU1WyDG4WG92WAS5750blrSe_EnWEhdGKxIHScu2IZDgnlQ";

        using (HttpClient client = new HttpClient())
        {
            // Adiciona o cabeçalho de autorização (Bearer Token)
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);

            // Adiciona o cabeçalho de Cookie (opcional, depende da necessidade)
            client.DefaultRequestHeaders.Add("Cookie", "app_powerzap=useus0iqvo8uf72809n3b9bib1");

            // Cria o objeto para enviar no corpo da requisição
            var contactData = new
            {
                name = name,
                email = email
            };

            // Serializa o objeto para JSON
            string jsonData = JsonConvert.SerializeObject(contactData);

            // Converte os dados para StringContent com o Content-Type correto
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            try
            {
                // Faz a requisição POST para criar o contato
                HttpResponseMessage response = await client.PostAsync(url, content);

                // Lê o conteúdo da resposta
                string responseBody = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Contato criado com sucesso:");
                    Console.WriteLine(responseBody);
                }
                else
                {
                    Console.WriteLine($"Falha ao criar contato. Status Code: {response.StatusCode}");
                    Console.WriteLine(responseBody);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exceção capturada: {ex.Message}");
            }
        }
    }
}