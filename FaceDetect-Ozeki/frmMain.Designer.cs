namespace FaceDetect_Ozeki
{
    partial class frmMain
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.OriginalViewer = new Ozeki.Media.VideoViewerWF();
            this.ProcessedViewer = new Ozeki.Media.VideoViewerWF();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.stateLabel = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.button_Connect = new System.Windows.Forms.Button();
            this.button_Disconnect = new System.Windows.Forms.Button();
            this.tb_cameraUrl = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.button_Compose = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tbMaxSizeHeight = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tbMinSizeHeight = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.buttonSetFace = new System.Windows.Forms.Button();
            this.tbMaxSizeWidth = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbMinSizeWidth = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();

            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(7, 399);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Original image";

            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(348, 399);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Processed image";

            this.OriginalViewer.BackColor = System.Drawing.Color.Black;
            this.OriginalViewer.FlipMode = Ozeki.Media.FlipMode.None;
            this.OriginalViewer.FrameStretch = Ozeki.Media.FrameStretch.Uniform;
            this.OriginalViewer.FullScreenEnabled = true;
            this.OriginalViewer.Location = new System.Drawing.Point(10, 143);
            this.OriginalViewer.Name = "OriginalViewer";
            this.OriginalViewer.RotateAngle = 0;
            this.OriginalViewer.Size = new System.Drawing.Size(330, 240);
            this.OriginalViewer.TabIndex = 17;
            this.OriginalViewer.Text = "videoViewerWF1";

            this.ProcessedViewer.BackColor = System.Drawing.Color.Black;
            this.ProcessedViewer.FlipMode = Ozeki.Media.FlipMode.None;
            this.ProcessedViewer.FrameStretch = Ozeki.Media.FrameStretch.Uniform;
            this.ProcessedViewer.FullScreenEnabled = true;
            this.ProcessedViewer.Location = new System.Drawing.Point(351, 143);
            this.ProcessedViewer.Name = "ProcessedViewer";
            this.ProcessedViewer.RotateAngle = 0;
            this.ProcessedViewer.Size = new System.Drawing.Size(320, 240);
            this.ProcessedViewer.TabIndex = 18;
            this.ProcessedViewer.Text = "videoViewerWF1";

            this.groupBox5.Controls.Add(this.stateLabel);
            this.groupBox5.Controls.Add(this.label14);
            this.groupBox5.Controls.Add(this.button_Connect);
            this.groupBox5.Controls.Add(this.button_Disconnect);
            this.groupBox5.Controls.Add(this.tb_cameraUrl);
            this.groupBox5.Controls.Add(this.label13);
            this.groupBox5.Controls.Add(this.button_Compose);
            this.groupBox5.Location = new System.Drawing.Point(12, 12);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(328, 125);
            this.groupBox5.TabIndex = 21;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Connect";

            this.stateLabel.AutoSize = true;
            this.stateLabel.Location = new System.Drawing.Point(80, 72);
            this.stateLabel.Name = "stateLabel";
            this.stateLabel.Size = new System.Drawing.Size(0, 13);
            this.stateLabel.TabIndex = 24;

            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(39, 72);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(35, 13);
            this.label14.TabIndex = 23;
            this.label14.Text = "State:";

            this.button_Connect.Enabled = false;
            this.button_Connect.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button_Connect.ForeColor = System.Drawing.Color.Black;
            this.button_Connect.Location = new System.Drawing.Point(83, 39);
            this.button_Connect.Name = "button_Connect";
            this.button_Connect.Size = new System.Drawing.Size(69, 23);
            this.button_Connect.TabIndex = 18;
            this.button_Connect.Text = "Connect";
            this.button_Connect.UseVisualStyleBackColor = true;
            this.button_Connect.Click += new System.EventHandler(this.button_Connect_Click);

            this.button_Disconnect.Enabled = false;
            this.button_Disconnect.Location = new System.Drawing.Point(180, 39);
            this.button_Disconnect.Name = "button_Disconnect";
            this.button_Disconnect.Size = new System.Drawing.Size(69, 23);
            this.button_Disconnect.TabIndex = 22;
            this.button_Disconnect.Text = "Disconnect";
            this.button_Disconnect.UseVisualStyleBackColor = true;
            this.button_Disconnect.Click += new System.EventHandler(this.button_Disconnect_Click);

            this.tb_cameraUrl.Location = new System.Drawing.Point(83, 13);
            this.tb_cameraUrl.Name = "tb_cameraUrl";
            this.tb_cameraUrl.ReadOnly = true;
            this.tb_cameraUrl.Size = new System.Drawing.Size(166, 20);
            this.tb_cameraUrl.TabIndex = 21;

            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 16);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(71, 13);
            this.label13.TabIndex = 20;
            this.label13.Text = "Camera URL:";

            this.button_Compose.Location = new System.Drawing.Point(253, 11);
            this.button_Compose.Name = "button_Compose";
            this.button_Compose.Size = new System.Drawing.Size(69, 23);
            this.button_Compose.TabIndex = 19;
            this.button_Compose.Text = "Compose";
            this.button_Compose.UseVisualStyleBackColor = true;
            this.button_Compose.Click += new System.EventHandler(this.button_Compose_Click);

            this.groupBox3.Controls.Add(this.tbMaxSizeHeight);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.tbMinSizeHeight);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.buttonSetFace);
            this.groupBox3.Controls.Add(this.tbMaxSizeWidth);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.tbMinSizeWidth);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Location = new System.Drawing.Point(351, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(320, 125);
            this.groupBox3.TabIndex = 22;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Face Detection";

            this.tbMaxSizeHeight.Location = new System.Drawing.Point(225, 59);
            this.tbMaxSizeHeight.Name = "tbMaxSizeHeight";
            this.tbMaxSizeHeight.Size = new System.Drawing.Size(50, 20);
            this.tbMaxSizeHeight.TabIndex = 10;

            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(222, 39);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 13);
            this.label10.TabIndex = 9;
            this.label10.Text = "Height:";

            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(150, 43);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Width:";

            this.tbMinSizeHeight.Location = new System.Drawing.Point(85, 59);
            this.tbMinSizeHeight.Name = "tbMinSizeHeight";
            this.tbMinSizeHeight.Size = new System.Drawing.Size(50, 20);
            this.tbMinSizeHeight.TabIndex = 7;

            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(82, 43);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "Height:";

            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 44);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Width:";

            this.buttonSetFace.Location = new System.Drawing.Point(234, 88);
            this.buttonSetFace.Name = "buttonSetFace";
            this.buttonSetFace.Size = new System.Drawing.Size(75, 23);
            this.buttonSetFace.TabIndex = 4;
            this.buttonSetFace.Text = "Set";
            this.buttonSetFace.UseVisualStyleBackColor = true;
            this.buttonSetFace.Click += new System.EventHandler(this.buttonSetFace_Click);

            this.tbMaxSizeWidth.Location = new System.Drawing.Point(153, 59);
            this.tbMaxSizeWidth.Name = "tbMaxSizeWidth";
            this.tbMaxSizeWidth.Size = new System.Drawing.Size(50, 20);
            this.tbMaxSizeWidth.TabIndex = 3;

            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(150, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Maximum Size:";

            this.tbMinSizeWidth.Location = new System.Drawing.Point(10, 59);
            this.tbMinSizeWidth.Name = "tbMinSizeWidth";
            this.tbMinSizeWidth.Size = new System.Drawing.Size(50, 20);
            this.tbMinSizeWidth.TabIndex = 1;

            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Minimum Size:";

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 421);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.ProcessedViewer);
            this.Controls.Add(this.OriginalViewer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Face Detection";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Ozeki.Media.VideoViewerWF OriginalViewer;
        private Ozeki.Media.VideoViewerWF ProcessedViewer;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button button_Connect;
        private System.Windows.Forms.Button button_Disconnect;
        private System.Windows.Forms.TextBox tb_cameraUrl;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button button_Compose;
        private System.Windows.Forms.Label stateLabel;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox tbMaxSizeHeight;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbMinSizeHeight;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button buttonSetFace;
        private System.Windows.Forms.TextBox tbMaxSizeWidth;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbMinSizeWidth;
        private System.Windows.Forms.Label label5;
    }
}

