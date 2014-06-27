namespace СкладскойУчет
{
    partial class ОсновноеМеню
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
            this.Пользователь = new System.Windows.Forms.Label();
            this.Выход = new System.Windows.Forms.Button();
            this.Перемещение = new System.Windows.Forms.Button();
            this.Инвентаризация = new System.Windows.Forms.Button();
            this.Табулятор = new System.Windows.Forms.TabControl();
            this.Панель_ОсновногоМеню = new System.Windows.Forms.TabPage();
            this.Подбор = new System.Windows.Forms.Button();
            this.Панель_Информации = new System.Windows.Forms.TabPage();
            this.СписокИнформации = new System.Windows.Forms.TextBox();
            this.Табулятор.SuspendLayout();
            this.Панель_ОсновногоМеню.SuspendLayout();
            this.Панель_Информации.SuspendLayout();
            this.SuspendLayout();
            // 
            // Пользователь
            // 
            this.Пользователь.Location = new System.Drawing.Point(0, 254);
            this.Пользователь.Name = "Пользователь";
            this.Пользователь.Size = new System.Drawing.Size(240, 20);
            // 
            // Выход
            // 
            this.Выход.Location = new System.Drawing.Point(3, 178);
            this.Выход.Name = "Выход";
            this.Выход.Size = new System.Drawing.Size(226, 38);
            this.Выход.TabIndex = 4;
            this.Выход.Text = "0.Выход";
            this.Выход.Click += new System.EventHandler(this.ПриНажатииНаКнопку);
            // 
            // Перемещение
            // 
            this.Перемещение.Location = new System.Drawing.Point(3, 105);
            this.Перемещение.Name = "Перемещение";
            this.Перемещение.Size = new System.Drawing.Size(226, 38);
            this.Перемещение.TabIndex = 3;
            this.Перемещение.Text = "3.Переместить";
            this.Перемещение.Click += new System.EventHandler(this.ПриНажатииНаКнопку);
            // 
            // Инвентаризация
            // 
            this.Инвентаризация.Location = new System.Drawing.Point(3, 63);
            this.Инвентаризация.Name = "Инвентаризация";
            this.Инвентаризация.Size = new System.Drawing.Size(226, 36);
            this.Инвентаризация.TabIndex = 2;
            this.Инвентаризация.Text = "2.Инвентаризация";
            this.Инвентаризация.Click += new System.EventHandler(this.ПриНажатииНаКнопку);
            // 
            // Табулятор
            // 
            this.Табулятор.Controls.Add(this.Панель_ОсновногоМеню);
            this.Табулятор.Controls.Add(this.Панель_Информации);
            this.Табулятор.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular);
            this.Табулятор.Location = new System.Drawing.Point(0, 0);
            this.Табулятор.Name = "Табулятор";
            this.Табулятор.SelectedIndex = 0;
            this.Табулятор.Size = new System.Drawing.Size(240, 251);
            this.Табулятор.TabIndex = 8;
            // 
            // Панель_ОсновногоМеню
            // 
            this.Панель_ОсновногоМеню.BackColor = System.Drawing.SystemColors.Info;
            this.Панель_ОсновногоМеню.Controls.Add(this.Подбор);
            this.Панель_ОсновногоМеню.Controls.Add(this.Инвентаризация);
            this.Панель_ОсновногоМеню.Controls.Add(this.Выход);
            this.Панель_ОсновногоМеню.Controls.Add(this.Перемещение);
            this.Панель_ОсновногоМеню.Location = new System.Drawing.Point(0, 0);
            this.Панель_ОсновногоМеню.Name = "Панель_ОсновногоМеню";
            this.Панель_ОсновногоМеню.Size = new System.Drawing.Size(240, 228);
            this.Панель_ОсновногоМеню.Text = "<Задания";
            // 
            // Подбор
            // 
            this.Подбор.Location = new System.Drawing.Point(3, 21);
            this.Подбор.Name = "Подбор";
            this.Подбор.Size = new System.Drawing.Size(226, 36);
            this.Подбор.TabIndex = 1;
            this.Подбор.Text = "1.Подбор";
            this.Подбор.Click += new System.EventHandler(this.ПриНажатииНаКнопку);
            // 
            // Панель_Информации
            // 
            this.Панель_Информации.BackColor = System.Drawing.SystemColors.Info;
            this.Панель_Информации.Controls.Add(this.СписокИнформации);
            this.Панель_Информации.Location = new System.Drawing.Point(0, 0);
            this.Панель_Информации.Name = "Панель_Информации";
            this.Панель_Информации.Size = new System.Drawing.Size(232, 224);
            this.Панель_Информации.Text = "Поиск>";
            // 
            // СписокИнформации
            // 
            this.СписокИнформации.AcceptsReturn = true;
            this.СписокИнформации.Location = new System.Drawing.Point(8, 4);
            this.СписокИнформации.Multiline = true;
            this.СписокИнформации.Name = "СписокИнформации";
            this.СписокИнформации.ReadOnly = true;
            this.СписокИнформации.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.СписокИнформации.Size = new System.Drawing.Size(225, 221);
            this.СписокИнформации.TabIndex = 0;
            this.СписокИнформации.Text = "Сканируйте ШК для получения информации";
            // 
            // ОсновноеМеню
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.ControlBox = false;
            this.Controls.Add(this.Табулятор);
            this.Controls.Add(this.Пользователь);
            this.Name = "ОсновноеМеню";
            this.Text = "Основное меню";
            this.Load += new System.EventHandler(this.ОсновноеМеню_Load);
            this.Closed += new System.EventHandler(this.ОсновноеМеню_Closed);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.ОсновноеМеню_Closing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ОсновноеМеню_KeyDown);
            this.Табулятор.ResumeLayout(false);
            this.Панель_ОсновногоМеню.ResumeLayout(false);
            this.Панель_Информации.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label Пользователь;
        private System.Windows.Forms.Button Выход;
        private System.Windows.Forms.Button Перемещение;
        private System.Windows.Forms.Button Инвентаризация;
        private System.Windows.Forms.TabControl Табулятор;
        private System.Windows.Forms.TabPage Панель_ОсновногоМеню;
        private System.Windows.Forms.TabPage Панель_Информации;
        private System.Windows.Forms.Button Подбор;
        private System.Windows.Forms.TextBox СписокИнформации;
    }
}