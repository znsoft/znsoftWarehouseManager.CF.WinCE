namespace СкладскойУчет
{
    partial class Окно_выбора_из_дерева
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
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Узел0");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Узел1");
            this.Пользователь = new System.Windows.Forms.Label();
            this.Инструкция = new System.Windows.Forms.Label();
            this.Дерево = new System.Windows.Forms.TreeView();
            this.Далее = new System.Windows.Forms.Button();
            this.Назад = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Пользователь
            // 
            this.Пользователь.BackColor = System.Drawing.SystemColors.Info;
            this.Пользователь.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.Пользователь.Location = new System.Drawing.Point(0, 305);
            this.Пользователь.Name = "Пользователь";
            this.Пользователь.Size = new System.Drawing.Size(97, 15);
            this.Пользователь.Text = "_";
            this.Пользователь.ParentChanged += new System.EventHandler(this.Пользователь_ParentChanged);
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
            // Дерево
            // 
            this.Дерево.Location = new System.Drawing.Point(3, 12);
            this.Дерево.Name = "Дерево";
            treeNode8.Text = "Узел1";
            treeNode7.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode8});
            treeNode7.Text = "Узел0";
            this.Дерево.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode7});
            this.Дерево.Size = new System.Drawing.Size(237, 266);
            this.Дерево.TabIndex = 2;
            // 
            // Далее
            // 
            this.Далее.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.Далее.Location = new System.Drawing.Point(137, 280);
            this.Далее.Name = "Далее";
            this.Далее.Size = new System.Drawing.Size(100, 22);
            this.Далее.TabIndex = 6;
            this.Далее.Text = "&1. Далее";
            this.Далее.Click += new System.EventHandler(this.Далее_Click);
            // 
            // Назад
            // 
            this.Назад.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.Назад.Location = new System.Drawing.Point(3, 280);
            this.Назад.Name = "Назад";
            this.Назад.Size = new System.Drawing.Size(100, 22);
            this.Назад.TabIndex = 5;
            this.Назад.Text = "&0. Назад";
            this.Назад.Click += new System.EventHandler(this.Назад_Click);
            // 
            // Окно_выбора_из_дерева
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(240, 320);
            this.ControlBox = false;
            this.Controls.Add(this.Далее);
            this.Controls.Add(this.Назад);
            this.Controls.Add(this.Дерево);
            this.Controls.Add(this.Инструкция);
            this.Controls.Add(this.Пользователь);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.Name = "Окно_выбора_из_дерева";
            this.Text = "Выбор";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Окно_выбора_из_списка_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Окно_выбора_из_списка_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label Пользователь;
        private System.Windows.Forms.Label Инструкция;
        private System.Windows.Forms.TreeView Дерево;
        private System.Windows.Forms.Button Далее;
        private System.Windows.Forms.Button Назад;
    }
}