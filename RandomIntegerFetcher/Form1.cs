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
