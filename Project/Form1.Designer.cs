namespace Project
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
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
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.button_done = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_pic = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // button_done
            // 
            this.button_done.Location = new System.Drawing.Point(337, 233);
            this.button_done.Name = "button_done";
            this.button_done.Size = new System.Drawing.Size(75, 23);
            this.button_done.TabIndex = 5;
            this.button_done.Text = "Выбор";
            this.button_done.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(334, 147);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Выбор таблицы";
            // 
            // comboBox_pic
            // 
            this.comboBox_pic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_pic.FormattingEnabled = true;
            this.comboBox_pic.Items.AddRange(new object[] {
            "1. Клиент",
            "2. Машины",
            "3. Аренда"});
            this.comboBox_pic.Location = new System.Drawing.Point(320, 184);
            this.comboBox_pic.Name = "comboBox_pic";
            this.comboBox_pic.Size = new System.Drawing.Size(121, 21);
            this.comboBox_pic.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button_done);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox_pic);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_done;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_pic;
    }
}

