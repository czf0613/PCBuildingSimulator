namespace WindowsFormsApp1
{
    partial class Frm_game
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_game));
            this.panel1 = new System.Windows.Forms.Panel();
            this.submit = new System.Windows.Forms.PictureBox();
            this.powerSwitch = new System.Windows.Forms.PictureBox();
            this.uninstall = new System.Windows.Forms.PictureBox();
            this.install = new System.Windows.Forms.PictureBox();
            this.information = new System.Windows.Forms.Label();
            this.taskDescription = new System.Windows.Forms.Label();
            this.items = new System.Windows.Forms.TreeView();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.submit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.powerSwitch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uninstall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.install)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.背景;
            this.panel1.Controls.Add(this.submit);
            this.panel1.Controls.Add(this.powerSwitch);
            this.panel1.Controls.Add(this.uninstall);
            this.panel1.Controls.Add(this.install);
            this.panel1.Controls.Add(this.information);
            this.panel1.Controls.Add(this.taskDescription);
            this.panel1.Controls.Add(this.items);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1920, 1080);
            this.panel1.TabIndex = 0;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel1_MouseDown);
            // 
            // submit
            // 
            this.submit.BackColor = System.Drawing.Color.Transparent;
            this.submit.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.submit1;
            this.submit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.submit.Location = new System.Drawing.Point(1091, 618);
            this.submit.Name = "submit";
            this.submit.Size = new System.Drawing.Size(131, 124);
            this.submit.TabIndex = 9;
            this.submit.TabStop = false;
            this.submit.Click += new System.EventHandler(this.Submit_Click);
            this.submit.MouseEnter += new System.EventHandler(this.Submit_MouseEnter);
            this.submit.MouseLeave += new System.EventHandler(this.Submit_MouseLeave);
            // 
            // powerSwitch
            // 
            this.powerSwitch.BackColor = System.Drawing.Color.Transparent;
            this.powerSwitch.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.switchon;
            this.powerSwitch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.powerSwitch.Location = new System.Drawing.Point(1473, 798);
            this.powerSwitch.Name = "powerSwitch";
            this.powerSwitch.Size = new System.Drawing.Size(250, 250);
            this.powerSwitch.TabIndex = 8;
            this.powerSwitch.TabStop = false;
            this.powerSwitch.Click += new System.EventHandler(this.PowerSwitch_Click);
            // 
            // uninstall
            // 
            this.uninstall.BackColor = System.Drawing.Color.Transparent;
            this.uninstall.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.uninstall1;
            this.uninstall.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.uninstall.Location = new System.Drawing.Point(1067, 798);
            this.uninstall.Name = "uninstall";
            this.uninstall.Size = new System.Drawing.Size(250, 250);
            this.uninstall.TabIndex = 7;
            this.uninstall.TabStop = false;
            this.uninstall.Click += new System.EventHandler(this.Uninstall_Click);
            // 
            // install
            // 
            this.install.BackColor = System.Drawing.Color.Transparent;
            this.install.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.install1;
            this.install.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.install.Location = new System.Drawing.Point(676, 798);
            this.install.Name = "install";
            this.install.Size = new System.Drawing.Size(250, 250);
            this.install.TabIndex = 6;
            this.install.TabStop = false;
            this.install.Click += new System.EventHandler(this.Install_Click);
            // 
            // information
            // 
            this.information.AutoSize = true;
            this.information.BackColor = System.Drawing.Color.Transparent;
            this.information.Font = new System.Drawing.Font("楷体", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.information.Location = new System.Drawing.Point(336, 464);
            this.information.MaximumSize = new System.Drawing.Size(650, 250);
            this.information.Name = "information";
            this.information.Size = new System.Drawing.Size(131, 37);
            this.information.TabIndex = 5;
            this.information.Text = "label1";
            // 
            // taskDescription
            // 
            this.taskDescription.AutoSize = true;
            this.taskDescription.BackColor = System.Drawing.Color.Transparent;
            this.taskDescription.Font = new System.Drawing.Font("楷体", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.taskDescription.Location = new System.Drawing.Point(84, 88);
            this.taskDescription.MaximumSize = new System.Drawing.Size(1250, 200);
            this.taskDescription.Name = "taskDescription";
            this.taskDescription.Size = new System.Drawing.Size(137, 37);
            this.taskDescription.TabIndex = 4;
            this.taskDescription.Text = "label1";
            // 
            // items
            // 
            this.items.BackColor = System.Drawing.Color.Black;
            this.items.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.items.ForeColor = System.Drawing.Color.White;
            this.items.Location = new System.Drawing.Point(12, 297);
            this.items.Name = "items";
            this.items.Size = new System.Drawing.Size(301, 676);
            this.items.TabIndex = 2;
            this.items.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.Items_AfterSelect);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.全部装完;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(1134, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(774, 730);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PictureBox2_MouseDown);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(101, 98);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.PictureBox1_Click);
            this.pictureBox1.MouseEnter += new System.EventHandler(this.PictureBox1_MouseEnter);
            this.pictureBox1.MouseLeave += new System.EventHandler(this.PictureBox1_MouseLeave);
            // 
            // Frm_game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_game";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.Load += new System.EventHandler(this.Frm_game_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.submit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.powerSwitch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uninstall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.install)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TreeView items;
        private System.Windows.Forms.Label taskDescription;
        private System.Windows.Forms.Label information;
        private System.Windows.Forms.PictureBox powerSwitch;
        private System.Windows.Forms.PictureBox uninstall;
        private System.Windows.Forms.PictureBox install;
        private System.Windows.Forms.PictureBox submit;
    }
}