﻿
namespace WinFormsExample
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSin = new System.Windows.Forms.Button();
            this.brnClear = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.btnTree = new System.Windows.Forms.Button();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSin
            // 
            this.btnSin.Location = new System.Drawing.Point(112, 45);
            this.btnSin.Name = "btnSin";
            this.btnSin.Size = new System.Drawing.Size(94, 29);
            this.btnSin.TabIndex = 0;
            this.btnSin.Text = "SIN(X)";
            this.btnSin.UseVisualStyleBackColor = true;
            this.btnSin.Click += new System.EventHandler(this.btnSin_Click);
            // 
            // brnClear
            // 
            this.brnClear.Location = new System.Drawing.Point(12, 78);
            this.brnClear.Name = "brnClear";
            this.brnClear.Size = new System.Drawing.Size(94, 29);
            this.brnClear.TabIndex = 2;
            this.brnClear.Text = "Clear";
            this.brnClear.UseVisualStyleBackColor = true;
            this.brnClear.Click += new System.EventHandler(this.brnClear_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown1.Location = new System.Drawing.Point(12, 45);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(94, 27);
            this.numericUpDown1.TabIndex = 3;
            this.numericUpDown1.Value = new decimal(new int[] {
            130,
            0,
            0,
            0});
            // 
            // btnTree
            // 
            this.btnTree.Location = new System.Drawing.Point(112, 10);
            this.btnTree.Name = "btnTree";
            this.btnTree.Size = new System.Drawing.Size(94, 29);
            this.btnTree.TabIndex = 4;
            this.btnTree.Text = "Tree";
            this.btnTree.UseVisualStyleBackColor = true;
            this.btnTree.Click += new System.EventHandler(this.btnTree_Click);
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(12, 12);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(94, 27);
            this.numericUpDown2.TabIndex = 5;
            this.numericUpDown2.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.numericUpDown2);
            this.Controls.Add(this.btnTree);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.brnClear);
            this.Controls.Add(this.btnSin);
            this.Name = "Form1";
            this.Text = "Playground";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSin;
        private System.Windows.Forms.Button brnClear;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button btnTree;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
    }
}

