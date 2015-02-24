namespace СкладскойУчет
{
    partial class ПогрузкаМест
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
            this.Таблица = new System.Windows.Forms.ListView();
            this.КолонкаФилиал = new System.Windows.Forms.ColumnHeader();
            this.КолонкаФилиалГуид = new System.Windows.Forms.ColumnHeader();
            this.КолонкаМеста = new System.Windows.Forms.ColumnHeader();
            this.Назад = new System.Windows.Forms.Button();
            this.Далее = new System.Windows.Forms.Button();
            this.НадписьТТН = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Таблица
            // 
            this.Таблица.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            this.Таблица.Columns.Add(this.КолонкаФилиал);
            this.Таблица.Columns.Add(this.КолонкаФилиалГуид);
            this.Таблица.Columns.Add(this.КолонкаМеста);
            this.Таблица.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.Таблица.FullRowSelect = true;
            this.Таблица.Location = new System.Drawing.Point(3, 39);
            this.Таблица.Name = "Таблица";
            this.Таблица.Size = new System.Drawing.Size(234, 249);
            this.Таблица.TabIndex = 0;
            this.Таблица.Tag = "";
            this.Таблица.View = System.Windows.Forms.View.Details;
            // 
            // КолонкаФилиал
            // 
            this.КолонкаФилиал.Text = "Филиал";
            this.КолонкаФилиал.Width = 177;
            // 
            // КолонкаФилиалГуид
            // 
            this.КолонкаФилиалГуид.Text = "ФилиалГуид";
            this.КолонкаФилиалГуид.Width = 0;
            // 
            // КолонкаМеста
            // 
            this.КолонкаМеста.Text = "Мест";
            this.КолонкаМеста.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.КолонкаМеста.Width = 54;
            // 
            // Назад
            // 
            this.Назад.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.Назад.Location = new System.Drawing.Point(2, 294);
            this.Назад.Name = "Назад";
            this.Назад.Size = new System.Drawing.Size(105, 22);
            this.Назад.TabIndex = 1;
            this.Назад.Text = "Назад";
            this.Назад.Click += new System.EventHandler(this.Назад_Click);
            // 
            // Далее
            // 
            this.Далее.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.Далее.Location = new System.Drawing.Point(133, 294);
            this.Далее.Name = "Далее";
            this.Далее.Size = new System.Drawing.Size(105, 22);
            this.Далее.TabIndex = 2;
            this.Далее.Text = "Завершить";
            this.Далее.Click += new System.EventHandler(this.Далее_Click);
            // 
            // НадписьТТН
            // 
            this.НадписьТТН.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(225)))));
            this.НадписьТТН.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold);
            this.НадписьТТН.Location = new System.Drawing.Point(3, 3);
            this.НадписьТТН.Name = "НадписьТТН";
            this.НадписьТТН.Size = new System.Drawing.Size(234, 35);
            this.НадписьТТН.Tag = "";
            this.НадписьТТН.Text = "Сканируйте ТТН";
            this.НадписьТТН.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ПогрузкаМест
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(240, 320);
            this.ControlBox = false;
            this.Controls.Add(this.НадписьТТН);
            this.Controls.Add(this.Далее);
            this.Controls.Add(this.Назад);
            this.Controls.Add(this.Таблица);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.Name = "ПогрузкаМест";
            this.Text = "Выбор";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.ПогрузкаМест_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ПогрузкаМест_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ListView Таблица;
        private System.Windows.Forms.Button Назад;
        private System.Windows.Forms.Button Далее;
        public System.Windows.Forms.Label НадписьТТН;
        private System.Windows.Forms.ColumnHeader КолонкаФилиал;
        private System.Windows.Forms.ColumnHeader КолонкаМеста;
        private System.Windows.Forms.ColumnHeader КолонкаФилиалГуид;
    }
}