
namespace SQL_AdreseDB_Practica
{
    partial class Home
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.afisareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PanelInregistrare = new System.Windows.Forms.Panel();
            this.buttonModificare = new System.Windows.Forms.Button();
            this.buttonAdauga = new System.Windows.Forms.Button();
            this.dataGridHome = new System.Windows.Forms.DataGridView();
            this.menuStrip1.SuspendLayout();
            this.PanelInregistrare.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridHome)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.afisareToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1105, 28);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // afisareToolStripMenuItem
            // 
            this.afisareToolStripMenuItem.Name = "afisareToolStripMenuItem";
            this.afisareToolStripMenuItem.Size = new System.Drawing.Size(192, 24);
            this.afisareToolStripMenuItem.Text = "Vizualizare Lista Persoane";
            this.afisareToolStripMenuItem.Click += new System.EventHandler(this.afisareToolStripMenuItem_Click);
            // 
            // PanelInregistrare
            // 
            this.PanelInregistrare.Controls.Add(this.buttonModificare);
            this.PanelInregistrare.Controls.Add(this.buttonAdauga);
            this.PanelInregistrare.Controls.Add(this.dataGridHome);
            this.PanelInregistrare.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelInregistrare.Location = new System.Drawing.Point(0, 28);
            this.PanelInregistrare.Name = "PanelInregistrare";
            this.PanelInregistrare.Size = new System.Drawing.Size(1105, 497);
            this.PanelInregistrare.TabIndex = 11;
            // 
            // buttonModificare
            // 
            this.buttonModificare.AutoSize = true;
            this.buttonModificare.Location = new System.Drawing.Point(978, 449);
            this.buttonModificare.Name = "buttonModificare";
            this.buttonModificare.Size = new System.Drawing.Size(115, 27);
            this.buttonModificare.TabIndex = 128;
            this.buttonModificare.Text = "Editare date";
            this.buttonModificare.UseVisualStyleBackColor = true;
            this.buttonModificare.Click += new System.EventHandler(this.buttonModificare_Click);
            // 
            // buttonAdauga
            // 
            this.buttonAdauga.AutoSize = true;
            this.buttonAdauga.Location = new System.Drawing.Point(840, 449);
            this.buttonAdauga.Name = "buttonAdauga";
            this.buttonAdauga.Size = new System.Drawing.Size(132, 27);
            this.buttonAdauga.TabIndex = 127;
            this.buttonAdauga.Text = "Adauga Date";
            this.buttonAdauga.UseVisualStyleBackColor = true;
            this.buttonAdauga.Click += new System.EventHandler(this.buttonAdauga_Click);
            // 
            // dataGridHome
            // 
            this.dataGridHome.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridHome.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridHome.Location = new System.Drawing.Point(12, 36);
            this.dataGridHome.Name = "dataGridHome";
            this.dataGridHome.RowHeadersWidth = 51;
            this.dataGridHome.RowTemplate.Height = 24;
            this.dataGridHome.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridHome.Size = new System.Drawing.Size(1081, 380);
            this.dataGridHome.TabIndex = 126;
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1105, 525);
            this.Controls.Add(this.PanelInregistrare);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Persoane-Adrese";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.PanelInregistrare.ResumeLayout(false);
            this.PanelInregistrare.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridHome)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Panel PanelInregistrare;
        private System.Windows.Forms.ToolStripMenuItem afisareToolStripMenuItem;
        private System.Windows.Forms.Button buttonModificare;
        private System.Windows.Forms.Button buttonAdauga;
        private System.Windows.Forms.DataGridView dataGridHome;
    }
}

