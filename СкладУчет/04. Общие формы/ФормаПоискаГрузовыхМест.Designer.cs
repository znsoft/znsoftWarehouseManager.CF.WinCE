namespace СкладскойУчет
{
    partial class ФормаПоискаГрузовыхМест
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
            this.СписокНайденныхГрузовыхМест = new System.Windows.Forms.ListView();
            this.КнопкаНайтиГрузовыеМеста = new System.Windows.Forms.Button();
            this.ТекстДляПоискаМест = new System.Windows.Forms.TextBox();
            this.Завершить = new System.Windows.Forms.Button();
            this.Назад = new System.Windows.Forms.Button();
            this.ПодсказкаПользователю = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // СписокНайденныхГрузовыхМест
            // 
            this.СписокНайденныхГрузовыхМест.FullRowSelect = true;
            this.СписокНайденныхГрузовыхМест.Location = new System.Drawing.Point(2, 71);
            this.СписокНайденныхГрузовыхМест.Name = "СписокНайденныхГрузовыхМест";
            this.СписокНайденныхГрузовыхМест.Size = new System.Drawing.Size(236, 223);
            this.СписокНайденныхГрузовыхМест.TabIndex = 5;
            this.СписокНайденныхГрузовыхМест.View = System.Windows.Forms.View.List;
            this.СписокНайденныхГрузовыхМест.KeyDown += new System.Windows.Forms.KeyEventHandler(this.СписокНайденныхГрузовыхМест_KeyDown);
            // 
            // КнопкаНайтиГрузовыеМеста
            // 
            this.КнопкаНайтиГрузовыеМеста.Location = new System.Drawing.Point(188, 46);
            this.КнопкаНайтиГрузовыеМеста.Name = "КнопкаНайтиГрузовыеМеста";
            this.КнопкаНайтиГрузовыеМеста.Size = new System.Drawing.Size(50, 23);
            this.КнопкаНайтиГрузовыеМеста.TabIndex = 4;
            this.КнопкаНайтиГрузовыеМеста.Text = "Найти";
            this.КнопкаНайтиГрузовыеМеста.Click += new System.EventHandler(this.КнопкаНайтиГрузовыеМеста_Click);
            // 
            // ТекстДляПоискаМест
            // 
            this.ТекстДляПоискаМест.Location = new System.Drawing.Point(2, 46);
            this.ТекстДляПоискаМест.Name = "ТекстДляПоискаМест";
            this.ТекстДляПоискаМест.Size = new System.Drawing.Size(184, 23);
            this.ТекстДляПоискаМест.TabIndex = 3;
            this.ТекстДляПоискаМест.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ТекстДляПоискаМест_KeyDown);
            // 
            // Завершить
            // 
            this.Завершить.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.Завершить.Location = new System.Drawing.Point(133, 296);
            this.Завершить.Name = "Завершить";
            this.Завершить.Size = new System.Drawing.Size(105, 22);
            this.Завершить.TabIndex = 7;
            this.Завершить.Text = "Найти";
            this.Завершить.Click += new System.EventHandler(this.Завершить_Click);
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
            // ПодсказкаПользователю
            // 
            this.ПодсказкаПользователю.BackColor = System.Drawing.SystemColors.Info;
            this.ПодсказкаПользователю.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.ПодсказкаПользователю.Location = new System.Drawing.Point(2, 3);
            this.ПодсказкаПользователю.Name = "ПодсказкаПользователю";
            this.ПодсказкаПользователю.Size = new System.Drawing.Size(236, 40);
            this.ПодсказкаПользователю.Text = "ВВЕДИТЕ ЗНАЧЕНИЕ ПОИСКА\r\n(более 4-х символов)";
            this.ПодсказкаПользователю.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ФормаПоискаГрузовыхМест
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(240, 320);
            this.ControlBox = false;
            this.Controls.Add(this.ПодсказкаПользователю);
            this.Controls.Add(this.Завершить);
            this.Controls.Add(this.Назад);
            this.Controls.Add(this.СписокНайденныхГрузовыхМест);
            this.Controls.Add(this.КнопкаНайтиГрузовыеМеста);
            this.Controls.Add(this.ТекстДляПоискаМест);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.Name = "ФормаПоискаГрузовыхМест";
            this.Text = "ФормаПоискаГрузовыхМест";
            this.TopMost = true;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ФормаПоискаГрузовыхМест_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView СписокНайденныхГрузовыхМест;
        private System.Windows.Forms.Button КнопкаНайтиГрузовыеМеста;
        private System.Windows.Forms.TextBox ТекстДляПоискаМест;
        public System.Windows.Forms.Button Завершить;
        public System.Windows.Forms.Button Назад;
        private System.Windows.Forms.Label ПодсказкаПользователю;
    }
}