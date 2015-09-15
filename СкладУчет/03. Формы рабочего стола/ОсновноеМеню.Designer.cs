namespace СкладскойУчет
{
    partial class ОсновноеМеню
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.Пользователь = new System.Windows.Forms.Label();
            this.Выход = new System.Windows.Forms.Button();
            this.Перемещение = new System.Windows.Forms.Button();
            this.Инвентаризация = new System.Windows.Forms.Button();
            this.Табулятор = new System.Windows.Forms.TabControl();
            this.Панель_ОсновногоМеню = new System.Windows.Forms.TabPage();
            this.ПодборЗК = new System.Windows.Forms.Button();
            this.ПогрузкаМест = new System.Windows.Forms.Button();
            this.РазгрузкаМест = new System.Windows.Forms.Button();
            this.Подтоварка = new System.Windows.Forms.Button();
            this.Подбор = new System.Windows.Forms.Button();
            this.Панель_Информации = new System.Windows.Forms.TabPage();
            this.РучнойКод = new System.Windows.Forms.TextBox();
            this.СписокИнформации = new System.Windows.Forms.TextBox();
            this.ОбработкаМест = new System.Windows.Forms.Button();
            this.Табулятор.SuspendLayout();
            this.Панель_ОсновногоМеню.SuspendLayout();
            this.Панель_Информации.SuspendLayout();
            this.SuspendLayout();
            // 
            // Пользователь
            // 
            this.Пользователь.Location = new System.Drawing.Point(0, 252);
            this.Пользователь.Name = "Пользователь";
            this.Пользователь.Size = new System.Drawing.Size(240, 14);
            this.Пользователь.Text = "Пользователь";
            // 
            // Выход
            // 
            this.Выход.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.Выход.Location = new System.Drawing.Point(3, 198);
            this.Выход.Name = "Выход";
            this.Выход.Size = new System.Drawing.Size(226, 23);
            this.Выход.TabIndex = 9;
            this.Выход.Text = "&0.Выход";
            this.Выход.Click += new System.EventHandler(this.ПриНажатииНаКнопку);
            this.Выход.GotFocus += new System.EventHandler(this.ФокусированиеКнопки);
            this.Выход.LostFocus += new System.EventHandler(this.РасфокусированиеКнопки);
            // 
            // Перемещение
            // 
            this.Перемещение.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.Перемещение.Location = new System.Drawing.Point(3, 53);
            this.Перемещение.Name = "Перемещение";
            this.Перемещение.Size = new System.Drawing.Size(226, 21);
            this.Перемещение.TabIndex = 3;
            this.Перемещение.Text = "&5. Переместить";
            this.Перемещение.Click += new System.EventHandler(this.ПриНажатииНаКнопку);
            this.Перемещение.GotFocus += new System.EventHandler(this.ФокусированиеКнопки);
            this.Перемещение.LostFocus += new System.EventHandler(this.РасфокусированиеКнопки);
            // 
            // Инвентаризация
            // 
            this.Инвентаризация.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.Инвентаризация.Location = new System.Drawing.Point(3, 29);
            this.Инвентаризация.Name = "Инвентаризация";
            this.Инвентаризация.Size = new System.Drawing.Size(226, 21);
            this.Инвентаризация.TabIndex = 2;
            this.Инвентаризация.Text = "&4. Инвентаризация";
            this.Инвентаризация.Click += new System.EventHandler(this.ПриНажатииНаКнопку);
            this.Инвентаризация.GotFocus += new System.EventHandler(this.ФокусированиеКнопки);
            this.Инвентаризация.LostFocus += new System.EventHandler(this.РасфокусированиеКнопки);
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
            this.Табулятор.TabIndex = 10;
            // 
            // Панель_ОсновногоМеню
            // 
            this.Панель_ОсновногоМеню.BackColor = System.Drawing.SystemColors.Info;
            this.Панель_ОсновногоМеню.Controls.Add(this.ОбработкаМест);
            this.Панель_ОсновногоМеню.Controls.Add(this.ПодборЗК);
            this.Панель_ОсновногоМеню.Controls.Add(this.ПогрузкаМест);
            this.Панель_ОсновногоМеню.Controls.Add(this.РазгрузкаМест);
            this.Панель_ОсновногоМеню.Controls.Add(this.Подтоварка);
            this.Панель_ОсновногоМеню.Controls.Add(this.Подбор);
            this.Панель_ОсновногоМеню.Controls.Add(this.Инвентаризация);
            this.Панель_ОсновногоМеню.Controls.Add(this.Выход);
            this.Панель_ОсновногоМеню.Controls.Add(this.Перемещение);
            this.Панель_ОсновногоМеню.Location = new System.Drawing.Point(4, 23);
            this.Панель_ОсновногоМеню.Name = "Панель_ОсновногоМеню";
            this.Панель_ОсновногоМеню.Size = new System.Drawing.Size(232, 224);
            this.Панель_ОсновногоМеню.Text = "1.Задания";
            // 
            // ПодборЗК
            // 
            this.ПодборЗК.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.ПодборЗК.Location = new System.Drawing.Point(3, 173);
            this.ПодборЗК.Name = "ПодборЗК";
            this.ПодборЗК.Size = new System.Drawing.Size(226, 21);
            this.ПодборЗК.TabIndex = 8;
            this.ПодборЗК.Text = "&1&0. Подбор заказов клиентов";
            this.ПодборЗК.Click += new System.EventHandler(this.ПриНажатииНаКнопку);
            this.ПодборЗК.GotFocus += new System.EventHandler(this.ФокусированиеКнопки);
            this.ПодборЗК.LostFocus += new System.EventHandler(this.РасфокусированиеКнопки);
            // 
            // ПогрузкаМест
            // 
            this.ПогрузкаМест.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.ПогрузкаМест.Location = new System.Drawing.Point(3, 125);
            this.ПогрузкаМест.Name = "ПогрузкаМест";
            this.ПогрузкаМест.Size = new System.Drawing.Size(226, 21);
            this.ПогрузкаМест.TabIndex = 6;
            this.ПогрузкаМест.Text = "&8. Погрузка мест";
            this.ПогрузкаМест.Click += new System.EventHandler(this.ПриНажатииНаКнопку);
            this.ПогрузкаМест.GotFocus += new System.EventHandler(this.ФокусированиеКнопки);
            this.ПогрузкаМест.LostFocus += new System.EventHandler(this.РасфокусированиеКнопки);
            // 
            // РазгрузкаМест
            // 
            this.РазгрузкаМест.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.РазгрузкаМест.Location = new System.Drawing.Point(3, 101);
            this.РазгрузкаМест.Name = "РазгрузкаМест";
            this.РазгрузкаМест.Size = new System.Drawing.Size(226, 21);
            this.РазгрузкаМест.TabIndex = 5;
            this.РазгрузкаМест.Text = "&7. Разгрузка мест";
            this.РазгрузкаМест.Click += new System.EventHandler(this.ПриНажатииНаКнопку);
            this.РазгрузкаМест.GotFocus += new System.EventHandler(this.ФокусированиеКнопки);
            this.РазгрузкаМест.LostFocus += new System.EventHandler(this.РасфокусированиеКнопки);
            // 
            // Подтоварка
            // 
            this.Подтоварка.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.Подтоварка.Location = new System.Drawing.Point(3, 77);
            this.Подтоварка.Name = "Подтоварка";
            this.Подтоварка.Size = new System.Drawing.Size(226, 21);
            this.Подтоварка.TabIndex = 4;
            this.Подтоварка.Text = "&6. Подтоварка";
            this.Подтоварка.Click += new System.EventHandler(this.ПриНажатииНаКнопку);
            this.Подтоварка.GotFocus += new System.EventHandler(this.ФокусированиеКнопки);
            this.Подтоварка.LostFocus += new System.EventHandler(this.РасфокусированиеКнопки);
            // 
            // Подбор
            // 
            this.Подбор.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.Подбор.Location = new System.Drawing.Point(3, 5);
            this.Подбор.Name = "Подбор";
            this.Подбор.Size = new System.Drawing.Size(226, 21);
            this.Подбор.TabIndex = 1;
            this.Подбор.Text = "&3. Подбор";
            this.Подбор.Click += new System.EventHandler(this.ПриНажатииНаКнопку);
            this.Подбор.GotFocus += new System.EventHandler(this.ФокусированиеКнопки);
            this.Подбор.LostFocus += new System.EventHandler(this.РасфокусированиеКнопки);
            // 
            // Панель_Информации
            // 
            this.Панель_Информации.BackColor = System.Drawing.SystemColors.Info;
            this.Панель_Информации.Controls.Add(this.РучнойКод);
            this.Панель_Информации.Controls.Add(this.СписокИнформации);
            this.Панель_Информации.Location = new System.Drawing.Point(4, 23);
            this.Панель_Информации.Name = "Панель_Информации";
            this.Панель_Информации.Size = new System.Drawing.Size(232, 224);
            this.Панель_Информации.Text = "2.Поиск>";
            // 
            // РучнойКод
            // 
            this.РучнойКод.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.РучнойКод.Location = new System.Drawing.Point(0, 0);
            this.РучнойКод.Name = "РучнойКод";
            this.РучнойКод.Size = new System.Drawing.Size(232, 19);
            this.РучнойКод.TabIndex = 20;
            this.РучнойКод.WordWrap = false;
            this.РучнойКод.KeyDown += new System.Windows.Forms.KeyEventHandler(this.РучнойКод_KeyDown);
            this.РучнойКод.LostFocus += new System.EventHandler(this.РучнойКод_LostFocus);
            // 
            // СписокИнформации
            // 
            this.СписокИнформации.AcceptsReturn = true;
            this.СписокИнформации.BackColor = System.Drawing.SystemColors.HighlightText;
            this.СписокИнформации.ForeColor = System.Drawing.SystemColors.InfoText;
            this.СписокИнформации.Location = new System.Drawing.Point(0, 20);
            this.СписокИнформации.Multiline = true;
            this.СписокИнформации.Name = "СписокИнформации";
            this.СписокИнформации.ReadOnly = true;
            this.СписокИнформации.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.СписокИнформации.Size = new System.Drawing.Size(232, 204);
            this.СписокИнформации.TabIndex = 0;
            this.СписокИнформации.Text = "Сканируйте ШК для получения информации";
            // 
            // ОбработкаМест
            // 
            this.ОбработкаМест.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.ОбработкаМест.Location = new System.Drawing.Point(3, 149);
            this.ОбработкаМест.Name = "ОбработкаМест";
            this.ОбработкаМест.Size = new System.Drawing.Size(226, 21);
            this.ОбработкаМест.TabIndex = 7;
            this.ОбработкаМест.Text = "&9. Обработка мест";
            this.ОбработкаМест.Click += new System.EventHandler(this.ПриНажатииНаКнопку);
            this.ОбработкаМест.GotFocus += new System.EventHandler(this.ФокусированиеКнопки);
            this.ОбработкаМест.LostFocus += new System.EventHandler(this.РасфокусированиеКнопки);
            // 
            // ОсновноеМеню
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.ControlBox = false;
            this.Controls.Add(this.Табулятор);
            this.Controls.Add(this.Пользователь);
            this.Name = "ОсновноеМеню";
            this.Text = "Основное меню";
            this.Load += new System.EventHandler(this.ОсновноеМеню_Load);
            this.Closed += new System.EventHandler(this.ОсновноеМеню_Closed);
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
        private System.Windows.Forms.Button Подтоварка;
        private System.Windows.Forms.TextBox РучнойКод;
        private System.Windows.Forms.Button РазгрузкаМест;
        private System.Windows.Forms.Button ПогрузкаМест;
        private System.Windows.Forms.Button ПодборЗК;
        private System.Windows.Forms.Button ОбработкаМест;
    }
}