﻿namespace Registracija.UI
{
    partial class MainForm
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
            this.mnRegistar = new System.Windows.Forms.ToolStripMenuItem();
            this.mnGimnasticari = new System.Windows.Forms.ToolStripMenuItem();
            this.mnSudije = new System.Windows.Forms.ToolStripMenuItem();
            this.mnKlubovi = new System.Windows.Forms.ToolStripMenuItem();
            this.mnKategorijeGimnasticara = new System.Windows.Forms.ToolStripMenuItem();
            this.mnTreneri = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnRegistar});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(631, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnRegistar
            // 
            this.mnRegistar.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnGimnasticari,
            this.mnTreneri,
            this.mnSudije,
            this.mnKlubovi,
            this.mnKategorijeGimnasticara});
            this.mnRegistar.Name = "mnRegistar";
            this.mnRegistar.Size = new System.Drawing.Size(61, 20);
            this.mnRegistar.Text = "Registar";
            // 
            // mnGimnasticari
            // 
            this.mnGimnasticari.Name = "mnGimnasticari";
            this.mnGimnasticari.Size = new System.Drawing.Size(198, 22);
            this.mnGimnasticari.Text = "Gimnasticari";
            this.mnGimnasticari.Click += new System.EventHandler(this.mnGimnasticari_Click);
            // 
            // mnSudije
            // 
            this.mnSudije.Name = "mnSudije";
            this.mnSudije.Size = new System.Drawing.Size(198, 22);
            this.mnSudije.Text = "Sudije";
            this.mnSudije.Click += new System.EventHandler(this.mnSudije_Click);
            // 
            // mnKlubovi
            // 
            this.mnKlubovi.Name = "mnKlubovi";
            this.mnKlubovi.Size = new System.Drawing.Size(198, 22);
            this.mnKlubovi.Text = "Klubovi";
            this.mnKlubovi.Click += new System.EventHandler(this.mnKlubovi_Click);
            // 
            // mnKategorijeGimnasticara
            // 
            this.mnKategorijeGimnasticara.Name = "mnKategorijeGimnasticara";
            this.mnKategorijeGimnasticara.Size = new System.Drawing.Size(198, 22);
            this.mnKategorijeGimnasticara.Text = "Kategorije gimnasticara";
            this.mnKategorijeGimnasticara.Click += new System.EventHandler(this.mnKategorijeGimnasticara_Click);
            // 
            // mnTreneri
            // 
            this.mnTreneri.Name = "mnTreneri";
            this.mnTreneri.Size = new System.Drawing.Size(198, 22);
            this.mnTreneri.Text = "Treneri";
            this.mnTreneri.Click += new System.EventHandler(this.mnTreneri_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 262);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Registracija";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnRegistar;
        private System.Windows.Forms.ToolStripMenuItem mnGimnasticari;
        private System.Windows.Forms.ToolStripMenuItem mnKlubovi;
        private System.Windows.Forms.ToolStripMenuItem mnKategorijeGimnasticara;
        private System.Windows.Forms.ToolStripMenuItem mnSudije;
        private System.Windows.Forms.ToolStripMenuItem mnTreneri;
    }
}

