namespace СкладскойУчет
{
    partial class ОкноСканированияДЯ
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
            this.Таб = new System.Windows.Forms.TabControl();
            this.Сканирование = new System.Windows.Forms.TabPage();
            this.Поиск = new System.Windows.Forms.TabPage();
            this.СписокИнформации = new System.Windows.Forms.TextBox();
            this.Пользователь = new System.Windows.Forms.Label();
            this.Таб.SuspendLayout();
            this.Сканирование.SuspendLayout();
            this.Поиск.SuspendLayout();
            this.SuspendLayout();
            // 
            // Инструкция
            // 
            this.Инструкция.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular);
            this.Инструкция.Location = new System.Drawing.Point(0, 0);
            this.Инструкция.Name = "Инструкция";
            this.Инструкция.Size = new System.Drawing.Size(232, 166);
            this.Инструкция.Tag = "Инструкция";
            this.Инструкция.Text = "Необходимо сканировать динамическую ячейку для начала выполнения задания на подбо" +
                "р филиала";
            // 
            // Назад
            // 
            this.Назад.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.Назад.Location = new System.Drawing.Point(60, 256);
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
            this.СписокВыбора.Location = new System.Drawing.Point(0, 149);
            this.СписокВыбора.Name = "СписокВыбора";
            this.СписокВыбора.Size = new System.Drawing.Size(229, 108);
            this.СписокВыбора.TabIndex = 3;
            this.СписокВыбора.Tag = "Таблица";
            this.СписокВыбора.View = System.Windows.Forms.View.Details;
            this.СписокВыбора.Visible = false;
            // 
            // Таб
            // 
            this.Таб.Controls.Add(this.Сканирование);
            this.Таб.Controls.Add(this.Поиск);
            this.Таб.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.Таб.Location = new System.Drawing.Point(2, 2);
            this.Таб.Name = "Таб";
            this.Таб.SelectedIndex = 0;
            this.Таб.Size = new System.Drawing.Size(238, 304);
            this.Таб.TabIndex = 6;
            // 
            // Сканирование
            // 
            this.Сканирование.BackColor = System.Drawing.SystemColors.Info;
            this.Сканирование.Controls.Add(this.СписокВыбора);
            this.Сканирование.Controls.Add(this.Инструкция);
            this.Сканирование.Controls.Add(this.Назад);
            this.Сканирование.Location = new System.Drawing.Point(4, 22);
            this.Сканирование.Name = "Сканирование";
            this.Сканирование.Size = new System.Drawing.Size(230, 278);
            this.Сканирование.Text = "1.Сканирование";
            // 
            // Поиск
            // 
            this.Поиск.Controls.Add(this.СписокИнформации);
            this.Поиск.Location = new System.Drawing.Point(4, 22);
            this.Поиск.Name = "Поиск";
            this.Поиск.Size = new System.Drawing.Size(230, 278);
            this.Поиск.Text = "2.Поиск>";
            // 
            // СписокИнформации
            // 
            this.СписокИнформации.AcceptsReturn = true;
            this.СписокИнформации.BackColor = System.Drawing.SystemColors.HighlightText;
            this.СписокИнформации.ForeColor = System.Drawing.SystemColors.InfoText;
            this.СписокИнформации.Location = new System.Drawing.Point(0, 0);
            this.СписокИнформации.Multiline = true;
            this.СписокИнформации.Name = "СписокИнформации";
            this.СписокИнформации.ReadOnly = true;
            this.СписокИнформации.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.СписокИнформации.Size = new System.Drawing.Size(230, 276);
            this.СписокИнформации.TabIndex = 1;
            this.СписокИнформации.Text = "Сканируйте ШК для получения информации";
            // 
            // Пользователь
            // 
            this.Пользователь.BackColor = System.Drawing.SystemColors.Info;
            this.Пользователь.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.Пользователь.Location = new System.Drawing.Point(3, 305);
            this.Пользователь.Name = "Пользователь";
            this.Пользователь.Size = new System.Drawing.Size(240, 12);
            this.Пользователь.Text = "Пользователь";
            // 
            // ОкноСканированияДЯ
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(240, 320);
            this.ControlBox = false;
            this.Controls.Add(this.Таб);
            this.Controls.Add(this.Пользователь);
            this.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.Name = "ОкноСканированияДЯ";
            this.Text = "Выбор динамической ячейки подбора";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.ОкноСканированияДЯ_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ОкноСканированияДЯ_KeyDown);
            this.Таб.ResumeLayout(false);
            this.Сканирование.ResumeLayout(false);
            this.Поиск.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Label Инструкция;
        private System.Windows.Forms.Button Назад;
        public System.Windows.Forms.ListView СписокВыбора;
        public System.Windows.Forms.TabControl Таб;
        private System.Windows.Forms.TabPage Сканирование;
        private System.Windows.Forms.TabPage Поиск;
        public System.Windows.Forms.TextBox СписокИнформации;
        private System.Windows.Forms.Label Пользователь;

    }
}