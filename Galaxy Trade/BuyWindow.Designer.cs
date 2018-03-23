namespace Galaxy_Trade
{
    partial class BuyWindow
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
            this.cancelBtn = new System.Windows.Forms.Button();
            this.buyBtn = new System.Windows.Forms.Button();
            this.cashLabel = new System.Windows.Forms.Label();
            this.cashValueLabel = new System.Windows.Forms.Label();
            this.productLabel = new System.Windows.Forms.Label();
            this.numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.totalLabel = new System.Windows.Forms.Label();
            this.totalAmountLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(80, 152);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(90, 35);
            this.cancelBtn.TabIndex = 0;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // buyBtn
            // 
            this.buyBtn.Location = new System.Drawing.Point(253, 152);
            this.buyBtn.Name = "buyBtn";
            this.buyBtn.Size = new System.Drawing.Size(90, 35);
            this.buyBtn.TabIndex = 1;
            this.buyBtn.Text = "Buy";
            this.buyBtn.UseVisualStyleBackColor = true;
            this.buyBtn.Click += new System.EventHandler(this.buyBtn_Click);
            // 
            // cashLabel
            // 
            this.cashLabel.Font = new System.Drawing.Font("Courier New", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cashLabel.Location = new System.Drawing.Point(115, 9);
            this.cashLabel.Name = "cashLabel";
            this.cashLabel.Size = new System.Drawing.Size(75, 25);
            this.cashLabel.TabIndex = 2;
            this.cashLabel.Text = "Cash";
            this.cashLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cashValueLabel
            // 
            this.cashValueLabel.Font = new System.Drawing.Font("Courier New", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cashValueLabel.ForeColor = System.Drawing.Color.LimeGreen;
            this.cashValueLabel.Location = new System.Drawing.Point(196, 9);
            this.cashValueLabel.Name = "cashValueLabel";
            this.cashValueLabel.Size = new System.Drawing.Size(206, 25);
            this.cashValueLabel.TabIndex = 3;
            this.cashValueLabel.Text = "$100000";
            this.cashValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // productLabel
            // 
            this.productLabel.Font = new System.Drawing.Font("Courier New", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productLabel.Location = new System.Drawing.Point(13, 69);
            this.productLabel.Name = "productLabel";
            this.productLabel.Size = new System.Drawing.Size(258, 23);
            this.productLabel.TabIndex = 4;
            this.productLabel.Text = "Galaxy Dust";
            // 
            // numericUpDown
            // 
            this.numericUpDown.Font = new System.Drawing.Font("Courier New", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown.Location = new System.Drawing.Point(300, 67);
            this.numericUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown.Name = "numericUpDown";
            this.numericUpDown.Size = new System.Drawing.Size(102, 31);
            this.numericUpDown.TabIndex = 5;
            this.numericUpDown.ValueChanged += new System.EventHandler(this.numericUpDown_ValueChanged);
            // 
            // totalLabel
            // 
            this.totalLabel.Font = new System.Drawing.Font("Courier New", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalLabel.Location = new System.Drawing.Point(13, 110);
            this.totalLabel.Name = "totalLabel";
            this.totalLabel.Size = new System.Drawing.Size(92, 23);
            this.totalLabel.TabIndex = 6;
            this.totalLabel.Text = "Total: ";
            // 
            // totalAmountLabel
            // 
            this.totalAmountLabel.Font = new System.Drawing.Font("Courier New", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalAmountLabel.Location = new System.Drawing.Point(196, 110);
            this.totalAmountLabel.Name = "totalAmountLabel";
            this.totalAmountLabel.Size = new System.Drawing.Size(206, 23);
            this.totalAmountLabel.TabIndex = 7;
            this.totalAmountLabel.Text = "$000000";
            // 
            // BuyWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 211);
            this.ControlBox = false;
            this.Controls.Add(this.totalAmountLabel);
            this.Controls.Add(this.totalLabel);
            this.Controls.Add(this.numericUpDown);
            this.Controls.Add(this.productLabel);
            this.Controls.Add(this.cashValueLabel);
            this.Controls.Add(this.cashLabel);
            this.Controls.Add(this.buyBtn);
            this.Controls.Add(this.cancelBtn);
            this.Name = "BuyWindow";
            this.Text = "BuyWindow";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button buyBtn;
        private System.Windows.Forms.Label cashLabel;
        private System.Windows.Forms.Label cashValueLabel;
        private System.Windows.Forms.Label productLabel;
        private System.Windows.Forms.NumericUpDown numericUpDown;
        private System.Windows.Forms.Label totalLabel;
        private System.Windows.Forms.Label totalAmountLabel;
    }
}