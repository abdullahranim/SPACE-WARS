
namespace SPACE_WARS
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.starstimer1 = new System.Windows.Forms.Timer(this.components);
            this.player1 = new System.Windows.Forms.PictureBox();
            this.movetimer = new System.Windows.Forms.Timer(this.components);
            this.shoot_timer1 = new System.Windows.Forms.Timer(this.components);
            this.enemies_timer = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.replaybtn = new System.Windows.Forms.Button();
            this.exitbtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.player1)).BeginInit();
            this.SuspendLayout();
            // 
            // starstimer1
            // 
            this.starstimer1.Enabled = true;
            this.starstimer1.Interval = 10;
            this.starstimer1.Tick += new System.EventHandler(this.starstimer1_Tick);
            // 
            // player1
            // 
            this.player1.BackColor = System.Drawing.Color.Transparent;
            this.player1.Image = ((System.Drawing.Image)(resources.GetObject("player1.Image")));
            this.player1.Location = new System.Drawing.Point(298, 391);
            this.player1.Name = "player1";
            this.player1.Size = new System.Drawing.Size(50, 50);
            this.player1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.player1.TabIndex = 0;
            this.player1.TabStop = false;
            // 
            // movetimer
            // 
            this.movetimer.Enabled = true;
            this.movetimer.Interval = 15;
            this.movetimer.Tick += new System.EventHandler(this.movetimer_Tick);
            // 
            // shoot_timer1
            // 
            this.shoot_timer1.Enabled = true;
            this.shoot_timer1.Interval = 20;
            this.shoot_timer1.Tick += new System.EventHandler(this.shoot_timer1_Tick);
            // 
            // enemies_timer
            // 
            this.enemies_timer.Enabled = true;
            this.enemies_timer.Tick += new System.EventHandler(this.enemies_timer_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Elephant", 40.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(43, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(241, 88);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            this.label1.Visible = false;
            // 
            // replaybtn
            // 
            this.replaybtn.BackColor = System.Drawing.Color.SkyBlue;
            this.replaybtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.replaybtn.Font = new System.Drawing.Font("Elephant", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.replaybtn.Location = new System.Drawing.Point(224, 188);
            this.replaybtn.Name = "replaybtn";
            this.replaybtn.Size = new System.Drawing.Size(226, 49);
            this.replaybtn.TabIndex = 2;
            this.replaybtn.Text = "Replay";
            this.replaybtn.UseVisualStyleBackColor = false;
            this.replaybtn.Visible = false;
            this.replaybtn.Click += new System.EventHandler(this.replaybtn_Click);
            // 
            // exitbtn
            // 
            this.exitbtn.Font = new System.Drawing.Font("Elephant", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitbtn.ForeColor = System.Drawing.Color.Black;
            this.exitbtn.Location = new System.Drawing.Point(224, 267);
            this.exitbtn.Name = "exitbtn";
            this.exitbtn.Size = new System.Drawing.Size(226, 51);
            this.exitbtn.TabIndex = 3;
            this.exitbtn.Text = "Exit";
            this.exitbtn.UseVisualStyleBackColor = true;
            this.exitbtn.Visible = false;
            this.exitbtn.Click += new System.EventHandler(this.exitbtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century", 40.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(168, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(335, 82);
            this.label2.TabIndex = 4;
            this.label2.Text = "PAUSED";
            this.label2.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(561, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Click P to pause";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 25);
            this.label4.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(12, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 25);
            this.label5.TabIndex = 7;
            this.label5.Text = "label5";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(682, 453);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.exitbtn);
            this.Controls.Add(this.replaybtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.player1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(700, 500);
            this.MinimumSize = new System.Drawing.Size(700, 500);
            this.Name = "Form1";
            this.Text = "SPACE WARS";
            this.Load += new System.EventHandler(this.form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown_1);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp_1);
            ((System.ComponentModel.ISupportInitialize)(this.player1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer starstimer1;
        private System.Windows.Forms.PictureBox player1;
        private System.Windows.Forms.Timer movetimer;
        private System.Windows.Forms.Timer shoot_timer1;
        private System.Windows.Forms.Timer enemies_timer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button replaybtn;
        private System.Windows.Forms.Button exitbtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}

