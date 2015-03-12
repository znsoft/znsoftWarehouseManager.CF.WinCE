namespace СкладскойУчет
{
    partial class ФормаВыборТТН
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
            this.СписокТТН = new System.Windows.Forms.ListView();
            this.КолонкаНомер = new System.Windows.Forms.ColumnHeader();
            this.КолонкаГУИД = new System.Windows.Forms.ColumnHeader();
            this.КолонкаТС = new System.Windows.Forms.ColumnHeader();
            this.Далее = new System.Windows.Forms.Button();
            this.Назад = new System.Windows.Forms.Button();
            this.ПодсказкаПользователю = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // СписокТТН
            // 
            this.СписокТТН.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            this.СписокТТН.Columns.Add(this.КолонкаНомер);
            this.СписокТТН.Columns.Add(this.КолонкаГУИД);
            this.СписокТТН.Columns.Add(this.КолонкаТС);
            this.СписокТТН.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.СписокТТН.FullRowSelect = true;
            this.СписокТТН.Location = new System.Drawing.Point(2, 25);
            this.СписокТТН.Name = "СписокТТН";
            this.СписокТТН.Size = new System.Drawing.Size(236, 269);
            this.СписокТТН.TabIndex = 0;
            this.СписокТТН.View = System.Windows.Forms.View.Details;
            // 
            // КолонкаНомер
            // 
            this.КолонкаНомер.Text = "Номер ТТН";
            this.КолонкаНомер.Width = 93;
            // 
            // КолонкаГУИД
            // 
            this.КолонкаГУИД.Text = "ГУИД";
            this.КолонкаГУИД.Width = 0;
            // 
            // КолонкаТС
            // 
            this.КолонкаТС.Text = "Номер ТС";
            this.КолонкаТС.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.КолонкаТС.Width = 140;
            // 
            // Далее
            // 
            this.Далее.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.Далее.Location = new System.Drawing.Point(133, 296);
            this.Далее.Name = "Далее";
            this.Далее.Size = new System.Drawing.Size(105, 22);
            this.Далее.TabIndex = 5;
            this.Далее.Text = "Далее";
            this.Далее.Click += new System.EventHandler(this.Далее_Click);
            // 
            // Назад
            // 
            this.Назад.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.Назад.Location = new System.Drawing.Point(2, 296);
            this.Назад.Name = "Назад";
            this.Назад.Size = new System.Drawing.Size(105, 22);
            this.Назад.TabIndex = 4;
            this.Назад.Text = "Назад";
            this.Назад.Click += new System.EventHandler(this.Назад_Click);
            // 
            // ПодсказкаПользователю
            // 
            this.ПодсказкаПользователю.BackColor = System.Drawing.SystemColors.Info;
            this.ПодсказкаПользователю.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.ПодсказкаПользователю.Location = new System.Drawing.Point(2, 2);
            this.ПодсказкаПользователю.Name = "ПодсказкаПользователю";
            this.ПодсказкаПользователю.Size = new System.Drawing.Size(236, 20);
            this.ПодсказкаПользователю.Text = "ВЫБЕРИТЕ ТС ПОГРУЗКИ";
            this.ПодсказкаПользователю.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ФормаВыборТТН
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(240, 320);
            this.ControlBox = false;
            this.Controls.Add(this.ПодсказкаПользователю);
            this.Controls.Add(this.Далее);
            this.Controls.Add(this.Назад);
            this.Controls.Add(this.СписокТТН);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.Name = "ФормаВыборТТН";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.ФормаВыборТТН_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ФормаВыборТТН_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button Далее;
        public System.Windows.Forms.Button Назад;
        public System.Windows.Forms.ListView СписокТТН;
        private System.Windows.Forms.ColumnHeader КолонкаНомер;
        private System.Windows.Forms.ColumnHeader КолонкаГУИД;
        private System.Windows.Forms.ColumnHeader КолонкаТС;
        private System.Windows.Forms.Label ПодсказкаПользователю;
    }
}