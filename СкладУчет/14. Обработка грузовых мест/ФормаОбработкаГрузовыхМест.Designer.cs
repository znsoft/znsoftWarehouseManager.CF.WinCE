namespace СкладскойУчет
{
    partial class ОбработкаГрузовыхМест
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
            this.Назад = new System.Windows.Forms.Button();
            this.Завершить = new System.Windows.Forms.Button();
            this.СписокГрузовыхМест = new System.Windows.Forms.ListView();
            this.МестоНомер = new System.Windows.Forms.ColumnHeader();
            this.МестоАналог = new System.Windows.Forms.ColumnHeader();
            this.ГоричиеКлавиши = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ПодсказкаПользователю
            // 
            this.ПодсказкаПользователю.BackColor = System.Drawing.SystemColors.Info;
            this.ПодсказкаПользователю.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.ПодсказкаПользователю.Location = new System.Drawing.Point(2, 2);
            this.ПодсказкаПользователю.Name = "ПодсказкаПользователю";
            this.ПодсказкаПользователю.Size = new System.Drawing.Size(236, 20);
            this.ПодсказкаПользователю.Text = "СКАНИРУЙТЕ ШК ГМ";
            this.ПодсказкаПользователю.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Назад
            // 
            this.Назад.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.Назад.Location = new System.Drawing.Point(2, 296);
            this.Назад.Name = "Назад";
            this.Назад.Size = new System.Drawing.Size(105, 22);
            this.Назад.TabIndex = 6;
            this.Назад.Text = "Назад";
            this.Назад.Click += new System.EventHandler(this.Назад_Click);
            // 
            // Завершить
            // 
            this.Завершить.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.Завершить.Location = new System.Drawing.Point(133, 296);
            this.Завершить.Name = "Завершить";
            this.Завершить.Size = new System.Drawing.Size(105, 22);
            this.Завершить.TabIndex = 7;
            this.Завершить.Text = "Завершить";
            this.Завершить.Click += new System.EventHandler(this.Далее_Click);
            // 
            // СписокГрузовыхМест
            // 
            this.СписокГрузовыхМест.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            this.СписокГрузовыхМест.Columns.Add(this.МестоНомер);
            this.СписокГрузовыхМест.Columns.Add(this.МестоАналог);
            this.СписокГрузовыхМест.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.СписокГрузовыхМест.FullRowSelect = true;
            this.СписокГрузовыхМест.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.СписокГрузовыхМест.Location = new System.Drawing.Point(2, 25);
            this.СписокГрузовыхМест.Name = "СписокГрузовыхМест";
            this.СписокГрузовыхМест.Size = new System.Drawing.Size(236, 236);
            this.СписокГрузовыхМест.TabIndex = 8;
            this.СписокГрузовыхМест.View = System.Windows.Forms.View.Details;
            // 
            // МестоНомер
            // 
            this.МестоНомер.Text = "ColumnHeader";
            this.МестоНомер.Width = 0;
            // 
            // МестоАналог
            // 
            this.МестоАналог.Text = "ColumnHeader";
            this.МестоАналог.Width = 180;
            // 
            // ГоричиеКлавиши
            // 
            this.ГоричиеКлавиши.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.ГоричиеКлавиши.Location = new System.Drawing.Point(2, 264);
            this.ГоричиеКлавиши.Name = "ГоричиеКлавиши";
            this.ГоричиеКлавиши.Size = new System.Drawing.Size(236, 29);
            this.ГоричиеКлавиши.Text = "F1 - поиск грузовых мест; F3 - добавление сотрудников\r\n";
            // 
            // ОбработкаГрузовыхМест
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(240, 320);
            this.ControlBox = false;
            this.Controls.Add(this.ГоричиеКлавиши);
            this.Controls.Add(this.СписокГрузовыхМест);
            this.Controls.Add(this.Завершить);
            this.Controls.Add(this.Назад);
            this.Controls.Add(this.ПодсказкаПользователю);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.Name = "ОбработкаГрузовыхМест";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.ОбработкаГрузовыхМест_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ОбработкаГрузовыхМест_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label ПодсказкаПользователю;
        public System.Windows.Forms.Button Назад;
        public System.Windows.Forms.Button Завершить;
        public System.Windows.Forms.ListView СписокГрузовыхМест;
        private System.Windows.Forms.ColumnHeader МестоНомер;
        private System.Windows.Forms.ColumnHeader МестоАналог;
        private System.Windows.Forms.Label ГоричиеКлавиши;
    }
}