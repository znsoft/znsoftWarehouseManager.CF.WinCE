namespace СкладскойУчет
{
    partial class ОкноСканированияАдреса
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
            this.Назад = new System.Windows.Forms.Button();
            this.СписокВыбора = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // Инструкция
            // 
            this.Инструкция.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular);
            this.Инструкция.Location = new System.Drawing.Point(3, 13);
            this.Инструкция.Name = "Инструкция";
            this.Инструкция.Size = new System.Drawing.Size(232, 178);
            this.Инструкция.Tag = "Инструкция";
            this.Инструкция.Text = "Необходимо сканировать адрес или ячейку для перемещения товара";
            // 
            // Назад
            // 
            this.Назад.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.Назад.Location = new System.Drawing.Point(131, 298);
            this.Назад.Name = "Назад";
            this.Назад.Size = new System.Drawing.Size(100, 22);
            this.Назад.TabIndex = 1;
            this.Назад.Text = "&0. Назад";
            this.Назад.Click += new System.EventHandler(this.Назад_Click);
            // 
            // СписокВыбора
            // 
            this.СписокВыбора.BackColor = System.Drawing.SystemColors.Info;
            this.СписокВыбора.Enabled = false;
            this.СписокВыбора.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.СписокВыбора.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.СписокВыбора.Location = new System.Drawing.Point(3, 189);
            this.СписокВыбора.Name = "СписокВыбора";
            this.СписокВыбора.Size = new System.Drawing.Size(229, 108);
            this.СписокВыбора.TabIndex = 3;
            this.СписокВыбора.Tag = "Таблица";
            this.СписокВыбора.View = System.Windows.Forms.View.Details;
            this.СписокВыбора.Visible = false;
            // 
            // ОкноСканированияАдреса
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(240, 320);
            this.ControlBox = false;
            this.Controls.Add(this.Назад);
            this.Controls.Add(this.СписокВыбора);
            this.Controls.Add(this.Инструкция);
            this.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.Name = "ОкноСканированияАдреса";
            this.Text = "Выбор динамической ячейки подбора";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.ОкноСканированияАдреса_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ОкноСканированияАдреса_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label Инструкция;
        private System.Windows.Forms.Button Назад;
        private System.Windows.Forms.ListView СписокВыбора;

    }
}