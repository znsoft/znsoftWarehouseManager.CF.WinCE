namespace СкладскойУчет
{
    partial class ВыборТовараИзМножества
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
            this.СписокВыбора = new System.Windows.Forms.ListView();
            this.Назад = new System.Windows.Forms.Button();
            this.Далее = new System.Windows.Forms.Button();
            this.Инструкция = new System.Windows.Forms.Label();
            this.ДопИнфо = new System.Windows.Forms.Label();
            this.Код = new System.Windows.Forms.ColumnHeader();
            this.Товар = new System.Windows.Forms.ColumnHeader();
            this.КолонкаГуид = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // СписокВыбора
            // 
            this.СписокВыбора.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            this.СписокВыбора.Columns.Add(this.Код);
            this.СписокВыбора.Columns.Add(this.Товар);
            this.СписокВыбора.Columns.Add(this.КолонкаГуид);
            this.СписокВыбора.FullRowSelect = true;
            this.СписокВыбора.Location = new System.Drawing.Point(5, 30);
            this.СписокВыбора.Name = "СписокВыбора";
            this.СписокВыбора.Size = new System.Drawing.Size(230, 116);
            this.СписокВыбора.TabIndex = 0;
            this.СписокВыбора.Tag = "Таблица";
            this.СписокВыбора.View = System.Windows.Forms.View.Details;
            this.СписокВыбора.ItemActivate += new System.EventHandler(this.СписокВыбора_ItemActivate);
            this.СписокВыбора.SelectedIndexChanged += new System.EventHandler(this.СписокВыбора_SelectedIndexChanged);
            // 
            // Назад
            // 
            this.Назад.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.Назад.Location = new System.Drawing.Point(5, 283);
            this.Назад.Name = "Назад";
            this.Назад.Size = new System.Drawing.Size(100, 25);
            this.Назад.TabIndex = 1;
            this.Назад.Text = "&0. Назад";
            this.Назад.Click += new System.EventHandler(this.Назад_Click);
            // 
            // Далее
            // 
            this.Далее.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.Далее.Location = new System.Drawing.Point(135, 283);
            this.Далее.Name = "Далее";
            this.Далее.Size = new System.Drawing.Size(100, 25);
            this.Далее.TabIndex = 2;
            this.Далее.Text = "&1. Далее";
            this.Далее.Click += new System.EventHandler(this.Далее_Click);
            // 
            // Инструкция
            // 
            this.Инструкция.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.Инструкция.Location = new System.Drawing.Point(6, 7);
            this.Инструкция.Name = "Инструкция";
            this.Инструкция.Size = new System.Drawing.Size(228, 19);
            this.Инструкция.Tag = "Инструкция";
            this.Инструкция.Text = "Выберите товар";
            // 
            // ДопИнфо
            // 
            this.ДопИнфо.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular);
            this.ДопИнфо.Location = new System.Drawing.Point(5, 149);
            this.ДопИнфо.Name = "ДопИнфо";
            this.ДопИнфо.Size = new System.Drawing.Size(230, 128);
            this.ДопИнфо.Text = "Дополнительная информация по товару";
            // 
            // Код
            // 
            this.Код.Text = "Код";
            this.Код.Width = 60;
            // 
            // Товар
            // 
            this.Товар.Text = "Товар";
            this.Товар.Width = 167;
            // 
            // КолонкаГуид
            // 
            this.КолонкаГуид.Text = "Гуид";
            this.КолонкаГуид.Width = 0;
            // 
            // ВыборТовараИзМножества
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(240, 320);
            this.ControlBox = false;
            this.Controls.Add(this.ДопИнфо);
            this.Controls.Add(this.Инструкция);
            this.Controls.Add(this.Далее);
            this.Controls.Add(this.Назад);
            this.Controls.Add(this.СписокВыбора);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.Name = "ВыборТовараИзМножества";
            this.Text = "Выбор";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.ВыборТовараИзМножества_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ВыборТовараИзМножества_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ListView СписокВыбора;
        private System.Windows.Forms.Button Назад;
        private System.Windows.Forms.Button Далее;
        public System.Windows.Forms.Label Инструкция;
        private System.Windows.Forms.Label ДопИнфо;
        private System.Windows.Forms.ColumnHeader Код;
        private System.Windows.Forms.ColumnHeader Товар;
        private System.Windows.Forms.ColumnHeader КолонкаГуид;
    }
}