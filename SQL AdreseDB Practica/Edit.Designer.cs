
namespace SQL_AdreseDB_Practica
{
    partial class FormEdit
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
            this.dataGridHome = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.listaPersoaneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtNumeEdit = new System.Windows.Forms.TextBox();
            this.labelCautaEdit = new System.Windows.Forms.Label();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonCautare = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridHome)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridHome
            // 
            this.dataGridHome.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridHome.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridHome.Location = new System.Drawing.Point(12, 134);
            this.dataGridHome.Name = "dataGridHome";
            this.dataGridHome.RowHeadersWidth = 51;
            this.dataGridHome.RowTemplate.Height = 24;
            this.dataGridHome.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridHome.Size = new System.Drawing.Size(982, 396);
            this.dataGridHome.TabIndex = 127;
            this.dataGridHome.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridHome_CellClick);
            this.dataGridHome.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridHome_CellDoubleClick);
            this.dataGridHome.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrid_CellValueChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listaPersoaneToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1006, 28);
            this.menuStrip1.TabIndex = 128;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // listaPersoaneToolStripMenuItem
            // 
            this.listaPersoaneToolStripMenuItem.Name = "listaPersoaneToolStripMenuItem";
            this.listaPersoaneToolStripMenuItem.Size = new System.Drawing.Size(199, 24);
            this.listaPersoaneToolStripMenuItem.Text = "Inapoi la Lista de Persoane";
            this.listaPersoaneToolStripMenuItem.Click += new System.EventHandler(this.listaPersoaneToolStripMenuItem_Click_1);
            // 
            // txtNumeEdit
            // 
            this.txtNumeEdit.Location = new System.Drawing.Point(458, 67);
            this.txtNumeEdit.Name = "txtNumeEdit";
            this.txtNumeEdit.Size = new System.Drawing.Size(100, 22);
            this.txtNumeEdit.TabIndex = 129;
            // 
            // labelCautaEdit
            // 
            this.labelCautaEdit.AutoSize = true;
            this.labelCautaEdit.Location = new System.Drawing.Point(252, 69);
            this.labelCautaEdit.Name = "labelCautaEdit";
            this.labelCautaEdit.Size = new System.Drawing.Size(191, 17);
            this.labelCautaEdit.TabIndex = 130;
            this.labelCautaEdit.Text = "Introduceti numele persoanei";
            // 
            // buttonEdit
            // 
            this.buttonEdit.AutoSize = true;
            this.buttonEdit.Location = new System.Drawing.Point(796, 101);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(198, 27);
            this.buttonEdit.TabIndex = 131;
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonStergerePersoana_Click);
            // 
            // buttonCautare
            // 
            this.buttonCautare.Location = new System.Drawing.Point(586, 66);
            this.buttonCautare.Name = "buttonCautare";
            this.buttonCautare.Size = new System.Drawing.Size(75, 23);
            this.buttonCautare.TabIndex = 132;
            this.buttonCautare.Text = "Cauta";
            this.buttonCautare.UseVisualStyleBackColor = true;
            this.buttonCautare.Click += new System.EventHandler(this.buttonCautare_Click);
            // 
            // FormEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 542);
            this.Controls.Add(this.buttonCautare);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.labelCautaEdit);
            this.Controls.Add(this.txtNumeEdit);
            this.Controls.Add(this.dataGridHome);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridHome)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridHome;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem listaPersoaneToolStripMenuItem;
        private System.Windows.Forms.TextBox txtNumeEdit;
        private System.Windows.Forms.Label labelCautaEdit;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonCautare;
    }
}