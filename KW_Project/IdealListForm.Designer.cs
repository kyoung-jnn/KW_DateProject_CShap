namespace KW_Project
{
    partial class IdealListForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dgvNameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvAgeCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvDptCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvDhatCol = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dgvDelCol = new System.Windows.Forms.DataGridViewButtonColumn();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvNameCol,
            this.dgvAgeCol,
            this.dgvDptCol,
            this.dgvDhatCol,
            this.dgvDelCol});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1.Location = new System.Drawing.Point(0, 81);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 4;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(569, 529);
            this.dataGridView1.TabIndex = 2;
            // 
            // dgvNameCol
            // 
            this.dgvNameCol.HeaderText = "이름";
            this.dgvNameCol.MinimumWidth = 6;
            this.dgvNameCol.Name = "dgvNameCol";
            this.dgvNameCol.ReadOnly = true;
            this.dgvNameCol.Width = 125;
            // 
            // dgvAgeCol
            // 
            this.dgvAgeCol.HeaderText = "나이";
            this.dgvAgeCol.MinimumWidth = 6;
            this.dgvAgeCol.Name = "dgvAgeCol";
            this.dgvAgeCol.ReadOnly = true;
            this.dgvAgeCol.Width = 60;
            // 
            // dgvDptCol
            // 
            this.dgvDptCol.HeaderText = "학과";
            this.dgvDptCol.MinimumWidth = 6;
            this.dgvDptCol.Name = "dgvDptCol";
            this.dgvDptCol.ReadOnly = true;
            this.dgvDptCol.Width = 130;
            // 
            // dgvDhatCol
            // 
            this.dgvDhatCol.HeaderText = "채팅";
            this.dgvDhatCol.MinimumWidth = 6;
            this.dgvDhatCol.Name = "dgvDhatCol";
            this.dgvDhatCol.ReadOnly = true;
            this.dgvDhatCol.Width = 40;
            // 
            // dgvDelCol
            // 
            this.dgvDelCol.HeaderText = "삭제";
            this.dgvDelCol.MinimumWidth = 6;
            this.dgvDelCol.Name = "dgvDelCol";
            this.dgvDelCol.ReadOnly = true;
            this.dgvDelCol.Width = 40;
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Margin = new System.Windows.Forms.Padding(0);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(569, 25);
            this.textBox1.TabIndex = 4;
            this.textBox1.Text = "이상형을 최대 10명까지 저장할 수 있습니다";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(281, 38);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(127, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "받은 채팅신청";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(434, 38);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(123, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "채팅 신청하기";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // IdealListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 610);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "IdealListForm";
            this.Text = "IdealList";
            this.Load += new System.EventHandler(this.IdealListForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvNameCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvAgeCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvDptCol;
        private System.Windows.Forms.DataGridViewButtonColumn dgvDhatCol;
        private System.Windows.Forms.DataGridViewButtonColumn dgvDelCol;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}