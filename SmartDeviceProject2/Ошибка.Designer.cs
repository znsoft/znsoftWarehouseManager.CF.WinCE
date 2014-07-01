namespace СкладскойУчет
{
    partial class Ошибка
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
            this.Выход = new System.Windows.Forms.Button();
            this.ТекстОшибки = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Выход
            // 
            this.Выход.Location = new System.Drawing.Point(48, 201);
            this.Выход.Name = "Выход";
            this.Выход.Size = new System.Drawing.Size(140, 63);
            this.Выход.TabIndex = 0;
            this.Выход.Text = "0.Выход";
            this.Выход.Click += new System.EventHandler(this.Выход_Click);
            // 
            // ТекстОшибки
            // 
            this.ТекстОшибки.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular);
            this.ТекстОшибки.Location = new System.Drawing.Point(0, 15);
            this.ТекстОшибки.Multiline = true;
            this.ТекстОшибки.Name = "ТекстОшибки";
            this.ТекстОшибки.ReadOnly = true;
            this.ТекстОшибки.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.ТекстОшибки.Size = new System.Drawing.Size(239, 180);
            this.ТекстОшибки.TabIndex = 1;
            // 
            // Ошибка
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.Controls.Add(this.ТекстОшибки);
            this.Controls.Add(this.Выход);
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.Name = "Ошибка";
            this.Text = "Ошибка";
            this.TopMost = true;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Ошибка_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Выход;
        private System.Windows.Forms.TextBox ТекстОшибки;
    }
}