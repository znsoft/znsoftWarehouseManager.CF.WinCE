namespace СкладскойУчет
{
    partial class Окно_скан_из_дерева
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
            this.Инструкция = new System.Windows.Forms.Label();
            this.Дерево = new System.Windows.Forms.TreeView();
            this.Таб = new System.Windows.Forms.TabControl();
            this.Подбор = new System.Windows.Forms.TabPage();
            this.Поиск = new System.Windows.Forms.TabPage();
            this.Таб.SuspendLayout();
            this.Подбор.SuspendLayout();
            this.SuspendLayout();
            // 
            // Пользователь
            // 
            this.Пользователь.BackColor = System.Drawing.SystemColors.Info;
            this.Пользователь.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.Пользователь.Location = new System.Drawing.Point(4, 305);
            this.Пользователь.Name = "Пользователь";
            this.Пользователь.Size = new System.Drawing.Size(229, 12);
            // 
            // Инструкция
            // 
            this.Инструкция.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.Инструкция.Location = new System.Drawing.Point(3, 0);
            this.Инструкция.Name = "Инструкция";
            this.Инструкция.Size = new System.Drawing.Size(230, 9);
            this.Инструкция.Tag = "Инструкция";
            // 
            // Дерево
            // 
            this.Дерево.Location = new System.Drawing.Point(0, 0);
            this.Дерево.Name = "Дерево";
            this.Дерево.Size = new System.Drawing.Size(222, 258);
            this.Дерево.TabIndex = 2;
            // 
            // Таб
            // 
            this.Таб.Controls.Add(this.Подбор);
            this.Таб.Controls.Add(this.Поиск);
            this.Таб.Location = new System.Drawing.Point(3, 12);
            this.Таб.Name = "Таб";
            this.Таб.SelectedIndex = 0;
            this.Таб.Size = new System.Drawing.Size(230, 290);
            this.Таб.TabIndex = 5;
            // 
            // Подбор
            // 
            this.Подбор.BackColor = System.Drawing.SystemColors.Info;
            this.Подбор.Controls.Add(this.Дерево);
            this.Подбор.Location = new System.Drawing.Point(4, 25);
            this.Подбор.Name = "Подбор";
            this.Подбор.Size = new System.Drawing.Size(222, 261);
            this.Подбор.Text = "Подбор";
            // 
            // Поиск
            // 
            this.Поиск.Location = new System.Drawing.Point(4, 25);
            this.Поиск.Name = "Поиск";
            this.Поиск.Size = new System.Drawing.Size(222, 261);
            this.Поиск.Text = "Поиск";
            this.Поиск.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // Окно_скан_из_дерева
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(240, 320);
            this.ControlBox = false;
            this.Controls.Add(this.Таб);
            this.Controls.Add(this.Инструкция);
            this.Controls.Add(this.Пользователь);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.Name = "Окно_скан_из_дерева";
            this.Text = "Выбор";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Окно_выбора_из_списка_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Окно_выбора_из_списка_KeyDown);
            this.Таб.ResumeLayout(false);
            this.Подбор.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label Пользователь;
        private System.Windows.Forms.Label Инструкция;
        private System.Windows.Forms.TreeView Дерево;
        private System.Windows.Forms.TabControl Таб;
        private System.Windows.Forms.TabPage Подбор;
        private System.Windows.Forms.TabPage Поиск;
    }
}