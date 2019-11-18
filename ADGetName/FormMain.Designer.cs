namespace ADGetName
{
    partial class FormMain
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
            this.components = new System.ComponentModel.Container();
            this.textBoxComputerName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDownStartNumber = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDownNumberLength = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.listBoxAvailableNames = new System.Windows.Forms.ListBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.contextMenuStripComputerNameActions = new System.Windows.Forms.ContextMenuStrip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStartNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumberLength)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxComputerName
            // 
            this.textBoxComputerName.Location = new System.Drawing.Point(99, 12);
            this.textBoxComputerName.Name = "textBoxComputerName";
            this.textBoxComputerName.Size = new System.Drawing.Size(120, 20);
            this.textBoxComputerName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Computer name";
            // 
            // numericUpDownStartNumber
            // 
            this.numericUpDownStartNumber.Location = new System.Drawing.Point(99, 38);
            this.numericUpDownStartNumber.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.numericUpDownStartNumber.Name = "numericUpDownStartNumber";
            this.numericUpDownStartNumber.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownStartNumber.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Starting number";
            // 
            // numericUpDownNumberLength
            // 
            this.numericUpDownNumberLength.Location = new System.Drawing.Point(99, 64);
            this.numericUpDownNumberLength.Name = "numericUpDownNumberLength";
            this.numericUpDownNumberLength.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownNumberLength.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Number length";
            // 
            // listBoxAvailableNames
            // 
            this.listBoxAvailableNames.ContextMenuStrip = this.contextMenuStripComputerNameActions;
            this.listBoxAvailableNames.FormattingEnabled = true;
            this.listBoxAvailableNames.Location = new System.Drawing.Point(15, 119);
            this.listBoxAvailableNames.Name = "listBoxAvailableNames";
            this.listBoxAvailableNames.Size = new System.Drawing.Size(204, 134);
            this.listBoxAvailableNames.TabIndex = 7;
            this.listBoxAvailableNames.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listBoxAvailableNames_KeyDown);
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(15, 90);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(204, 23);
            this.buttonSearch.TabIndex = 6;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // contextMenuStripComputerNameActions
            // 
            this.contextMenuStripComputerNameActions.Name = "contextMenuStripComputerNameActions";
            this.contextMenuStripComputerNameActions.Size = new System.Drawing.Size(181, 26);
            this.contextMenuStripComputerNameActions.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStripComputerNameActions_Opening);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(229, 261);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.listBoxAvailableNames);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numericUpDownNumberLength);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericUpDownStartNumber);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxComputerName);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AD Get";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStartNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumberLength)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxComputerName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDownStartNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDownNumberLength;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox listBoxAvailableNames;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripComputerNameActions;
    }
}

