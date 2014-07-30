namespace PayrollUI
{
	public class PayrollWindow : System.Windows.Forms.Form, PayrollView
	{
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label employeeLabel;
		public System.Windows.Forms.TextBox employeesTextBox;
		public System.Windows.Forms.TextBox transactionsTextBox;
		public System.Windows.Forms.Button runButton;
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.MenuItem actionMenuItem;
		public System.Windows.Forms.MenuItem addEmployeeMenuItem;
		private PayrollPresenter presenter;

		public PayrollWindow()
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
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.actionMenuItem = new System.Windows.Forms.MenuItem();
			this.addEmployeeMenuItem = new System.Windows.Forms.MenuItem();
			this.label1 = new System.Windows.Forms.Label();
			this.employeeLabel = new System.Windows.Forms.Label();
			this.employeesTextBox = new System.Windows.Forms.TextBox();
			this.transactionsTextBox = new System.Windows.Forms.TextBox();
			this.runButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.actionMenuItem});
			// 
			// actionMenuItem
			// 
			this.actionMenuItem.Index = 0;
			this.actionMenuItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						   this.addEmployeeMenuItem});
			this.actionMenuItem.Text = "Action";
			// 
			// addEmployeeMenuItem
			// 
			this.addEmployeeMenuItem.Index = 0;
			this.addEmployeeMenuItem.Text = "Add Employee";
			this.addEmployeeMenuItem.Click += new System.EventHandler(this.addEmployeeMenuItem_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(246, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(117, 23);
			this.label1.TabIndex = 1;
			this.label1.Text = "Pending Transactions:";
			// 
			// employeeLabel
			// 
			this.employeeLabel.Location = new System.Drawing.Point(272, 200);
			this.employeeLabel.Name = "employeeLabel";
			this.employeeLabel.Size = new System.Drawing.Size(64, 23);
			this.employeeLabel.TabIndex = 3;
			this.employeeLabel.Text = "Employees:";
			// 
			// employeesTextBox
			// 
			this.employeesTextBox.Location = new System.Drawing.Point(16, 216);
			this.employeesTextBox.Multiline = true;
			this.employeesTextBox.Name = "employeesTextBox";
			this.employeesTextBox.ReadOnly = true;
			this.employeesTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.employeesTextBox.Size = new System.Drawing.Size(576, 104);
			this.employeesTextBox.TabIndex = 2;
			this.employeesTextBox.Text = "";
			// 
			// transactionsTextBox
			// 
			this.transactionsTextBox.Location = new System.Drawing.Point(16, 24);
			this.transactionsTextBox.Multiline = true;
			this.transactionsTextBox.Name = "transactionsTextBox";
			this.transactionsTextBox.ReadOnly = true;
			this.transactionsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.transactionsTextBox.Size = new System.Drawing.Size(576, 104);
			this.transactionsTextBox.TabIndex = 4;
			this.transactionsTextBox.Text = "";
			// 
			// runButton
			// 
			this.runButton.Location = new System.Drawing.Point(204, 152);
			this.runButton.Name = "runButton";
			this.runButton.Size = new System.Drawing.Size(200, 24);
			this.runButton.TabIndex = 5;
			this.runButton.Text = "Run Transactions";
			this.runButton.Click += new System.EventHandler(this.runButton_Click);
			// 
			// PayrollWindow
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(608, 337);
			this.Controls.Add(this.runButton);
			this.Controls.Add(this.employeesTextBox);
			this.Controls.Add(this.transactionsTextBox);
			this.Controls.Add(this.employeeLabel);
			this.Controls.Add(this.label1);
			this.Menu = this.mainMenu1;
			this.Name = "PayrollWindow";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Payroll";
			this.ResumeLayout(false);

		}
		#endregion

		private void addEmployeeMenuItem_Click(
			object sender, System.EventArgs e)
		{
			presenter.AddEmployeeActionInvoked();
		}

		private void runButton_Click(
			object sender, System.EventArgs e)
		{
			presenter.RunTransactions();
		}

		public string TransactionsText
		{
			set { transactionsTextBox.Text = value; }
		}

		public string EmployeesText
		{
			set { employeesTextBox.Text = value; }
		}

		public PayrollPresenter Presenter
		{
			get { return presenter; }
			set { presenter = value; }
		}

	}
}
