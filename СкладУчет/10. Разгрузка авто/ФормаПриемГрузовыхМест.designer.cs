namespace СкладскойУчет
{
    partial class ПриемГрузовыхМест
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
            this.СписокГрузовыхМест = new System.Windows.Forms.ListView();
            this.Место = new System.Windows.Forms.ColumnHeader();
            this.Назад = new System.Windows.Forms.Button();
            this.Завершить = new System.Windows.Forms.Button();
            this.ПодсказкаПользователю = new System.Windows.Forms.Label();
            this.ОсновнаяПанель = new System.Windows.Forms.TabControl();
            this.СтраницаМеста = new System.Windows.Forms.TabPage();
            this.СтраницаПоиск = new System.Windows.Forms.TabPage();
            this.СписокНайденныхГрузовыхМест = new System.Windows.Forms.ListView();
            this.КнопкаНайтиГрузовыеМеста = new System.Windows.Forms.Button();
            this.ТекстДляПоискаМест = new System.Windows.Forms.TextBox();
            this.ОсновнаяПанель.SuspendLayout();
            this.СтраницаМеста.SuspendLayout();
            this.СтраницаПоиск.SuspendLayout();
            this.SuspendLayout();
            // 
            // СписокГрузовыхМест
            // 
            this.СписокГрузовыхМест.Columns.Add(this.Место);
            this.СписокГрузовыхМест.FullRowSelect = true;
            this.СписокГрузовыхМест.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.СписокГрузовыхМест.Location = new System.Drawing.Point(1, 2);
            this.СписокГрузовыхМест.Name = "СписокГрузовыхМест";
            this.СписокГрузовыхМест.Size = new System.Drawing.Size(225, 240);
            this.СписокГрузовыхМест.TabIndex = 0;
            this.СписокГрузовыхМест.View = System.Windows.Forms.View.Details;
            // 
            // Место
            // 
            this.Место.Text = "Место";
            this.Место.Width = 200;
            // 
            // Назад
            // 
            this.Назад.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.Назад.Location = new System.Drawing.Point(2, 296);
            this.Назад.Name = "Назад";
            this.Назад.Size = new System.Drawing.Size(105, 22);
            this.Назад.TabIndex = 2;
            this.Назад.Text = "Назад";
            this.Назад.Click += new System.EventHandler(this.Назад_Click);
            // 
            // Завершить
            // 
            this.Завершить.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.Завершить.Location = new System.Drawing.Point(133, 296);
            this.Завершить.Name = "Завершить";
            this.Завершить.Size = new System.Drawing.Size(105, 22);
            this.Завершить.TabIndex = 3;
            this.Завершить.Text = "Завершить";
            this.Завершить.Click += new System.EventHandler(this.Завершить_Click);
            // 
            // ПодсказкаПользователю
            // 
            this.ПодсказкаПользователю.BackColor = System.Drawing.SystemColors.Info;
            this.ПодсказкаПользователю.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.ПодсказкаПользователю.Location = new System.Drawing.Point(2, 2);
            this.ПодсказкаПользователю.Name = "ПодсказкаПользователю";
            this.ПодсказкаПользователю.Size = new System.Drawing.Size(236, 20);
            // 
            // ОсновнаяПанель
            // 
            this.ОсновнаяПанель.Controls.Add(this.СтраницаМеста);
            this.ОсновнаяПанель.Controls.Add(this.СтраницаПоиск);
            this.ОсновнаяПанель.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular);
            this.ОсновнаяПанель.Location = new System.Drawing.Point(2, 25);
            this.ОсновнаяПанель.Name = "ОсновнаяПанель";
            this.ОсновнаяПанель.SelectedIndex = 0;
            this.ОсновнаяПанель.Size = new System.Drawing.Size(236, 269);
            this.ОсновнаяПанель.TabIndex = 4;
            this.ОсновнаяПанель.SelectedIndexChanged += new System.EventHandler(this.ОсновнаяПанель_SelectedIndexChanged);
            // 
            // СтраницаМеста
            // 
            this.СтраницаМеста.Controls.Add(this.СписокГрузовыхМест);
            this.СтраницаМеста.Location = new System.Drawing.Point(4, 23);
            this.СтраницаМеста.Name = "СтраницаМеста";
            this.СтраницаМеста.Size = new System.Drawing.Size(228, 242);
            this.СтраницаМеста.Text = "< Места";
            // 
            // СтраницаПоиск
            // 
            this.СтраницаПоиск.Controls.Add(this.СписокНайденныхГрузовыхМест);
            this.СтраницаПоиск.Controls.Add(this.КнопкаНайтиГрузовыеМеста);
            this.СтраницаПоиск.Controls.Add(this.ТекстДляПоискаМест);
            this.СтраницаПоиск.Location = new System.Drawing.Point(4, 23);
            this.СтраницаПоиск.Name = "СтраницаПоиск";
            this.СтраницаПоиск.Size = new System.Drawing.Size(228, 242);
            this.СтраницаПоиск.Text = "Поиск >";
            // 
            // СписокНайденныхГрузовыхМест
            // 
            this.СписокНайденныхГрузовыхМест.FullRowSelect = true;
            this.СписокНайденныхГрузовыхМест.Location = new System.Drawing.Point(1, 28);
            this.СписокНайденныхГрузовыхМест.Name = "СписокНайденныхГрузовыхМест";
            this.СписокНайденныхГрузовыхМест.Size = new System.Drawing.Size(225, 214);
            this.СписокНайденныхГрузовыхМест.TabIndex = 2;
            this.СписокНайденныхГрузовыхМест.View = System.Windows.Forms.View.List;
            this.СписокНайденныхГрузовыхМест.KeyDown += new System.Windows.Forms.KeyEventHandler(this.СписокНайденныхГрузовыхМест_KeyDown);
            // 
            // КнопкаНайтиГрузовыеМеста
            // 
            this.КнопкаНайтиГрузовыеМеста.Location = new System.Drawing.Point(176, 2);
            this.КнопкаНайтиГрузовыеМеста.Name = "КнопкаНайтиГрузовыеМеста";
            this.КнопкаНайтиГрузовыеМеста.Size = new System.Drawing.Size(50, 23);
            this.КнопкаНайтиГрузовыеМеста.TabIndex = 1;
            this.КнопкаНайтиГрузовыеМеста.Text = "Найти";
            this.КнопкаНайтиГрузовыеМеста.Click += new System.EventHandler(this.КнопкаНайтиГрузовыеМеста_Click);
            // 
            // ТекстДляПоискаМест
            // 
            this.ТекстДляПоискаМест.Location = new System.Drawing.Point(1, 2);
            this.ТекстДляПоискаМест.Name = "ТекстДляПоискаМест";
            this.ТекстДляПоискаМест.Size = new System.Drawing.Size(173, 23);
            this.ТекстДляПоискаМест.TabIndex = 0;
            this.ТекстДляПоискаМест.TextChanged += new System.EventHandler(this.ТекстДляПоискаМест_TextChanged);
            this.ТекстДляПоискаМест.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ТекстДляПоискаМест_KeyDown);
            // 
            // ПриемГрузовыхМест
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
            this.Controls.Add(this.ОсновнаяПанель);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.Name = "ПриемГрузовыхМест";
            this.Text = "ФормаПриемГрузовыхМест";
            this.TopMost = true;
            this.Deactivate += new System.EventHandler(this.ПриемГрузовыхМест_Deactivate);
            this.Load += new System.EventHandler(this.ФормаПриемГрузовыхМест_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.ПриемГрузовыхМест_Closing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ФормаПриемГрузовыхМест_KeyDown);
            this.ОсновнаяПанель.ResumeLayout(false);
            this.СтраницаМеста.ResumeLayout(false);
            this.СтраницаПоиск.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView СписокГрузовыхМест;
        public System.Windows.Forms.Button Назад;
        public System.Windows.Forms.Button Завершить;
        private System.Windows.Forms.ColumnHeader Место;
        private System.Windows.Forms.Label ПодсказкаПользователю;
        private System.Windows.Forms.TabControl ОсновнаяПанель;
        private System.Windows.Forms.TabPage СтраницаПоиск;
        private System.Windows.Forms.TabPage СтраницаМеста;
        private System.Windows.Forms.TextBox ТекстДляПоискаМест;
        private System.Windows.Forms.Button КнопкаНайтиГрузовыеМеста;
        private System.Windows.Forms.ListView СписокНайденныхГрузовыхМест;
    }
}