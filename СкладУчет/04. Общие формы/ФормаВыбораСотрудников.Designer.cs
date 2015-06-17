namespace СкладскойУчет
{
    partial class ФормаВыбораСотрудников
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
            this.СписокСотрудников = new System.Windows.Forms.ListView();
            this.СотрудникНаименование = new System.Windows.Forms.ColumnHeader();
            this.СотрудникКод = new System.Windows.Forms.ColumnHeader();
            this.Далее = new System.Windows.Forms.Button();
            this.Назад = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ПодсказкаПользователю
            // 
            this.ПодсказкаПользователю.BackColor = System.Drawing.SystemColors.Info;
            this.ПодсказкаПользователю.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.ПодсказкаПользователю.Location = new System.Drawing.Point(2, 2);
            this.ПодсказкаПользователю.Name = "ПодсказкаПользователю";
            this.ПодсказкаПользователю.Size = new System.Drawing.Size(236, 40);
            this.ПодсказкаПользователю.Text = "СКАНИРУЙТЕ ШК \r\nСОТРУДНИКА";
            this.ПодсказкаПользователю.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // СписокСотрудников
            // 
            this.СписокСотрудников.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            this.СписокСотрудников.Columns.Add(this.СотрудникНаименование);
            this.СписокСотрудников.Columns.Add(this.СотрудникКод);
            this.СписокСотрудников.FullRowSelect = true;
            this.СписокСотрудников.Location = new System.Drawing.Point(2, 46);
            this.СписокСотрудников.Name = "СписокСотрудников";
            this.СписокСотрудников.Size = new System.Drawing.Size(236, 248);
            this.СписокСотрудников.TabIndex = 2;
            this.СписокСотрудников.View = System.Windows.Forms.View.Details;
            // 
            // СотрудникНаименование
            // 
            this.СотрудникНаименование.Text = "Сотрудник";
            this.СотрудникНаименование.Width = 200;
            // 
            // СотрудникКод
            // 
            this.СотрудникКод.Text = "";
            this.СотрудникКод.Width = 0;
            // 
            // Далее
            // 
            this.Далее.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.Далее.Location = new System.Drawing.Point(133, 296);
            this.Далее.Name = "Далее";
            this.Далее.Size = new System.Drawing.Size(105, 22);
            this.Далее.TabIndex = 11;
            this.Далее.Text = "Ок";
            this.Далее.Click += new System.EventHandler(this.Далее_Click);
            // 
            // Назад
            // 
            this.Назад.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.Назад.Location = new System.Drawing.Point(2, 296);
            this.Назад.Name = "Назад";
            this.Назад.Size = new System.Drawing.Size(105, 22);
            this.Назад.TabIndex = 10;
            this.Назад.Text = "Отмена";
            this.Назад.Click += new System.EventHandler(this.Назад_Click);
            // 
            // ФормаВыбораСотрудников
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(240, 320);
            this.ControlBox = false;
            this.Controls.Add(this.Далее);
            this.Controls.Add(this.Назад);
            this.Controls.Add(this.СписокСотрудников);
            this.Controls.Add(this.ПодсказкаПользователю);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.Name = "ФормаВыбораСотрудников";
            this.Text = "ФормаВыбораСотрудников";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.ФормаВыбораСотрудников_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ФормаВыбораСотрудников_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label ПодсказкаПользователю;
        private System.Windows.Forms.ListView СписокСотрудников;
        public System.Windows.Forms.Button Далее;
        public System.Windows.Forms.Button Назад;
        private System.Windows.Forms.ColumnHeader СотрудникНаименование;
        private System.Windows.Forms.ColumnHeader СотрудникКод;
    }
}