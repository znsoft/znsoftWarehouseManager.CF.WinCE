namespace СкладскойУчет
{
    partial class ОкноВыбораЗаданийНаИнвентаризацию
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
            this.Далее = new System.Windows.Forms.Button();
            this.Назад = new System.Windows.Forms.Button();
            this.СписокВыбора = new System.Windows.Forms.ListView();
            this.Отбор = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // Инструкция
            // 
            this.Инструкция.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.Инструкция.Location = new System.Drawing.Point(6, 7);
            this.Инструкция.Name = "Инструкция";
            this.Инструкция.Size = new System.Drawing.Size(228, 19);
            this.Инструкция.Text = "Инструкция";
            // 
            // Далее
            // 
            this.Далее.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.Далее.Location = new System.Drawing.Point(135, 283);
            this.Далее.Name = "Далее";
            this.Далее.Size = new System.Drawing.Size(100, 25);
            this.Далее.TabIndex = 8;
            this.Далее.Text = "Далее";
            this.Далее.Click += new System.EventHandler(this.Далее_Click);
            // 
            // Назад
            // 
            this.Назад.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.Назад.Location = new System.Drawing.Point(5, 283);
            this.Назад.Name = "Назад";
            this.Назад.Size = new System.Drawing.Size(100, 25);
            this.Назад.TabIndex = 6;
            this.Назад.Text = "Назад";
            this.Назад.Click += new System.EventHandler(this.Назад_Click);
            // 
            // СписокВыбора
            // 
            this.СписокВыбора.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            this.СписокВыбора.Columns.Add(this.Отбор);
            this.СписокВыбора.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Regular);
            this.СписокВыбора.FullRowSelect = true;
            this.СписокВыбора.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.СписокВыбора.Location = new System.Drawing.Point(5, 30);
            this.СписокВыбора.Name = "СписокВыбора";
            this.СписокВыбора.Size = new System.Drawing.Size(230, 254);
            this.СписокВыбора.TabIndex = 4;
            this.СписокВыбора.Tag = "Таблица";
            this.СписокВыбора.View = System.Windows.Forms.View.Details;
            this.СписокВыбора.ItemActivate += new System.EventHandler(this.СписокВыбора_ItemActivate);
            // 
            // Отбор
            // 
            this.Отбор.Text = "Отбор";
            this.Отбор.Width = 207;
            // 
            // ОкноВыбораЗаданийНаИнвентаризацию
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(240, 320);
            this.ControlBox = false;
            this.Controls.Add(this.Инструкция);
            this.Controls.Add(this.Далее);
            this.Controls.Add(this.Назад);
            this.Controls.Add(this.СписокВыбора);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.Name = "ОкноВыбораЗаданийНаИнвентаризацию";
            this.Text = "Выбор заданий";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.ОкноВыбораЗаданий_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ОкноВыбораЗаданий_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Далее;
        private System.Windows.Forms.Button Назад;
        public System.Windows.Forms.ListView СписокВыбора;
        private System.Windows.Forms.ColumnHeader Отбор;
        private System.Windows.Forms.Label Инструкция;

    }
}