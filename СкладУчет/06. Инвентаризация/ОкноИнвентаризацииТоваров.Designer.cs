namespace СкладскойУчет
{
    partial class ОкноИнвентаризацииТоваров
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
            this.НадписьАдрес = new System.Windows.Forms.Label();
            this.СписокИнвентаризации = new System.Windows.Forms.ListView();
            this.КолонкаТовар = new System.Windows.Forms.ColumnHeader();
            this.КолонкаКод = new System.Windows.Forms.ColumnHeader();
            this.КолонкаГуид = new System.Windows.Forms.ColumnHeader();
            this.КолонкаКоличество = new System.Windows.Forms.ColumnHeader();
            this.ДопИнфо = new System.Windows.Forms.Label();
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
            this.Далее.Text = "Завершить";
            this.Далее.Click += new System.EventHandler(this.Далее_Click);
            // 
            // НадписьАдрес
            // 
            this.НадписьАдрес.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.НадписьАдрес.Location = new System.Drawing.Point(0, 0);
            this.НадписьАдрес.Name = "НадписьАдрес";
            this.НадписьАдрес.Size = new System.Drawing.Size(240, 15);
            this.НадписьАдрес.Tag = "Инструкция";
            this.НадписьАдрес.Text = "Инвентаризация А66-66-6";
            this.НадписьАдрес.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // СписокИнвентаризации
            // 
            this.СписокИнвентаризации.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            this.СписокИнвентаризации.Columns.Add(this.КолонкаТовар);
            this.СписокИнвентаризации.Columns.Add(this.КолонкаКод);
            this.СписокИнвентаризации.Columns.Add(this.КолонкаГуид);
            this.СписокИнвентаризации.Columns.Add(this.КолонкаКоличество);
            this.СписокИнвентаризации.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.СписокИнвентаризации.FullRowSelect = true;
            this.СписокИнвентаризации.Location = new System.Drawing.Point(3, 18);
            this.СписокИнвентаризации.Name = "СписокИнвентаризации";
            this.СписокИнвентаризации.Size = new System.Drawing.Size(234, 216);
            this.СписокИнвентаризации.TabIndex = 1;
            this.СписокИнвентаризации.Tag = "Таблица";
            this.СписокИнвентаризации.View = System.Windows.Forms.View.Details;
            this.СписокИнвентаризации.SelectedIndexChanged += new System.EventHandler(this.СписокИнвентаризации_SelectedIndexChanged);
            // 
            // КолонкаТовар
            // 
            this.КолонкаТовар.Text = "Товар";
            this.КолонкаТовар.Width = 162;
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
            this.КолонкаКоличество.Text = "Кол.";
            this.КолонкаКоличество.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.КолонкаКоличество.Width = 50;
            // 
            // ДопИнфо
            // 
            this.ДопИнфо.BackColor = System.Drawing.SystemColors.Info;
            this.ДопИнфо.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.ДопИнфо.Location = new System.Drawing.Point(3, 237);
            this.ДопИнфо.Name = "ДопИнфо";
            this.ДопИнфо.Size = new System.Drawing.Size(234, 53);
            this.ДопИнфо.Text = "Смартфон Samsung SM-C1150 Galaxy K Zoom 4.8\" 8Gb Black 4x1.3+2x1.7Ghz/2048Mb/1280" +
                "x720/sAmoled/3G/LTE/GPS/Cam20.7/And 4.4";
            // 
            // ОкноИнвентаризацииТоваров
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(240, 320);
            this.ControlBox = false;
            this.Controls.Add(this.ДопИнфо);
            this.Controls.Add(this.СписокИнвентаризации);
            this.Controls.Add(this.НадписьАдрес);
            this.Controls.Add(this.Далее);
            this.Controls.Add(this.Назад);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.Name = "ОкноИнвентаризацииТоваров";
            this.Text = "Выбор";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.ОкноИнвентаризацииТоваров_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ОкноИнвентаризацииТоваров_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button Назад;
        public System.Windows.Forms.Button Далее;
        public System.Windows.Forms.Label НадписьАдрес;
        public System.Windows.Forms.ListView СписокИнвентаризации;
        private System.Windows.Forms.ColumnHeader КолонкаТовар;
        private System.Windows.Forms.ColumnHeader КолонкаКоличество;
        public System.Windows.Forms.Label ДопИнфо;
        private System.Windows.Forms.ColumnHeader КолонкаКод;
        private System.Windows.Forms.ColumnHeader КолонкаГуид;
    }
}