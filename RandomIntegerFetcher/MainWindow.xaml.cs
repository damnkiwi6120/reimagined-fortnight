using System.Net;
using System.Net.Http;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace RandomIntegerFetcher;

public partial class MainWindow : Window
{
	private static readonly HttpClientHandler handler = new()
	{
		AutomaticDecompression = DecompressionMethods.All
	};
	private static readonly HttpClient client = new(handler);

	public MainWindow()
	{
		InitializeComponent();
	}

	private async void ButtonGetRandom_Click(object sender, RoutedEventArgs e)
	{
		var clickedButton = sender as Button;
		if (!int.TryParse(clickedButton?.Content?.ToString(), out int clickedValue))
			clickedValue = -9999;

		//// Properly setting up HttpClient headers
		client.DefaultRequestHeaders.Clear();
		client.DefaultRequestHeaders.Add("Host", "www.random.org");
		client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:149.0) Gecko/20100101 Firefox/149.0");
		client.DefaultRequestHeaders.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8");
		client.DefaultRequestHeaders.Add("Accept-Language", "zh-TW,zh;q=0.9,en-US;q=0.8,en;q=0.7");
		client.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate, br, zstd");
		client.DefaultRequestHeaders.Add("DNT", "1");
		client.DefaultRequestHeaders.Add("Sec-GPC", "1");
		client.DefaultRequestHeaders.Add("Connection", "keep-alive");
		client.DefaultRequestHeaders.Add("Upgrade-Insecure-Requests", "1");
		client.DefaultRequestHeaders.Add("Sec-Fetch-Dest", "document");
		client.DefaultRequestHeaders.Add("Sec-Fetch-Mode", "navigate");
		client.DefaultRequestHeaders.Add("Sec-Fetch-Site", "none");
		client.DefaultRequestHeaders.Add("Priority", "u=0, i");
		client.DefaultRequestHeaders.Add("Pragma", "no-cache");
		client.DefaultRequestHeaders.Add("Cache-Control", "no-cache");
		client.DefaultRequestHeaders.Add("TE", "trailers");

		try
		{
			buttonGetRandom.IsEnabled = false;
			button1.IsEnabled = false;
			labelStatus.Content = "Fetching...";
			labelStatus.Foreground = Brushes.Blue;

			// Fetch random integer from random.org
			string url = "https://www.random.org/integers/?num=1&min=1&max=6&col=1&base=10&format=plain&rnd=new";
			string response = await client.GetStringAsync(url);
			if (!int.TryParse(response.Trim(), out int randomInteger))
				randomInteger = -9999;

			// Deal with the random integer according to the button's text
			const decimal LCM = 6.0M;
			decimal prInteger = Math.Ceiling(randomInteger / LCM * clickedValue);

			// Display the random integer and current date/time
			labelRandomInteger.Content = $"Random Integer: {prInteger}";
			labelDateTime.Content = $"Date & Time: {DateTime.Now:yyyy-MM-dd HH:mm:ss}";
			labelStatus.Content = "Success!";
			labelStatus.Foreground = Brushes.Green;
		}
		catch (Exception ex)
		{
			labelStatus.Content = $"Error: {ex.Message}";
			labelStatus.Foreground = Brushes.Red;
		}
		finally
		{
			buttonGetRandom.IsEnabled = true;
			button1.IsEnabled = true;
		}
	}

	private void Window_Loaded(object sender, RoutedEventArgs e)
	{
		labelStatus.Content = "Ready. Click the button to fetch a random integer.";
		labelStatus.Foreground = Brushes.Black;
	}
}
