﻿namespace Circuits
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonAnd = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonOr = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonNot = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonCopy = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonInput = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonOutput = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonStartCompound = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonEndCompound = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonEvaluate = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonAnd,
            this.toolStripButtonOr,
            this.toolStripButtonNot,
            this.toolStripButtonInput,
            this.toolStripButtonOutput,
            this.toolStripButtonCopy,
            this.toolStripButtonStartCompound,
            this.toolStripButtonEndCompound,
            this.toolStripButtonEvaluate});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1008, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "Controls";
            // 
            // toolStripButtonAnd
            // 
            this.toolStripButtonAnd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonAnd.Image = global::Circuits.Properties.Resources.AndIcon;
            this.toolStripButtonAnd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAnd.Name = "toolStripButtonAnd";
            this.toolStripButtonAnd.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonAnd.ToolTipText = "Add a new \'AND\' gate";
            this.toolStripButtonAnd.Click += new System.EventHandler(this.toolStripButtonAnd_Click);
            // 
            // toolStripButtonOr
            // 
            this.toolStripButtonOr.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonOr.Image = global::Circuits.Properties.Resources.OrIcon;
            this.toolStripButtonOr.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonOr.Name = "toolStripButtonOr";
            this.toolStripButtonOr.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonOr.Text = "Add a new OR gate";
            this.toolStripButtonOr.ToolTipText = "Add a new \'OR\' gate";
            this.toolStripButtonOr.Click += new System.EventHandler(this.toolStripButtonOr_Click);
            // 
            // toolStripButtonNot
            // 
            this.toolStripButtonNot.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonNot.Image = global::Circuits.Properties.Resources.NotIcon;
            this.toolStripButtonNot.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonNot.Name = "toolStripButtonNot";
            this.toolStripButtonNot.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonNot.Text = "Add a new \'NOT\' gate";
            this.toolStripButtonNot.Click += new System.EventHandler(this.toolStripButtonNot_Click);
            // 
            // toolStripButtonCopy
            // 
            this.toolStripButtonCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonCopy.Image = global::Circuits.Properties.Resources.CopyIcon;
            this.toolStripButtonCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonCopy.Name = "toolStripButtonCopy";
            this.toolStripButtonCopy.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonCopy.Text = "toolStripButton3";
            this.toolStripButtonCopy.ToolTipText = "Duplicates the selected gate";
            this.toolStripButtonCopy.Click += new System.EventHandler(this.toolStripButtonCopy_Click);
            // 
            // toolStripButtonInput
            // 
            this.toolStripButtonInput.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonInput.Image = global::Circuits.Properties.Resources.InputIcon;
            this.toolStripButtonInput.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonInput.Name = "toolStripButtonInput";
            this.toolStripButtonInput.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonInput.Text = "toolStripButton4";
            this.toolStripButtonInput.ToolTipText = "Add an \'Input\' switch";
            this.toolStripButtonInput.Click += new System.EventHandler(this.toolStripButtonInput_Click);
            // 
            // toolStripButtonOutput
            // 
            this.toolStripButtonOutput.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonOutput.Image = global::Circuits.Properties.Resources.OutputIcon;
            this.toolStripButtonOutput.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonOutput.Name = "toolStripButtonOutput";
            this.toolStripButtonOutput.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonOutput.Text = "toolStripButton5";
            this.toolStripButtonOutput.ToolTipText = "Add an \'Output\' lamp";
            this.toolStripButtonOutput.Click += new System.EventHandler(this.toolStripButtonOutput_Click);
            // 
            // toolStripButtonStartCompound
            // 
            this.toolStripButtonStartCompound.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonStartCompound.Image = global::Circuits.Properties.Resources.StartCompoundIcon;
            this.toolStripButtonStartCompound.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonStartCompound.Name = "toolStripButtonStartCompound";
            this.toolStripButtonStartCompound.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonStartCompound.Text = "toolStripButton6";
            this.toolStripButtonStartCompound.ToolTipText = "Starts a compounded circuit";
            this.toolStripButtonStartCompound.Click += new System.EventHandler(this.toolStripButtonStartCompound_Click);
            // 
            // toolStripButtonEndCompound
            // 
            this.toolStripButtonEndCompound.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonEndCompound.Image = global::Circuits.Properties.Resources.EndCompoundIcon;
            this.toolStripButtonEndCompound.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonEndCompound.Name = "toolStripButtonEndCompound";
            this.toolStripButtonEndCompound.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonEndCompound.Text = "toolStripButton7";
            this.toolStripButtonEndCompound.ToolTipText = "Ends the compounded circuit";
            this.toolStripButtonEndCompound.Click += new System.EventHandler(this.toolStripButtonEndCompound_Click);
            // 
            // toolStripButtonEvaluate
            // 
            this.toolStripButtonEvaluate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonEvaluate.Image = global::Circuits.Properties.Resources.EvaluateIcon;
            this.toolStripButtonEvaluate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonEvaluate.Name = "toolStripButtonEvaluate";
            this.toolStripButtonEvaluate.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonEvaluate.Text = "toolStripButton8";
            this.toolStripButtonEvaluate.ToolTipText = "Evaluates the circuit";
            this.toolStripButtonEvaluate.Click += new System.EventHandler(this.toolStripButtonEvaluate_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Circuits 2023";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonAnd;
        private System.Windows.Forms.ToolStripButton toolStripButtonOr;
        private System.Windows.Forms.ToolStripButton toolStripButtonNot;
        private System.Windows.Forms.ToolStripButton toolStripButtonCopy;
        private System.Windows.Forms.ToolStripButton toolStripButtonInput;
        private System.Windows.Forms.ToolStripButton toolStripButtonOutput;
        private System.Windows.Forms.ToolStripButton toolStripButtonStartCompound;
        private System.Windows.Forms.ToolStripButton toolStripButtonEndCompound;
        private System.Windows.Forms.ToolStripButton toolStripButtonEvaluate;
    }
}

