namespace СкладскойУчет
{
    partial class ОкноПодбораТоваров
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
            this.НадписьАдрес = new System.Windows.Forms.Label();
            this.НадписьДинамическаяЯчейка = new System.Windows.Forms.Label();
            this.ДопИнфо = new System.Windows.Forms.Label();
            this.КнопкаПовторитьЗавершение = new System.Windows.Forms.Button();
            this.СписокВыбора = new System.Windows.Forms.ListView();
            this.КолонкаТовар = new System.Windows.Forms.ColumnHeader();
            this.КолонкаКоличество = new System.Windows.Forms.ColumnHeader();
            this.КолонкаГуид = new System.Windows.Forms.ColumnHeader();
            this.МенюПодбора = new System.Windows.Forms.ContextMenu();
            this.Вычерк = new System.Windows.Forms.MenuItem();
            this.Завершить = new System.Windows.Forms.MenuItem();
            this.Меню = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // НадписьАдрес
            // 
            this.НадписьАдрес.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.НадписьАдрес.Location = new System.Drawing.Point(69, 1);
            this.НадписьАдрес.Name = "НадписьАдрес";
            this.НадписьАдрес.Size = new System.Drawing.Size(168, 19);
            this.НадписьАдрес.Text = "Адрес: А01-01-1";
            // 
            // НадписьДинамическаяЯчейка
            // 
            this.НадписьДинамическаяЯчейка.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.НадписьДинамическаяЯчейка.Location = new System.Drawing.Point(0, 300);
            this.НадписьДинамическаяЯчейка.Name = "НадписьДинамическаяЯчейка";
            this.НадписьДинамическаяЯчейка.Size = new System.Drawing.Size(240, 19);
            this.НадписьДинамическаяЯчейка.Text = "Сосканируйте ДЯ";
            this.НадписьДинамическаяЯчейка.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ДопИнфо
            // 
            this.ДопИнфо.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.ДопИнфо.Location = new System.Drawing.Point(0, 244);
            this.ДопИнфо.Name = "ДопИнфо";
            this.ДопИнфо.Size = new System.Drawing.Size(240, 53);
            this.ДопИнфо.Text = "Дополнительная информация по товару";
            // 
            // КнопкаПовторитьЗавершение
            // 
            this.КнопкаПовторитьЗавершение.BackColor = System.Drawing.Color.LightSalmon;
            this.КнопкаПовторитьЗавершение.Location = new System.Drawing.Point(0, 244);
            this.КнопкаПовторитьЗавершение.Name = "КнопкаПовторитьЗавершение";
            this.КнопкаПовторитьЗавершение.Size = new System.Drawing.Size(240, 53);
            this.КнопкаПовторитьЗавершение.TabIndex = 5;
            this.КнопкаПовторитьЗавершение.Text = "Повторить завершение задания";
            this.КнопкаПовторитьЗавершение.Visible = false;
            this.КнопкаПовторитьЗавершение.Click += new System.EventHandler(this.КнопкаПовторитьЗавершение_Click);
            // 
            // СписокВыбора
            // 
            this.СписокВыбора.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            this.СписокВыбора.Columns.Add(this.КолонкаТовар);
            this.СписокВыбора.Columns.Add(this.КолонкаКоличество);
            this.СписокВыбора.Columns.Add(this.КолонкаГуид);
            this.СписокВыбора.ContextMenu = this.МенюПодбора;
            this.СписокВыбора.FullRowSelect = true;
            this.СписокВыбора.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.СписокВыбора.Location = new System.Drawing.Point(-1, 18);
            this.СписокВыбора.Name = "СписокВыбора";
            this.СписокВыбора.Size = new System.Drawing.Size(241, 226);
            this.СписокВыбора.TabIndex = 4;
            this.СписокВыбора.Tag = "Таблица";
            this.СписокВыбора.View = System.Windows.Forms.View.Details;
            this.СписокВыбора.SelectedIndexChanged += new System.EventHandler(this.СписокВыбора_SelectedIndexChanged);
            // 
            // КолонкаТовар
            // 
            this.КолонкаТовар.Text = " Товар";
            this.КолонкаТовар.Width = 140;
            // 
            // КолонкаКоличество
            // 
            this.КолонкаКоличество.Text = "Кол-во";
            this.КолонкаКоличество.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.КолонкаКоличество.Width = 80;
            // 
            // КолонкаГуид
            // 
            this.КолонкаГуид.Text = "ColumnHeader";
            this.КолонкаГуид.Width = 0;
            // 
            // МенюПодбора
            // 
            this.МенюПодбора.MenuItems.Add(this.Вычерк);
            this.МенюПодбора.MenuItems.Add(this.Завершить);
            // 
            // Вычерк
            // 
            this.Вычерк.Text = "Вычерк";
            this.Вычерк.Click += new System.EventHandler(this.Вычерк_Click);
            // 
            // Завершить
            // 
            this.Завершить.Text = "Завершить подбор";
            this.Завершить.Click += new System.EventHandler(this.Завершить_Click);
            // 
            // Меню
            // 
            this.Меню.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Меню.BackColor = System.Drawing.SystemColors.Menu;
            this.Меню.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.Меню.Location = new System.Drawing.Point(0, -1);
            this.Меню.Name = "Меню";
            this.Меню.Size = new System.Drawing.Size(61, 21);
            this.Меню.TabIndex = 11;
            this.Меню.Text = "&0.меню";
            this.Меню.Click += new System.EventHandler(this.Меню_Click);
            // 
            // ОкноПодбораТоваров
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(240, 320);
            this.ControlBox = false;
            this.Controls.Add(this.СписокВыбора);
            this.Controls.Add(this.Меню);
            this.Controls.Add(this.НадписьДинамическаяЯчейка);
            this.Controls.Add(this.НадписьАдрес);
            this.Controls.Add(this.КнопкаПовторитьЗавершение);
            this.Controls.Add(this.ДопИнфо);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.Name = "ОкноПодбораТоваров";
            this.Text = "Подбор товара";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.ОкноПодбораЗаданий_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ОкноПодбораЗаданий_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label НадписьАдрес;
        private System.Windows.Forms.Label НадписьДинамическаяЯчейка;
        private System.Windows.Forms.Label ДопИнфо;
        private System.Windows.Forms.Button КнопкаПовторитьЗавершение;
        public System.Windows.Forms.ListView СписокВыбора;
        private System.Windows.Forms.ColumnHeader КолонкаТовар;
        private System.Windows.Forms.ColumnHeader КолонкаКоличество;
        private System.Windows.Forms.Button Меню;
        private System.Windows.Forms.ContextMenu МенюПодбора;
        private System.Windows.Forms.MenuItem Вычерк;
        private System.Windows.Forms.MenuItem Завершить;
        private System.Windows.Forms.ColumnHeader КолонкаГуид;

    }
}