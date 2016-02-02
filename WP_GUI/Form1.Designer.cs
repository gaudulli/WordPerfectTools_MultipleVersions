namespace WP_GUI
{
    partial class Form1
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sampleTablesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.randomTextAndPlaceCursorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sampleMergeLetterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.convertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.numberToTextToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.numberToMoneyLegalStyleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.integerToTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.asTextAlwaysIncludeDecimalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.numberToCurrencyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.button2 = new System.Windows.Forms.Button();
            this.menuStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.insertToolStripMenuItem,
            this.convertToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1008, 24);
            this.menuStrip.TabIndex = 5;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.openToolStripMenuItem.Text = "Capture WordPerfect";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.CaptureWPToolStripMenuItem_Click);
            // 
            // insertToolStripMenuItem
            // 
            this.insertToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sampleTablesToolStripMenuItem,
            this.randomTextAndPlaceCursorToolStripMenuItem,
            this.sampleMergeLetterToolStripMenuItem});
            this.insertToolStripMenuItem.Name = "insertToolStripMenuItem";
            this.insertToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.insertToolStripMenuItem.Text = "Insert";
            // 
            // sampleTablesToolStripMenuItem
            // 
            this.sampleTablesToolStripMenuItem.Name = "sampleTablesToolStripMenuItem";
            this.sampleTablesToolStripMenuItem.Size = new System.Drawing.Size(236, 22);
            this.sampleTablesToolStripMenuItem.Text = "Sample Table";
            this.sampleTablesToolStripMenuItem.Click += new System.EventHandler(this.sampleTablesToolStripMenuItem_Click);
            // 
            // randomTextAndPlaceCursorToolStripMenuItem
            // 
            this.randomTextAndPlaceCursorToolStripMenuItem.Name = "randomTextAndPlaceCursorToolStripMenuItem";
            this.randomTextAndPlaceCursorToolStripMenuItem.Size = new System.Drawing.Size(236, 22);
            this.randomTextAndPlaceCursorToolStripMenuItem.Text = "Random Text and Place Cursor";
            this.randomTextAndPlaceCursorToolStripMenuItem.Click += new System.EventHandler(this.randomTextAndPlaceCursorToolStripMenuItem_Click);
            // 
            // sampleMergeLetterToolStripMenuItem
            // 
            this.sampleMergeLetterToolStripMenuItem.Name = "sampleMergeLetterToolStripMenuItem";
            this.sampleMergeLetterToolStripMenuItem.Size = new System.Drawing.Size(236, 22);
            this.sampleMergeLetterToolStripMenuItem.Text = "Sample \"Merge\" Letter";
            this.sampleMergeLetterToolStripMenuItem.Click += new System.EventHandler(this.sampleMergeLetterToolStripMenuItem_Click);
            // 
            // convertToolStripMenuItem
            // 
            this.convertToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.numberToTextToolStripMenuItem1});
            this.convertToolStripMenuItem.Name = "convertToolStripMenuItem";
            this.convertToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.convertToolStripMenuItem.Text = "Convert";
            // 
            // numberToTextToolStripMenuItem1
            // 
            this.numberToTextToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.numberToMoneyLegalStyleToolStripMenuItem,
            this.integerToTextToolStripMenuItem,
            this.asTextAlwaysIncludeDecimalToolStripMenuItem,
            this.numberToCurrencyToolStripMenuItem});
            this.numberToTextToolStripMenuItem1.Name = "numberToTextToolStripMenuItem1";
            this.numberToTextToolStripMenuItem1.Size = new System.Drawing.Size(160, 22);
            this.numberToTextToolStripMenuItem1.Text = "Number To Text";
            this.numberToTextToolStripMenuItem1.Click += new System.EventHandler(this.numberToTextToolStripMenuItem_Click);
            // 
            // numberToMoneyLegalStyleToolStripMenuItem
            // 
            this.numberToMoneyLegalStyleToolStripMenuItem.Name = "numberToMoneyLegalStyleToolStripMenuItem";
            this.numberToMoneyLegalStyleToolStripMenuItem.Size = new System.Drawing.Size(248, 22);
            this.numberToMoneyLegalStyleToolStripMenuItem.Text = "As Money (Legal Style)";
            this.numberToMoneyLegalStyleToolStripMenuItem.Click += new System.EventHandler(this.moneyLegalStyleToolStripMenuItem_Click);
            // 
            // integerToTextToolStripMenuItem
            // 
            this.integerToTextToolStripMenuItem.Name = "integerToTextToolStripMenuItem";
            this.integerToTextToolStripMenuItem.Size = new System.Drawing.Size(248, 22);
            this.integerToTextToolStripMenuItem.Text = "As Text";
            this.integerToTextToolStripMenuItem.Click += new System.EventHandler(this.numberToTextToolStripMenuItem_Click);
            // 
            // asTextAlwaysIncludeDecimalToolStripMenuItem
            // 
            this.asTextAlwaysIncludeDecimalToolStripMenuItem.Name = "asTextAlwaysIncludeDecimalToolStripMenuItem";
            this.asTextAlwaysIncludeDecimalToolStripMenuItem.Size = new System.Drawing.Size(248, 22);
            this.asTextAlwaysIncludeDecimalToolStripMenuItem.Text = "As Text (Always Include Decimal)";
            this.asTextAlwaysIncludeDecimalToolStripMenuItem.Click += new System.EventHandler(this.asTextAlwaysIncludeDecimalToolStripMenuItem_Click);
            // 
            // numberToCurrencyToolStripMenuItem
            // 
            this.numberToCurrencyToolStripMenuItem.Name = "numberToCurrencyToolStripMenuItem";
            this.numberToCurrencyToolStripMenuItem.Size = new System.Drawing.Size(248, 22);
            this.numberToCurrencyToolStripMenuItem.Text = "As Currency";
            this.numberToCurrencyToolStripMenuItem.Click += new System.EventHandler(this.numberToCurrencyToolStripMenuItem_Click);
            // 
            // panel2
            // 
            this.panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(307, 24);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(701, 666);
            this.panel2.TabIndex = 7;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(307, 666);
            this.panel1.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(64, 321);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 44);
            this.button1.TabIndex = 0;
            this.button1.Text = "Mark Text for Deletion/Insertion";
            this.toolTip1.SetToolTip(this.button1, "Formats selected text with strikethrough and surrounds it\r\nwith brackets; sets in" +
        "sertion point after selected text; and\r\nturns on underscoring at insertion point" +
        ".");
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(64, 207);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 43);
            this.button2.TabIndex = 1;
            this.button2.Text = "Hello World";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 690);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WordPerfect Tools";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem insertToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem convertToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem numberToTextToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem numberToMoneyLegalStyleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem integerToTextToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem asTextAlwaysIncludeDecimalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem numberToCurrencyToolStripMenuItem;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem sampleTablesToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripMenuItem randomTextAndPlaceCursorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sampleMergeLetterToolStripMenuItem;
        private System.Windows.Forms.Button button2;
    }
}

