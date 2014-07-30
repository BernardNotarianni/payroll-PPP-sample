using System;
using System.Windows.Forms;

namespace PayrollUI
{
	public class AddEmployeeWindow : Form, AddEmployeeView
	{
		public System.Windows.Forms.TextBox empIdTextBox;
		private System.Windows.Forms.Label empIdLabel;
		private System.Windows.Forms.Label nameLabel;
		public System.Windows.Forms.TextBox nameTextBox;
		private System.Windows.Forms.Label addressLabel;
		public System.Windows.Forms.TextBox addressTextBox;
		public System.Windows.Forms.RadioButton hourlyRadioButton;
		public System.Windows.Forms.RadioButton salaryRadioButton;
		public System.Windows.Forms.RadioButton commissionRadioButton;
		private System.Windows.Forms.Label hourlyRateLabel;
		public System.Windows.Forms.TextBox hourlyRateTextBox;
		private System.Windows.Forms.Label salaryLabel;
		public System.Windows.Forms.TextBox salaryTextBox;
		private System.Windows.Forms.Label commissionSalaryLabel;
		public System.Windows.Forms.TextBox commissionSalaryTextBox;
		private System.Windows.Forms.Label commissionLabel;
		public System.Windows.Forms.TextBox commissionTextBox;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label label1;
		private System.ComponentModel.Container components = null;
		public System.Windows.Forms.Button submitButton;
		private AddEmployeePresenter presenter;

