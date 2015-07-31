namespace TextCounter
{
    partial class countTextForm
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
            this.resultBox = new System.Windows.Forms.TextBox();
            this.browse_button = new System.Windows.Forms.Button();
            this.execute_button = new System.Windows.Forms.Button();
            this.filePath_label = new System.Windows.Forms.Label();
            this.result_label = new System.Windows.Forms.Label();
            this.locationBox = new System.Windows.Forms.TextBox();
            this.locationDialog = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // resultBox
            // 
            this.resultBox.CausesValidation = false;
            this.resultBox.Location = new System.Drawing.Point(12, 73);
            this.resultBox.Multiline = true;
            this.resultBox.Name = "resultBox";
            this.resultBox.ReadOnly = true;
            this.resultBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.resultBox.Size = new System.Drawing.Size(343, 203);
            this.resultBox.TabIndex = 5;
            // 
            // browse_button
            // 
            this.browse_button.Location = new System.Drawing.Point(280, 26);
            this.browse_button.Name = "browse_button";
            this.browse_button.Size = new System.Drawing.Size(75, 23);
            this.browse_button.TabIndex = 1;
            this.browse_button.Text = "Browse";
            this.browse_button.UseVisualStyleBackColor = true;
            this.browse_button.Click += new System.EventHandler(this.browse_button_Click);
            // 
            // execute_button
            // 
            this.execute_button.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.execute_button.Location = new System.Drawing.Point(12, 282);
            this.execute_button.Name = "execute_button";
            this.execute_button.Size = new System.Drawing.Size(75, 23);
            this.execute_button.TabIndex = 2;
            this.execute_button.Text = "Execute";
            this.execute_button.UseVisualStyleBackColor = true;
            this.execute_button.Click += new System.EventHandler(this.execute_button_Click);
            // 
            // filePath_label
            // 
            this.filePath_label.AutoSize = true;
            this.filePath_label.Location = new System.Drawing.Point(12, 9);
            this.filePath_label.Name = "filePath_label";
            this.filePath_label.Size = new System.Drawing.Size(54, 13);
            this.filePath_label.TabIndex = 3;
            this.filePath_label.Text = "File Name";
            // 
            // result_label
            // 
            this.result_label.AutoSize = true;
            this.result_label.Location = new System.Drawing.Point(12, 55);
            this.result_label.Name = "result_label";
            this.result_label.Size = new System.Drawing.Size(37, 13);
            this.result_label.TabIndex = 4;
            this.result_label.Text = "Result";
            // 
            // locationBox
            // 
            this.locationBox.Location = new System.Drawing.Point(15, 28);
            this.locationBox.Name = "locationBox";
            this.locationBox.Size = new System.Drawing.Size(259, 20);
            this.locationBox.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(229, 291);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 9);
            this.label1.TabIndex = 6;
            this.label1.Text = "A program by John Kenneth Ganzan";
            // 
            // countTextForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ClientSize = new System.Drawing.Size(367, 313);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.result_label);
            this.Controls.Add(this.filePath_label);
            this.Controls.Add(this.execute_button);
            this.Controls.Add(this.browse_button);
            this.Controls.Add(this.resultBox);
            this.Controls.Add(this.locationBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "countTextForm";
            this.Text = "Word and Sentence Counter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox resultBox;
        private System.Windows.Forms.Button browse_button;
        private System.Windows.Forms.Button execute_button;
        private System.Windows.Forms.Label filePath_label;
        private System.Windows.Forms.Label result_label;
        private System.Windows.Forms.TextBox locationBox;
        private System.Windows.Forms.OpenFileDialog locationDialog;
        private System.Windows.Forms.Label label1;
    }    
}

