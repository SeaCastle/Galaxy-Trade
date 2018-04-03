namespace Galaxy_Trade
{
    partial class GameForm
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
            this.statsGroupBox = new System.Windows.Forms.GroupBox();
            this.spaceValLabel = new System.Windows.Forms.Label();
            this.spaceLabel = new System.Windows.Forms.Label();
            this.healthValLabel = new System.Windows.Forms.Label();
            this.healthLabel = new System.Windows.Forms.Label();
            this.debtValLabel = new System.Windows.Forms.Label();
            this.cashValLabel = new System.Windows.Forms.Label();
            this.bankValLabel = new System.Windows.Forms.Label();
            this.bankLabel = new System.Windows.Forms.Label();
            this.debtLabel = new System.Windows.Forms.Label();
            this.locationNameLabel = new System.Windows.Forms.Label();
            this.cashLabel = new System.Windows.Forms.Label();
            this.dayCounterLabel = new System.Windows.Forms.Label();
            this.locationLabel = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eventTextBox = new System.Windows.Forms.RichTextBox();
            this.itemsGroupBox = new System.Windows.Forms.GroupBox();
            this.itemsListView = new System.Windows.Forms.ListView();
            this.nameColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.priceColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.inventoryGroupBox = new System.Windows.Forms.GroupBox();
            this.inventoryListView = new System.Windows.Forms.ListView();
            this.invNameColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.invTotalColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buyButton = new System.Windows.Forms.Button();
            this.sellButton = new System.Windows.Forms.Button();
            this.dropButton = new System.Windows.Forms.Button();
            this.travelButton = new System.Windows.Forms.Button();
            this.itemAndInvPanel = new System.Windows.Forms.Panel();
            this.errandsButton = new System.Windows.Forms.Button();
            this.errandPanel = new System.Windows.Forms.Panel();
            this.greetingLabel = new System.Windows.Forms.Label();
            this.errandCashLabel = new System.Windows.Forms.Label();
            this.errandCashValLabel = new System.Windows.Forms.Label();
            this.errandDebtLabel = new System.Windows.Forms.Label();
            this.errandDebtValLabel = new System.Windows.Forms.Label();
            this.errandNumUpDn = new System.Windows.Forms.NumericUpDown();
            this.errandCancelBtn = new System.Windows.Forms.Button();
            this.errandSubmitBtn = new System.Windows.Forms.Button();
            this.statsGroupBox.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.itemsGroupBox.SuspendLayout();
            this.inventoryGroupBox.SuspendLayout();
            this.itemAndInvPanel.SuspendLayout();
            this.errandPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errandNumUpDn)).BeginInit();
            this.SuspendLayout();
            // 
            // statsGroupBox
            // 
            this.statsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.statsGroupBox.Controls.Add(this.spaceValLabel);
            this.statsGroupBox.Controls.Add(this.spaceLabel);
            this.statsGroupBox.Controls.Add(this.healthValLabel);
            this.statsGroupBox.Controls.Add(this.healthLabel);
            this.statsGroupBox.Controls.Add(this.debtValLabel);
            this.statsGroupBox.Controls.Add(this.cashValLabel);
            this.statsGroupBox.Controls.Add(this.bankValLabel);
            this.statsGroupBox.Controls.Add(this.bankLabel);
            this.statsGroupBox.Controls.Add(this.debtLabel);
            this.statsGroupBox.Controls.Add(this.locationNameLabel);
            this.statsGroupBox.Controls.Add(this.cashLabel);
            this.statsGroupBox.Controls.Add(this.dayCounterLabel);
            this.statsGroupBox.Controls.Add(this.locationLabel);
            this.statsGroupBox.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statsGroupBox.Location = new System.Drawing.Point(12, 27);
            this.statsGroupBox.Name = "statsGroupBox";
            this.statsGroupBox.Size = new System.Drawing.Size(667, 100);
            this.statsGroupBox.TabIndex = 0;
            this.statsGroupBox.TabStop = false;
            this.statsGroupBox.Text = "Stats";
            // 
            // spaceValLabel
            // 
            this.spaceValLabel.Location = new System.Drawing.Point(591, 51);
            this.spaceValLabel.Name = "spaceValLabel";
            this.spaceValLabel.Size = new System.Drawing.Size(70, 20);
            this.spaceValLabel.TabIndex = 12;
            this.spaceValLabel.Text = "100";
            this.spaceValLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // spaceLabel
            // 
            this.spaceLabel.Location = new System.Drawing.Point(515, 51);
            this.spaceLabel.Name = "spaceLabel";
            this.spaceLabel.Size = new System.Drawing.Size(70, 20);
            this.spaceLabel.TabIndex = 11;
            this.spaceLabel.Text = "Space";
            this.spaceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // healthValLabel
            // 
            this.healthValLabel.Location = new System.Drawing.Point(591, 77);
            this.healthValLabel.Name = "healthValLabel";
            this.healthValLabel.Size = new System.Drawing.Size(70, 20);
            this.healthValLabel.TabIndex = 10;
            this.healthValLabel.Text = "100";
            this.healthValLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // healthLabel
            // 
            this.healthLabel.Location = new System.Drawing.Point(515, 77);
            this.healthLabel.Name = "healthLabel";
            this.healthLabel.Size = new System.Drawing.Size(70, 20);
            this.healthLabel.TabIndex = 9;
            this.healthLabel.Text = "Health";
            this.healthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // debtValLabel
            // 
            this.debtValLabel.ForeColor = System.Drawing.Color.Red;
            this.debtValLabel.Location = new System.Drawing.Point(353, 51);
            this.debtValLabel.Name = "debtValLabel";
            this.debtValLabel.Size = new System.Drawing.Size(156, 20);
            this.debtValLabel.TabIndex = 8;
            this.debtValLabel.Text = "$5,500";
            this.debtValLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cashValLabel
            // 
            this.cashValLabel.ForeColor = System.Drawing.Color.LimeGreen;
            this.cashValLabel.Location = new System.Drawing.Point(353, 77);
            this.cashValLabel.Name = "cashValLabel";
            this.cashValLabel.Size = new System.Drawing.Size(156, 20);
            this.cashValLabel.TabIndex = 7;
            this.cashValLabel.Text = "$2,000";
            this.cashValLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bankValLabel
            // 
            this.bankValLabel.Location = new System.Drawing.Point(102, 77);
            this.bankValLabel.Name = "bankValLabel";
            this.bankValLabel.Size = new System.Drawing.Size(154, 20);
            this.bankValLabel.TabIndex = 6;
            this.bankValLabel.Text = "$0";
            this.bankValLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bankLabel
            // 
            this.bankLabel.Location = new System.Drawing.Point(6, 77);
            this.bankLabel.Name = "bankLabel";
            this.bankLabel.Size = new System.Drawing.Size(90, 20);
            this.bankLabel.TabIndex = 5;
            this.bankLabel.Text = "Bank";
            this.bankLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // debtLabel
            // 
            this.debtLabel.Location = new System.Drawing.Point(262, 51);
            this.debtLabel.Name = "debtLabel";
            this.debtLabel.Size = new System.Drawing.Size(85, 20);
            this.debtLabel.TabIndex = 4;
            this.debtLabel.Text = "Debt";
            this.debtLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // locationNameLabel
            // 
            this.locationNameLabel.Location = new System.Drawing.Point(102, 51);
            this.locationNameLabel.Name = "locationNameLabel";
            this.locationNameLabel.Size = new System.Drawing.Size(154, 20);
            this.locationNameLabel.TabIndex = 3;
            this.locationNameLabel.Text = "LocationHere";
            this.locationNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cashLabel
            // 
            this.cashLabel.Location = new System.Drawing.Point(262, 77);
            this.cashLabel.Name = "cashLabel";
            this.cashLabel.Size = new System.Drawing.Size(85, 20);
            this.cashLabel.TabIndex = 2;
            this.cashLabel.Text = "Cash";
            this.cashLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dayCounterLabel
            // 
            this.dayCounterLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dayCounterLabel.AutoSize = true;
            this.dayCounterLabel.Location = new System.Drawing.Point(291, 22);
            this.dayCounterLabel.Name = "dayCounterLabel";
            this.dayCounterLabel.Size = new System.Drawing.Size(88, 18);
            this.dayCounterLabel.TabIndex = 1;
            this.dayCounterLabel.Text = "Day 0/30";
            // 
            // locationLabel
            // 
            this.locationLabel.Location = new System.Drawing.Point(6, 51);
            this.locationLabel.Name = "locationLabel";
            this.locationLabel.Size = new System.Drawing.Size(98, 20);
            this.locationLabel.TabIndex = 0;
            this.locationLabel.Text = "Location:";
            this.locationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(691, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // gameToolStripMenuItem
            // 
            this.gameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem});
            this.gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            this.gameToolStripMenuItem.ShortcutKeyDisplayString = "";
            this.gameToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
            this.gameToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.gameToolStripMenuItem.Text = "Game";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // eventTextBox
            // 
            this.eventTextBox.BackColor = System.Drawing.SystemColors.Menu;
            this.eventTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.eventTextBox.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eventTextBox.Location = new System.Drawing.Point(12, 133);
            this.eventTextBox.Name = "eventTextBox";
            this.eventTextBox.ReadOnly = true;
            this.eventTextBox.Size = new System.Drawing.Size(667, 89);
            this.eventTextBox.TabIndex = 3;
            this.eventTextBox.Text = "";
            // 
            // itemsGroupBox
            // 
            this.itemsGroupBox.Controls.Add(this.itemsListView);
            this.itemsGroupBox.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemsGroupBox.Location = new System.Drawing.Point(12, 3);
            this.itemsGroupBox.Name = "itemsGroupBox";
            this.itemsGroupBox.Size = new System.Drawing.Size(280, 235);
            this.itemsGroupBox.TabIndex = 4;
            this.itemsGroupBox.TabStop = false;
            this.itemsGroupBox.Text = "Items";
            // 
            // itemsListView
            // 
            this.itemsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameColumnHeader,
            this.priceColumnHeader});
            this.itemsListView.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemsListView.FullRowSelect = true;
            this.itemsListView.GridLines = true;
            this.itemsListView.Location = new System.Drawing.Point(7, 23);
            this.itemsListView.Name = "itemsListView";
            this.itemsListView.Size = new System.Drawing.Size(267, 206);
            this.itemsListView.TabIndex = 0;
            this.itemsListView.UseCompatibleStateImageBehavior = false;
            this.itemsListView.View = System.Windows.Forms.View.Details;
            // 
            // nameColumnHeader
            // 
            this.nameColumnHeader.Text = "Name";
            this.nameColumnHeader.Width = 143;
            // 
            // priceColumnHeader
            // 
            this.priceColumnHeader.Text = "Price";
            this.priceColumnHeader.Width = 120;
            // 
            // inventoryGroupBox
            // 
            this.inventoryGroupBox.Controls.Add(this.inventoryListView);
            this.inventoryGroupBox.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inventoryGroupBox.Location = new System.Drawing.Point(399, 3);
            this.inventoryGroupBox.Name = "inventoryGroupBox";
            this.inventoryGroupBox.Size = new System.Drawing.Size(280, 235);
            this.inventoryGroupBox.TabIndex = 5;
            this.inventoryGroupBox.TabStop = false;
            this.inventoryGroupBox.Text = "Inventory";
            // 
            // inventoryListView
            // 
            this.inventoryListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.invNameColumnHeader,
            this.invTotalColumnHeader});
            this.inventoryListView.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inventoryListView.FullRowSelect = true;
            this.inventoryListView.GridLines = true;
            this.inventoryListView.Location = new System.Drawing.Point(7, 24);
            this.inventoryListView.Name = "inventoryListView";
            this.inventoryListView.Size = new System.Drawing.Size(267, 205);
            this.inventoryListView.TabIndex = 0;
            this.inventoryListView.UseCompatibleStateImageBehavior = false;
            this.inventoryListView.View = System.Windows.Forms.View.Details;
            // 
            // invNameColumnHeader
            // 
            this.invNameColumnHeader.Text = "Name";
            this.invNameColumnHeader.Width = 141;
            // 
            // invTotalColumnHeader
            // 
            this.invTotalColumnHeader.Text = "Total";
            this.invTotalColumnHeader.Width = 122;
            // 
            // buyButton
            // 
            this.buyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buyButton.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buyButton.Location = new System.Drawing.Point(300, 12);
            this.buyButton.Name = "buyButton";
            this.buyButton.Size = new System.Drawing.Size(89, 33);
            this.buyButton.TabIndex = 6;
            this.buyButton.Text = "Buy ->";
            this.buyButton.UseVisualStyleBackColor = true;
            this.buyButton.Click += new System.EventHandler(this.buyButton_Click);
            // 
            // sellButton
            // 
            this.sellButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sellButton.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sellButton.Location = new System.Drawing.Point(300, 60);
            this.sellButton.Name = "sellButton";
            this.sellButton.Size = new System.Drawing.Size(89, 33);
            this.sellButton.TabIndex = 7;
            this.sellButton.Text = "<- Sell";
            this.sellButton.UseVisualStyleBackColor = true;
            this.sellButton.Click += new System.EventHandler(this.sellButton_Click);
            // 
            // dropButton
            // 
            this.dropButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dropButton.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dropButton.Location = new System.Drawing.Point(300, 108);
            this.dropButton.Name = "dropButton";
            this.dropButton.Size = new System.Drawing.Size(89, 33);
            this.dropButton.TabIndex = 8;
            this.dropButton.Text = "Drop <-";
            this.dropButton.UseVisualStyleBackColor = true;
            this.dropButton.Click += new System.EventHandler(this.dropButton_Click);
            // 
            // travelButton
            // 
            this.travelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.travelButton.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.travelButton.Location = new System.Drawing.Point(300, 204);
            this.travelButton.Name = "travelButton";
            this.travelButton.Size = new System.Drawing.Size(89, 33);
            this.travelButton.TabIndex = 9;
            this.travelButton.Text = "Jet!";
            this.travelButton.UseVisualStyleBackColor = true;
            this.travelButton.Click += new System.EventHandler(this.travelButton_Click);
            // 
            // itemAndInvPanel
            // 
            this.itemAndInvPanel.Controls.Add(this.errandsButton);
            this.itemAndInvPanel.Controls.Add(this.itemsGroupBox);
            this.itemAndInvPanel.Controls.Add(this.travelButton);
            this.itemAndInvPanel.Controls.Add(this.inventoryGroupBox);
            this.itemAndInvPanel.Controls.Add(this.dropButton);
            this.itemAndInvPanel.Controls.Add(this.buyButton);
            this.itemAndInvPanel.Controls.Add(this.sellButton);
            this.itemAndInvPanel.Location = new System.Drawing.Point(0, 228);
            this.itemAndInvPanel.Name = "itemAndInvPanel";
            this.itemAndInvPanel.Size = new System.Drawing.Size(691, 243);
            this.itemAndInvPanel.TabIndex = 10;
            // 
            // errandsButton
            // 
            this.errandsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.errandsButton.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errandsButton.Location = new System.Drawing.Point(300, 156);
            this.errandsButton.Name = "errandsButton";
            this.errandsButton.Size = new System.Drawing.Size(89, 33);
            this.errandsButton.TabIndex = 10;
            this.errandsButton.Text = "Errands";
            this.errandsButton.UseVisualStyleBackColor = true;
            this.errandsButton.Click += new System.EventHandler(this.errandsButton_Click);
            // 
            // errandPanel
            // 
            this.errandPanel.Controls.Add(this.errandSubmitBtn);
            this.errandPanel.Controls.Add(this.errandCancelBtn);
            this.errandPanel.Controls.Add(this.errandNumUpDn);
            this.errandPanel.Controls.Add(this.errandDebtValLabel);
            this.errandPanel.Controls.Add(this.errandDebtLabel);
            this.errandPanel.Controls.Add(this.errandCashValLabel);
            this.errandPanel.Controls.Add(this.errandCashLabel);
            this.errandPanel.Controls.Add(this.greetingLabel);
            this.errandPanel.Location = new System.Drawing.Point(0, 476);
            this.errandPanel.Name = "errandPanel";
            this.errandPanel.Size = new System.Drawing.Size(691, 243);
            this.errandPanel.TabIndex = 11;
            this.errandPanel.Visible = false;
            // 
            // greetingLabel
            // 
            this.greetingLabel.Font = new System.Drawing.Font("Courier New", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.greetingLabel.Location = new System.Drawing.Point(80, 23);
            this.greetingLabel.Name = "greetingLabel";
            this.greetingLabel.Size = new System.Drawing.Size(531, 56);
            this.greetingLabel.TabIndex = 0;
            this.greetingLabel.Text = "Welcome to the Loan Shark. How much would you like to pay off?";
            this.greetingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // errandCashLabel
            // 
            this.errandCashLabel.Font = new System.Drawing.Font("Courier New", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errandCashLabel.Location = new System.Drawing.Point(84, 93);
            this.errandCashLabel.Name = "errandCashLabel";
            this.errandCashLabel.Size = new System.Drawing.Size(75, 23);
            this.errandCashLabel.TabIndex = 1;
            this.errandCashLabel.Text = "Cash:";
            this.errandCashLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // errandCashValLabel
            // 
            this.errandCashValLabel.Font = new System.Drawing.Font("Courier New", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errandCashValLabel.ForeColor = System.Drawing.Color.LimeGreen;
            this.errandCashValLabel.Location = new System.Drawing.Point(165, 93);
            this.errandCashValLabel.Name = "errandCashValLabel";
            this.errandCashValLabel.Size = new System.Drawing.Size(179, 23);
            this.errandCashValLabel.TabIndex = 2;
            this.errandCashValLabel.Text = "1,000,000,000";
            this.errandCashValLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // errandDebtLabel
            // 
            this.errandDebtLabel.Font = new System.Drawing.Font("Courier New", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errandDebtLabel.Location = new System.Drawing.Point(364, 93);
            this.errandDebtLabel.Name = "errandDebtLabel";
            this.errandDebtLabel.Size = new System.Drawing.Size(75, 23);
            this.errandDebtLabel.TabIndex = 3;
            this.errandDebtLabel.Text = "Debt:";
            this.errandDebtLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // errandDebtValLabel
            // 
            this.errandDebtValLabel.Font = new System.Drawing.Font("Courier New", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errandDebtValLabel.ForeColor = System.Drawing.Color.Red;
            this.errandDebtValLabel.Location = new System.Drawing.Point(432, 93);
            this.errandDebtValLabel.Name = "errandDebtValLabel";
            this.errandDebtValLabel.Size = new System.Drawing.Size(179, 23);
            this.errandDebtValLabel.TabIndex = 4;
            this.errandDebtValLabel.Text = "1,000,000,000";
            this.errandDebtValLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // errandNumUpDn
            // 
            this.errandNumUpDn.Font = new System.Drawing.Font("Courier New", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errandNumUpDn.Location = new System.Drawing.Point(277, 141);
            this.errandNumUpDn.Name = "errandNumUpDn";
            this.errandNumUpDn.Size = new System.Drawing.Size(109, 31);
            this.errandNumUpDn.TabIndex = 5;
            // 
            // errandCancelBtn
            // 
            this.errandCancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.errandCancelBtn.Location = new System.Drawing.Point(139, 191);
            this.errandCancelBtn.Name = "errandCancelBtn";
            this.errandCancelBtn.Size = new System.Drawing.Size(105, 35);
            this.errandCancelBtn.TabIndex = 6;
            this.errandCancelBtn.Text = "Cancel";
            this.errandCancelBtn.UseVisualStyleBackColor = true;
            this.errandCancelBtn.Click += new System.EventHandler(this.errandCancelBtn_Click);
            // 
            // errandSubmitBtn
            // 
            this.errandSubmitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.errandSubmitBtn.Location = new System.Drawing.Point(416, 191);
            this.errandSubmitBtn.Name = "errandSubmitBtn";
            this.errandSubmitBtn.Size = new System.Drawing.Size(105, 35);
            this.errandSubmitBtn.TabIndex = 7;
            this.errandSubmitBtn.Text = "Submit";
            this.errandSubmitBtn.UseVisualStyleBackColor = true;
            this.errandSubmitBtn.Click += new System.EventHandler(this.errandSubmitBtn_Click);
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 720);
            this.Controls.Add(this.errandPanel);
            this.Controls.Add(this.itemAndInvPanel);
            this.Controls.Add(this.eventTextBox);
            this.Controls.Add(this.statsGroupBox);
            this.Controls.Add(this.menuStrip1);
            this.Name = "GameForm";
            this.Text = "Galaxy Trade";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GameForm_FormClosing);
            this.statsGroupBox.ResumeLayout(false);
            this.statsGroupBox.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.itemsGroupBox.ResumeLayout(false);
            this.inventoryGroupBox.ResumeLayout(false);
            this.itemAndInvPanel.ResumeLayout(false);
            this.errandPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errandNumUpDn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        /// NOTE:
        /// THE BUY AND SELL BUTTONS ARE STACKED ON TOP OF EACH OTHER
        /// IF YOU NEED ACCESS TO THE SELL BUTTON IN THE DESIGN EDITOR
        /// MOVE THE SELL BUTTON OUT OF THE WAY

        private System.Windows.Forms.GroupBox statsGroupBox;
        private System.Windows.Forms.Label dayCounterLabel;
        private System.Windows.Forms.Label locationLabel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem gameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Label cashLabel;
        private System.Windows.Forms.Label debtLabel;
        private System.Windows.Forms.Label locationNameLabel;
        private System.Windows.Forms.Label debtValLabel;
        private System.Windows.Forms.Label cashValLabel;
        private System.Windows.Forms.Label bankValLabel;
        private System.Windows.Forms.Label bankLabel;
        private System.Windows.Forms.Label healthLabel;
        private System.Windows.Forms.Label healthValLabel;
        private System.Windows.Forms.Label spaceValLabel;
        private System.Windows.Forms.Label spaceLabel;
        private System.Windows.Forms.RichTextBox eventTextBox;
        private System.Windows.Forms.GroupBox itemsGroupBox;
        private System.Windows.Forms.GroupBox inventoryGroupBox;
        private System.Windows.Forms.Button buyButton;
        private System.Windows.Forms.Button sellButton;
        private System.Windows.Forms.Button dropButton;
        private System.Windows.Forms.Button travelButton;
        private System.Windows.Forms.ListView itemsListView;
        private System.Windows.Forms.ColumnHeader nameColumnHeader;
        private System.Windows.Forms.ColumnHeader priceColumnHeader;
        private System.Windows.Forms.ListView inventoryListView;
        private System.Windows.Forms.ColumnHeader invNameColumnHeader;
        private System.Windows.Forms.ColumnHeader invTotalColumnHeader;
        private System.Windows.Forms.Panel itemAndInvPanel;
        private System.Windows.Forms.Button errandsButton;
        private System.Windows.Forms.Panel errandPanel;
        private System.Windows.Forms.Button errandSubmitBtn;
        private System.Windows.Forms.Button errandCancelBtn;
        private System.Windows.Forms.NumericUpDown errandNumUpDn;
        private System.Windows.Forms.Label errandDebtValLabel;
        private System.Windows.Forms.Label errandDebtLabel;
        private System.Windows.Forms.Label errandCashValLabel;
        private System.Windows.Forms.Label errandCashLabel;
        private System.Windows.Forms.Label greetingLabel;
    }
}

