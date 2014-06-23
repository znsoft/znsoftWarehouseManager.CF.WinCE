namespace СкладскойУчет
{
    partial class Окно_выбора_из_списка
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
            this.СписокВыбора = new System.Windows.Forms.ListView();
            this.Назад = new System.Windows.Forms.Button();
            this.Далее = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // СписокВыбора
            // 
            this.СписокВыбора.FullRowSelect = true;
            this.СписокВыбора.Location = new System.Drawing.Point(3, 19);
            this.СписокВыбора.Name = "СписокВыбора";
            this.СписокВыбора.Size = new System.Drawing.Size(234, 234);
            this.СписокВыбора.TabIndex = 0;
            // 
            // Назад
            // 
            this.Назад.Location = new System.Drawing.Point(4, 259);
            this.Назад.Name = "Назад";
            this.Назад.Size = new System.Drawing.Size(118, 33);
            this.Назад.TabIndex = 1;
            this.Назад.Text = "0.Назад";
            this.Назад.Click += new System.EventHandler(this.ПриНажатииНаКнопку);
            // 
            // Далее
            // 
            this.Далее.Location = new System.Drawing.Point(128, 259);
            this.Далее.Name = "Далее";
            this.Далее.Size = new System.Drawing.Size(109, 33);
            this.Далее.TabIndex = 2;
            this.Далее.Text = "1.Далее";
            this.Далее.Click += new System.EventHandler(this.ПриНажатииНаКнопку);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 6F, System.Drawing.FontStyle.Regular);
            this.label1.Location = new System.Drawing.Point(3, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(232, 14);
            this.label1.Text = "label1";
            // 
            // Окно_выбора_из_списка
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(240, 320);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Далее);
            this.Controls.Add(this.Назад);
            this.Controls.Add(this.СписокВыбора);
            this.KeyPreview = true;
            this.Location = new System.Drawing.Point(0, 0);
            this.MinimizeBox = false;
            this.Name = "Окно_выбора_из_списка";
            this.Text = "Окно_выбора_из_списка";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Окно_выбора_из_списка_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView СписокВыбора;
        private System.Windows.Forms.Button Назад;
        private System.Windows.Forms.Button Далее;
        private System.Windows.Forms.Label label1;
    }
}