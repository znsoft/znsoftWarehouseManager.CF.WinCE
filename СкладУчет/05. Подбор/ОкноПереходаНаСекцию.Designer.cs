namespace СкладскойУчет
{
    partial class ОкноПереходаНаСекцию
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
            this.НадписьСекция = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Инструкция
            // 
            this.Инструкция.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold);
            this.Инструкция.Location = new System.Drawing.Point(6, 5);
            this.Инструкция.Name = "Инструкция";
            this.Инструкция.Size = new System.Drawing.Size(228, 97);
            this.Инструкция.Text = "Перейти на следующую секцию?";
            this.Инструкция.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Далее
            // 
            this.Далее.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Bold);
            this.Далее.Location = new System.Drawing.Point(6, 155);
            this.Далее.Name = "Далее";
            this.Далее.Size = new System.Drawing.Size(228, 70);
            this.Далее.TabIndex = 8;
            this.Далее.Text = "&1. Да";
            this.Далее.Click += new System.EventHandler(this.Да_Click);
            // 
            // Назад
            // 
            this.Назад.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Bold);
            this.Назад.Location = new System.Drawing.Point(6, 237);
            this.Назад.Name = "Назад";
            this.Назад.Size = new System.Drawing.Size(228, 70);
            this.Назад.TabIndex = 6;
            this.Назад.Text = "&0. Нет";
            this.Назад.Click += new System.EventHandler(this.Нет_Click);
            // 
            // НадписьСекция
            // 
            this.НадписьСекция.Font = new System.Drawing.Font("Arial", 28F, System.Drawing.FontStyle.Bold);
            this.НадписьСекция.Location = new System.Drawing.Point(6, 104);
            this.НадписьСекция.Name = "НадписьСекция";
            this.НадписьСекция.Size = new System.Drawing.Size(228, 39);
            this.НадписьСекция.Text = "А01-01";
            this.НадписьСекция.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ОкноПереходаНаСекцию
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(240, 320);
            this.ControlBox = false;
            this.Controls.Add(this.НадписьСекция);
            this.Controls.Add(this.Инструкция);
            this.Controls.Add(this.Далее);
            this.Controls.Add(this.Назад);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.Name = "ОкноПереходаНаСекцию";
            this.Text = "Выбор заданий";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.ОкноПереходаНаСекцию_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ОкноПереходаНаСекцию_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Далее;
        private System.Windows.Forms.Button Назад;
        private System.Windows.Forms.Label Инструкция;
        private System.Windows.Forms.Label НадписьСекция;

    }
}