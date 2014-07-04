namespace СкладскойУчет
{
    partial class Окно_перемещения_списка
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
            this.СписокПеремещения = new System.Windows.Forms.ListView();
            this.Назад = new System.Windows.Forms.Button();
            this.Далее = new System.Windows.Forms.Button();
            this.Пользователь = new System.Windows.Forms.Label();
            this.Инструкция = new System.Windows.Forms.Label();
            this.ТекстДЯ = new System.Windows.Forms.Label();
            this.Информация = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // СписокПеремещения
            // 
            this.СписокПеремещения.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            this.СписокПеремещения.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.СписокПеремещения.FullRowSelect = true;
            this.СписокПеремещения.Location = new System.Drawing.Point(0, 12);
            this.СписокПеремещения.Name = "СписокПеремещения";
            this.СписокПеремещения.Size = new System.Drawing.Size(238, 196);
            this.СписокПеремещения.TabIndex = 0;
            this.СписокПеремещения.Tag = "Таблица";
            this.СписокПеремещения.View = System.Windows.Forms.View.Details;
            this.СписокПеремещения.ItemActivate += new System.EventHandler(this.СписокВыбора_ItemActivate);
            // 
            // Назад
            // 
            this.Назад.Location = new System.Drawing.Point(1, 283);
            this.Назад.Name = "Назад";
            this.Назад.Size = new System.Drawing.Size(63, 22);
            this.Назад.TabIndex = 1;
            this.Назад.Text = "0.Назад";
            this.Назад.Click += new System.EventHandler(this.ПриНажатииНаКнопку);
            // 
            // Далее
            // 
            this.Далее.Location = new System.Drawing.Point(166, 283);
            this.Далее.Name = "Далее";
            this.Далее.Size = new System.Drawing.Size(67, 22);
            this.Далее.TabIndex = 2;
            this.Далее.Text = "1.Далее";
            this.Далее.Click += new System.EventHandler(this.ПриНажатииНаКнопку);
            // 
            // Пользователь
            // 
            this.Пользователь.BackColor = System.Drawing.SystemColors.Info;
            this.Пользователь.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.Пользователь.Location = new System.Drawing.Point(4, 307);
            this.Пользователь.Name = "Пользователь";
            this.Пользователь.Size = new System.Drawing.Size(229, 10);
            // 
            // Инструкция
            // 
            this.Инструкция.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.Инструкция.Location = new System.Drawing.Point(128, -1);
            this.Инструкция.Name = "Инструкция";
            this.Инструкция.Size = new System.Drawing.Size(105, 10);
            this.Инструкция.Tag = "Инструкция";
            // 
            // ТекстДЯ
            // 
            this.ТекстДЯ.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.ТекстДЯ.Location = new System.Drawing.Point(3, 0);
            this.ТекстДЯ.Name = "ТекстДЯ";
            this.ТекстДЯ.Size = new System.Drawing.Size(120, 10);
            this.ТекстДЯ.Tag = "Инструкция";
            // 
            // Информация
            // 
            this.Информация.Location = new System.Drawing.Point(4, 211);
            this.Информация.Name = "Информация";
            this.Информация.Size = new System.Drawing.Size(229, 69);
            this.Информация.Text = "Товар";
            // 
            // Окно_перемещения_списка
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(240, 320);
            this.ControlBox = false;
            this.Controls.Add(this.Информация);
            this.Controls.Add(this.ТекстДЯ);
            this.Controls.Add(this.Инструкция);
            this.Controls.Add(this.Пользователь);
            this.Controls.Add(this.Далее);
            this.Controls.Add(this.Назад);
            this.Controls.Add(this.СписокПеремещения);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.Name = "Окно_перемещения_списка";
            this.Text = "Выбор";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Окно_выбора_из_списка_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Окно_выбора_из_списка_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView СписокПеремещения;
        private System.Windows.Forms.Button Назад;
        private System.Windows.Forms.Button Далее;
        private System.Windows.Forms.Label Пользователь;
        private System.Windows.Forms.Label Инструкция;
        private System.Windows.Forms.Label ТекстДЯ;
        private System.Windows.Forms.Label Информация;
    }
}