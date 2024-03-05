namespace Praktika_clock
{
    partial class Clock
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Clock));
            this.pictureBox_clock = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_clock)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_clock
            // 
            this.pictureBox_clock.BackColor = System.Drawing.Color.MidnightBlue;
            this.pictureBox_clock.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_clock.Image")));
            this.pictureBox_clock.Location = new System.Drawing.Point(0, 0);
            this.pictureBox_clock.Name = "pictureBox_clock";
            this.pictureBox_clock.Size = new System.Drawing.Size(350, 350);
            this.pictureBox_clock.TabIndex = 0;
            this.pictureBox_clock.TabStop = false;
            this.pictureBox_clock.Click += new System.EventHandler(this.pictureBox_clock_Click);
            // 
            // Clock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 350);
            this.Controls.Add(this.pictureBox_clock);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(350, 350);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(350, 350);
            this.Name = "Clock";
            this.Text = "Clock";
            this.Load += new System.EventHandler(this.Clock_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_clock)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_clock;
    }
}

