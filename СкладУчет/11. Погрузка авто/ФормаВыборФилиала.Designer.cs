namespace СкладскойУчет
{
    partial class ФормаВыборФилиала
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
            this.ПодсказкаПользователю = new System.Windows.Forms.Label();
            this.Далее = new System.Windows.Forms.Button();
            this.Назад = new System.Windows.Forms.Button();
            this.СписокФилиалов = new System.Windows.Forms.ListView();
            this.КолонкаФилиал = new System.Windows.Forms.ColumnHeader();
            this.КолонкаГУИД = new System.Windows.Forms.ColumnHeader();
            this.КолонкаКоличество = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // ПодсказкаПользователю
            // 
            this.ПодсказкаПользователю.BackColor = System.Drawing.SystemColors.Info;
            this.ПодсказкаПользователю.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.ПодсказкаПользователю.Location = new System.Drawing.Point(2, 3);
            this.ПодсказкаПользователю.Name = "ПодсказкаПользователю";
            this.ПодсказкаПользователю.Size = new System.Drawing.Size(236, 40);
            this.ПодсказкаПользователю.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Далее
            // 
            this.Далее.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.Далее.Location = new System.Drawing.Point(133, 296);
            this.Далее.Name = "Далее";
            this.Далее.Size = new System.Drawing.Size(105, 22);
            this.Далее.TabIndex = 9;
            this.Далее.Text = "Далее";
            this.Далее.Click += new System.EventHandler(this.Далее_Click);
            // 
            // Назад
            // 
            this.Назад.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.Назад.Location = new System.Drawing.Point(2, 296);
            this.Назад.Name = "Назад";
            this.Назад.Size = new System.Drawing.Size(105, 22);
            this.Назад.TabIndex = 8;
            this.Назад.Text = "Назад";
            this.Назад.Click += new System.EventHandler(this.Назад_Click);
            // 
            // СписокФилиалов
            // 
            this.СписокФилиалов.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            this.СписокФилиалов.Columns.Add(this.КолонкаФилиал);
            this.СписокФилиалов.Columns.Add(this.КолонкаГУИД);
            this.СписокФилиалов.Columns.Add(this.КолонкаКоличество);
            this.СписокФилиалов.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.СписокФилиалов.FullRowSelect = true;
            this.СписокФилиалов.Location = new System.Drawing.Point(2, 46);
            this.СписокФилиалов.Name = "СписокФилиалов";
            this.СписокФилиалов.Size = new System.Drawing.Size(236, 244);
            this.СписокФилиалов.TabIndex = 6;
            this.СписокФилиалов.View = System.Windows.Forms.View.Details;
            // 
            // КолонкаФилиал
            // 
            this.КолонкаФилиал.Text = "Филиал";
            this.КолонкаФилиал.Width = 160;
            // 
            // КолонкаГУИД
            // 
            this.КолонкаГУИД.Text = "ГУИД";
            this.КолонкаГУИД.Width = 0;
            // 
            // КолонкаКоличество
            // 
            this.КолонкаКоличество.Text = "Кол-во";
            this.КолонкаКоличество.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.КолонкаКоличество.Width = 73;
            // 
            // ФормаВыборФилиала
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(240, 320);
            this.ControlBox = false;
            this.Controls.Add(this.ПодсказкаПользователю);
            this.Controls.Add(this.Далее);
            this.Controls.Add(this.Назад);
            this.Controls.Add(this.СписокФилиалов);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.Name = "ФормаВыборФилиала";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.ФормаВыборФилиала_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ФормаВыборФилиала_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label ПодсказкаПользователю;
        public System.Windows.Forms.Button Далее;
        public System.Windows.Forms.Button Назад;
        public System.Windows.Forms.ListView СписокФилиалов;
        private System.Windows.Forms.ColumnHeader КолонкаФилиал;
        private System.Windows.Forms.ColumnHeader КолонкаГУИД;
        private System.Windows.Forms.ColumnHeader КолонкаКоличество;
    }
}