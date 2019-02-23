namespace Client.FormIhm
{
    partial class IHM
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
            this.btnNouveauBagage = new System.Windows.Forms.Button();
            this.textBoxCodeIata = new System.Windows.Forms.TextBox();
            this.labelCodeIata = new System.Windows.Forms.Label();
            this.btnRechercher = new System.Windows.Forms.Button();
            this.labelIdBagage = new System.Windows.Forms.Label();
            this.labelCompagnie = new System.Windows.Forms.Label();
            this.textBoxPrestataire = new System.Windows.Forms.TextBox();
            this.labelLigne = new System.Windows.Forms.Label();
            this.labelDateVol = new System.Windows.Forms.Label();
            this.labelItineraire = new System.Windows.Forms.Label();
            this.labelPrioritaire = new System.Windows.Forms.Label();
            this.labelEnContinuation = new System.Windows.Forms.Label();
            this.textBoxIdBagage = new System.Windows.Forms.TextBox();
            this.textBoxCompagnie = new System.Windows.Forms.TextBox();
            this.textBoxLigne = new System.Windows.Forms.TextBox();
            this.textBoxDateVol = new System.Windows.Forms.TextBox();
            this.textBoxItineraire = new System.Windows.Forms.TextBox();
            this.textBoxPrioritaire = new System.Windows.Forms.TextBox();
            this.textBoxEnContinuation = new System.Windows.Forms.TextBox();
            this.labelResultatRecherche = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnNouveauBagage
            // 
            this.btnNouveauBagage.Location = new System.Drawing.Point(13, 14);
            this.btnNouveauBagage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnNouveauBagage.Name = "btnNouveauBagage";
            this.btnNouveauBagage.Size = new System.Drawing.Size(145, 37);
            this.btnNouveauBagage.TabIndex = 0;
            this.btnNouveauBagage.Text = "Nouveau Bagage";
            this.btnNouveauBagage.UseVisualStyleBackColor = true;
            this.btnNouveauBagage.Click += new System.EventHandler(this.btnNewBagage_Click);
            // 
            // textBoxCodeIata
            // 
            this.textBoxCodeIata.Location = new System.Drawing.Point(268, 83);
            this.textBoxCodeIata.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxCodeIata.Name = "textBoxCodeIata";
            this.textBoxCodeIata.Size = new System.Drawing.Size(122, 26);
            this.textBoxCodeIata.TabIndex = 2;
            // 
            // labelCodeIata
            // 
            this.labelCodeIata.AutoSize = true;
            this.labelCodeIata.Location = new System.Drawing.Point(13, 86);
            this.labelCodeIata.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCodeIata.Name = "labelCodeIata";
            this.labelCodeIata.Size = new System.Drawing.Size(87, 20);
            this.labelCodeIata.TabIndex = 3;
            this.labelCodeIata.Text = "Code IATA";
            // 
            // btnRechercher
            // 
            this.btnRechercher.Location = new System.Drawing.Point(419, 78);
            this.btnRechercher.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnRechercher.Name = "btnRechercher";
            this.btnRechercher.Size = new System.Drawing.Size(107, 33);
            this.btnRechercher.TabIndex = 4;
            this.btnRechercher.Text = "Rechercher";
            this.btnRechercher.UseVisualStyleBackColor = true;
            this.btnRechercher.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // labelIdBagage
            // 
            this.labelIdBagage.AutoSize = true;
            this.labelIdBagage.Location = new System.Drawing.Point(13, 169);
            this.labelIdBagage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelIdBagage.Name = "labelIdBagage";
            this.labelIdBagage.Size = new System.Drawing.Size(86, 20);
            this.labelIdBagage.TabIndex = 5;
            this.labelIdBagage.Text = "ID Bagage";
            // 
            // labelCompagnie
            // 
            this.labelCompagnie.AutoSize = true;
            this.labelCompagnie.Location = new System.Drawing.Point(13, 220);
            this.labelCompagnie.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCompagnie.Name = "labelCompagnie";
            this.labelCompagnie.Size = new System.Drawing.Size(90, 20);
            this.labelCompagnie.TabIndex = 6;
            this.labelCompagnie.Text = "Compagnie";
            // 
            // textBoxPrestataire
            // 
            this.textBoxPrestataire.Location = new System.Drawing.Point(182, 83);
            this.textBoxPrestataire.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxPrestataire.Name = "textBoxPrestataire";
            this.textBoxPrestataire.Size = new System.Drawing.Size(78, 26);
            this.textBoxPrestataire.TabIndex = 7;
            // 
            // labelLigne
            // 
            this.labelLigne.AutoSize = true;
            this.labelLigne.Location = new System.Drawing.Point(13, 270);
            this.labelLigne.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelLigne.Name = "labelLigne";
            this.labelLigne.Size = new System.Drawing.Size(48, 20);
            this.labelLigne.TabIndex = 8;
            this.labelLigne.Text = "Ligne";
            // 
            // labelDateVol
            // 
            this.labelDateVol.AutoSize = true;
            this.labelDateVol.Location = new System.Drawing.Point(13, 321);
            this.labelDateVol.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDateVol.Name = "labelDateVol";
            this.labelDateVol.Size = new System.Drawing.Size(67, 20);
            this.labelDateVol.TabIndex = 9;
            this.labelDateVol.Text = "Date vol";
            // 
            // labelItineraire
            // 
            this.labelItineraire.AutoSize = true;
            this.labelItineraire.Location = new System.Drawing.Point(13, 370);
            this.labelItineraire.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelItineraire.Name = "labelItineraire";
            this.labelItineraire.Size = new System.Drawing.Size(71, 20);
            this.labelItineraire.TabIndex = 10;
            this.labelItineraire.Text = "Itinéraire";
            // 
            // labelPrioritaire
            // 
            this.labelPrioritaire.AutoSize = true;
            this.labelPrioritaire.Location = new System.Drawing.Point(13, 419);
            this.labelPrioritaire.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPrioritaire.Name = "labelPrioritaire";
            this.labelPrioritaire.Size = new System.Drawing.Size(75, 20);
            this.labelPrioritaire.TabIndex = 11;
            this.labelPrioritaire.Text = "Prioritaire";
            // 
            // labelEnContinuation
            // 
            this.labelEnContinuation.AutoSize = true;
            this.labelEnContinuation.Location = new System.Drawing.Point(13, 466);
            this.labelEnContinuation.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelEnContinuation.Name = "labelEnContinuation";
            this.labelEnContinuation.Size = new System.Drawing.Size(120, 20);
            this.labelEnContinuation.TabIndex = 12;
            this.labelEnContinuation.Text = "En continuation";
            // 
            // textBoxIdBagage
            // 
            this.textBoxIdBagage.Location = new System.Drawing.Point(182, 166);
            this.textBoxIdBagage.Name = "textBoxIdBagage";
            this.textBoxIdBagage.Size = new System.Drawing.Size(208, 26);
            this.textBoxIdBagage.TabIndex = 13;
            // 
            // textBoxCompagnie
            // 
            this.textBoxCompagnie.Location = new System.Drawing.Point(182, 217);
            this.textBoxCompagnie.Name = "textBoxCompagnie";
            this.textBoxCompagnie.Size = new System.Drawing.Size(208, 26);
            this.textBoxCompagnie.TabIndex = 14;
            // 
            // textBoxLigne
            // 
            this.textBoxLigne.Location = new System.Drawing.Point(182, 267);
            this.textBoxLigne.Name = "textBoxLigne";
            this.textBoxLigne.Size = new System.Drawing.Size(208, 26);
            this.textBoxLigne.TabIndex = 15;
            // 
            // textBoxDateVol
            // 
            this.textBoxDateVol.Location = new System.Drawing.Point(182, 318);
            this.textBoxDateVol.Name = "textBoxDateVol";
            this.textBoxDateVol.Size = new System.Drawing.Size(208, 26);
            this.textBoxDateVol.TabIndex = 16;
            // 
            // textBoxItineraire
            // 
            this.textBoxItineraire.Location = new System.Drawing.Point(182, 367);
            this.textBoxItineraire.Name = "textBoxItineraire";
            this.textBoxItineraire.Size = new System.Drawing.Size(208, 26);
            this.textBoxItineraire.TabIndex = 17;
            // 
            // textBoxPrioritaire
            // 
            this.textBoxPrioritaire.Location = new System.Drawing.Point(182, 416);
            this.textBoxPrioritaire.Name = "textBoxPrioritaire";
            this.textBoxPrioritaire.Size = new System.Drawing.Size(208, 26);
            this.textBoxPrioritaire.TabIndex = 18;
            // 
            // textBoxEnContinuation
            // 
            this.textBoxEnContinuation.Location = new System.Drawing.Point(182, 463);
            this.textBoxEnContinuation.Name = "textBoxEnContinuation";
            this.textBoxEnContinuation.Size = new System.Drawing.Size(208, 26);
            this.textBoxEnContinuation.TabIndex = 19;
            // 
            // labelResultatRecherche
            // 
            this.labelResultatRecherche.AutoSize = true;
            this.labelResultatRecherche.Location = new System.Drawing.Point(561, 84);
            this.labelResultatRecherche.Name = "labelResultatRecherche";
            this.labelResultatRecherche.Size = new System.Drawing.Size(0, 20);
            this.labelResultatRecherche.TabIndex = 20;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 531);
            this.Controls.Add(this.labelResultatRecherche);
            this.Controls.Add(this.textBoxEnContinuation);
            this.Controls.Add(this.textBoxPrioritaire);
            this.Controls.Add(this.textBoxItineraire);
            this.Controls.Add(this.textBoxDateVol);
            this.Controls.Add(this.textBoxLigne);
            this.Controls.Add(this.textBoxCompagnie);
            this.Controls.Add(this.textBoxIdBagage);
            this.Controls.Add(this.labelEnContinuation);
            this.Controls.Add(this.labelPrioritaire);
            this.Controls.Add(this.labelItineraire);
            this.Controls.Add(this.labelDateVol);
            this.Controls.Add(this.labelLigne);
            this.Controls.Add(this.textBoxPrestataire);
            this.Controls.Add(this.labelCompagnie);
            this.Controls.Add(this.labelIdBagage);
            this.Controls.Add(this.btnRechercher);
            this.Controls.Add(this.labelCodeIata);
            this.Controls.Add(this.textBoxCodeIata);
            this.Controls.Add(this.btnNouveauBagage);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNouveauBagage;
        private System.Windows.Forms.TextBox textBoxCodeIata;
        private System.Windows.Forms.Label labelCodeIata;
        private System.Windows.Forms.Button btnRechercher;
        private System.Windows.Forms.Label labelIdBagage;
        private System.Windows.Forms.Label labelCompagnie;
        private System.Windows.Forms.TextBox textBoxPrestataire;
        private System.Windows.Forms.Label labelLigne;
        private System.Windows.Forms.Label labelDateVol;
        private System.Windows.Forms.Label labelItineraire;
        private System.Windows.Forms.Label labelPrioritaire;
        private System.Windows.Forms.Label labelEnContinuation;
        private System.Windows.Forms.TextBox textBoxIdBagage;
        private System.Windows.Forms.TextBox textBoxCompagnie;
        private System.Windows.Forms.TextBox textBoxLigne;
        private System.Windows.Forms.TextBox textBoxDateVol;
        private System.Windows.Forms.TextBox textBoxItineraire;
        private System.Windows.Forms.TextBox textBoxPrioritaire;
        private System.Windows.Forms.TextBox textBoxEnContinuation;
        private System.Windows.Forms.Label labelResultatRecherche;
    }
}

