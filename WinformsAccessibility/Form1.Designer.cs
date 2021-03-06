
namespace WinformsAccessibility
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
            this.customButtonId = new WinformsAccessibility.CustomControls.CustomButton();
            this.SuspendLayout();
            // 
            // customButtonId
            // 
            this.customButtonId.Location = new System.Drawing.Point(52, 73);
            this.customButtonId.Name = "customButtonId";
            this.customButtonId.Size = new System.Drawing.Size(123, 40);
            this.customButtonId.TabIndex = 0;
            this.customButtonId.Text = "CustomButtonText";
            this.customButtonId.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(235, 212);
            this.Controls.Add(this.customButtonId);
            this.Name = "Form1";
            this.Text = "WinformsAccessibility";
            this.ResumeLayout(false);

        }

        #endregion

        private CustomControls.CustomButton customButtonId;
    }
}

