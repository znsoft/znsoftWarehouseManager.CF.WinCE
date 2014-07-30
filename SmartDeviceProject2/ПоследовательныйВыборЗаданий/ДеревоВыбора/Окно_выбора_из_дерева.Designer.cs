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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Узел0");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Узел1");
            this.Пользователь = new System.Windows.Forms.Label();
            this.Инструкция = new System.Windows.Forms.Label();
            this.Дерево = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // Пользователь
            // 
            this.Пользователь.BackColor = System.Drawing.SystemColors.Info;
            this.Пользователь.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.Пользователь.Location = new System.Drawing.Point(3, 281);
            this.Пользователь.Name = "Пользователь";
            this.Пользователь.Size = new System.Drawing.Size(97, 15);
            this.Пользователь.Text = "_";
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
            treeNode2.Text = "Узел1";
            treeNode1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2});
            treeNode1.Text = "Узел0";
            this.Дерево.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.Дерево.Size = new System.Drawing.Size(237, 266);
            this.Дерево.TabIndex = 2;
            // 
            // Окно_выбора_из_дерева
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(240, 320);
            this.ControlBox = false;
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
    }
}