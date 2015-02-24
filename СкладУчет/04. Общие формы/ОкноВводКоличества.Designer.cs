namespace СкладскойУчет
{
    partial class ОкноВводКоличества
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
            this.Инструкция = new System.Windows.Forms.Label();
            this.Количество = new System.Windows.Forms.TextBox();
            this.Принять = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Инструкция
            // 
            this.Инструкция.Location = new System.Drawing.Point(4, 4);
            this.Инструкция.Name = "Инструкция";
            this.Инструкция.Size = new System.Drawing.Size(150, 68);
            this.Инструкция.Text = "Введите необходимое количество товара для подбора из требуемых";
            // 
            // Количество
            // 
            this.Количество.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Количество.Location = new System.Drawing.Point(5, 75);
            this.Количество.MaxLength = 5;
            this.Количество.Name = "Количество";
            this.Количество.Size = new System.Drawing.Size(78, 23);
            this.Количество.TabIndex = 1;
            this.Количество.Text = "1";
            this.Количество.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Количество_KeyDown);
            this.Количество.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Количество_KeyPress);
            // 
            // Принять
            // 
            this.Принять.Location = new System.Drawing.Point(88, 75);
            this.Принять.Name = "Принять";
            this.Принять.Size = new System.Drawing.Size(66, 23);
            this.Принять.TabIndex = 2;
            this.Принять.Text = "Принять";
            this.Принять.Click += new System.EventHandler(this.Принять_Click);
            // 
            // ОкноВводКоличества
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(159, 105);
            this.Controls.Add(this.Принять);
            this.Controls.Add(this.Количество);
            this.Controls.Add(this.Инструкция);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ОкноВводКоличества";
            this.Text = "Ручной ввод";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label Инструкция;
        public System.Windows.Forms.TextBox Количество;
        private System.Windows.Forms.Button Принять;
    }
}