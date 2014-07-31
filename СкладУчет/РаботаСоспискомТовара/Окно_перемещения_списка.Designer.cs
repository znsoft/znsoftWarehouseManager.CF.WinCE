namespace СкладскойУчет
{
    partial class Окно_перемещения_списка
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;

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
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.Назад = new System.Windows.Forms.Button();
            this.Далее = new System.Windows.Forms.Button();
            this.Пользователь = new System.Windows.Forms.Label();
            this.Инструкция = new System.Windows.Forms.Label();
            this.ТекстДЯ = new System.Windows.Forms.Label();
            this.Информация = new System.Windows.Forms.Label();
            this.СписокПеремещения = new System.Windows.Forms.ListView();
            this.ПанельСоСплиттером = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Сплиттер = new System.Windows.Forms.Splitter();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ПолеВвода = new System.Windows.Forms.TextBox();
            this.ПанельСоСплиттером.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Назад
            // 
            this.Назад.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.Назад.Location = new System.Drawing.Point(1, 283);
            this.Назад.Name = "Назад";
            this.Назад.Size = new System.Drawing.Size(100, 22);
            this.Назад.TabIndex = 1;
            this.Назад.Text = "&0. Назад";
            this.Назад.Click += new System.EventHandler(this.ПриНажатииНаКнопку);
            // 
            // Далее
            // 
            this.Далее.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.Далее.Location = new System.Drawing.Point(138, 283);
            this.Далее.Name = "Далее";
            this.Далее.Size = new System.Drawing.Size(100, 22);
            this.Далее.TabIndex = 2;
            this.Далее.Text = "&1. Далее";
            this.Далее.Click += new System.EventHandler(this.ПриНажатииНаКнопку);
            // 
            // Пользователь
            // 
            this.Пользователь.BackColor = System.Drawing.SystemColors.Info;
            this.Пользователь.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.Пользователь.Location = new System.Drawing.Point(4, 307);
            this.Пользователь.Name = "Пользователь";
            this.Пользователь.Size = new System.Drawing.Size(229, 10);
            // 
            // Инструкция
            // 
            this.Инструкция.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.Инструкция.Location = new System.Drawing.Point(3, 0);
            this.Инструкция.Name = "Инструкция";
            this.Инструкция.Size = new System.Drawing.Size(105, 10);
            this.Инструкция.Tag = "Инструкция";
            // 
            // ТекстДЯ
            // 
            this.ТекстДЯ.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.ТекстДЯ.Location = new System.Drawing.Point(120, 0);
            this.ТекстДЯ.Name = "ТекстДЯ";
            this.ТекстДЯ.Size = new System.Drawing.Size(120, 10);
            this.ТекстДЯ.Tag = "Инструкция";
            // 
            // Информация
            // 
            this.Информация.BackColor = System.Drawing.SystemColors.Info;
            this.Информация.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Информация.Location = new System.Drawing.Point(0, 0);
            this.Информация.Name = "Информация";
            this.Информация.Size = new System.Drawing.Size(237, 53);
            this.Информация.Text = "Товар";
            // 
            // СписокПеремещения
            // 
            this.СписокПеремещения.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            this.СписокПеремещения.Dock = System.Windows.Forms.DockStyle.Fill;
            this.СписокПеремещения.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.СписокПеремещения.FullRowSelect = true;
            this.СписокПеремещения.Location = new System.Drawing.Point(0, 0);
            this.СписокПеремещения.Name = "СписокПеремещения";
            this.СписокПеремещения.Size = new System.Drawing.Size(237, 208);
            this.СписокПеремещения.TabIndex = 0;
            this.СписокПеремещения.Tag = "Таблица";
            this.СписокПеремещения.View = System.Windows.Forms.View.Details;
            this.СписокПеремещения.ItemActivate += new System.EventHandler(this.СписокПеремещения_ItemActivate);
            this.СписокПеремещения.SelectedIndexChanged += new System.EventHandler(this.СписокПеремещения_SelectedIndexChanged);
            // 
            // ПанельСоСплиттером
            // 
            this.ПанельСоСплиттером.BackColor = System.Drawing.Color.PapayaWhip;
            this.ПанельСоСплиттером.Controls.Add(this.panel2);
            this.ПанельСоСплиттером.Controls.Add(this.Сплиттер);
            this.ПанельСоСплиттером.Controls.Add(this.panel1);
            this.ПанельСоСплиттером.Location = new System.Drawing.Point(0, 13);
            this.ПанельСоСплиттером.Name = "ПанельСоСплиттером";
            this.ПанельСоСплиттером.Size = new System.Drawing.Size(237, 264);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.Информация);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 211);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(237, 53);
            // 
            // Сплиттер
            // 
            this.Сплиттер.BackColor = System.Drawing.Color.Lime;
            this.Сплиттер.Dock = System.Windows.Forms.DockStyle.Top;
            this.Сплиттер.Location = new System.Drawing.Point(0, 208);
            this.Сплиттер.Name = "Сплиттер";
            this.Сплиттер.Size = new System.Drawing.Size(237, 3);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ПолеВвода);
            this.panel1.Controls.Add(this.СписокПеремещения);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(237, 208);
            // 
            // ПолеВвода
            // 
            this.ПолеВвода.BackColor = System.Drawing.Color.LightYellow;
            this.ПолеВвода.Location = new System.Drawing.Point(41, 34);
            this.ПолеВвода.Name = "ПолеВвода";
            this.ПолеВвода.Size = new System.Drawing.Size(67, 23);
            this.ПолеВвода.TabIndex = 1;
            this.ПолеВвода.Visible = false;
            this.ПолеВвода.WordWrap = false;
            this.ПолеВвода.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ПолеВвода_KeyPress);
            this.ПолеВвода.LostFocus += new System.EventHandler(this.ПолеВвода_LostFocus);
            // 
            // Окно_перемещения_списка
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(240, 320);
            this.ControlBox = false;
            this.Controls.Add(this.ПанельСоСплиттером);
            this.Controls.Add(this.ТекстДЯ);
            this.Controls.Add(this.Инструкция);
            this.Controls.Add(this.Пользователь);
            this.Controls.Add(this.Далее);
            this.Controls.Add(this.Назад);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.Name = "Окно_перемещения_списка";
            this.Text = "Выбор";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Окно_выбора_из_списка_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Окно_выбора_из_списка_KeyDown);
            this.ПанельСоСплиттером.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button Назад;
        public System.Windows.Forms.Button Далее;
        public System.Windows.Forms.Label Пользователь;
        public System.Windows.Forms.Label Инструкция;
        public System.Windows.Forms.Label ТекстДЯ;
        public System.Windows.Forms.Label Информация;
        public System.Windows.Forms.ListView СписокПеремещения;
        public System.Windows.Forms.Panel ПанельСоСплиттером;
        public System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Splitter Сплиттер;
        public System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox ПолеВвода;
    }
}