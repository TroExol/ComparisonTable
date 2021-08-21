namespace ComparisonTable
{
    partial class Form1
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.comparisonTable = new System.Windows.Forms.DataGridView();
            this.siteFromCB = new System.Windows.Forms.ComboBox();
            this.siteToCB = new System.Windows.Forms.ComboBox();
            this.loadTable = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.minCountHaveSiteFrom = new System.Windows.Forms.TextBox();
            this.minCountHaveSiteTo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.isNotOvestockFrom = new System.Windows.Forms.CheckBox();
            this.isNotOvestockTo = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.reverseSites = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize) (this.comparisonTable)).BeginInit();
            this.SuspendLayout();
            // 
            // comparisonTable
            // 
            this.comparisonTable.AllowUserToAddRows = false;
            this.comparisonTable.AllowUserToDeleteRows = false;
            this.comparisonTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.comparisonTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.comparisonTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.comparisonTable.DefaultCellStyle = dataGridViewCellStyle2;
            this.comparisonTable.Location = new System.Drawing.Point(12, 153);
            this.comparisonTable.Name = "comparisonTable";
            this.comparisonTable.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.comparisonTable.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.comparisonTable.RowHeadersVisible = false;
            this.comparisonTable.RowTemplate.Height = 24;
            this.comparisonTable.Size = new System.Drawing.Size(887, 397);
            this.comparisonTable.TabIndex = 0;
            // 
            // siteFromCB
            // 
            this.siteFromCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.siteFromCB.FormattingEnabled = true;
            this.siteFromCB.Location = new System.Drawing.Point(25, 49);
            this.siteFromCB.Name = "siteFromCB";
            this.siteFromCB.Size = new System.Drawing.Size(207, 24);
            this.siteFromCB.TabIndex = 1;
            // 
            // siteToCB
            // 
            this.siteToCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.siteToCB.FormattingEnabled = true;
            this.siteToCB.Location = new System.Drawing.Point(281, 49);
            this.siteToCB.Name = "siteToCB";
            this.siteToCB.Size = new System.Drawing.Size(207, 24);
            this.siteToCB.TabIndex = 2;
            // 
            // loadTable
            // 
            this.loadTable.Location = new System.Drawing.Point(513, 37);
            this.loadTable.Name = "loadTable";
            this.loadTable.Size = new System.Drawing.Size(134, 46);
            this.loadTable.TabIndex = 3;
            this.loadTable.Text = "Загрузить";
            this.loadTable.UseVisualStyleBackColor = true;
            this.loadTable.Click += new System.EventHandler(this.loadTable_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(25, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "На боте от";
            // 
            // minCountHaveSiteFrom
            // 
            this.minCountHaveSiteFrom.Location = new System.Drawing.Point(112, 89);
            this.minCountHaveSiteFrom.Name = "minCountHaveSiteFrom";
            this.minCountHaveSiteFrom.Size = new System.Drawing.Size(82, 22);
            this.minCountHaveSiteFrom.TabIndex = 5;
            // 
            // minCountHaveSiteTo
            // 
            this.minCountHaveSiteTo.Location = new System.Drawing.Point(368, 86);
            this.minCountHaveSiteTo.Name = "minCountHaveSiteTo";
            this.minCountHaveSiteTo.Size = new System.Drawing.Size(82, 22);
            this.minCountHaveSiteTo.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(281, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "На боте от";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(24, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Без оверстока?";
            // 
            // isNotOvestockFrom
            // 
            this.isNotOvestockFrom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.isNotOvestockFrom.Location = new System.Drawing.Point(151, 117);
            this.isNotOvestockFrom.Name = "isNotOvestockFrom";
            this.isNotOvestockFrom.Size = new System.Drawing.Size(17, 14);
            this.isNotOvestockFrom.TabIndex = 9;
            this.isNotOvestockFrom.Text = "checkBox1";
            this.isNotOvestockFrom.UseVisualStyleBackColor = true;
            // 
            // isNotOvestockTo
            // 
            this.isNotOvestockTo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.isNotOvestockTo.Location = new System.Drawing.Point(408, 117);
            this.isNotOvestockTo.Name = "isNotOvestockTo";
            this.isNotOvestockTo.Size = new System.Drawing.Size(17, 14);
            this.isNotOvestockTo.TabIndex = 11;
            this.isNotOvestockTo.Text = "checkBox1";
            this.isNotOvestockTo.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(281, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "Без оверстока?";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(25, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 20);
            this.label5.TabIndex = 12;
            this.label5.Text = "Откуда";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(281, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 20);
            this.label6.TabIndex = 13;
            this.label6.Text = "Куда";
            // 
            // reverseSites
            // 
            this.reverseSites.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.reverseSites.Location = new System.Drawing.Point(238, 49);
            this.reverseSites.Name = "reverseSites";
            this.reverseSites.Size = new System.Drawing.Size(37, 24);
            this.reverseSites.TabIndex = 14;
            this.reverseSites.Text = "<>";
            this.reverseSites.UseVisualStyleBackColor = true;
            this.reverseSites.Click += new System.EventHandler(this.reverseSites_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(911, 562);
            this.Controls.Add(this.reverseSites);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.isNotOvestockTo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.isNotOvestockFrom);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.minCountHaveSiteTo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.minCountHaveSiteFrom);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.loadTable);
            this.Controls.Add(this.siteToCB);
            this.Controls.Add(this.siteFromCB);
            this.Controls.Add(this.comparisonTable);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Таблица сравнения";
            ((System.ComponentModel.ISupportInitialize) (this.comparisonTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button reverseSites;

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;

        private System.Windows.Forms.CheckBox isNotOvestockFrom;
        private System.Windows.Forms.CheckBox isNotOvestockTo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox minCountHaveSiteFrom;
        private System.Windows.Forms.TextBox minCountHaveSiteTo;

        private System.Windows.Forms.Button loadTable;
        private System.Windows.Forms.ComboBox siteFromCB;
        private System.Windows.Forms.ComboBox siteToCB;

        private System.Windows.Forms.DataGridView comparisonTable;

        #endregion
    }
}