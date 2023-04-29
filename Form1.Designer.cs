namespace MazeGenerator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ResolveButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.WidthValue = new System.Windows.Forms.NumericUpDown();
            this.HeightValue = new System.Windows.Forms.NumericUpDown();
            this.MazeWidthLabel = new System.Windows.Forms.Label();
            this.MazeHeightLabel = new System.Windows.Forms.Label();
            this.CellSizeLabel = new System.Windows.Forms.Label();
            this.CellSizeValue = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.WidthValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HeightValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CellSizeValue)).BeginInit();
            this.SuspendLayout();
            // 
            // ResolveButton
            // 
            this.ResolveButton.Enabled = false;
            this.ResolveButton.Location = new System.Drawing.Point(31, 364);
            this.ResolveButton.Name = "ResolveButton";
            this.ResolveButton.Size = new System.Drawing.Size(95, 33);
            this.ResolveButton.TabIndex = 0;
            this.ResolveButton.Text = "Resolve";
            this.ResolveButton.UseVisualStyleBackColor = true;
            this.ResolveButton.Click += new System.EventHandler(this.ResolveButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(224, 364);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(129, 33);
            this.button1.TabIndex = 2;
            this.button1.Text = "Generate new maze";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.GenerateMazeClick);
            // 
            // WidthValue
            // 
            this.WidthValue.BackColor = System.Drawing.Color.White;
            this.WidthValue.Location = new System.Drawing.Point(79, 181);
            this.WidthValue.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            this.WidthValue.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.WidthValue.Name = "WidthValue";
            this.WidthValue.Size = new System.Drawing.Size(120, 20);
            this.WidthValue.TabIndex = 3;
            this.WidthValue.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // HeightValue
            // 
            this.HeightValue.BackColor = System.Drawing.Color.White;
            this.HeightValue.Location = new System.Drawing.Point(79, 210);
            this.HeightValue.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            this.HeightValue.Minimum = new decimal(new int[] { 2, 0, 0, 0 });
            this.HeightValue.Name = "HeightValue";
            this.HeightValue.Size = new System.Drawing.Size(120, 20);
            this.HeightValue.TabIndex = 4;
            this.HeightValue.Value = new decimal(new int[] { 2, 0, 0, 0 });
            // 
            // MazeWidthLabel
            // 
            this.MazeWidthLabel.BackColor = System.Drawing.Color.Wheat;
            this.MazeWidthLabel.Font = new System.Drawing.Font("Segoe UI Symbol", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MazeWidthLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.MazeWidthLabel.Location = new System.Drawing.Point(224, 181);
            this.MazeWidthLabel.Name = "MazeWidthLabel";
            this.MazeWidthLabel.Size = new System.Drawing.Size(100, 23);
            this.MazeWidthLabel.TabIndex = 6;
            this.MazeWidthLabel.Text = "Maze width";
            // 
            // MazeHeightLabel
            // 
            this.MazeHeightLabel.BackColor = System.Drawing.Color.BurlyWood;
            this.MazeHeightLabel.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MazeHeightLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.MazeHeightLabel.Location = new System.Drawing.Point(224, 204);
            this.MazeHeightLabel.Name = "MazeHeightLabel";
            this.MazeHeightLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.MazeHeightLabel.Size = new System.Drawing.Size(100, 23);
            this.MazeHeightLabel.TabIndex = 7;
            this.MazeHeightLabel.Text = "Maze height";
            // 
            // CellSizeLabel
            // 
            this.CellSizeLabel.BackColor = System.Drawing.Color.Tan;
            this.CellSizeLabel.Font = new System.Drawing.Font("Segoe UI Symbol", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CellSizeLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CellSizeLabel.Location = new System.Drawing.Point(224, 227);
            this.CellSizeLabel.Name = "CellSizeLabel";
            this.CellSizeLabel.Size = new System.Drawing.Size(100, 23);
            this.CellSizeLabel.TabIndex = 8;
            this.CellSizeLabel.Text = "Cell size";
            // 
            // CellSizeValue
            // 
            this.CellSizeValue.BackColor = System.Drawing.Color.White;
            this.CellSizeValue.Location = new System.Drawing.Point(79, 236);
            this.CellSizeValue.Minimum = new decimal(new int[] { 3, 0, 0, 0 });
            this.CellSizeValue.Name = "CellSizeValue";
            this.CellSizeValue.Size = new System.Drawing.Size(120, 20);
            this.CellSizeValue.TabIndex = 9;
            this.CellSizeValue.Value = new decimal(new int[] { 3, 0, 0, 0 });
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Mistral", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.PaleTurquoise;
            this.label2.Location = new System.Drawing.Point(110, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(167, 90);
            this.label2.TabIndex = 11;
            this.label2.Text = "MAZE GENERATOR";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSalmon;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(373, 418);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CellSizeValue);
            this.Controls.Add(this.CellSizeLabel);
            this.Controls.Add(this.MazeHeightLabel);
            this.Controls.Add(this.MazeWidthLabel);
            this.Controls.Add(this.HeightValue);
            this.Controls.Add(this.WidthValue);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ResolveButton);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Location = new System.Drawing.Point(15, 15);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "MazeGenerator v1.0";
            this.TransparencyKey = System.Drawing.Color.DimGray;
            this.Load += new System.EventHandler(this.Form1_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.WidthValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HeightValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CellSizeValue)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label label2;

        private System.Windows.Forms.Label MazeWidthLabel;
        private System.Windows.Forms.Label CellSizeLabel;
        private System.Windows.Forms.Label MazeHeightLabel;

        private System.Windows.Forms.NumericUpDown CellSizeValue;
        private System.Windows.Forms.NumericUpDown WidthValue;
        private System.Windows.Forms.NumericUpDown HeightValue;

        private System.Windows.Forms.Button button1;

        private System.Windows.Forms.Button ResolveButton;

        #endregion
    }
}