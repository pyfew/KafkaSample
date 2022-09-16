namespace PlayForm
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
            this.txtTopic = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPartition = new System.Windows.Forms.TextBox();
            this.btnpull = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.txtoffset = new System.Windows.Forms.TextBox();
            this.btnoffset = new System.Windows.Forms.Button();
            this.txtser = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnListen = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnParti = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtTopic
            // 
            this.txtTopic.Location = new System.Drawing.Point(162, 41);
            this.txtTopic.Name = "txtTopic";
            this.txtTopic.Size = new System.Drawing.Size(153, 23);
            this.txtTopic.TabIndex = 0;
            this.txtTopic.Text = "P2";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(77, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Topic";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(27, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "Partition";
            // 
            // txtPartition
            // 
            this.txtPartition.Location = new System.Drawing.Point(122, 44);
            this.txtPartition.Name = "txtPartition";
            this.txtPartition.Size = new System.Drawing.Size(100, 23);
            this.txtPartition.TabIndex = 3;
            this.txtPartition.Text = "0";
            // 
            // btnpull
            // 
            this.btnpull.Location = new System.Drawing.Point(77, 139);
            this.btnpull.Name = "btnpull";
            this.btnpull.Size = new System.Drawing.Size(75, 23);
            this.btnpull.TabIndex = 4;
            this.btnpull.Text = "拉取消息";
            this.btnpull.UseVisualStyleBackColor = true;
            this.btnpull.Click += new System.EventHandler(this.btnpull_Click);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(77, 87);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 5;
            this.btnNew.Text = "Create";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // txtoffset
            // 
            this.txtoffset.Location = new System.Drawing.Point(122, 83);
            this.txtoffset.Name = "txtoffset";
            this.txtoffset.Size = new System.Drawing.Size(100, 23);
            this.txtoffset.TabIndex = 6;
            this.txtoffset.Text = "0";
            // 
            // btnoffset
            // 
            this.btnoffset.Location = new System.Drawing.Point(27, 123);
            this.btnoffset.Name = "btnoffset";
            this.btnoffset.Size = new System.Drawing.Size(100, 23);
            this.btnoffset.TabIndex = 9;
            this.btnoffset.Text = "指定offset拉取";
            this.btnoffset.UseVisualStyleBackColor = true;
            this.btnoffset.Click += new System.EventHandler(this.btnoffset_Click);
            // 
            // txtser
            // 
            this.txtser.Location = new System.Drawing.Point(162, 16);
            this.txtser.Name = "txtser";
            this.txtser.Size = new System.Drawing.Size(153, 23);
            this.txtser.TabIndex = 10;
            this.txtser.Text = "192.168.10.73:9092";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(77, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 23);
            this.label3.TabIndex = 11;
            this.label3.Text = "Server";
            // 
            // btnListen
            // 
            this.btnListen.Location = new System.Drawing.Point(165, 139);
            this.btnListen.Name = "btnListen";
            this.btnListen.Size = new System.Drawing.Size(75, 23);
            this.btnListen.TabIndex = 12;
            this.btnListen.Text = "监听消息";
            this.btnListen.UseVisualStyleBackColor = true;
            this.btnListen.Click += new System.EventHandler(this.btnListen_Click);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(27, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 21);
            this.label4.TabIndex = 13;
            this.label4.Text = "OffSet";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnParti);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtPartition);
            this.groupBox1.Controls.Add(this.txtoffset);
            this.groupBox1.Controls.Add(this.btnoffset);
            this.groupBox1.Location = new System.Drawing.Point(77, 259);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(314, 168);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            // 
            // btnParti
            // 
            this.btnParti.Location = new System.Drawing.Point(138, 123);
            this.btnParti.Name = "btnParti";
            this.btnParti.Size = new System.Drawing.Size(100, 23);
            this.btnParti.TabIndex = 14;
            this.btnParti.Text = "指定分区拉取";
            this.btnParti.UseVisualStyleBackColor = true;
            this.btnParti.Click += new System.EventHandler(this.btnParti_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnListen);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtser);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnpull);
            this.Controls.Add(this.txtTopic);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox txtTopic;
        private Label label1;
        private Label label2;
        private TextBox txtPartition;
        private Button btnpull;
        private Button btnNew;
        private TextBox txtoffset;
        private Button btnoffset;
        private TextBox txtser;
        private Label label3;
        private Button btnListen;
        private Label label4;
        private GroupBox groupBox1;
        private Button btnParti;
    }
}