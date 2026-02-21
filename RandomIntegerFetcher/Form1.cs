using System;
using System.Net.Http;
using System.Windows.Forms;

namespace RandomIntegerFetcher;

public partial class Form1 : Form
{
	private static readonly HttpClient client = new HttpClient();

	public Form1()
	{
		InitializeComponent();
	}

	private async void ButtonGetRandom_Click(object sender, EventArgs e)
	{
		var clickedButton = sender as Button;
		if (!int.TryParse(clickedButton?.Text, out int clickedValue))
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
			buttonGetRandom.Enabled = false;
			button1.Enabled = false;
			labelStatus.Text = "Fetching...";
			labelStatus.ForeColor = System.Drawing.Color.Blue;

			// Fetch random integer from random.org
			string url = "https://www.random.org/integers/?num=1&min=1&max=6&col=1&base=10&format=plain&rnd=new";
			string response = await client.GetStringAsync(url);
			if(!int.TryParse(response.Trim(), out int randomInteger))
				randomInteger = -9999;

			// Deal with the random integer according to the button's text
			const decimal LCM = 6.0M;
			decimal prInteger = Math.Ceiling(randomInteger/LCM*clickedValue);

			// Display the random integer and current date/time
			labelRandomInteger.Text = $"Random Integer: {prInteger}";
			labelDateTime.Text = $"Date & Time: {DateTime.Now:yyyy-MM-dd HH:mm:ss}";
			labelStatus.Text = "Success!";
			labelStatus.ForeColor = System.Drawing.Color.Green;
		}
		catch (Exception ex)
		{
			labelStatus.Text = $"Error: {ex.Message}";
			labelStatus.ForeColor = System.Drawing.Color.Red;
		}
		finally
		{
			buttonGetRandom.Enabled = true;
			button1.Enabled = true;
		}
	}

	private void Form1_Load(object sender, EventArgs e)
	{
		labelStatus.Text = "Ready. Click the button to fetch a random integer.";
		labelStatus.ForeColor = System.Drawing.Color.Black;
	}
}
