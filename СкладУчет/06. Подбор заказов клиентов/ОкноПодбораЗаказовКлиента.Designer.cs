namespace СкладскойУчет
{
    partial class ОкноПодбораЗаказовКлиента
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
            this.ДопИнфо = new System.Windows.Forms.Label();
            this.СписокВыбора = new System.Windows.Forms.ListView();
            this.Товар = new System.Windows.Forms.ColumnHeader();
            this.Количество = new System.Windows.Forms.ColumnHeader();
            this.Гуид = new System.Windows.Forms.ColumnHeader();
            this.НадписьРН = new System.Windows.Forms.Label();
            this.Далее = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // НадписьАдрес
            // 
            this.НадписьАдрес.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.НадписьАдрес.Location = new System.Drawing.Point(64, 0);
            this.НадписьАдрес.Name = "НадписьАдрес";
            this.НадписьАдрес.Size = new System.Drawing.Size(113, 19);
            this.НадписьАдрес.Text = "Адрес: А01-01-1";
            this.НадписьАдрес.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ДопИнфо
            // 
            this.ДопИнфо.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.ДопИнфо.Location = new System.Drawing.Point(0, 244);
            this.ДопИнфо.Name = "ДопИнфо";
            this.ДопИнфо.Size = new System.Drawing.Size(240, 53);
            this.ДопИнфо.Text = "Дополнительная информация по товару";
            // 
            // СписокВыбора
            // 
            this.СписокВыбора.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            this.СписокВыбора.Columns.Add(this.Товар);
            this.СписокВыбора.Columns.Add(this.Количество);
            this.СписокВыбора.Columns.Add(this.Гуид);
            this.СписокВыбора.FullRowSelect = true;
            this.СписокВыбора.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.СписокВыбора.Location = new System.Drawing.Point(-1, 19);
            this.СписокВыбора.Name = "СписокВыбора";
            this.СписокВыбора.Size = new System.Drawing.Size(241, 225);
            this.СписокВыбора.TabIndex = 4;
            this.СписокВыбора.Tag = "Таблица";
            this.СписокВыбора.View = System.Windows.Forms.View.Details;
            this.СписокВыбора.SelectedIndexChanged += new System.EventHandler(this.СписокВыбора_SelectedIndexChanged);
            // 
            // Товар
            // 
            this.Товар.Text = " Товар";
            this.Товар.Width = 140;
            // 
            // Количество
            // 
            this.Количество.Text = "Кол-во";
            this.Количество.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Количество.Width = 80;
            // 
            // Гуид
            // 
            this.Гуид.Text = "ColumnHeader";
            this.Гуид.Width = 0;
            // 
            // НадписьРН
            // 
            this.НадписьРН.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.НадписьРН.Location = new System.Drawing.Point(0, 299);
            this.НадписьРН.Name = "НадписьРН";
            this.НадписьРН.Size = new System.Drawing.Size(113, 19);
            this.НадписьРН.Text = "РН: Аэ3-123456";
            this.НадписьРН.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Далее
            // 
            this.Далее.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.Далее.Location = new System.Drawing.Point(138, 298);
            this.Далее.Name = "Далее";
            this.Далее.Size = new System.Drawing.Size(100, 20);
            this.Далее.TabIndex = 17;
            this.Далее.Text = "Завершить";
            this.Далее.Click += new System.EventHandler(this.Далее_Click);
            // 
            // ОкноПодбораЗаказовКлиента
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(240, 320);
            this.ControlBox = false;
            this.Controls.Add(this.Далее);
            this.Controls.Add(this.НадписьРН);
            this.Controls.Add(this.СписокВыбора);
            this.Controls.Add(this.НадписьАдрес);
            this.Controls.Add(this.ДопИнфо);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.Name = "ОкноПодбораЗаказовКлиента";
            this.Text = "Подбор товара";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.ОкноПодбораЗаданий_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ОкноПодбораЗаданий_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label НадписьАдрес;
        private System.Windows.Forms.Label ДопИнфо;
        public System.Windows.Forms.ListView СписокВыбора;
        private System.Windows.Forms.ColumnHeader Товар;
        private System.Windows.Forms.ColumnHeader Количество;
        private System.Windows.Forms.ColumnHeader Гуид;
        private System.Windows.Forms.Label НадписьРН;
        private System.Windows.Forms.Button Далее;

    }
}