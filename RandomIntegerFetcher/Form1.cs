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

	private async void buttonGetRandom_Click(object sender, EventArgs e)
	{
		try
		{
			buttonGetRandom.Enabled = false;
			labelStatus.Text = "Fetching...";
			labelStatus.ForeColor = System.Drawing.Color.Blue;

			// Fetch random integer from random.org
			string url = "https://www.random.org/integers/?num=1&min=1&max=100&col=1&base=10&format=plain&rnd=new";
			string response = await client.GetStringAsync(url);
			int randomInteger = int.Parse(response.Trim());

			// Display the random integer and current date/time
			labelRandomInteger.Text = $"Random Integer: {randomInteger}";
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
		}
	}

	private void Form1_Load(object sender, EventArgs e)
	{
		labelStatus.Text = "Ready. Click the button to fetch a random integer.";
		labelStatus.ForeColor = System.Drawing.Color.Black;
	}
}
