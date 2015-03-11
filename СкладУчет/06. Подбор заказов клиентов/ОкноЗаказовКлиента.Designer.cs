namespace СкладскойУчет
{
    partial class ОкноЗаказовКлиента
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
            this.ДопИнфо = new System.Windows.Forms.Label();
            this.ТаблицаТоваров = new System.Windows.Forms.ListView();
            this.КолонкаТовар = new System.Windows.Forms.ColumnHeader();
            this.КолонкаКоличество = new System.Windows.Forms.ColumnHeader();
            this.КолонкаГуид = new System.Windows.Forms.ColumnHeader();
            this.НадписьРН = new System.Windows.Forms.Label();
            this.ТаблицаАдресов = new System.Windows.Forms.ListView();
            this.КолонкаАдрес = new System.Windows.Forms.ColumnHeader();
            this.КолонкаОстаток = new System.Windows.Forms.ColumnHeader();
            this.Назад = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ДопИнфо
            // 
            this.ДопИнфо.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.ДопИнфо.Location = new System.Drawing.Point(0, 133);
            this.ДопИнфо.Name = "ДопИнфо";
            this.ДопИнфо.Size = new System.Drawing.Size(240, 53);
            this.ДопИнфо.Text = "Дополнительная информация по товару";
            // 
            // ТаблицаТоваров
            // 
            this.ТаблицаТоваров.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            this.ТаблицаТоваров.Columns.Add(this.КолонкаТовар);
            this.ТаблицаТоваров.Columns.Add(this.КолонкаКоличество);
            this.ТаблицаТоваров.Columns.Add(this.КолонкаГуид);
            this.ТаблицаТоваров.FullRowSelect = true;
            this.ТаблицаТоваров.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.ТаблицаТоваров.Location = new System.Drawing.Point(-1, 19);
            this.ТаблицаТоваров.Name = "ТаблицаТоваров";
            this.ТаблицаТоваров.Size = new System.Drawing.Size(241, 111);
            this.ТаблицаТоваров.TabIndex = 4;
            this.ТаблицаТоваров.Tag = "Таблица";
            this.ТаблицаТоваров.View = System.Windows.Forms.View.Details;
            this.ТаблицаТоваров.SelectedIndexChanged += new System.EventHandler(this.СписокВыбора_SelectedIndexChanged);
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
            // НадписьРН
            // 
            this.НадписьРН.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.НадписьРН.Location = new System.Drawing.Point(65, 0);
            this.НадписьРН.Name = "НадписьРН";
            this.НадписьРН.Size = new System.Drawing.Size(113, 19);
            this.НадписьРН.Text = "РН: Аэ3-123456";
            this.НадписьРН.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ТаблицаАдресов
            // 
            this.ТаблицаАдресов.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            this.ТаблицаАдресов.Columns.Add(this.КолонкаАдрес);
            this.ТаблицаАдресов.Columns.Add(this.КолонкаОстаток);
            this.ТаблицаАдресов.FullRowSelect = true;
            this.ТаблицаАдресов.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.ТаблицаАдресов.Location = new System.Drawing.Point(-1, 188);
            this.ТаблицаАдресов.Name = "ТаблицаАдресов";
            this.ТаблицаАдресов.Size = new System.Drawing.Size(241, 107);
            this.ТаблицаАдресов.TabIndex = 21;
            this.ТаблицаАдресов.Tag = "Таблица";
            this.ТаблицаАдресов.View = System.Windows.Forms.View.Details;
            // 
            // КолонкаАдрес
            // 
            this.КолонкаАдрес.Text = "Адрес";
            this.КолонкаАдрес.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.КолонкаАдрес.Width = 140;
            // 
            // КолонкаОстаток
            // 
            this.КолонкаОстаток.Text = "Остаток";
            this.КолонкаОстаток.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.КолонкаОстаток.Width = 80;
            // 
            // Назад
            // 
            this.Назад.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.Назад.Location = new System.Drawing.Point(2, 298);
            this.Назад.Name = "Назад";
            this.Назад.Size = new System.Drawing.Size(100, 20);
            this.Назад.TabIndex = 22;
            this.Назад.Text = "Назад";
            // 
            // ОкноЗаказовКлиента
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(240, 320);
            this.ControlBox = false;
            this.Controls.Add(this.Назад);
            this.Controls.Add(this.ТаблицаАдресов);
            this.Controls.Add(this.НадписьРН);
            this.Controls.Add(this.ТаблицаТоваров);
            this.Controls.Add(this.ДопИнфо);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.Name = "ОкноЗаказовКлиента";
            this.Text = "Подбор товара";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.ОкноЗаказовКлиента_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ОкноЗаказовКлиента_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label ДопИнфо;
        public System.Windows.Forms.ListView ТаблицаТоваров;
        private System.Windows.Forms.ColumnHeader КолонкаТовар;
        private System.Windows.Forms.ColumnHeader КолонкаКоличество;
        private System.Windows.Forms.ColumnHeader КолонкаГуид;
        private System.Windows.Forms.Label НадписьРН;
        public System.Windows.Forms.ListView ТаблицаАдресов;
        private System.Windows.Forms.ColumnHeader КолонкаОстаток;
        private System.Windows.Forms.ColumnHeader КолонкаАдрес;
        private System.Windows.Forms.Button Назад;

    }
}