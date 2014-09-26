namespace СкладскойУчет
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ФормаАвторизации));
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.Меню = new System.Windows.Forms.MenuItem();
            this.Войти = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Пароль = new System.Windows.Forms.TextBox();
            this.Сотрудник = new System.Windows.Forms.ComboBox();
            this.ПоказыватьПароль = new System.Windows.Forms.CheckBox();
            this.ТекстОшибки = new System.Windows.Forms.Label();
            this.ВерсияПрограммы = new System.Windows.Forms.Label();
            this.ПолеВводаСервер = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.КнопкаОбновить = new System.Windows.Forms.PictureBox();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.Меню);
            // 
            // Меню
            // 
            this.Меню.Text = "Настройки";
            this.Меню.Click += new System.EventHandler(this.Меню_Click);
            // 
            // Войти
            // 
            this.Войти.Location = new System.Drawing.Point(45, 207);
            this.Войти.Name = "Войти";
            this.Войти.Size = new System.Drawing.Size(150, 24);
            this.Войти.TabIndex = 0;
            this.Войти.Text = "Войти";
            this.Войти.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(9, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 20);
            this.label2.Text = "Сотрудник";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(9, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(222, 21);
            this.label3.Text = "Пароль";
            // 
            // Пароль
            // 
            this.Пароль.Location = new System.Drawing.Point(4, 152);
            this.Пароль.Name = "Пароль";
            this.Пароль.PasswordChar = '*';
            this.Пароль.Size = new System.Drawing.Size(230, 23);
            this.Пароль.TabIndex = 7;
            this.Пароль.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Пароль_KeyDown);
            // 
            // Сотрудник
            // 
            this.Сотрудник.Location = new System.Drawing.Point(4, 95);
            this.Сотрудник.Name = "Сотрудник";
            this.Сотрудник.Size = new System.Drawing.Size(230, 23);
            this.Сотрудник.TabIndex = 11;
            this.Сотрудник.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // ПоказыватьПароль
            // 
            this.ПоказыватьПароль.Location = new System.Drawing.Point(45, 179);
            this.ПоказыватьПароль.Name = "ПоказыватьПароль";
            this.ПоказыватьПароль.Size = new System.Drawing.Size(150, 20);
            this.ПоказыватьПароль.TabIndex = 12;
            this.ПоказыватьПароль.Text = "показать пароль";
            this.ПоказыватьПароль.CheckStateChanged += new System.EventHandler(this.ПоказыватьПароль_CheckStateChanged);
            // 
            // ТекстОшибки
            // 
            this.ТекстОшибки.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular);
            this.ТекстОшибки.Location = new System.Drawing.Point(-1, 238);
            this.ТекстОшибки.Name = "ТекстОшибки";
            this.ТекстОшибки.Size = new System.Drawing.Size(240, 16);
            this.ТекстОшибки.Text = "Необходимо выбрать себя из списка";
            // 
            // ВерсияПрограммы
            // 
            this.ВерсияПрограммы.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular);
            this.ВерсияПрограммы.Location = new System.Drawing.Point(0, 254);
            this.ВерсияПрограммы.Name = "ВерсияПрограммы";
            this.ВерсияПрограммы.Size = new System.Drawing.Size(240, 14);
            this.ВерсияПрограммы.Text = "Версия c#1";
            // 
            // ПолеВводаСервер
            // 
            this.ПолеВводаСервер.Location = new System.Drawing.Point(4, 30);
            this.ПолеВводаСервер.Name = "ПолеВводаСервер";
            this.ПолеВводаСервер.Size = new System.Drawing.Size(191, 23);
            this.ПолеВводаСервер.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(9, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 21);
            this.label1.Text = "Сервер";
            // 
            // КнопкаОбновить
            // 
            this.КнопкаОбновить.BackColor = System.Drawing.Color.WhiteSmoke;
            this.КнопкаОбновить.Image = ((System.Drawing.Image)(resources.GetObject("КнопкаОбновить.Image")));
            this.КнопкаОбновить.Location = new System.Drawing.Point(199, 20);
            this.КнопкаОбновить.Name = "КнопкаОбновить";
            this.КнопкаОбновить.Size = new System.Drawing.Size(35, 33);
            this.КнопкаОбновить.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.КнопкаОбновить.Click += new System.EventHandler(this.КнопкаОбновить_Click);
            // 
            // ФормаАвторизации
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.КнопкаОбновить);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ПолеВводаСервер);
            this.Controls.Add(this.ВерсияПрограммы);
            this.Controls.Add(this.ТекстОшибки);
            this.Controls.Add(this.ПоказыватьПароль);
            this.Controls.Add(this.Сотрудник);
            this.Controls.Add(this.Пароль);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Войти);
            this.Name = "ФормаАвторизации";
            this.Text = "Авторизация";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.ФормаАвторизации_Closing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Войти;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Пароль;
        private System.Windows.Forms.MenuItem Меню;
        private System.Windows.Forms.ComboBox Сотрудник;
        private System.Windows.Forms.CheckBox ПоказыватьПароль;
        private System.Windows.Forms.Label ТекстОшибки;
        private System.Windows.Forms.Label ВерсияПрограммы;
        private System.Windows.Forms.TextBox ПолеВводаСервер;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox КнопкаОбновить;
    }
}

