namespace СкладскойУчет
{
    partial class Разгрузка_ОбработкаТТН
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
            this.lvСписокФилиалов = new System.Windows.Forms.ListView();
            this.ФилиалИмя = new System.Windows.Forms.ColumnHeader();
            this.КоличествоЖдем = new System.Windows.Forms.ColumnHeader();
            this.КоличествоПринято = new System.Windows.Forms.ColumnHeader();
            this.Назад = new System.Windows.Forms.Button();
            this.Далее = new System.Windows.Forms.Button();
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
            // lvСписокФилиалов
            // 
            this.lvСписокФилиалов.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            this.lvСписокФилиалов.Columns.Add(this.ФилиалИмя);
            this.lvСписокФилиалов.Columns.Add(this.КоличествоЖдем);
            this.lvСписокФилиалов.Columns.Add(this.КоличествоПринято);
            this.lvСписокФилиалов.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.lvСписокФилиалов.FullRowSelect = true;
            this.lvСписокФилиалов.Location = new System.Drawing.Point(2, 46);
            this.lvСписокФилиалов.Name = "lvСписокФилиалов";
            this.lvСписокФилиалов.Size = new System.Drawing.Size(236, 248);
            this.lvСписокФилиалов.TabIndex = 7;
            this.lvСписокФилиалов.View = System.Windows.Forms.View.Details;
            // 
            // ФилиалИмя
            // 
            this.ФилиалИмя.Text = "Филиал";
            this.ФилиалИмя.Width = 123;
            // 
            // КоличествоЖдем
            // 
            this.КоличествоЖдем.Text = "Ждем";
            this.КоличествоЖдем.Width = 48;
            // 
            // КоличествоПринято
            // 
            this.КоличествоПринято.Text = "Принято";
            this.КоличествоПринято.Width = 62;
            // 
            // Назад
            // 
            this.Назад.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.Назад.Location = new System.Drawing.Point(2, 296);
            this.Назад.Name = "Назад";
            this.Назад.Size = new System.Drawing.Size(105, 22);
            this.Назад.TabIndex = 9;
            this.Назад.Text = "Назад";
            this.Назад.Click += new System.EventHandler(this.Назад_Click);
            // 
            // Далее
            // 
            this.Далее.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.Далее.Location = new System.Drawing.Point(133, 296);
            this.Далее.Name = "Далее";
            this.Далее.Size = new System.Drawing.Size(105, 22);
            this.Далее.TabIndex = 10;
            this.Далее.Text = "Завершить";
            this.Далее.Click += new System.EventHandler(this.Далее_Click);
            // 
            // Разгрузка_ОбработкаТТН
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(240, 320);
            this.ControlBox = false;
            this.Controls.Add(this.Далее);
            this.Controls.Add(this.Назад);
            this.Controls.Add(this.lvСписокФилиалов);
            this.Controls.Add(this.ПодсказкаПользователю);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.Name = "Разгрузка_ОбработкаТТН";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Разгрузка_ОбработкаТТН_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Разгрузка_ОбработкаТТН_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label ПодсказкаПользователю;
        public System.Windows.Forms.ListView lvСписокФилиалов;
        public System.Windows.Forms.Button Назад;
        public System.Windows.Forms.Button Далее;
        private System.Windows.Forms.ColumnHeader ФилиалИмя;
        private System.Windows.Forms.ColumnHeader КоличествоЖдем;
        private System.Windows.Forms.ColumnHeader КоличествоПринято;
    }
}