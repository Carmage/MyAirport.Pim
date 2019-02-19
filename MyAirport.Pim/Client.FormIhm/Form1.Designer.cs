namespace Client.FormIhm
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnNewBagage = new System.Windows.Forms.Button();
            this.tbCodeIata = new System.Windows.Forms.TextBox();
            this.lblCodeIata = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnNewBagage
            // 
            this.btnNewBagage.Location = new System.Drawing.Point(22, 25);
            this.btnNewBagage.Name = "btnNewBagage";
            this.btnNewBagage.Size = new System.Drawing.Size(159, 58);
            this.btnNewBagage.TabIndex = 0;
            this.btnNewBagage.Text = "Nouveau Bagage";
            this.btnNewBagage.UseVisualStyleBackColor = true;
            this.btnNewBagage.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbCodeIata
            // 
            this.tbCodeIata.Location = new System.Drawing.Point(145, 126);
            this.tbCodeIata.Name = "tbCodeIata";
            this.tbCodeIata.Size = new System.Drawing.Size(100, 20);
            this.tbCodeIata.TabIndex = 2;
            this.tbCodeIata.TextChanged += new System.EventHandler(this.textBox1_TextChanged_1);
            // 
            // lblCodeIata
            // 
            this.lblCodeIata.AutoSize = true;
            this.lblCodeIata.Location = new System.Drawing.Point(56, 129);
            this.lblCodeIata.Name = "lblCodeIata";
            this.lblCodeIata.Size = new System.Drawing.Size(59, 13);
            this.lblCodeIata.TabIndex = 3;
            this.lblCodeIata.Text = "Code IATA";
            this.lblCodeIata.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(339, 108);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(117, 54);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Rechercher";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.lblCodeIata);
            this.Controls.Add(this.tbCodeIata);
            this.Controls.Add(this.btnNewBagage);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNewBagage;
        private System.Windows.Forms.TextBox tbCodeIata;
        private System.Windows.Forms.Label lblCodeIata;
        private System.Windows.Forms.Button btnSearch;
    }
}

