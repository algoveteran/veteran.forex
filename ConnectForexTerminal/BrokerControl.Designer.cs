namespace Dashboard
{
    partial class BrokerControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.guna2CircleButton1 = new Guna.UI2.WinForms.Guna2CircleButton();
            this.lbl_broker = new System.Windows.Forms.Label();
            this.guna2Elipse2 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
            this.guna2VSeparator1 = new Guna.UI2.WinForms.Guna2VSeparator();
            this.lbl_bid = new System.Windows.Forms.Label();
            this.lbl_ask = new System.Windows.Forms.Label();
            this.lbl_bid_rate = new System.Windows.Forms.Label();
            this.lbl_info = new System.Windows.Forms.Label();
            this.lbl_ask_rate = new System.Windows.Forms.Label();
            this.lbl_spread = new System.Windows.Forms.Label();
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.lbl_time = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.RoyalBlue;
            this.panel1.Controls.Add(this.guna2CircleButton1);
            this.panel1.Controls.Add(this.lbl_broker);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(340, 32);
            this.panel1.TabIndex = 0;
            // 
            // guna2CircleButton1
            // 
            this.guna2CircleButton1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2CircleButton1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2CircleButton1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2CircleButton1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2CircleButton1.FillColor = System.Drawing.Color.OrangeRed;
            this.guna2CircleButton1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2CircleButton1.ForeColor = System.Drawing.Color.White;
            this.guna2CircleButton1.Location = new System.Drawing.Point(309, 6);
            this.guna2CircleButton1.Name = "guna2CircleButton1";
            this.guna2CircleButton1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CircleButton1.Size = new System.Drawing.Size(20, 20);
            this.guna2CircleButton1.TabIndex = 4;
            this.guna2CircleButton1.Click += new System.EventHandler(this.Guna2CircleButton1_Click);
            // 
            // lbl_broker
            // 
            this.lbl_broker.BackColor = System.Drawing.Color.Transparent;
            this.lbl_broker.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_broker.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_broker.Location = new System.Drawing.Point(0, 0);
            this.lbl_broker.Name = "lbl_broker";
            this.lbl_broker.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.lbl_broker.Size = new System.Drawing.Size(295, 32);
            this.lbl_broker.TabIndex = 0;
            this.lbl_broker.Text = "Broker";
            this.lbl_broker.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // guna2Elipse2
            // 
            this.guna2Elipse2.BorderRadius = 40;
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.TargetControl = this;
            // 
            // guna2Separator1
            // 
            this.guna2Separator1.Location = new System.Drawing.Point(6, 34);
            this.guna2Separator1.Name = "guna2Separator1";
            this.guna2Separator1.Size = new System.Drawing.Size(327, 10);
            this.guna2Separator1.TabIndex = 1;
            // 
            // guna2VSeparator1
            // 
            this.guna2VSeparator1.Location = new System.Drawing.Point(167, 73);
            this.guna2VSeparator1.Name = "guna2VSeparator1";
            this.guna2VSeparator1.Size = new System.Drawing.Size(10, 91);
            this.guna2VSeparator1.TabIndex = 2;
            // 
            // lbl_bid
            // 
            this.lbl_bid.BackColor = System.Drawing.Color.Transparent;
            this.lbl_bid.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_bid.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_bid.Location = new System.Drawing.Point(6, 72);
            this.lbl_bid.Name = "lbl_bid";
            this.lbl_bid.Size = new System.Drawing.Size(155, 26);
            this.lbl_bid.TabIndex = 3;
            this.lbl_bid.Text = "BID";
            // 
            // lbl_ask
            // 
            this.lbl_ask.BackColor = System.Drawing.Color.Transparent;
            this.lbl_ask.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_ask.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ask.Location = new System.Drawing.Point(183, 72);
            this.lbl_ask.Name = "lbl_ask";
            this.lbl_ask.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbl_ask.Size = new System.Drawing.Size(150, 26);
            this.lbl_ask.TabIndex = 4;
            this.lbl_ask.Text = "ASK";
            // 
            // lbl_bid_rate
            // 
            this.lbl_bid_rate.BackColor = System.Drawing.Color.Transparent;
            this.lbl_bid_rate.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_bid_rate.Location = new System.Drawing.Point(6, 104);
            this.lbl_bid_rate.Name = "lbl_bid_rate";
            this.lbl_bid_rate.Size = new System.Drawing.Size(155, 26);
            this.lbl_bid_rate.TabIndex = 5;
            this.lbl_bid_rate.Text = "#.#####";
            // 
            // lbl_info
            // 
            this.lbl_info.BackColor = System.Drawing.Color.Transparent;
            this.lbl_info.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_info.Location = new System.Drawing.Point(6, 40);
            this.lbl_info.Name = "lbl_info";
            this.lbl_info.Size = new System.Drawing.Size(323, 26);
            this.lbl_info.TabIndex = 6;
            this.lbl_info.Text = "HOST, ACCOUNT, SYMBOL\r\n";
            // 
            // lbl_ask_rate
            // 
            this.lbl_ask_rate.BackColor = System.Drawing.Color.Transparent;
            this.lbl_ask_rate.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ask_rate.Location = new System.Drawing.Point(187, 104);
            this.lbl_ask_rate.Name = "lbl_ask_rate";
            this.lbl_ask_rate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbl_ask_rate.Size = new System.Drawing.Size(146, 26);
            this.lbl_ask_rate.TabIndex = 7;
            this.lbl_ask_rate.Text = "#.#####";
            // 
            // lbl_spread
            // 
            this.lbl_spread.BackColor = System.Drawing.Color.Transparent;
            this.lbl_spread.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_spread.Location = new System.Drawing.Point(6, 164);
            this.lbl_spread.Name = "lbl_spread";
            this.lbl_spread.Size = new System.Drawing.Size(155, 26);
            this.lbl_spread.TabIndex = 8;
            this.lbl_spread.Text = "SPREAD";
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // lbl_time
            // 
            this.lbl_time.BackColor = System.Drawing.Color.Transparent;
            this.lbl_time.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_time.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_time.Location = new System.Drawing.Point(183, 164);
            this.lbl_time.Name = "lbl_time";
            this.lbl_time.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbl_time.Size = new System.Drawing.Size(146, 26);
            this.lbl_time.TabIndex = 9;
            this.lbl_time.Text = "SPREAD";
            // 
            // BrokerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lbl_time);
            this.Controls.Add(this.lbl_spread);
            this.Controls.Add(this.lbl_ask_rate);
            this.Controls.Add(this.lbl_info);
            this.Controls.Add(this.lbl_bid_rate);
            this.Controls.Add(this.lbl_ask);
            this.Controls.Add(this.lbl_bid);
            this.Controls.Add(this.guna2VSeparator1);
            this.Controls.Add(this.guna2Separator1);
            this.Controls.Add(this.panel1);
            this.Name = "BrokerControl";
            this.Size = new System.Drawing.Size(340, 200);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_broker;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse2;
        private Guna.UI2.WinForms.Guna2CircleButton guna2CircleButton1;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator1;
        private System.Windows.Forms.Label lbl_ask_rate;
        private System.Windows.Forms.Label lbl_info;
        private System.Windows.Forms.Label lbl_bid_rate;
        private System.Windows.Forms.Label lbl_ask;
        private System.Windows.Forms.Label lbl_bid;
        private System.Windows.Forms.Label lbl_spread;
        private Guna.UI2.WinForms.Guna2VSeparator guna2VSeparator1;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private System.Windows.Forms.Label lbl_time;
    }
}
