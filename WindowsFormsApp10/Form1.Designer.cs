namespace WindowsFormsApp10
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
            this.LstCommands = new System.Windows.Forms.ListBox();
            this.TmrSpeaking = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.btn_start = new System.Windows.Forms.Button();
            this.btn_Stop = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.btn_clear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LstCommands
            // 
            this.LstCommands.BackColor = System.Drawing.SystemColors.Desktop;
            this.LstCommands.Dock = System.Windows.Forms.DockStyle.Right;
            this.LstCommands.ForeColor = System.Drawing.SystemColors.Window;
            this.LstCommands.FormattingEnabled = true;
            this.LstCommands.ItemHeight = 12;
            this.LstCommands.Location = new System.Drawing.Point(426, 0);
            this.LstCommands.Name = "LstCommands";
            this.LstCommands.Size = new System.Drawing.Size(329, 414);
            this.LstCommands.TabIndex = 0;
            // 
            // TmrSpeaking
            // 
            this.TmrSpeaking.Enabled = true;
            this.TmrSpeaking.Interval = 1000;
            this.TmrSpeaking.Tick += new System.EventHandler(this.TmrSpeaking_Tick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(345, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_start
            // 
            this.btn_start.Location = new System.Drawing.Point(12, 196);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(75, 23);
            this.btn_start.TabIndex = 2;
            this.btn_start.Text = "start";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // btn_Stop
            // 
            this.btn_Stop.Location = new System.Drawing.Point(123, 195);
            this.btn_Stop.Name = "btn_Stop";
            this.btn_Stop.Size = new System.Drawing.Size(75, 23);
            this.btn_Stop.TabIndex = 3;
            this.btn_Stop.Text = "stop";
            this.btn_Stop.UseVisualStyleBackColor = true;
            this.btn_Stop.Click += new System.EventHandler(this.btn_Stop_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 12);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(296, 178);
            this.richTextBox1.TabIndex = 4;
            this.richTextBox1.Text = "";
            // 
            // btn_clear
            // 
            this.btn_clear.Location = new System.Drawing.Point(233, 196);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(75, 23);
            this.btn_clear.TabIndex = 5;
            this.btn_clear.Text = "clear";
            this.btn_clear.UseVisualStyleBackColor = true;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(755, 414);
            this.Controls.Add(this.btn_clear);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.btn_Stop);
            this.Controls.Add(this.btn_start);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.LstCommands);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox LstCommands;
        private System.Windows.Forms.Timer TmrSpeaking;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.Button btn_Stop;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button btn_clear;
    }
}

