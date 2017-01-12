using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ignition.Installer.IIS;

namespace Ignition.Installer
{
	public partial class Installer : Form
	{
		public Installer()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			try
			{
				outputList.Items.Add("Creating IIS Site");
				IisWorker.CreateSite("aetest.local", "aetest", installationPath.Text);
			}
			catch (Exception ex)
			{
				outputList.Items.Add($"Error: {ex.Message}");
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{

		}

		private void button3_Click(object sender, EventArgs e)
		{

		}
	}
}
