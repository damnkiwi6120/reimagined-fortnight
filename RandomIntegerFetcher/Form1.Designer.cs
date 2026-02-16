namespace RandomIntegerFetcher;

partial class Form1
{
	/// <summary>
	///  Required designer variable.
	/// </summary>
	private System.ComponentModel.IContainer components = null;
	private System.Windows.Forms.Button buttonGetRandom;
	private System.Windows.Forms.Label labelRandomInteger;
	private System.Windows.Forms.Label labelDateTime;
	private System.Windows.Forms.Label labelStatus;

	/// <summary>
	///  Clean up any resources being used.
	/// </summary>
	/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
	protected override void Dispose(bool disposing)
	{
		if (disposing && (components != null))
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	#region Windows Form Designer generated code

	/// <summary>
	///  Required method for Designer support - do not modify
	///  the contents of this method with the code editor.
	/// </summary>
	private void InitializeComponent()
	{
		buttonGetRandom = new Button();
		labelRandomInteger = new Label();
		labelDateTime = new Label();
		labelStatus = new Label();
		SuspendLayout();
		// 
		// buttonGetRandom
		// 
		buttonGetRandom.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
		buttonGetRandom.Location = new Point(58, 59);
		buttonGetRandom.Margin = new Padding(4, 3, 4, 3);
		buttonGetRandom.Name = "buttonGetRandom";
		buttonGetRandom.Size = new Size(350, 58);
		buttonGetRandom.TabIndex = 0;
		buttonGetRandom.Text = "Get Random Integer from Random.org";
		buttonGetRandom.UseVisualStyleBackColor = true;
		buttonGetRandom.Click += buttonGetRandom_Click;
		// 
		// labelRandomInteger
		// 
		labelRandomInteger.AutoSize = true;
		labelRandomInteger.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold);
		labelRandomInteger.Location = new Point(58, 150);
		labelRandomInteger.Margin = new Padding(4, 0, 4, 0);
		labelRandomInteger.Name = "labelRandomInteger";
		labelRandomInteger.Size = new Size(185, 24);
		labelRandomInteger.TabIndex = 1;
		labelRandomInteger.Text = "Random Integer: --";
		// 
		// labelDateTime
		// 
		labelDateTime.AutoSize = true;
		labelDateTime.Font = new Font("Microsoft Sans Serif", 12F);
		labelDateTime.Location = new Point(58, 196);
		labelDateTime.Margin = new Padding(4, 0, 4, 0);
		labelDateTime.Name = "labelDateTime";
		labelDateTime.Size = new Size(104, 20);
		labelDateTime.TabIndex = 2;
		labelDateTime.Text = "Date & Time: --";
		// 
		// labelStatus
		// 
		labelStatus.AutoSize = true;
		labelStatus.Font = new Font("Microsoft Sans Serif", 10F);
		labelStatus.Location = new Point(58, 242);
		labelStatus.Margin = new Padding(4, 0, 4, 0);
		labelStatus.Name = "labelStatus";
		labelStatus.Size = new Size(53, 17);
		labelStatus.TabIndex = 3;
		labelStatus.Text = "Ready.";
		// 
		// Form1
		// 
		AutoScaleDimensions = new SizeF(7F, 15F);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(467, 346);
		Controls.Add(labelStatus);
		Controls.Add(labelDateTime);
		Controls.Add(labelRandomInteger);
		Controls.Add(buttonGetRandom);
		Margin = new Padding(4, 3, 4, 3);
		Name = "Form1";
		Text = "Random Integer Fetcher";
		Load += Form1_Load;
		ResumeLayout(false);
		PerformLayout();
	}

	#endregion
}
