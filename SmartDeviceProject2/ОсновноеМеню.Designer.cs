namespace СкладскойУчет
{
    partial class ОсновноеМеню
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
            this.Пользователь = new System.Windows.Forms.Label();
            this.Выход = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Пользователь
            // 
            this.Пользователь.Location = new System.Drawing.Point(0, 254);
            this.Пользователь.Name = "Пользователь";
            this.Пользователь.Size = new System.Drawing.Size(240, 20);
            // 
            // Выход
            // 
            this.Выход.Location = new System.Drawing.Point(4, 216);
            this.Выход.Name = "Выход";
            this.Выход.Size = new System.Drawing.Size(233, 35);
            this.Выход.TabIndex = 3;
            this.Выход.Text = "Выход";
            this.Выход.Click += new System.EventHandler(this.Выход_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(4, 169);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(233, 41);
            this.button1.TabIndex = 5;
            this.button1.Text = "button1";
            // 
            // ОсновноеМеню
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.ControlBox = false;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Выход);
            this.Controls.Add(this.Пользователь);
            this.Name = "ОсновноеМеню";
            this.Text = "Основное меню";
            this.Load += new System.EventHandler(this.ОсновноеМеню_Load);
            this.Closed += new System.EventHandler(this.ОсновноеМеню_Closed);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.ОсновноеМеню_Closing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ОсновноеМеню_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label Пользователь;
        private System.Windows.Forms.Button Выход;
        private System.Windows.Forms.Button button1;
    }
}