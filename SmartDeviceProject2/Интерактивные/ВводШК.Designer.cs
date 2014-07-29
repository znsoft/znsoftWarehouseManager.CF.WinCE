namespace СкладскойУчет
{
    partial class ВводШК
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ВводШК));
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.РучнойШК = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // РучнойШК
            // 
            this.РучнойШК.Location = new System.Drawing.Point(0, 0);
            this.РучнойШК.MaxLength = 0;
            this.РучнойШК.Name = "РучнойШК";
            this.РучнойШК.Size = new System.Drawing.Size(159, 23);
            this.РучнойШК.TabIndex = 1;
            this.РучнойШК.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Количество_KeyDown);
            // 
            // ВводШК
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.Aquamarine;
            this.ClientSize = new System.Drawing.Size(159, 23);
            this.Controls.Add(this.РучнойШК);
            this.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ВводШК";
            this.Text = "Ручной Ввод ШК";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.ВводКоличества_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TextBox РучнойШК;
    }
}