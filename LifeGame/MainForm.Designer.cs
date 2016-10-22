namespace LifeGame
{
    partial class MainForm
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
            this.bToggle = new System.Windows.Forms.Button();
            this.tDelay = new System.Windows.Forms.Timer(this.components);
            this.hsbDelay = new System.Windows.Forms.HScrollBar();
            this.pField = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // bToggle
            // 
            this.bToggle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bToggle.Location = new System.Drawing.Point(617, 315);
            this.bToggle.Name = "bToggle";
            this.bToggle.Size = new System.Drawing.Size(75, 23);
            this.bToggle.TabIndex = 0;
            this.bToggle.Text = "Старт";
            this.bToggle.UseVisualStyleBackColor = true;
            this.bToggle.Click += new System.EventHandler(this.bToggle_Click);
            // 
            // tDelay
            // 
            this.tDelay.Interval = 200;
            this.tDelay.Tick += new System.EventHandler(this.tDelay_Tick);
            // 
            // hsbDelay
            // 
            this.hsbDelay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hsbDelay.Location = new System.Drawing.Point(13, 315);
            this.hsbDelay.Maximum = 500;
            this.hsbDelay.Minimum = 50;
            this.hsbDelay.Name = "hsbDelay";
            this.hsbDelay.Size = new System.Drawing.Size(601, 23);
            this.hsbDelay.TabIndex = 2;
            this.hsbDelay.Value = 50;
            this.hsbDelay.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hsbDelay_Scroll);
            // 
            // pField
            // 
            this.pField.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pField.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pField.Location = new System.Drawing.Point(12, 12);
            this.pField.Name = "pField";
            this.pField.Size = new System.Drawing.Size(680, 297);
            this.pField.TabIndex = 3;
            this.pField.Paint += new System.Windows.Forms.PaintEventHandler(this.pField_Paint);
            this.pField.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pField_MouseClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 350);
            this.Controls.Add(this.pField);
            this.Controls.Add(this.hsbDelay);
            this.Controls.Add(this.bToggle);
            this.DoubleBuffered = true;
            this.Name = "MainForm";
            this.Text = "Жиза";
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bToggle;
        private System.Windows.Forms.Timer tDelay;
        private System.Windows.Forms.HScrollBar hsbDelay;
        private System.Windows.Forms.Panel pField;
    }
}

