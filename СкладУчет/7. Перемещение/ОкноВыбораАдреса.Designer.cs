namespace СкладскойУчет
{
    partial class ОкноВыбораАдреса
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
            this.Далее = new System.Windows.Forms.Button();
            this.Назад = new System.Windows.Forms.Button();
            this.ПрефиксАдреса = new System.Windows.Forms.Label();
            this.ВводАдреса = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Инструкция
            // 
            this.Инструкция.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular);
            this.Инструкция.Location = new System.Drawing.Point(3, 13);
            this.Инструкция.Name = "Инструкция";
            this.Инструкция.Size = new System.Drawing.Size(232, 110);
            this.Инструкция.Tag = "Инструкция";
            this.Инструкция.Text = "Сосканируйте адрес, с которого нужно переместить товар";
            // 
            // Далее
            // 
            this.Далее.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.Далее.Location = new System.Drawing.Point(133, 294);
            this.Далее.Name = "Далее";
            this.Далее.Size = new System.Drawing.Size(105, 22);
            this.Далее.TabIndex = 7;
            this.Далее.Text = "Далее";
            this.Далее.Click += new System.EventHandler(this.Далее_Click);
            // 
            // Назад
            // 
            this.Назад.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.Назад.Location = new System.Drawing.Point(2, 294);
            this.Назад.Name = "Назад";
            this.Назад.Size = new System.Drawing.Size(105, 22);
            this.Назад.TabIndex = 6;
            this.Назад.Text = "Назад";
            this.Назад.Click += new System.EventHandler(this.Назад_Click);
            // 
            // ПрефиксАдреса
            // 
            this.ПрефиксАдреса.BackColor = System.Drawing.Color.White;
            this.ПрефиксАдреса.Location = new System.Drawing.Point(15, 169);
            this.ПрефиксАдреса.Name = "ПрефиксАдреса";
            this.ПрефиксАдреса.Size = new System.Drawing.Size(29, 23);
            this.ПрефиксАдреса.Text = "adr";
            this.ПрефиксАдреса.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.ПрефиксАдреса.Visible = false;
            // 
            // ВводАдреса
            // 
            this.ВводАдреса.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ВводАдреса.Location = new System.Drawing.Point(44, 169);
            this.ВводАдреса.MaxLength = 10;
            this.ВводАдреса.Name = "ВводАдреса";
            this.ВводАдреса.Size = new System.Drawing.Size(156, 23);
            this.ВводАдреса.TabIndex = 11;
            this.ВводАдреса.WordWrap = false;
            this.ВводАдреса.TextChanged += new System.EventHandler(this.ВводАдреса_TextChanged);
            this.ВводАдреса.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ВводАдреса_KeyPress);
            // 
            // ОкноВыбораАдреса
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(240, 320);
            this.ControlBox = false;
            this.Controls.Add(this.ВводАдреса);
            this.Controls.Add(this.ПрефиксАдреса);
            this.Controls.Add(this.Далее);
            this.Controls.Add(this.Назад);
            this.Controls.Add(this.Инструкция);
            this.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.Name = "ОкноВыбораАдреса";
            this.Text = "Выбор динамической ячейки подбора";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.ОкноВыбораАдреса_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ОкноВыбораАдреса_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label Инструкция;
        private System.Windows.Forms.Button Далее;
        private System.Windows.Forms.Button Назад;
        private System.Windows.Forms.Label ПрефиксАдреса;
        private System.Windows.Forms.TextBox ВводАдреса;

    }
}