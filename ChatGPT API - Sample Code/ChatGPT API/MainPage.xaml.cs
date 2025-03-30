namespace ChatGPT_API
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void AddChatBubble(string message, bool isUserMessage)
        {
            var chatBubble = new Frame
            {
                BackgroundColor = isUserMessage ? Color.FromArgb("#ADD8E6") : Color.FromArgb("#D3D3D3"),
                CornerRadius = 15,
                Padding = 10,
                HorizontalOptions = isUserMessage ? LayoutOptions.EndAndExpand : LayoutOptions.StartAndExpand,
                VerticalOptions = LayoutOptions.Start,
                Content = new Label
                {
                    Text = message,
                    TextColor = Color.FromArgb("#000000"),
                    LineBreakMode = LineBreakMode.WordWrap
                }
            };

            ChatStackLayout.Children.Add(chatBubble);

            Device.BeginInvokeOnMainThread(() =>
            {
                ChatScrollView.ScrollToAsync(chatBubble, ScrollToPosition.End, true); 
            });
        }

        private async void OnSendButtonClicked(object sender, EventArgs e)
        {
            var userMessage = UserMessageEntry.Text;

            if (string.IsNullOrEmpty(userMessage))
            {
                AddChatBubble("Please enter a message.", isUserMessage: false);
                return;
            }

            SendButton.IsEnabled = false;

            AddChatBubble(userMessage, isUserMessage: true);

            try
            {
                string apiKey = "<YOUR API KEY HERE>";  // Change with your API Key 
                string endpoint = "https://your-endpoint.cognitiveservices.azure.com/";  // Change with your Endpoint 

                var openAIService = new OpenAIService(apiKey, endpoint);
                var response = await openAIService.GetChatbotResponse(userMessage);

                AddChatBubble(response, isUserMessage: false);
            }
            catch (Exception ex)
            {
                AddChatBubble($"Error: {ex.Message}", isUserMessage: false);
            }
            finally
            {
                SendButton.IsEnabled = true;
            }

            UserMessageEntry.Text = string.Empty;
        }
    }
}

