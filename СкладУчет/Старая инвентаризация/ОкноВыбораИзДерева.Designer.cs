namespace СкладскойУчет
{
    partial class ОкноВыбораИзДерева
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
            this.Пользователь = new System.Windows.Forms.Label();
            this.Инструкция = new System.Windows.Forms.Label();
            this.Далее = new System.Windows.Forms.Button();
            this.Назад = new System.Windows.Forms.Button();
            this.Дерево = new СкладскойУчет.РаботаСФормами.РасширенияЭлементов.TreeViewEx();
            this.SuspendLayout();
            // 
            // Пользователь
            // 
            this.Пользователь.BackColor = System.Drawing.SystemColors.Info;
            this.Пользователь.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.Пользователь.Location = new System.Drawing.Point(0, 304);
            this.Пользователь.Name = "Пользователь";
            this.Пользователь.Size = new System.Drawing.Size(240, 15);
            this.Пользователь.Text = "Пользователь";
            // 
            // Инструкция
            // 
            this.Инструкция.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.Инструкция.Location = new System.Drawing.Point(3, 0);
            this.Инструкция.Name = "Инструкция";
            this.Инструкция.Size = new System.Drawing.Size(230, 9);
            this.Инструкция.Tag = "Инструкция";
            this.Инструкция.Text = "_";
            // 
            // Далее
            // 
            this.Далее.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.Далее.Location = new System.Drawing.Point(132, 277);
            this.Далее.Name = "Далее";
            this.Далее.Size = new System.Drawing.Size(104, 22);
            this.Далее.TabIndex = 6;
            this.Далее.Text = "&1. Далее";
            this.Далее.Click += new System.EventHandler(this.Далее_Click);
            // 
            // Назад
            // 
            this.Назад.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.Назад.Location = new System.Drawing.Point(4, 277);
            this.Назад.Name = "Назад";
            this.Назад.Size = new System.Drawing.Size(104, 22);
            this.Назад.TabIndex = 5;
            this.Назад.Text = "&0. Назад";
            this.Назад.Click += new System.EventHandler(this.Назад_Click);
            // 
            // Дерево
            // 
            this.Дерево.Location = new System.Drawing.Point(4, 12);
            this.Дерево.Name = "Дерево";
            this.Дерево.Size = new System.Drawing.Size(232, 265);
            this.Дерево.TabIndex = 9;
            this.Дерево.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.Дерево_NodeMouseClick);
            // 
            // Окно_выбора_из_дерева
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(240, 320);
            this.ControlBox = false;
            this.Controls.Add(this.Дерево);
            this.Controls.Add(this.Далее);
            this.Controls.Add(this.Назад);
            this.Controls.Add(this.Инструкция);
            this.Controls.Add(this.Пользователь);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.Name = "Окно_выбора_из_дерева";
            this.Text = "Выбор";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.ОкноВыбораИзДерева_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ОкноВыбораИзДерева_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label Пользователь;
        private System.Windows.Forms.Label Инструкция;
        private System.Windows.Forms.Button Далее;
        private System.Windows.Forms.Button Назад;
        private СкладскойУчет.РаботаСФормами.РасширенияЭлементов.TreeViewEx Дерево;
    }
}