namespace mosu
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnIncreaseOut = new System.Windows.Forms.Button();
            this.btnDecreaseOut = new System.Windows.Forms.Button();
            this.btnIncrease12 = new System.Windows.Forms.Button();
            this.btnDecrease12 = new System.Windows.Forms.Button();
            this.btnIncreaseIn1 = new System.Windows.Forms.Button();
            this.btnDecreaseIn1 = new System.Windows.Forms.Button();
            this.btnIncreaseIn2 = new System.Windows.Forms.Button();
            this.btnDecreaseIn2 = new System.Windows.Forms.Button();
            this.btnMode = new System.Windows.Forms.Button();
            this.lblMode = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, -4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(802, 456);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnIncreaseOut
            // 
            this.btnIncreaseOut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnIncreaseOut.Location = new System.Drawing.Point(674, 329);
            this.btnIncreaseOut.Name = "btnIncreaseOut";
            this.btnIncreaseOut.Size = new System.Drawing.Size(32, 23);
            this.btnIncreaseOut.TabIndex = 1;
            this.btnIncreaseOut.Text = "+";
            this.btnIncreaseOut.UseVisualStyleBackColor = false;
            this.btnIncreaseOut.Click += new System.EventHandler(this.btnIncreaseOut_Click);
            // 
            // btnDecreaseOut
            // 
            this.btnDecreaseOut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnDecreaseOut.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnDecreaseOut.Location = new System.Drawing.Point(622, 329);
            this.btnDecreaseOut.Name = "btnDecreaseOut";
            this.btnDecreaseOut.Size = new System.Drawing.Size(30, 23);
            this.btnDecreaseOut.TabIndex = 2;
            this.btnDecreaseOut.Text = "-";
            this.btnDecreaseOut.UseVisualStyleBackColor = false;
            this.btnDecreaseOut.Click += new System.EventHandler(this.btnDecreaseOut_Click);
            // 
            // btnIncrease12
            // 
            this.btnIncrease12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnIncrease12.Location = new System.Drawing.Point(403, 329);
            this.btnIncrease12.Name = "btnIncrease12";
            this.btnIncrease12.Size = new System.Drawing.Size(30, 23);
            this.btnIncrease12.TabIndex = 3;
            this.btnIncrease12.Text = "+";
            this.btnIncrease12.UseVisualStyleBackColor = false;
            this.btnIncrease12.Click += new System.EventHandler(this.btnIncrease12_Click);
            // 
            // btnDecrease12
            // 
            this.btnDecrease12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnDecrease12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnDecrease12.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnDecrease12.Location = new System.Drawing.Point(353, 329);
            this.btnDecrease12.Name = "btnDecrease12";
            this.btnDecrease12.Size = new System.Drawing.Size(32, 23);
            this.btnDecrease12.TabIndex = 4;
            this.btnDecrease12.Text = "-";
            this.btnDecrease12.UseVisualStyleBackColor = false;
            this.btnDecrease12.Click += new System.EventHandler(this.btnDecrease12_Click);
            // 
            // btnIncreaseIn1
            // 
            this.btnIncreaseIn1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnIncreaseIn1.Location = new System.Drawing.Point(250, 69);
            this.btnIncreaseIn1.Name = "btnIncreaseIn1";
            this.btnIncreaseIn1.Size = new System.Drawing.Size(31, 23);
            this.btnIncreaseIn1.TabIndex = 5;
            this.btnIncreaseIn1.Text = "+";
            this.btnIncreaseIn1.UseVisualStyleBackColor = false;
            this.btnIncreaseIn1.Click += new System.EventHandler(this.btnIncreaseIn1_Click);
            // 
            // btnDecreaseIn1
            // 
            this.btnDecreaseIn1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnDecreaseIn1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnDecreaseIn1.Location = new System.Drawing.Point(173, 69);
            this.btnDecreaseIn1.Name = "btnDecreaseIn1";
            this.btnDecreaseIn1.Size = new System.Drawing.Size(30, 23);
            this.btnDecreaseIn1.TabIndex = 6;
            this.btnDecreaseIn1.Text = "-";
            this.btnDecreaseIn1.UseVisualStyleBackColor = false;
            this.btnDecreaseIn1.Click += new System.EventHandler(this.btnDecreaseIn1_Click);
            // 
            // btnIncreaseIn2
            // 
            this.btnIncreaseIn2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnIncreaseIn2.Location = new System.Drawing.Point(182, 329);
            this.btnIncreaseIn2.Name = "btnIncreaseIn2";
            this.btnIncreaseIn2.Size = new System.Drawing.Size(31, 23);
            this.btnIncreaseIn2.TabIndex = 7;
            this.btnIncreaseIn2.Text = "+";
            this.btnIncreaseIn2.UseVisualStyleBackColor = false;
            this.btnIncreaseIn2.Click += new System.EventHandler(this.btnIncreaseIn2_Click);
            // 
            // btnDecreaseIn2
            // 
            this.btnDecreaseIn2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnDecreaseIn2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnDecreaseIn2.Location = new System.Drawing.Point(132, 329);
            this.btnDecreaseIn2.Name = "btnDecreaseIn2";
            this.btnDecreaseIn2.Size = new System.Drawing.Size(31, 23);
            this.btnDecreaseIn2.TabIndex = 8;
            this.btnDecreaseIn2.Text = "-";
            this.btnDecreaseIn2.UseVisualStyleBackColor = false;
            this.btnDecreaseIn2.Click += new System.EventHandler(this.btnDecreaseIn2_Click);
            // 
            // btnMode
            // 
            this.btnMode.Location = new System.Drawing.Point(622, 69);
            this.btnMode.Name = "btnMode";
            this.btnMode.Size = new System.Drawing.Size(75, 23);
            this.btnMode.TabIndex = 9;
            this.btnMode.Text = "Mode";
            this.btnMode.UseVisualStyleBackColor = true;
            this.btnMode.Click += new System.EventHandler(this.btnMode_Click_1);
            // 
            // lblMode
            // 
            this.lblMode.AutoSize = true;
            this.lblMode.Location = new System.Drawing.Point(639, 95);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(42, 13);
            this.lblMode.TabIndex = 10;
            this.lblMode.Text = "Manual";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblMode);
            this.Controls.Add(this.btnMode);
            this.Controls.Add(this.btnDecreaseIn2);
            this.Controls.Add(this.btnIncreaseIn2);
            this.Controls.Add(this.btnDecreaseIn1);
            this.Controls.Add(this.btnIncreaseIn1);
            this.Controls.Add(this.btnDecrease12);
            this.Controls.Add(this.btnIncrease12);
            this.Controls.Add(this.btnDecreaseOut);
            this.Controls.Add(this.btnIncreaseOut);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnIncreaseOut;
        private System.Windows.Forms.Button btnDecreaseOut;
        private System.Windows.Forms.Button btnIncrease12;
        private System.Windows.Forms.Button btnDecrease12;
        private System.Windows.Forms.Button btnIncreaseIn1;
        private System.Windows.Forms.Button btnDecreaseIn1;
        private System.Windows.Forms.Button btnIncreaseIn2;
        private System.Windows.Forms.Button btnDecreaseIn2;
        private System.Windows.Forms.Button btnMode;
        private System.Windows.Forms.Label lblMode;
    }
}

