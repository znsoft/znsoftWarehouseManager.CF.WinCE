namespace СкладскойУчет
{
    partial class ВводКоличества
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
            this.Информация = new System.Windows.Forms.Label();
            this.Количество = new System.Windows.Forms.TextBox();
            this.Принять = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Информация
            // 
            this.Информация.Location = new System.Drawing.Point(4, 4);
            this.Информация.Name = "Информация";
            this.Информация.Size = new System.Drawing.Size(150, 80);
            this.Информация.Text = "Введите необходимое количество товара для подбора";
            // 
            // Количество
            // 
            this.Количество.Location = new System.Drawing.Point(0, 87);
            this.Количество.MaxLength = 5;
            this.Количество.Name = "Количество";
            this.Количество.Size = new System.Drawing.Size(87, 23);
            this.Количество.TabIndex = 1;
            this.Количество.Text = "1";
            this.Количество.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Количество_KeyDown);
            this.Количество.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Количество_KeyPress);
            // 
            // Принять
            // 
            this.Принять.Location = new System.Drawing.Point(88, 88);
            this.Принять.Name = "Принять";
            this.Принять.Size = new System.Drawing.Size(66, 22);
            this.Принять.TabIndex = 2;
            this.Принять.Text = "Принять";
            this.Принять.Click += new System.EventHandler(this.Принять_Click);
            // 
            // ВводКоличества
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(159, 115);
            this.Controls.Add(this.Принять);
            this.Controls.Add(this.Количество);
            this.Controls.Add(this.Информация);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MinimizeBox = false;
            this.Name = "ВводКоличества";
            this.Text = "Ручной подбор";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.ВводКоличества_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label Информация;
        private System.Windows.Forms.TextBox Количество;
        private System.Windows.Forms.Button Принять;
    }
}