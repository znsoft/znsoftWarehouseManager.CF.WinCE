namespace СкладскойУчет
{
    partial class ФормаПогрузка
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem();
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem();
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem();
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem();
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem();
            System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem();
            this.ПодсказкаПользователю = new System.Windows.Forms.Label();
            this.Далее = new System.Windows.Forms.Button();
            this.Назад = new System.Windows.Forms.Button();
            this.СписокПогрузки = new System.Windows.Forms.ListView();
            this.КолонкаНаименование = new System.Windows.Forms.ColumnHeader();
            this.КолонкаКоличествоМест = new System.Windows.Forms.ColumnHeader();
            this.КолонкаКоличествоМестБыло = new System.Windows.Forms.ColumnHeader();
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
            this.Далее.Text = "Завершить";
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
            // СписокПогрузки
            // 
            this.СписокПогрузки.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            this.СписокПогрузки.Columns.Add(this.КолонкаНаименование);
            this.СписокПогрузки.Columns.Add(this.КолонкаКоличествоМест);
            this.СписокПогрузки.Columns.Add(this.КолонкаКоличествоМестБыло);
            this.СписокПогрузки.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.СписокПогрузки.FullRowSelect = true;
            listViewItem1.Text = "Оргтехника";
            listViewItem1.SubItems.Add("0");
            listViewItem1.SubItems.Add("0");
            listViewItem2.Text = "Ноутбуки";
            listViewItem2.SubItems.Add("0");
            listViewItem2.SubItems.Add("0");
            listViewItem3.Text = "Телевизоры";
            listViewItem3.SubItems.Add("0");
            listViewItem3.SubItems.Add("0");
            listViewItem4.Text = "Дорогой товар";
            listViewItem4.SubItems.Add("0");
            listViewItem4.SubItems.Add("0");
            listViewItem5.Text = "Мешки";
            listViewItem5.SubItems.Add("0");
            listViewItem5.SubItems.Add("0");
            listViewItem6.Text = "Перекосы";
            listViewItem6.SubItems.Add("0");
            listViewItem6.SubItems.Add("0");
            this.СписокПогрузки.Items.Add(listViewItem1);
            this.СписокПогрузки.Items.Add(listViewItem2);
            this.СписокПогрузки.Items.Add(listViewItem3);
            this.СписокПогрузки.Items.Add(listViewItem4);
            this.СписокПогрузки.Items.Add(listViewItem5);
            this.СписокПогрузки.Items.Add(listViewItem6);
            this.СписокПогрузки.Location = new System.Drawing.Point(2, 46);
            this.СписокПогрузки.Name = "СписокПогрузки";
            this.СписокПогрузки.Size = new System.Drawing.Size(236, 248);
            this.СписокПогрузки.TabIndex = 6;
            this.СписокПогрузки.View = System.Windows.Forms.View.Details;
            // 
            // КолонкаНаименование
            // 
            this.КолонкаНаименование.Text = "Наименование";
            this.КолонкаНаименование.Width = 150;
            // 
            // КолонкаКоличествоМест
            // 
            this.КолонкаКоличествоМест.Text = "Кол-во";
            this.КолонкаКоличествоМест.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.КолонкаКоличествоМест.Width = 83;
            // 
            // КолонкаКоличествоМестБыло
            // 
            this.КолонкаКоличествоМестБыло.Text = "Кол-во было";
            this.КолонкаКоличествоМестБыло.Width = 0;
            // 
            // ФормаПогрузка
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(240, 320);
            this.ControlBox = false;
            this.Controls.Add(this.ПодсказкаПользователю);
            this.Controls.Add(this.Далее);
            this.Controls.Add(this.Назад);
            this.Controls.Add(this.СписокПогрузки);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.Name = "ФормаПогрузка";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.ФормаПогрузка_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ФормаПогрузка_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label ПодсказкаПользователю;
        public System.Windows.Forms.Button Далее;
        public System.Windows.Forms.Button Назад;
        public System.Windows.Forms.ListView СписокПогрузки;
        private System.Windows.Forms.ColumnHeader КолонкаНаименование;
        private System.Windows.Forms.ColumnHeader КолонкаКоличествоМест;
        private System.Windows.Forms.ColumnHeader КолонкаКоличествоМестБыло;
    }
}