namespace СкладскойУчет
{
    partial class ОкноВыбораЗаказовКлиента
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
            this.ТаблицаДокументов = new System.Windows.Forms.ListView();
            this.КолонкаДокумент = new System.Windows.Forms.ColumnHeader();
            this.КолонкаКоличество = new System.Windows.Forms.ColumnHeader();
            this.КолонкаГуид = new System.Windows.Forms.ColumnHeader();
            this.Инструкция = new System.Windows.Forms.Label();
            this.Назад = new System.Windows.Forms.Button();
            this.Далее = new System.Windows.Forms.Button();
            this.КолонкаОбъем = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // ТаблицаДокументов
            // 
            this.ТаблицаДокументов.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            this.ТаблицаДокументов.Columns.Add(this.КолонкаДокумент);
            this.ТаблицаДокументов.Columns.Add(this.КолонкаКоличество);
            this.ТаблицаДокументов.Columns.Add(this.КолонкаОбъем);
            this.ТаблицаДокументов.Columns.Add(this.КолонкаГуид);
            this.ТаблицаДокументов.FullRowSelect = true;
            this.ТаблицаДокументов.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.ТаблицаДокументов.Location = new System.Drawing.Point(-1, 19);
            this.ТаблицаДокументов.Name = "ТаблицаДокументов";
            this.ТаблицаДокументов.Size = new System.Drawing.Size(241, 273);
            this.ТаблицаДокументов.TabIndex = 4;
            this.ТаблицаДокументов.Tag = "Таблица";
            this.ТаблицаДокументов.View = System.Windows.Forms.View.Details;
            // 
            // КолонкаДокумент
            // 
            this.КолонкаДокумент.Text = "Документ";
            this.КолонкаДокумент.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.КолонкаДокумент.Width = 100;
            // 
            // КолонкаКоличество
            // 
            this.КолонкаКоличество.Text = "Кол-во";
            this.КолонкаКоличество.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.КолонкаКоличество.Width = 60;
            // 
            // КолонкаГуид
            // 
            this.КолонкаГуид.Text = "ColumnHeader";
            this.КолонкаГуид.Width = 0;
            // 
            // Инструкция
            // 
            this.Инструкция.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.Инструкция.Location = new System.Drawing.Point(0, 0);
            this.Инструкция.Name = "Инструкция";
            this.Инструкция.Size = new System.Drawing.Size(240, 19);
            this.Инструкция.Text = "Выберите расходную накладную";
            this.Инструкция.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Назад
            // 
            this.Назад.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.Назад.Location = new System.Drawing.Point(2, 298);
            this.Назад.Name = "Назад";
            this.Назад.Size = new System.Drawing.Size(100, 20);
            this.Назад.TabIndex = 22;
            this.Назад.Text = "Назад";
            this.Назад.Click += new System.EventHandler(this.Назад_Click);
            // 
            // Далее
            // 
            this.Далее.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.Далее.Location = new System.Drawing.Point(138, 298);
            this.Далее.Name = "Далее";
            this.Далее.Size = new System.Drawing.Size(100, 20);
            this.Далее.TabIndex = 25;
            this.Далее.Text = "Далее";
            this.Далее.Click += new System.EventHandler(this.Далее_Click);
            // 
            // КолонкаОбъем
            // 
            this.КолонкаОбъем.Text = "Объем";
            this.КолонкаОбъем.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.КолонкаОбъем.Width = 60;
            // 
            // ОкноВыбораЗаказовКлиента
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(240, 320);
            this.ControlBox = false;
            this.Controls.Add(this.Далее);
            this.Controls.Add(this.Назад);
            this.Controls.Add(this.Инструкция);
            this.Controls.Add(this.ТаблицаДокументов);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.Name = "ОкноВыбораЗаказовКлиента";
            this.Text = "Подбор товара";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.ОкноВыбораЗаказовКлиента_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ОкноВыбораЗаказовКлиента_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ListView ТаблицаДокументов;
        private System.Windows.Forms.ColumnHeader КолонкаКоличество;
        private System.Windows.Forms.ColumnHeader КолонкаГуид;
        private System.Windows.Forms.Label Инструкция;
        private System.Windows.Forms.Button Назад;
        private System.Windows.Forms.Button Далее;
        private System.Windows.Forms.ColumnHeader КолонкаДокумент;
        private System.Windows.Forms.ColumnHeader КолонкаОбъем;

    }
}