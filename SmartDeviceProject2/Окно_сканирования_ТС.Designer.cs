namespace СкладскойУчет
{
    partial class Окно_сканирования_ТС
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
            this.Инструкция = new System.Windows.Forms.Label();
            this.Назад = new System.Windows.Forms.Button();
            this.Пользователь = new System.Windows.Forms.Label();
            this.СписокВыбора = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // Инструкция
            // 
            this.Инструкция.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular);
            this.Инструкция.Location = new System.Drawing.Point(4, 4);
            this.Инструкция.Name = "Инструкция";
            this.Инструкция.Size = new System.Drawing.Size(233, 166);
            this.Инструкция.Tag = "Инструкция";
            this.Инструкция.Text = "Необходимо сканировать динамическую ячейку для начала выполнения задания на подбо" +
                "р филиала";
            // 
            // Назад
            // 
            this.Назад.Location = new System.Drawing.Point(41, 281);
            this.Назад.Name = "Назад";
            this.Назад.Size = new System.Drawing.Size(156, 24);
            this.Назад.TabIndex = 1;
            this.Назад.Text = "0.Назад";
            this.Назад.Click += new System.EventHandler(this.Назад_Click);
            // 
            // Пользователь
            // 
            this.Пользователь.BackColor = System.Drawing.SystemColors.Info;
            this.Пользователь.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.Пользователь.Location = new System.Drawing.Point(0, 308);
            this.Пользователь.Name = "Пользователь";
            this.Пользователь.Size = new System.Drawing.Size(240, 12);
            // 
            // СписокВыбора
            // 
            this.СписокВыбора.BackColor = System.Drawing.SystemColors.Info;
            this.СписокВыбора.Enabled = false;
            this.СписокВыбора.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.СписокВыбора.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.СписокВыбора.Location = new System.Drawing.Point(0, 172);
            this.СписокВыбора.Name = "СписокВыбора";
            this.СписокВыбора.Size = new System.Drawing.Size(240, 108);
            this.СписокВыбора.TabIndex = 3;
            this.СписокВыбора.Tag = "Таблица";
            this.СписокВыбора.View = System.Windows.Forms.View.Details;
            this.СписокВыбора.Visible = false;
            // 
            // Окно_сканирования_ТС
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(240, 320);
            this.ControlBox = false;
            this.Controls.Add(this.СписокВыбора);
            this.Controls.Add(this.Пользователь);
            this.Controls.Add(this.Назад);
            this.Controls.Add(this.Инструкция);
            this.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.Name = "Окно_сканирования_ТС";
            this.Text = "Выбор динамической ячейки подбора";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Окно_сканирования_ТС_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Окно_сканирования_ТС_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label Инструкция;
        private System.Windows.Forms.Button Назад;
        private System.Windows.Forms.Label Пользователь;
        private System.Windows.Forms.ListView СписокВыбора;

    }
}