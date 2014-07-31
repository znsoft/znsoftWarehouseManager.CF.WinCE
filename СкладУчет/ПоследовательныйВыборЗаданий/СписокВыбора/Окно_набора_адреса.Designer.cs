namespace СкладскойУчет
{
    partial class Окно_набора_адреса
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
            this.Инструкция = new System.Windows.Forms.Label();
            this.Пользователь = new System.Windows.Forms.Label();
            this.Далее = new System.Windows.Forms.Button();
            this.Назад = new System.Windows.Forms.Button();
            this.ПрефиксАдреса = new System.Windows.Forms.Label();
            this.ВводАдреса = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Инструкция
            // 
            this.Инструкция.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular);
            this.Инструкция.Location = new System.Drawing.Point(3, 13);
            this.Инструкция.Name = "Инструкция";
            this.Инструкция.Size = new System.Drawing.Size(232, 178);
            this.Инструкция.Tag = "Инструкция";
            this.Инструкция.Text = "Необходимо сканировать адрес или ячеку для перемещения товара";
            // 
            // Пользователь
            // 
            this.Пользователь.BackColor = System.Drawing.SystemColors.Info;
            this.Пользователь.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.Пользователь.Location = new System.Drawing.Point(3, 305);
            this.Пользователь.Name = "Пользователь";
            this.Пользователь.Size = new System.Drawing.Size(113, 12);
            this.Пользователь.Text = "Пользователь";
            // 
            // Далее
            // 
            this.Далее.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.Далее.Location = new System.Drawing.Point(134, 280);
            this.Далее.Name = "Далее";
            this.Далее.Size = new System.Drawing.Size(100, 22);
            this.Далее.TabIndex = 7;
            this.Далее.Text = "Далее";
            this.Далее.Click += new System.EventHandler(this.ПриНажатииНаКнопку);
            // 
            // Назад
            // 
            this.Назад.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.Назад.Location = new System.Drawing.Point(0, 280);
            this.Назад.Name = "Назад";
            this.Назад.Size = new System.Drawing.Size(100, 22);
            this.Назад.TabIndex = 6;
            this.Назад.Text = "Назад";
            this.Назад.Click += new System.EventHandler(this.ПриНажатииНаКнопку);
            // 
            // ПрефиксАдреса
            // 
            this.ПрефиксАдреса.BackColor = System.Drawing.Color.White;
            this.ПрефиксАдреса.Location = new System.Drawing.Point(8, 191);
            this.ПрефиксАдреса.Name = "ПрефиксАдреса";
            this.ПрефиксАдреса.Size = new System.Drawing.Size(29, 22);
            this.ПрефиксАдреса.Text = "adr";
            this.ПрефиксАдреса.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // ВводАдреса
            // 
            this.ВводАдреса.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ВводАдреса.Location = new System.Drawing.Point(37, 191);
            this.ВводАдреса.MaxLength = 7;
            this.ВводАдреса.Name = "ВводАдреса";
            this.ВводАдреса.Size = new System.Drawing.Size(156, 23);
            this.ВводАдреса.TabIndex = 11;
            this.ВводАдреса.WordWrap = false;
            this.ВводАдреса.TextChanged += new System.EventHandler(this.ВводАдреса_TextChanged);
            this.ВводАдреса.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ВводАдреса_KeyPress);
            // 
            // Окно_набора_адреса
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(240, 320);
            this.ControlBox = false;
            this.Controls.Add(this.ВводАдреса);
            this.Controls.Add(this.ПрефиксАдреса);
            this.Controls.Add(this.Далее);
            this.Controls.Add(this.Назад);
            this.Controls.Add(this.Инструкция);
            this.Controls.Add(this.Пользователь);
            this.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.Name = "Окно_набора_адреса";
            this.Text = "Выбор динамической ячейки подбора";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Окно_сканирования_ТС_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Окно_сканирования_ТС_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label Инструкция;
        private System.Windows.Forms.Label Пользователь;
        private System.Windows.Forms.Button Далее;
        private System.Windows.Forms.Button Назад;
        private System.Windows.Forms.Label ПрефиксАдреса;
        private System.Windows.Forms.TextBox ВводАдреса;

    }
}