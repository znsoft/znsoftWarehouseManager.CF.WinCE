namespace SmartDeviceProject2
{
    partial class ФормаАвторизации
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
            this.Меню = new System.Windows.Forms.MenuItem();
            this.Войти = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.СписокФирм = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Пароль = new System.Windows.Forms.TextBox();
            this.Сотрудник = new System.Windows.Forms.ComboBox();
            this.ПоказыватьПароль = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.Меню);
            // 
            // Меню
            // 
            this.Меню.Text = "Настройки";
            // 
            // Войти
            // 
            this.Войти.Location = new System.Drawing.Point(45, 212);
            this.Войти.Name = "Войти";
            this.Войти.Size = new System.Drawing.Size(150, 24);
            this.Войти.TabIndex = 0;
            this.Войти.Text = "Войти";
            this.Войти.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(45, 242);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(150, 21);
            this.button2.TabIndex = 1;
            this.button2.Text = "Выход";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // СписокФирм
            // 
            this.СписокФирм.Enabled = false;
            this.СписокФирм.Items.Add("Прим Аэртон");
            this.СписокФирм.Items.Add("Тест");
            this.СписокФирм.Location = new System.Drawing.Point(4, 70);
            this.СписокФирм.Name = "СписокФирм";
            this.СписокФирм.Size = new System.Drawing.Size(230, 22);
            this.СписокФирм.TabIndex = 2;
            this.СписокФирм.SelectedIndexChanged += new System.EventHandler(this.СписокФирм_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(9, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(227, 22);
            this.label1.Text = "Ваш филиал:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(9, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 20);
            this.label2.Text = "Сотрудник";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(9, 161);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(222, 21);
            this.label3.Text = "Пароль";
            // 
            // Пароль
            // 
            this.Пароль.Location = new System.Drawing.Point(4, 185);
            this.Пароль.Name = "Пароль";
            this.Пароль.PasswordChar = '*';
            this.Пароль.Size = new System.Drawing.Size(191, 21);
            this.Пароль.TabIndex = 7;
            // 
            // Сотрудник
            // 
            this.Сотрудник.Location = new System.Drawing.Point(4, 128);
            this.Сотрудник.Name = "Сотрудник";
            this.Сотрудник.Size = new System.Drawing.Size(230, 22);
            this.Сотрудник.TabIndex = 11;
            this.Сотрудник.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // ПоказыватьПароль
            // 
            this.ПоказыватьПароль.Location = new System.Drawing.Point(197, 185);
            this.ПоказыватьПароль.Name = "ПоказыватьПароль";
            this.ПоказыватьПароль.Size = new System.Drawing.Size(39, 20);
            this.ПоказыватьПароль.TabIndex = 12;
            this.ПоказыватьПароль.Text = "показать";
            this.ПоказыватьПароль.CheckStateChanged += new System.EventHandler(this.ПоказыватьПароль_CheckStateChanged);
            // 
            // ФормаАвторизации
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(240, 320);
            this.Controls.Add(this.ПоказыватьПароль);
            this.Controls.Add(this.Сотрудник);
            this.Controls.Add(this.Пароль);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.СписокФирм);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.Войти);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "ФормаАвторизации";
            this.Text = "Form1";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Войти;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox СписокФирм;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Пароль;
        private System.Windows.Forms.MenuItem Меню;
        private System.Windows.Forms.ComboBox Сотрудник;
        private System.Windows.Forms.CheckBox ПоказыватьПароль;
    }
}

