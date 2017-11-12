namespace Assignment1
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.option4 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.option3 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.option1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.option2 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.option5 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.toolTip5 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.toolTip3 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.toolTip2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.toolTip4 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.selected1 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.selected2 = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.selected3 = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.selected4 = new System.Windows.Forms.Panel();
            this.label15 = new System.Windows.Forms.Label();
            this.selected5 = new System.Windows.Forms.Panel();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.forenameBox = new System.Windows.Forms.TextBox();
            this.demographic1 = new System.Windows.Forms.ComboBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dayBox = new System.Windows.Forms.TextBox();
            this.surnameBox = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.monthBox = new System.Windows.Forms.TextBox();
            this.yearBox = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.option4.SuspendLayout();
            this.option3.SuspendLayout();
            this.option1.SuspendLayout();
            this.option2.SuspendLayout();
            this.option5.SuspendLayout();
            this.toolTip5.SuspendLayout();
            this.toolTip1.SuspendLayout();
            this.toolTip3.SuspendLayout();
            this.toolTip2.SuspendLayout();
            this.toolTip4.SuspendLayout();
            this.selected1.SuspendLayout();
            this.selected2.SuspendLayout();
            this.selected3.SuspendLayout();
            this.selected4.SuspendLayout();
            this.selected5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1920, 150);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Calibri", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(1690, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 78);
            this.label1.TabIndex = 2;
            this.label1.Text = "TITLE";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Location = new System.Drawing.Point(0, 150);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1920, 10);
            this.panel2.TabIndex = 1;
            // 
            // option4
            // 
            this.option4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.option4.Controls.Add(this.label10);
            this.option4.Location = new System.Drawing.Point(630, 73);
            this.option4.Name = "option4";
            this.option4.Size = new System.Drawing.Size(200, 100);
            this.option4.TabIndex = 5;
            this.option4.Tag = "3";
            this.option4.Click += new System.EventHandler(this.panel_onClick);
            this.option4.MouseEnter += new System.EventHandler(this.panel_onEnter);
            this.option4.MouseLeave += new System.EventHandler(this.panel_onLeave);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Calibri", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.label10.Location = new System.Drawing.Point(85, 32);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(30, 36);
            this.label10.TabIndex = 3;
            this.label10.Text = "4";
            // 
            // option3
            // 
            this.option3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.option3.Controls.Add(this.label9);
            this.option3.Location = new System.Drawing.Point(424, 73);
            this.option3.Name = "option3";
            this.option3.Size = new System.Drawing.Size(200, 100);
            this.option3.TabIndex = 6;
            this.option3.Tag = "2";
            this.option3.Click += new System.EventHandler(this.panel_onClick);
            this.option3.MouseEnter += new System.EventHandler(this.panel_onEnter);
            this.option3.MouseLeave += new System.EventHandler(this.panel_onLeave);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Calibri", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.label9.Location = new System.Drawing.Point(85, 32);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(30, 36);
            this.label9.TabIndex = 2;
            this.label9.Text = "3";
            // 
            // option1
            // 
            this.option1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.option1.Controls.Add(this.label7);
            this.option1.Location = new System.Drawing.Point(12, 73);
            this.option1.Name = "option1";
            this.option1.Size = new System.Drawing.Size(200, 100);
            this.option1.TabIndex = 8;
            this.option1.Tag = "0";
            this.option1.Click += new System.EventHandler(this.panel_onClick);
            this.option1.MouseEnter += new System.EventHandler(this.panel_onEnter);
            this.option1.MouseLeave += new System.EventHandler(this.panel_onLeave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Calibri", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(85, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 36);
            this.label7.TabIndex = 0;
            this.label7.Text = "1";
            // 
            // option2
            // 
            this.option2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.option2.Controls.Add(this.label8);
            this.option2.Location = new System.Drawing.Point(218, 73);
            this.option2.Name = "option2";
            this.option2.Size = new System.Drawing.Size(200, 100);
            this.option2.TabIndex = 7;
            this.option2.Tag = "1";
            this.option2.Click += new System.EventHandler(this.panel_onClick);
            this.option2.MouseEnter += new System.EventHandler(this.panel_onEnter);
            this.option2.MouseLeave += new System.EventHandler(this.panel_onLeave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Calibri", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.label8.Location = new System.Drawing.Point(85, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(30, 36);
            this.label8.TabIndex = 1;
            this.label8.Text = "2";
            // 
            // option5
            // 
            this.option5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.option5.Controls.Add(this.label11);
            this.option5.Location = new System.Drawing.Point(836, 73);
            this.option5.Name = "option5";
            this.option5.Size = new System.Drawing.Size(200, 100);
            this.option5.TabIndex = 10;
            this.option5.Tag = "4";
            this.option5.Click += new System.EventHandler(this.panel_onClick);
            this.option5.MouseEnter += new System.EventHandler(this.panel_onEnter);
            this.option5.MouseLeave += new System.EventHandler(this.panel_onLeave);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Calibri", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label11.Location = new System.Drawing.Point(85, 32);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(30, 36);
            this.label11.TabIndex = 4;
            this.label11.Text = "5";
            // 
            // toolTip5
            // 
            this.toolTip5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.toolTip5.Controls.Add(this.label3);
            this.toolTip5.Location = new System.Drawing.Point(1649, 362);
            this.toolTip5.Name = "toolTip5";
            this.toolTip5.Size = new System.Drawing.Size(200, 100);
            this.toolTip5.TabIndex = 15;
            this.toolTip5.Tag = "0";
            this.toolTip5.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label3.Location = new System.Drawing.Point(15, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(163, 26);
            this.label3.TabIndex = 1;
            this.label3.Text = "Strongly Disagree";
            // 
            // toolTip1
            // 
            this.toolTip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.toolTip1.Controls.Add(this.label2);
            this.toolTip1.Location = new System.Drawing.Point(825, 362);
            this.toolTip1.Name = "toolTip1";
            this.toolTip1.Size = new System.Drawing.Size(200, 100);
            this.toolTip1.TabIndex = 14;
            this.toolTip1.Tag = "0";
            this.toolTip1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(27, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 26);
            this.label2.TabIndex = 0;
            this.label2.Text = "Strongly Agree";
            // 
            // toolTip3
            // 
            this.toolTip3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.toolTip3.Controls.Add(this.label6);
            this.toolTip3.Location = new System.Drawing.Point(1237, 362);
            this.toolTip3.Name = "toolTip3";
            this.toolTip3.Size = new System.Drawing.Size(200, 100);
            this.toolTip3.TabIndex = 12;
            this.toolTip3.Tag = "0";
            this.toolTip3.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.label6.Location = new System.Drawing.Point(49, 37);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 26);
            this.label6.TabIndex = 3;
            this.label6.Text = "Don\'t Care";
            // 
            // toolTip2
            // 
            this.toolTip2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.toolTip2.Controls.Add(this.label4);
            this.toolTip2.Location = new System.Drawing.Point(1031, 362);
            this.toolTip2.Name = "toolTip2";
            this.toolTip2.Size = new System.Drawing.Size(200, 100);
            this.toolTip2.TabIndex = 13;
            this.toolTip2.Tag = "0";
            this.toolTip2.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.label4.Location = new System.Drawing.Point(22, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(162, 26);
            this.label4.TabIndex = 1;
            this.label4.Text = "Somewhat Agree";
            // 
            // toolTip4
            // 
            this.toolTip4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.toolTip4.Controls.Add(this.label5);
            this.toolTip4.Location = new System.Drawing.Point(1443, 362);
            this.toolTip4.Name = "toolTip4";
            this.toolTip4.Size = new System.Drawing.Size(200, 100);
            this.toolTip4.TabIndex = 11;
            this.toolTip4.Tag = "0";
            this.toolTip4.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.label5.Location = new System.Drawing.Point(10, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(185, 26);
            this.label5.TabIndex = 2;
            this.label5.Text = "Somewhat Disagree";
            // 
            // selected1
            // 
            this.selected1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.selected1.Controls.Add(this.label12);
            this.selected1.Location = new System.Drawing.Point(12, 49);
            this.selected1.Name = "selected1";
            this.selected1.Size = new System.Drawing.Size(200, 18);
            this.selected1.TabIndex = 9;
            this.selected1.Tag = "5";
            this.selected1.Visible = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Calibri", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(85, 32);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(30, 36);
            this.label12.TabIndex = 0;
            this.label12.Text = "1";
            // 
            // selected2
            // 
            this.selected2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.selected2.Controls.Add(this.label13);
            this.selected2.Location = new System.Drawing.Point(218, 49);
            this.selected2.Name = "selected2";
            this.selected2.Size = new System.Drawing.Size(200, 18);
            this.selected2.TabIndex = 10;
            this.selected2.Tag = "6";
            this.selected2.Visible = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Calibri", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(85, 32);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(30, 36);
            this.label13.TabIndex = 0;
            this.label13.Text = "1";
            // 
            // selected3
            // 
            this.selected3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.selected3.Controls.Add(this.label14);
            this.selected3.Location = new System.Drawing.Point(424, 49);
            this.selected3.Name = "selected3";
            this.selected3.Size = new System.Drawing.Size(200, 18);
            this.selected3.TabIndex = 11;
            this.selected3.Tag = "7";
            this.selected3.Visible = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Calibri", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(85, 32);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(30, 36);
            this.label14.TabIndex = 0;
            this.label14.Text = "1";
            // 
            // selected4
            // 
            this.selected4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.selected4.Controls.Add(this.label15);
            this.selected4.Location = new System.Drawing.Point(630, 49);
            this.selected4.Name = "selected4";
            this.selected4.Size = new System.Drawing.Size(200, 18);
            this.selected4.TabIndex = 12;
            this.selected4.Tag = "8";
            this.selected4.Visible = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Calibri", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(85, 32);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(30, 36);
            this.label15.TabIndex = 0;
            this.label15.Text = "1";
            // 
            // selected5
            // 
            this.selected5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.selected5.Controls.Add(this.label16);
            this.selected5.Location = new System.Drawing.Point(836, 49);
            this.selected5.Name = "selected5";
            this.selected5.Size = new System.Drawing.Size(200, 18);
            this.selected5.TabIndex = 13;
            this.selected5.Tag = "9";
            this.selected5.Visible = false;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("Calibri", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(85, 32);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(30, 36);
            this.label16.TabIndex = 0;
            this.label16.Text = "1";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(9, 8);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(461, 39);
            this.label17.TabIndex = 16;
            this.label17.Text = "DID YOU ENJOY THE SCULPTURE?";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.panel3.Controls.Add(this.selected1);
            this.panel3.Controls.Add(this.label17);
            this.panel3.Controls.Add(this.selected5);
            this.panel3.Controls.Add(this.option3);
            this.panel3.Controls.Add(this.option1);
            this.panel3.Controls.Add(this.option4);
            this.panel3.Controls.Add(this.option5);
            this.panel3.Controls.Add(this.selected4);
            this.panel3.Controls.Add(this.selected2);
            this.panel3.Controls.Add(this.selected3);
            this.panel3.Controls.Add(this.option2);
            this.panel3.Location = new System.Drawing.Point(813, 177);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1046, 179);
            this.panel3.TabIndex = 17;
            // 
            // forenameBox
            // 
            this.forenameBox.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.forenameBox.Location = new System.Drawing.Point(215, 20);
            this.forenameBox.Name = "forenameBox";
            this.forenameBox.Size = new System.Drawing.Size(261, 47);
            this.forenameBox.TabIndex = 18;
            // 
            // demographic1
            // 
            this.demographic1.FormattingEnabled = true;
            this.demographic1.Location = new System.Drawing.Point(60, 319);
            this.demographic1.Name = "demographic1";
            this.demographic1.Size = new System.Drawing.Size(121, 21);
            this.demographic1.TabIndex = 20;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.panel4.Controls.Add(this.label21);
            this.panel4.Controls.Add(this.label20);
            this.panel4.Controls.Add(this.yearBox);
            this.panel4.Controls.Add(this.monthBox);
            this.panel4.Controls.Add(this.dayBox);
            this.panel4.Controls.Add(this.surnameBox);
            this.panel4.Controls.Add(this.label19);
            this.panel4.Controls.Add(this.label18);
            this.panel4.Controls.Add(this.forenameBox);
            this.panel4.Controls.Add(this.demographic1);
            this.panel4.Location = new System.Drawing.Point(12, 177);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(764, 812);
            this.panel4.TabIndex = 21;
            // 
            // dayBox
            // 
            this.dayBox.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dayBox.ForeColor = System.Drawing.Color.Gray;
            this.dayBox.Location = new System.Drawing.Point(215, 185);
            this.dayBox.MaxLength = 2;
            this.dayBox.Name = "dayBox";
            this.dayBox.Size = new System.Drawing.Size(65, 47);
            this.dayBox.TabIndex = 24;
            this.dayBox.Tag = "0";
            this.dayBox.Text = "DD";
            this.dayBox.Enter += new System.EventHandler(this.dateEnter);
            this.dayBox.Leave += new System.EventHandler(this.dateLeave);
            // 
            // surnameBox
            // 
            this.surnameBox.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.surnameBox.Location = new System.Drawing.Point(215, 99);
            this.surnameBox.Name = "surnameBox";
            this.surnameBox.Size = new System.Drawing.Size(261, 47);
            this.surnameBox.TabIndex = 23;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(44, 102);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(155, 39);
            this.label19.TabIndex = 22;
            this.label19.Text = "SURNAME";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(27, 20);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(172, 39);
            this.label18.TabIndex = 21;
            this.label18.Text = "FORENAME";
            // 
            // monthBox
            // 
            this.monthBox.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.monthBox.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.monthBox.ForeColor = System.Drawing.Color.Gray;
            this.monthBox.Location = new System.Drawing.Point(323, 185);
            this.monthBox.MaxLength = 2;
            this.monthBox.Name = "monthBox";
            this.monthBox.Size = new System.Drawing.Size(65, 47);
            this.monthBox.TabIndex = 25;
            this.monthBox.Tag = "0";
            this.monthBox.Text = "MM";
            this.monthBox.Enter += new System.EventHandler(this.dateEnter);
            this.monthBox.Leave += new System.EventHandler(this.dateLeave);
            // 
            // yearBox
            // 
            this.yearBox.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yearBox.ForeColor = System.Drawing.Color.Gray;
            this.yearBox.Location = new System.Drawing.Point(431, 185);
            this.yearBox.MaxLength = 4;
            this.yearBox.Name = "yearBox";
            this.yearBox.Size = new System.Drawing.Size(80, 47);
            this.yearBox.TabIndex = 26;
            this.yearBox.Tag = "0";
            this.yearBox.Text = "YYYY";
            this.yearBox.Enter += new System.EventHandler(this.dateEnter);
            this.yearBox.Leave += new System.EventHandler(this.dateLeave);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(286, 188);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(31, 39);
            this.label20.TabIndex = 27;
            this.label20.Text = "/";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(394, 188);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(31, 39);
            this.label21.TabIndex = 28;
            this.label21.Text = "/";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1904, 1042);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.toolTip2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolTip5);
            this.Controls.Add(this.toolTip4);
            this.Controls.Add(this.toolTip1);
            this.Controls.Add(this.toolTip3);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.option4.ResumeLayout(false);
            this.option4.PerformLayout();
            this.option3.ResumeLayout(false);
            this.option3.PerformLayout();
            this.option1.ResumeLayout(false);
            this.option1.PerformLayout();
            this.option2.ResumeLayout(false);
            this.option2.PerformLayout();
            this.option5.ResumeLayout(false);
            this.option5.PerformLayout();
            this.toolTip5.ResumeLayout(false);
            this.toolTip5.PerformLayout();
            this.toolTip1.ResumeLayout(false);
            this.toolTip1.PerformLayout();
            this.toolTip3.ResumeLayout(false);
            this.toolTip3.PerformLayout();
            this.toolTip2.ResumeLayout(false);
            this.toolTip2.PerformLayout();
            this.toolTip4.ResumeLayout(false);
            this.toolTip4.PerformLayout();
            this.selected1.ResumeLayout(false);
            this.selected1.PerformLayout();
            this.selected2.ResumeLayout(false);
            this.selected2.PerformLayout();
            this.selected3.ResumeLayout(false);
            this.selected3.PerformLayout();
            this.selected4.ResumeLayout(false);
            this.selected4.PerformLayout();
            this.selected5.ResumeLayout(false);
            this.selected5.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel option4;
        private System.Windows.Forms.Panel option3;
        private System.Windows.Forms.Panel option1;
        private System.Windows.Forms.Panel option2;
        private System.Windows.Forms.Panel option5;
        private System.Windows.Forms.Panel toolTip5;
        private System.Windows.Forms.Panel toolTip1;
        private System.Windows.Forms.Panel toolTip3;
        private System.Windows.Forms.Panel toolTip2;
        private System.Windows.Forms.Panel toolTip4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel selected1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel selected2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel selected3;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Panel selected4;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Panel selected5;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox forenameBox;
        private System.Windows.Forms.ComboBox demographic1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox surnameBox;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox dayBox;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox yearBox;
        private System.Windows.Forms.TextBox monthBox;
    }
}