		public AddEmployeeWindow()
		{
			InitializeComponent();
		}

		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.submitButton = new System.Windows.Forms.Button();
			this.empIdTextBox = new System.Windows.Forms.TextBox();
			this.empIdLabel = new System.Windows.Forms.Label();
			this.nameLabel = new System.Windows.Forms.Label();
			this.nameTextBox = new System.Windows.Forms.TextBox();
			this.addressLabel = new System.Windows.Forms.Label();
			this.addressTextBox = new System.Windows.Forms.TextBox();
			this.commissionLabel = new System.Windows.Forms.Label();
			this.commissionTextBox = new System.Windows.Forms.TextBox();
			this.commissionSalaryLabel = new System.Windows.Forms.Label();
			this.commissionSalaryTextBox = new System.Windows.Forms.TextBox();
			this.salaryLabel = new System.Windows.Forms.Label();
			this.salaryTextBox = new System.Windows.Forms.TextBox();
			this.hourlyRateLabel = new System.Windows.Forms.Label();
			this.hourlyRateTextBox = new System.Windows.Forms.TextBox();
			this.commissionRadioButton = new System.Windows.Forms.RadioButton();
			this.salaryRadioButton = new System.Windows.Forms.RadioButton();
			this.hourlyRadioButton = new System.Windows.Forms.RadioButton();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// submitButton
			// 
			this.submitButton.Enabled = false;
			this.submitButton.Location = new System.Drawing.Point(104, 256);
			this.submitButton.Name = "submitButton";
			this.submitButton.Size = new System.Drawing.Size(120, 23);
			this.submitButton.TabIndex = 7;
			this.submitButton.Text = "Submit Transaction";
			this.submitButton.Click += new System.EventHandler(this.addEmployeeButton_Click);
			// 
			// empIdTextBox
			// 
			this.empIdTextBox.Location = new System.Drawing.Point(16, 32);
			this.empIdTextBox.Name = "empIdTextBox";
			this.empIdTextBox.TabIndex = 0;
			this.empIdTextBox.Text = "";
			this.empIdTextBox.TextChanged += new System.EventHandler(this.empIdTextBox_TextChanged);
			// 
			// empIdLabel
			// 
			this.empIdLabel.Location = new System.Drawing.Point(16, 16);
			this.empIdLabel.Name = "empIdLabel";
			this.empIdLabel.Size = new System.Drawing.Size(100, 16);
			this.empIdLabel.TabIndex = 2;
			this.empIdLabel.Text = "Employee ID:";
			// 
			// nameLabel
			// 
			this.nameLabel.Location = new System.Drawing.Point(16, 80);
			this.nameLabel.Name = "nameLabel";
			this.nameLabel.Size = new System.Drawing.Size(100, 16);
			this.nameLabel.TabIndex = 4;
			this.nameLabel.Text = "Name:";
			// 
			// nameTextBox
			// 
			this.nameTextBox.Location = new System.Drawing.Point(16, 96);
			this.nameTextBox.Name = "nameTextBox";
			this.nameTextBox.Size = new System.Drawing.Size(152, 20);
			this.nameTextBox.TabIndex = 1;
			this.nameTextBox.Text = "";
			this.nameTextBox.TextChanged += new System.EventHandler(this.nameTextBox_TextChanged);
			// 
			// addressLabel
			// 
			this.addressLabel.Location = new System.Drawing.Point(16, 144);
			this.addressLabel.Name = "addressLabel";
			this.addressLabel.Size = new System.Drawing.Size(100, 16);
			this.addressLabel.TabIndex = 6;
			this.addressLabel.Text = "Address:";
			// 
			// addressTextBox
			// 
			this.addressTextBox.Location = new System.Drawing.Point(16, 160);
			this.addressTextBox.Name = "addressTextBox";
			this.addressTextBox.Size = new System.Drawing.Size(152, 20);
			this.addressTextBox.TabIndex = 2;
			this.addressTextBox.Text = "";
			this.addressTextBox.TextChanged += new System.EventHandler(this.addressTextBox_TextChanged);
			// 
			// commissionLabel
			// 
			this.commissionLabel.Location = new System.Drawing.Point(208, 208);
			this.commissionLabel.Name = "commissionLabel";
			this.commissionLabel.Size = new System.Drawing.Size(100, 16);
			this.commissionLabel.TabIndex = 10;
			this.commissionLabel.Text = "Commission:";
			// 
			// commissionTextBox
			// 
			this.commissionTextBox.Enabled = false;
			this.commissionTextBox.Location = new System.Drawing.Point(208, 224);
			this.commissionTextBox.Name = "commissionTextBox";
			this.commissionTextBox.TabIndex = 9;
			this.commissionTextBox.Text = "";
			this.commissionTextBox.TextChanged += new System.EventHandler(this.commissionTextBox_TextChanged);
			// 
			// commissionSalaryLabel
			// 
			this.commissionSalaryLabel.Location = new System.Drawing.Point(208, 168);
			this.commissionSalaryLabel.Name = "commissionSalaryLabel";
			this.commissionSalaryLabel.Size = new System.Drawing.Size(100, 16);
			this.commissionSalaryLabel.TabIndex = 8;
			this.commissionSalaryLabel.Text = "Base Salary:";
			// 
			// commissionSalaryTextBox
			// 
			this.commissionSalaryTextBox.Enabled = false;
			this.commissionSalaryTextBox.Location = new System.Drawing.Point(208, 184);
			this.commissionSalaryTextBox.Name = "commissionSalaryTextBox";
			this.commissionSalaryTextBox.TabIndex = 7;
			this.commissionSalaryTextBox.Text = "";
			this.commissionSalaryTextBox.TextChanged += new System.EventHandler(this.commissionSalaryTextBox_TextChanged);
			// 
			// salaryLabel
			// 
			this.salaryLabel.Location = new System.Drawing.Point(208, 104);
			this.salaryLabel.Name = "salaryLabel";
			this.salaryLabel.Size = new System.Drawing.Size(100, 16);
			this.salaryLabel.TabIndex = 6;
			this.salaryLabel.Text = "Salary:";
			// 
			// salaryTextBox
			// 
			this.salaryTextBox.Enabled = false;
			this.salaryTextBox.Location = new System.Drawing.Point(208, 120);
			this.salaryTextBox.Name = "salaryTextBox";
			this.salaryTextBox.TabIndex = 5;
			this.salaryTextBox.Text = "";
			this.salaryTextBox.TextChanged += new System.EventHandler(this.salaryTextBox_TextChanged);
			// 
			// hourlyRateLabel
			// 
			this.hourlyRateLabel.Location = new System.Drawing.Point(208, 40);
			this.hourlyRateLabel.Name = "hourlyRateLabel";
			this.hourlyRateLabel.Size = new System.Drawing.Size(100, 16);
			this.hourlyRateLabel.TabIndex = 4;
			this.hourlyRateLabel.Text = "Hourly Rate:";
			// 
			// hourlyRateTextBox
			// 
			this.hourlyRateTextBox.Enabled = false;
			this.hourlyRateTextBox.Location = new System.Drawing.Point(208, 56);
			this.hourlyRateTextBox.Name = "hourlyRateTextBox";
			this.hourlyRateTextBox.TabIndex = 3;
			this.hourlyRateTextBox.Text = "";
			this.hourlyRateTextBox.TextChanged += new System.EventHandler(this.hourlyRateTextBox_TextChanged);
			// 
			// commissionRadioButton
			// 
			this.commissionRadioButton.Location = new System.Drawing.Point(184, 144);
			this.commissionRadioButton.Name = "commissionRadioButton";
			this.commissionRadioButton.TabIndex = 2;
			this.commissionRadioButton.Text = "Commission";
			this.commissionRadioButton.CheckedChanged += new System.EventHandler(this.commissionRadioButton_CheckedChanged);
			// 
			// salaryRadioButton
			// 
			this.salaryRadioButton.Location = new System.Drawing.Point(184, 80);
			this.salaryRadioButton.Name = "salaryRadioButton";
			this.salaryRadioButton.TabIndex = 1;
			this.salaryRadioButton.Text = "Salary";
			this.salaryRadioButton.CheckedChanged += new System.EventHandler(this.salaryRadioButton_CheckedChanged);
			// 
			// hourlyRadioButton
			// 
			this.hourlyRadioButton.Location = new System.Drawing.Point(184, 16);
			this.hourlyRadioButton.Name = "hourlyRadioButton";
			this.hourlyRadioButton.TabIndex = 0;
			this.hourlyRadioButton.Text = "Hourly";
			this.hourlyRadioButton.CheckedChanged += new System.EventHandler(this.hourlyRadioButton_CheckedChanged);
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(208, 56);
			this.textBox2.Name = "textBox2";
			this.textBox2.TabIndex = 3;
			this.textBox2.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(208, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 16);
			this.label1.TabIndex = 4;
			this.label1.Text = "Hourly Rate:";
			// 
			// AddEmployeeWindow
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(328, 294);
			this.Controls.Add(this.addressLabel);
			this.Controls.Add(this.addressTextBox);
			this.Controls.Add(this.nameTextBox);
			this.Controls.Add(this.empIdTextBox);
			this.Controls.Add(this.commissionTextBox);
			this.Controls.Add(this.commissionSalaryTextBox);
			this.Controls.Add(this.salaryTextBox);
			this.Controls.Add(this.hourlyRateTextBox);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.nameLabel);
			this.Controls.Add(this.empIdLabel);
			this.Controls.Add(this.submitButton);
			this.Controls.Add(this.commissionLabel);
			this.Controls.Add(this.commissionSalaryLabel);
			this.Controls.Add(this.salaryLabel);
			this.Controls.Add(this.hourlyRateLabel);
			this.Controls.Add(this.commissionRadioButton);
			this.Controls.Add(this.salaryRadioButton);
			this.Controls.Add(this.hourlyRadioButton);
			this.Controls.Add(this.label1);
			this.Name = "AddEmployeeWindow";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Add Employee";
			this.ResumeLayout(false);

		}
		#endregion

		public AddEmployeePresenter Presenter
		{
			get { return presenter; }
			set { presenter = value; }
		}

		private void hourlyRadioButton_CheckedChanged(
			object sender, System.EventArgs e)
		{
			hourlyRateTextBox.Enabled = hourlyRadioButton.Checked;
			presenter.IsHourly = hourlyRadioButton.Checked;
		}

		private void salaryRadioButton_CheckedChanged(
			object sender, System.EventArgs e)
		{
			salaryTextBox.Enabled = salaryRadioButton.Checked;
			presenter.IsSalary = salaryRadioButton.Checked;
		}

		private void commissionRadioButton_CheckedChanged(
			object sender, System.EventArgs e)
		{
			commissionSalaryTextBox.Enabled = 
				commissionRadioButton.Checked;
			commissionTextBox.Enabled = 
				commissionRadioButton.Checked;
			presenter.IsCommission = 
				commissionRadioButton.Checked;
		}

		private void empIdTextBox_TextChanged(
			object sender, System.EventArgs e)
		{
			presenter.EmpId = AsInt(empIdTextBox.Text);
		}

		private void nameTextBox_TextChanged(
			object sender, System.EventArgs e)
		{
			presenter.Name = nameTextBox.Text;
		}

		private void addressTextBox_TextChanged(
			object sender, System.EventArgs e)
		{
			presenter.Address = addressTextBox.Text;
		}

		private void hourlyRateTextBox_TextChanged(
			object sender, System.EventArgs e)
		{
			presenter.HourlyRate = AsDouble(hourlyRateTextBox.Text);
		}

		private void salaryTextBox_TextChanged(
			object sender, System.EventArgs e)
		{
			presenter.Salary = AsDouble(salaryTextBox.Text);
		}

		private void commissionSalaryTextBox_TextChanged(
			object sender, System.EventArgs e)
		{
			presenter.CommissionSalary = 
				AsDouble(commissionSalaryTextBox.Text);
		}

		private void commissionTextBox_TextChanged(
			object sender, System.EventArgs e)
		{
			presenter.Commission = AsDouble(commissionTextBox.Text);
		}

		private void addEmployeeButton_Click(
			object sender, System.EventArgs e)
		{
			presenter.AddEmployee();
			this.Close();
		}

		private double AsDouble(string text)
		{
			try
			{
				return Double.Parse(text);
			}
			catch (Exception)
			{
				return 0.0;
			}
		}

		private int AsInt(string text)
		{
			try
			{
				return Int32.Parse(text);
			}
			catch (Exception)
			{
				return 0;
			}
		}

		public bool SubmitEnabled
		{
			set { submitButton.Enabled = value; }
		}
	}
}
