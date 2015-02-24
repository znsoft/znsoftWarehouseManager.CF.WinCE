namespace СкладскойУчет
{
    partial class ОкноПеремещенияТоваров
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
            this.Назад = new System.Windows.Forms.Button();
            this.Далее = new System.Windows.Forms.Button();
            this.НадписьАдресОтправитель = new System.Windows.Forms.Label();
            this.НадписьАдресПолучатель = new System.Windows.Forms.Label();
            this.СписокПеремещения = new System.Windows.Forms.ListView();
            this.КолонкаТовар = new System.Windows.Forms.ColumnHeader();
            this.КолонкаКод = new System.Windows.Forms.ColumnHeader();
            this.КолонкаГуид = new System.Windows.Forms.ColumnHeader();
            this.КолонкаКоличество = new System.Windows.Forms.ColumnHeader();
            this.КолонкаАдрес = new System.Windows.Forms.ColumnHeader();
            this.ДопИнфо = new System.Windows.Forms.Label();
            this.Таб = new System.Windows.Forms.TabControl();
            this.Панель_ОсновногоМеню = new System.Windows.Forms.TabPage();
            this.Панель_Информации = new System.Windows.Forms.TabPage();
            this.РучнойКод = new System.Windows.Forms.TextBox();
            this.СписокИнформации = new System.Windows.Forms.TextBox();
            this.Таб.SuspendLayout();
            this.Панель_ОсновногоМеню.SuspendLayout();
            this.Панель_Информации.SuspendLayout();
            this.SuspendLayout();
            // 
            // Назад
            // 
            this.Назад.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.Назад.Location = new System.Drawing.Point(2, 294);
            this.Назад.Name = "Назад";
            this.Назад.Size = new System.Drawing.Size(105, 22);
            this.Назад.TabIndex = 2;
            this.Назад.Text = "Назад";
            this.Назад.Click += new System.EventHandler(this.Назад_Click);
            // 
            // Далее
            // 
            this.Далее.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.Далее.Location = new System.Drawing.Point(133, 294);
            this.Далее.Name = "Далее";
            this.Далее.Size = new System.Drawing.Size(105, 22);
            this.Далее.TabIndex = 3;
            this.Далее.Text = "Переместить";
            this.Далее.Click += new System.EventHandler(this.Далее_Click);
            // 
            // НадписьАдресОтправитель
            // 
            this.НадписьАдресОтправитель.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.НадписьАдресОтправитель.Location = new System.Drawing.Point(0, 0);
            this.НадписьАдресОтправитель.Name = "НадписьАдресОтправитель";
            this.НадписьАдресОтправитель.Size = new System.Drawing.Size(240, 15);
            this.НадписьАдресОтправитель.Tag = "Инструкция";
            this.НадписьАдресОтправитель.Text = "Перемещение с А66-66-6";
            this.НадписьАдресОтправитель.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // НадписьАдресПолучатель
            // 
            this.НадписьАдресПолучатель.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(225)))));
            this.НадписьАдресПолучатель.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.НадписьАдресПолучатель.Location = new System.Drawing.Point(0, 274);
            this.НадписьАдресПолучатель.Name = "НадписьАдресПолучатель";
            this.НадписьАдресПолучатель.Size = new System.Drawing.Size(240, 46);
            this.НадписьАдресПолучатель.Text = "Сосканируйте адрес получатель";
            this.НадписьАдресПолучатель.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // СписокПеремещения
            // 
            this.СписокПеремещения.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            this.СписокПеремещения.Columns.Add(this.КолонкаТовар);
            this.СписокПеремещения.Columns.Add(this.КолонкаКод);
            this.СписокПеремещения.Columns.Add(this.КолонкаГуид);
            this.СписокПеремещения.Columns.Add(this.КолонкаКоличество);
            this.СписокПеремещения.Columns.Add(this.КолонкаАдрес);
            this.СписокПеремещения.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.СписокПеремещения.FullRowSelect = true;
            this.СписокПеремещения.Location = new System.Drawing.Point(-1, 0);
            this.СписокПеремещения.Name = "СписокПеремещения";
            this.СписокПеремещения.Size = new System.Drawing.Size(234, 180);
            this.СписокПеремещения.TabIndex = 1;
            this.СписокПеремещения.Tag = "Таблица";
            this.СписокПеремещения.View = System.Windows.Forms.View.Details;
            this.СписокПеремещения.SelectedIndexChanged += new System.EventHandler(this.СписокПеремещения_SelectedIndexChanged);
            // 
            // КолонкаТовар
            // 
            this.КолонкаТовар.Text = "Товар";
            this.КолонкаТовар.Width = 80;
            // 
            // КолонкаКод
            // 
            this.КолонкаКод.Text = "Код";
            this.КолонкаКод.Width = 0;
            // 
            // КолонкаГуид
            // 
            this.КолонкаГуид.Text = "Гуид";
            this.КолонкаГуид.Width = 0;
            // 
            // КолонкаКоличество
            // 
            this.КолонкаКоличество.Text = "Кол / Ост";
            this.КолонкаКоличество.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.КолонкаКоличество.Width = 67;
            // 
            // КолонкаАдрес
            // 
            this.КолонкаАдрес.Text = "Адрес";
            this.КолонкаАдрес.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.КолонкаАдрес.Width = 65;
            // 
            // ДопИнфо
            // 
            this.ДопИнфо.BackColor = System.Drawing.SystemColors.Info;
            this.ДопИнфо.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.ДопИнфо.Location = new System.Drawing.Point(-1, 181);
            this.ДопИнфо.Name = "ДопИнфо";
            this.ДопИнфо.Size = new System.Drawing.Size(234, 51);
            this.ДопИнфо.Text = "Смартфон Samsung SM-C1150 Galaxy K Zoom 4.8\" 8Gb Black 4x1.3+2x1.7Ghz/2048Mb/1280" +
                "x720/sAmoled/3G/LTE/GPS/Cam20.7/And 4.4";
            // 
            // Таб
            // 
            this.Таб.Controls.Add(this.Панель_ОсновногоМеню);
            this.Таб.Controls.Add(this.Панель_Информации);
            this.Таб.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular);
            this.Таб.Location = new System.Drawing.Point(0, 16);
            this.Таб.Name = "Таб";
            this.Таб.SelectedIndex = 0;
            this.Таб.Size = new System.Drawing.Size(240, 258);
            this.Таб.TabIndex = 4;
            // 
            // Панель_ОсновногоМеню
            // 
            this.Панель_ОсновногоМеню.BackColor = System.Drawing.SystemColors.Info;
            this.Панель_ОсновногоМеню.Controls.Add(this.СписокПеремещения);
            this.Панель_ОсновногоМеню.Controls.Add(this.ДопИнфо);
            this.Панель_ОсновногоМеню.Location = new System.Drawing.Point(4, 23);
            this.Панель_ОсновногоМеню.Name = "Панель_ОсновногоМеню";
            this.Панель_ОсновногоМеню.Size = new System.Drawing.Size(232, 231);
            this.Панель_ОсновногоМеню.Text = "Таблица товаров";
            // 
            // Панель_Информации
            // 
            this.Панель_Информации.BackColor = System.Drawing.SystemColors.Info;
            this.Панель_Информации.Controls.Add(this.РучнойКод);
            this.Панель_Информации.Controls.Add(this.СписокИнформации);
            this.Панель_Информации.Location = new System.Drawing.Point(4, 23);
            this.Панель_Информации.Name = "Панель_Информации";
            this.Панель_Информации.Size = new System.Drawing.Size(232, 231);
            this.Панель_Информации.Text = "Поиск";
            // 
            // РучнойКод
            // 
            this.РучнойКод.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.РучнойКод.Location = new System.Drawing.Point(0, 0);
            this.РучнойКод.Name = "РучнойКод";
            this.РучнойКод.Size = new System.Drawing.Size(232, 19);
            this.РучнойКод.TabIndex = 20;
            this.РучнойКод.WordWrap = false;
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
            this.СписокИнформации.Size = new System.Drawing.Size(232, 213);
            this.СписокИнформации.TabIndex = 0;
            this.СписокИнформации.Text = "Сканируйте ШК для получения информации";
            // 
            // ОкноПеремещенияТоваров
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(240, 320);
            this.ControlBox = false;
            this.Controls.Add(this.Таб);
            this.Controls.Add(this.НадписьАдресОтправитель);
            this.Controls.Add(this.Далее);
            this.Controls.Add(this.Назад);
            this.Controls.Add(this.НадписьАдресПолучатель);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.Name = "ОкноПеремещенияТоваров";
            this.Text = "Выбор";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.ОкноПеремещенияТоваров_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ОкноПеремещенияТоваров_KeyDown);
            this.Таб.ResumeLayout(false);
            this.Панель_ОсновногоМеню.ResumeLayout(false);
            this.Панель_Информации.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button Назад;
        public System.Windows.Forms.Button Далее;
        public System.Windows.Forms.Label НадписьАдресОтправитель;
        private System.Windows.Forms.Label НадписьАдресПолучатель;
        public System.Windows.Forms.ListView СписокПеремещения;
        private System.Windows.Forms.ColumnHeader КолонкаТовар;
        private System.Windows.Forms.ColumnHeader КолонкаКоличество;
        private System.Windows.Forms.ColumnHeader КолонкаАдрес;
        public System.Windows.Forms.Label ДопИнфо;
        private System.Windows.Forms.TabControl Таб;
        private System.Windows.Forms.TabPage Панель_ОсновногоМеню;
        private System.Windows.Forms.TabPage Панель_Информации;
        private System.Windows.Forms.TextBox РучнойКод;
        private System.Windows.Forms.TextBox СписокИнформации;
        private System.Windows.Forms.ColumnHeader КолонкаКод;
        private System.Windows.Forms.ColumnHeader КолонкаГуид;
    }
}