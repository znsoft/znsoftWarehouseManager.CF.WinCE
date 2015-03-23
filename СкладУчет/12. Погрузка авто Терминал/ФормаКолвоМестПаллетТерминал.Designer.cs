namespace СкладскойУчет
{
    partial class ФормаКолвоМестПаллетТерминал
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
            this.Далее = new System.Windows.Forms.Button();
            this.Назад = new System.Windows.Forms.Button();
            this.КоличествоМест = new System.Windows.Forms.TextBox();
            this.НадписьКоличествоМест = new System.Windows.Forms.Label();
            this.КоличествоПаллет = new System.Windows.Forms.TextBox();
            this.НадписьКоличествоПаллет = new System.Windows.Forms.Label();
            this.ПодсказкаПользователю = new System.Windows.Forms.Label();
            this.SuspendLayout();
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
            // КоличествоМест
            // 
            this.КоличествоМест.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.КоличествоМест.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular);
            this.КоличествоМест.Location = new System.Drawing.Point(157, 99);
            this.КоличествоМест.MaxLength = 6;
            this.КоличествоМест.Name = "КоличествоМест";
            this.КоличествоМест.Size = new System.Drawing.Size(80, 29);
            this.КоличествоМест.TabIndex = 12;
            this.КоличествоМест.Text = "0";
            this.КоличествоМест.TextChanged += new System.EventHandler(this.КоличествоМест_TextChanged);
            this.КоличествоМест.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.КоличествоМест_KeyPress);
            // 
            // НадписьКоличествоМест
            // 
            this.НадписьКоличествоМест.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular);
            this.НадписьКоличествоМест.Location = new System.Drawing.Point(9, 99);
            this.НадписьКоличествоМест.Name = "НадписьКоличествоМест";
            this.НадписьКоличествоМест.Size = new System.Drawing.Size(142, 29);
            this.НадписьКоличествоМест.Text = "Кол-во мест:";
            // 
            // КоличествоПаллет
            // 
            this.КоличествоПаллет.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.КоличествоПаллет.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular);
            this.КоличествоПаллет.Location = new System.Drawing.Point(157, 144);
            this.КоличествоПаллет.MaxLength = 6;
            this.КоличествоПаллет.Name = "КоличествоПаллет";
            this.КоличествоПаллет.Size = new System.Drawing.Size(80, 29);
            this.КоличествоПаллет.TabIndex = 14;
            this.КоличествоПаллет.Text = "0";
            this.КоличествоПаллет.TextChanged += new System.EventHandler(this.КоличествоПаллет_TextChanged);
            this.КоличествоПаллет.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.КоличествоПаллет_KeyPress);
            // 
            // НадписьКоличествоПаллет
            // 
            this.НадписьКоличествоПаллет.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular);
            this.НадписьКоличествоПаллет.Location = new System.Drawing.Point(9, 143);
            this.НадписьКоличествоПаллет.Name = "НадписьКоличествоПаллет";
            this.НадписьКоличествоПаллет.Size = new System.Drawing.Size(142, 30);
            this.НадписьКоличествоПаллет.Text = "Кол-во паллет:";
            // 
            // ПодсказкаПользователю
            // 
            this.ПодсказкаПользователю.BackColor = System.Drawing.SystemColors.Info;
            this.ПодсказкаПользователю.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.ПодсказкаПользователю.Location = new System.Drawing.Point(2, 3);
            this.ПодсказкаПользователю.Name = "ПодсказкаПользователю";
            this.ПодсказкаПользователю.Size = new System.Drawing.Size(236, 60);
            this.ПодсказкаПользователю.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ФормаКолвоМестПаллетТерминал
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(240, 320);
            this.ControlBox = false;
            this.Controls.Add(this.ПодсказкаПользователю);
            this.Controls.Add(this.НадписьКоличествоПаллет);
            this.Controls.Add(this.КоличествоПаллет);
            this.Controls.Add(this.НадписьКоличествоМест);
            this.Controls.Add(this.КоличествоМест);
            this.Controls.Add(this.Далее);
            this.Controls.Add(this.Назад);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.Name = "ФормаКолвоМестПаллетТерминал";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.ФормаКолвоМестПаллетТерминал_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ФормаКолвоМестПаллетТерминал_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button Далее;
        public System.Windows.Forms.Button Назад;
        private System.Windows.Forms.Label НадписьКоличествоМест;
        private System.Windows.Forms.Label НадписьКоличествоПаллет;
        public System.Windows.Forms.TextBox КоличествоМест;
        public System.Windows.Forms.TextBox КоличествоПаллет;
        private System.Windows.Forms.Label ПодсказкаПользователю;
    }
}