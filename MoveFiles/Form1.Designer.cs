
namespace MoveFiles
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.Run = new System.Windows.Forms.Button();
            this.SourcePath = new System.Windows.Forms.TextBox();
            this.SelectSourcePath = new System.Windows.Forms.Button();
            this.TargetPath = new System.Windows.Forms.TextBox();
            this.SelectTargetPath = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Run
            // 
            this.Run.Location = new System.Drawing.Point(271, 319);
            this.Run.Name = "Run";
            this.Run.Size = new System.Drawing.Size(99, 48);
            this.Run.TabIndex = 1;
            this.Run.Text = "搬移";
            this.Run.UseVisualStyleBackColor = true;
            this.Run.Click += new System.EventHandler(this.Run_Click);
            // 
            // SourcePath
            // 
            this.SourcePath.Location = new System.Drawing.Point(99, 96);
            this.SourcePath.Name = "SourcePath";
            this.SourcePath.Size = new System.Drawing.Size(515, 29);
            this.SourcePath.TabIndex = 2;
            // 
            // SelectSourcePath
            // 
            this.SelectSourcePath.Location = new System.Drawing.Point(99, 144);
            this.SelectSourcePath.Name = "SelectSourcePath";
            this.SelectSourcePath.Size = new System.Drawing.Size(134, 31);
            this.SelectSourcePath.TabIndex = 3;
            this.SelectSourcePath.Text = "選擇來源目錄";
            this.SelectSourcePath.UseVisualStyleBackColor = true;
            this.SelectSourcePath.Click += new System.EventHandler(this.SelectSourcePath_Click);
            // 
            // TargetPath
            // 
            this.TargetPath.Location = new System.Drawing.Point(99, 206);
            this.TargetPath.Name = "TargetPath";
            this.TargetPath.Size = new System.Drawing.Size(515, 29);
            this.TargetPath.TabIndex = 2;
            // 
            // SelectTargetPath
            // 
            this.SelectTargetPath.Location = new System.Drawing.Point(99, 250);
            this.SelectTargetPath.Name = "SelectTargetPath";
            this.SelectTargetPath.Size = new System.Drawing.Size(134, 31);
            this.SelectTargetPath.TabIndex = 3;
            this.SelectTargetPath.Text = "選擇目標目錄";
            this.SelectTargetPath.UseVisualStyleBackColor = true;
            this.SelectTargetPath.Click += new System.EventHandler(this.SelectTargetPath_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.SelectTargetPath);
            this.Controls.Add(this.SelectSourcePath);
            this.Controls.Add(this.TargetPath);
            this.Controls.Add(this.SourcePath);
            this.Controls.Add(this.Run);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Run;
        private System.Windows.Forms.TextBox SourcePath;
        private System.Windows.Forms.Button SelectSourcePath;
        private System.Windows.Forms.TextBox TargetPath;
        private System.Windows.Forms.Button SelectTargetPath;
    }
}

