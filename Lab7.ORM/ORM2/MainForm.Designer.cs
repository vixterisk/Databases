﻿namespace ORM2
{
    partial class MainForm
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgvCaseFormFactor = new System.Windows.Forms.DataGridView();
            this.dgvCaseInformation = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCaseFormFactor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCaseInformation)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvCaseFormFactor);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvCaseInformation);
            this.splitContainer1.Size = new System.Drawing.Size(585, 450);
            this.splitContainer1.SplitterDistance = 208;
            this.splitContainer1.TabIndex = 0;
            // 
            // dgvCaseFormFactor
            // 
            this.dgvCaseFormFactor.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCaseFormFactor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCaseFormFactor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCaseFormFactor.Location = new System.Drawing.Point(0, 0);
            this.dgvCaseFormFactor.Name = "dgvCaseFormFactor";
            this.dgvCaseFormFactor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCaseFormFactor.Size = new System.Drawing.Size(585, 208);
            this.dgvCaseFormFactor.TabIndex = 0;
            this.dgvCaseFormFactor.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCaseFormFactor_CellValueChanged);
            this.dgvCaseFormFactor.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvCaseFormFactor_RowValidating);
            this.dgvCaseFormFactor.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvCaseFormFactor_UserDeletingRow);
            this.dgvCaseFormFactor.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.dgvCaseFormFactor_PreviewKeyDown);
            // 
            // dgvCaseInformation
            // 
            this.dgvCaseInformation.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCaseInformation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCaseInformation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCaseInformation.Location = new System.Drawing.Point(0, 0);
            this.dgvCaseInformation.Name = "dgvCaseInformation";
            this.dgvCaseInformation.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCaseInformation.Size = new System.Drawing.Size(585, 238);
            this.dgvCaseInformation.TabIndex = 1;
            this.dgvCaseInformation.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCaseInformation_CellValueChanged);
            this.dgvCaseInformation.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvCaseInformation_RowValidating);
            this.dgvCaseInformation.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvCaseInformation_UserDeletingRow);
            this.dgvCaseInformation.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.dgvCaseInformation_PreviewKeyDown);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 450);
            this.Controls.Add(this.splitContainer1);
            this.Name = "MainForm";
            this.Text = "Корпусы";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCaseFormFactor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCaseInformation)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgvCaseFormFactor;
        private System.Windows.Forms.DataGridView dgvCaseInformation;
    }
}

