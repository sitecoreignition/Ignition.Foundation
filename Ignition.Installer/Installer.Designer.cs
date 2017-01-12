namespace Ignition.Installer
{
	partial class Installer
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
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
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Installer));
			this.label1 = new System.Windows.Forms.Label();
			this.instanceName = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.hostName = new System.Windows.Forms.TextBox();
			this.ChoseCodeFolderDialog = new System.Windows.Forms.FolderBrowserDialog();
			this.ChooseSiteFolderDialog = new System.Windows.Forms.FolderBrowserDialog();
			this.label4 = new System.Windows.Forms.Label();
			this.installationPath = new System.Windows.Forms.TextBox();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.outputList = new System.Windows.Forms.ListBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(50, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(104, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "New Instance Name";
			// 
			// instanceName
			// 
			this.instanceName.Location = new System.Drawing.Point(161, 13);
			this.instanceName.Name = "instanceName";
			this.instanceName.Size = new System.Drawing.Size(191, 20);
			this.instanceName.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(69, 52);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(85, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "New Host Name";
			// 
			// hostName
			// 
			this.hostName.Location = new System.Drawing.Point(161, 49);
			this.hostName.Name = "hostName";
			this.hostName.Size = new System.Drawing.Size(191, 20);
			this.hostName.TabIndex = 3;
			// 
			// ChoseCodeFolderDialog
			// 
			this.ChoseCodeFolderDialog.RootFolder = System.Environment.SpecialFolder.MyComputer;
			// 
			// ChooseSiteFolderDialog
			// 
			this.ChooseSiteFolderDialog.RootFolder = System.Environment.SpecialFolder.MyComputer;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(12, 88);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(143, 13);
			this.label4.TabIndex = 6;
			this.label4.Text = "Sitecore Installation Location";
			// 
			// installationPath
			// 
			this.installationPath.Location = new System.Drawing.Point(162, 85);
			this.installationPath.Name = "installationPath";
			this.installationPath.Size = new System.Drawing.Size(190, 20);
			this.installationPath.TabIndex = 7;
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
			this.pictureBox1.Location = new System.Drawing.Point(766, 19);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(205, 189);
			this.pictureBox1.TabIndex = 8;
			this.pictureBox1.TabStop = false;
			// 
			// linkLabel1
			// 
			this.linkLabel1.AutoSize = true;
			this.linkLabel1.Location = new System.Drawing.Point(807, 211);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new System.Drawing.Size(122, 13);
			this.linkLabel1.TabIndex = 9;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "Sitecore Ignition Installer";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(52, 127);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(102, 23);
			this.button1.TabIndex = 10;
			this.button1.Text = "Install IIS";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(52, 169);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(102, 23);
			this.button2.TabIndex = 11;
			this.button2.Text = "Install SQL";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(52, 211);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(102, 23);
			this.button3.TabIndex = 12;
			this.button3.Text = "Setup File System";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// outputList
			// 
			this.outputList.FormattingEnabled = true;
			this.outputList.Location = new System.Drawing.Point(52, 258);
			this.outputList.Name = "outputList";
			this.outputList.Size = new System.Drawing.Size(919, 95);
			this.outputList.TabIndex = 13;
			// 
			// Installer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1019, 445);
			this.Controls.Add(this.outputList);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.linkLabel1);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.installationPath);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.hostName);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.instanceName);
			this.Controls.Add(this.label1);
			this.Name = "Installer";
			this.Text = "mainForm";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox instanceName;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox hostName;
		private System.Windows.Forms.FolderBrowserDialog ChoseCodeFolderDialog;
		private System.Windows.Forms.FolderBrowserDialog ChooseSiteFolderDialog;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox installationPath;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.LinkLabel linkLabel1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.ListBox outputList;
	}
}

