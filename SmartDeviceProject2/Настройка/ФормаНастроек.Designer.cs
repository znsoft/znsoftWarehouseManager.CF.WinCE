namespace СкладскойУчет
{
    partial class ФормаНастроек
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс  следует удалить; иначе ложно.</param>
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.Применить = new System.Windows.Forms.Button();
            this.Часть1ВебСсылки = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Часть3ВебСсылки = new System.Windows.Forms.TextBox();
            this.Часть4ВебСсылки = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Применить
            // 
            this.Применить.Location = new System.Drawing.Point(51, 213);
            this.Применить.Name = "Применить";
            this.Применить.Size = new System.Drawing.Size(144, 37);
            this.Применить.TabIndex = 0;
            this.Применить.Text = "Применить";
            this.Применить.Click += new System.EventHandler(this.Применить_Click);
            // 
            // Часть1ВебСсылки
            // 
            this.Часть1ВебСсылки.Location = new System.Drawing.Point(3, 87);
            this.Часть1ВебСсылки.Name = "Часть1ВебСсылки";
            this.Часть1ВебСсылки.Size = new System.Drawing.Size(234, 21);
            this.Часть1ВебСсылки.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(48, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 24);
            this.label3.Text = "Сервер";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(48, 123);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 24);
            this.label1.Text = "ВебСервис";
            // 
            // Часть3ВебСсылки
            // 
            this.Часть3ВебСсылки.Location = new System.Drawing.Point(3, 150);
            this.Часть3ВебСсылки.Name = "Часть3ВебСсылки";
            this.Часть3ВебСсылки.Size = new System.Drawing.Size(156, 21);
            this.Часть3ВебСсылки.TabIndex = 5;
            this.Часть3ВебСсылки.Text = "WS_Sklad";
            // 
            // Часть4ВебСсылки
            // 
            this.Часть4ВебСсылки.Enabled = false;
            this.Часть4ВебСсылки.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.Часть4ВебСсылки.Location = new System.Drawing.Point(159, 150);
            this.Часть4ВебСсылки.Name = "Часть4ВебСсылки";
            this.Часть4ВебСсылки.ReadOnly = true;
            this.Часть4ВебСсылки.Size = new System.Drawing.Size(81, 19);
            this.Часть4ВебСсылки.TabIndex = 7;
            this.Часть4ВебСсылки.Text = "/ws/TSD.1cws";
            // 
            // ФормаНастроек
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.Controls.Add(this.Часть4ВебСсылки);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Часть3ВебСсылки);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Часть1ВебСсылки);
            this.Controls.Add(this.Применить);
            this.Name = "ФормаНастроек";
            this.Text = "ФормаНастроек";
            this.Load += new System.EventHandler(this.ФормаНастроек_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Применить;
        private System.Windows.Forms.TextBox Часть1ВебСсылки;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Часть3ВебСсылки;
        private System.Windows.Forms.TextBox Часть4ВебСсылки;
    }
}