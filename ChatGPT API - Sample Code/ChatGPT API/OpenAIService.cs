using Azure;
using Azure.AI.OpenAI;
using OpenAI.Chat;
using System;
using System.ClientModel;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace ChatGPT_API
{
    public class OpenAIService
    {
        private ChatClient _chatClient;
        private readonly string _apiKey;
        private readonly string _endpoint;

        public OpenAIService(string apiKey, string endpoint)
        {
            // Ensure API and Endpoints are valid
            if (string.IsNullOrEmpty(apiKey) || string.IsNullOrEmpty(endpoint))
            {
                throw new ArgumentNullException("API Key and Endpoint cannot be null or empty.");
            }

            _apiKey = apiKey;
            _endpoint = endpoint;
            InitializeChatClient();
        }
        private void InitializeChatClient()
        {
            try
            {
                var azureClient = new AzureOpenAIClient(new Uri(_endpoint), new ApiKeyCredential(_apiKey));
                _chatClient = azureClient.GetChatClient("gpt-35-turbo");  
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error initializing ChatClient: {ex.Message}");
                throw;
            }
        }
        public async Task<string> GetChatbotResponse(string userMessage)
        {
            try
            {
                if (_chatClient == null)
                {
                    throw new InvalidOperationException("ChatClient is not initialized.");
                }
                var messages = new List<ChatMessage>
                {
                    new UserChatMessage(userMessage) 
                };
                var completionResponse = await _chatClient.CompleteChatAsync(messages);
                Console.WriteLine(completionResponse);

                return completionResponse.Value.Content[0].Text;  
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }
    }
}