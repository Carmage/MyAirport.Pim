namespace Client.FormIhm
{
    partial class PIM
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
            this.textBoxCodeIata = new System.Windows.Forms.TextBox();
            this.labelCodeIata = new System.Windows.Forms.Label();
            this.btnRechercher = new System.Windows.Forms.Button();
            this.groupBoxRecherche = new System.Windows.Forms.GroupBox();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuCommandes = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuReinitialiser = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelMessages = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelEtat = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBoxInformationsVol = new System.Windows.Forms.GroupBox();
            this.textBoxAlpha = new System.Windows.Forms.TextBox();
            this.labelCompagnie = new System.Windows.Forms.Label();
            this.textBoxDateVol = new System.Windows.Forms.TextBox();
            this.labelDateVol = new System.Windows.Forms.Label();
            this.labelLigne = new System.Windows.Forms.Label();
            this.textBoxCompagnie = new System.Windows.Forms.TextBox();
            this.textBoxLigne = new System.Windows.Forms.TextBox();
            this.groupBoxInformationsBagage = new System.Windows.Forms.GroupBox();
            this.btnCreer = new System.Windows.Forms.Button();
            this.checkBoxRush = new System.Windows.Forms.CheckBox();
            this.checkBoxContinuation = new System.Windows.Forms.CheckBox();
            this.labelItineraire = new System.Windows.Forms.Label();
            this.labelClasseBagage = new System.Windows.Forms.Label();
            this.textBoxItineraire = new System.Windows.Forms.TextBox();
            this.textBoxClasseBagage = new System.Windows.Forms.TextBox();
            this.groupBoxRecherche.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.groupBoxInformationsVol.SuspendLayout();
            this.groupBoxInformationsBagage.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxCodeIata
            // 
            this.textBoxCodeIata.Location = new System.Drawing.Point(124, 36);
            this.textBoxCodeIata.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxCodeIata.Name = "textBoxCodeIata";
            this.textBoxCodeIata.Size = new System.Drawing.Size(454, 26);
            this.textBoxCodeIata.TabIndex = 1;
            // 
            // labelCodeIata
            // 
            this.labelCodeIata.AutoSize = true;
            this.labelCodeIata.Location = new System.Drawing.Point(10, 39);
            this.labelCodeIata.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCodeIata.Name = "labelCodeIata";
            this.labelCodeIata.Size = new System.Drawing.Size(87, 20);
            this.labelCodeIata.TabIndex = 3;
            this.labelCodeIata.Text = "Code IATA";
            // 
            // btnRechercher
            // 
            this.btnRechercher.Location = new System.Drawing.Point(598, 33);
            this.btnRechercher.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnRechercher.Name = "btnRechercher";
            this.btnRechercher.Size = new System.Drawing.Size(107, 33);
            this.btnRechercher.TabIndex = 2;
            this.btnRechercher.Text = "Rechercher";
            this.btnRechercher.UseVisualStyleBackColor = true;
            this.btnRechercher.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // groupBoxRecherche
            // 
            this.groupBoxRecherche.Controls.Add(this.labelCodeIata);
            this.groupBoxRecherche.Controls.Add(this.textBoxCodeIata);
            this.groupBoxRecherche.Controls.Add(this.btnRechercher);
            this.groupBoxRecherche.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxRecherche.Location = new System.Drawing.Point(0, 33);
            this.groupBoxRecherche.Name = "groupBoxRecherche";
            this.groupBoxRecherche.Size = new System.Drawing.Size(736, 88);
            this.groupBoxRecherche.TabIndex = 1;
            this.groupBoxRecherche.TabStop = false;
            this.groupBoxRecherche.Text = "Recherche";
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuCommandes});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(736, 33);
            this.menuStrip.TabIndex = 23;
            this.menuStrip.Text = "menuStrip1";
            // 
            // toolStripMenuCommandes
            // 
            this.toolStripMenuCommandes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuReinitialiser});
            this.toolStripMenuCommandes.Name = "toolStripMenuCommandes";
            this.toolStripMenuCommandes.Size = new System.Drawing.Size(125, 29);
            this.toolStripMenuCommandes.Text = "Commandes";
            // 
            // toolStripMenuReinitialiser
            // 
            this.toolStripMenuReinitialiser.Name = "toolStripMenuReinitialiser";
            this.toolStripMenuReinitialiser.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.toolStripMenuReinitialiser.Size = new System.Drawing.Size(245, 30);
            this.toolStripMenuReinitialiser.Text = "Réinitialiser";
            this.toolStripMenuReinitialiser.Click += new System.EventHandler(this.toolStripMenuReinitialiser_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelMessages,
            this.toolStripStatusLabelEtat});
            this.statusStrip.Location = new System.Drawing.Point(0, 383);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(736, 37);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 24;
            // 
            // toolStripStatusLabelMessages
            // 
            this.toolStripStatusLabelMessages.AutoSize = false;
            this.toolStripStatusLabelMessages.BackColor = System.Drawing.SystemColors.Info;
            this.toolStripStatusLabelMessages.Margin = new System.Windows.Forms.Padding(2);
            this.toolStripStatusLabelMessages.Name = "toolStripStatusLabelMessages";
            this.toolStripStatusLabelMessages.Size = new System.Drawing.Size(300, 33);
            this.toolStripStatusLabelMessages.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabelEtat
            // 
            this.toolStripStatusLabelEtat.AutoSize = false;
            this.toolStripStatusLabelEtat.BackColor = System.Drawing.SystemColors.Info;
            this.toolStripStatusLabelEtat.Margin = new System.Windows.Forms.Padding(2);
            this.toolStripStatusLabelEtat.Name = "toolStripStatusLabelEtat";
            this.toolStripStatusLabelEtat.Padding = new System.Windows.Forms.Padding(1);
            this.toolStripStatusLabelEtat.Size = new System.Drawing.Size(150, 33);
            this.toolStripStatusLabelEtat.Text = "AttenteBagage";
            this.toolStripStatusLabelEtat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBoxInformationsVol
            // 
            this.groupBoxInformationsVol.Controls.Add(this.textBoxAlpha);
            this.groupBoxInformationsVol.Controls.Add(this.labelCompagnie);
            this.groupBoxInformationsVol.Controls.Add(this.textBoxDateVol);
            this.groupBoxInformationsVol.Controls.Add(this.labelDateVol);
            this.groupBoxInformationsVol.Controls.Add(this.labelLigne);
            this.groupBoxInformationsVol.Controls.Add(this.textBoxCompagnie);
            this.groupBoxInformationsVol.Controls.Add(this.textBoxLigne);
            this.groupBoxInformationsVol.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBoxInformationsVol.Location = new System.Drawing.Point(0, 121);
            this.groupBoxInformationsVol.Name = "groupBoxInformationsVol";
            this.groupBoxInformationsVol.Size = new System.Drawing.Size(357, 262);
            this.groupBoxInformationsVol.TabIndex = 2;
            this.groupBoxInformationsVol.TabStop = false;
            this.groupBoxInformationsVol.Text = "Informations Vol";
            // 
            // textBoxAlpha
            // 
            this.textBoxAlpha.Location = new System.Drawing.Point(124, 74);
            this.textBoxAlpha.Name = "textBoxAlpha";
            this.textBoxAlpha.ReadOnly = true;
            this.textBoxAlpha.Size = new System.Drawing.Size(110, 26);
            this.textBoxAlpha.TabIndex = 10;
            // 
            // labelCompagnie
            // 
            this.labelCompagnie.AutoSize = true;
            this.labelCompagnie.Location = new System.Drawing.Point(10, 31);
            this.labelCompagnie.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCompagnie.Name = "labelCompagnie";
            this.labelCompagnie.Size = new System.Drawing.Size(90, 20);
            this.labelCompagnie.TabIndex = 6;
            this.labelCompagnie.Text = "Compagnie";
            // 
            // textBoxDateVol
            // 
            this.textBoxDateVol.Location = new System.Drawing.Point(124, 126);
            this.textBoxDateVol.Name = "textBoxDateVol";
            this.textBoxDateVol.ReadOnly = true;
            this.textBoxDateVol.Size = new System.Drawing.Size(227, 26);
            this.textBoxDateVol.TabIndex = 3;
            // 
            // labelDateVol
            // 
            this.labelDateVol.AutoSize = true;
            this.labelDateVol.Location = new System.Drawing.Point(7, 129);
            this.labelDateVol.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDateVol.Name = "labelDateVol";
            this.labelDateVol.Size = new System.Drawing.Size(67, 20);
            this.labelDateVol.TabIndex = 9;
            this.labelDateVol.Text = "Date vol";
            // 
            // labelLigne
            // 
            this.labelLigne.AutoSize = true;
            this.labelLigne.Location = new System.Drawing.Point(10, 77);
            this.labelLigne.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelLigne.Name = "labelLigne";
            this.labelLigne.Size = new System.Drawing.Size(48, 20);
            this.labelLigne.TabIndex = 8;
            this.labelLigne.Text = "Ligne";
            // 
            // textBoxCompagnie
            // 
            this.textBoxCompagnie.Location = new System.Drawing.Point(124, 28);
            this.textBoxCompagnie.Name = "textBoxCompagnie";
            this.textBoxCompagnie.ReadOnly = true;
            this.textBoxCompagnie.Size = new System.Drawing.Size(227, 26);
            this.textBoxCompagnie.TabIndex = 1;
            // 
            // textBoxLigne
            // 
            this.textBoxLigne.Location = new System.Drawing.Point(241, 74);
            this.textBoxLigne.Name = "textBoxLigne";
            this.textBoxLigne.ReadOnly = true;
            this.textBoxLigne.Size = new System.Drawing.Size(110, 26);
            this.textBoxLigne.TabIndex = 2;
            // 
            // groupBoxInformationsBagage
            // 
            this.groupBoxInformationsBagage.Controls.Add(this.btnCreer);
            this.groupBoxInformationsBagage.Controls.Add(this.checkBoxRush);
            this.groupBoxInformationsBagage.Controls.Add(this.checkBoxContinuation);
            this.groupBoxInformationsBagage.Controls.Add(this.labelItineraire);
            this.groupBoxInformationsBagage.Controls.Add(this.labelClasseBagage);
            this.groupBoxInformationsBagage.Controls.Add(this.textBoxItineraire);
            this.groupBoxInformationsBagage.Controls.Add(this.textBoxClasseBagage);
            this.groupBoxInformationsBagage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxInformationsBagage.Location = new System.Drawing.Point(357, 121);
            this.groupBoxInformationsBagage.Name = "groupBoxInformationsBagage";
            this.groupBoxInformationsBagage.Size = new System.Drawing.Size(379, 262);
            this.groupBoxInformationsBagage.TabIndex = 3;
            this.groupBoxInformationsBagage.TabStop = false;
            this.groupBoxInformationsBagage.Text = "Informations Bagage";
            // 
            // btnCreer
            // 
            this.btnCreer.Location = new System.Drawing.Point(241, 218);
            this.btnCreer.Name = "btnCreer";
            this.btnCreer.Size = new System.Drawing.Size(107, 29);
            this.btnCreer.TabIndex = 12;
            this.btnCreer.Text = "Créer";
            this.btnCreer.UseVisualStyleBackColor = true;
            this.btnCreer.Click += new System.EventHandler(this.btnCreer_Click);
            // 
            // checkBoxRush
            // 
            this.checkBoxRush.AutoSize = true;
            this.checkBoxRush.Enabled = false;
            this.checkBoxRush.Location = new System.Drawing.Point(148, 165);
            this.checkBoxRush.Name = "checkBoxRush";
            this.checkBoxRush.Size = new System.Drawing.Size(73, 24);
            this.checkBoxRush.TabIndex = 4;
            this.checkBoxRush.Text = "Rush";
            this.checkBoxRush.UseVisualStyleBackColor = true;
            // 
            // checkBoxContinuation
            // 
            this.checkBoxContinuation.AutoSize = true;
            this.checkBoxContinuation.Enabled = false;
            this.checkBoxContinuation.Location = new System.Drawing.Point(149, 125);
            this.checkBoxContinuation.Name = "checkBoxContinuation";
            this.checkBoxContinuation.Size = new System.Drawing.Size(125, 24);
            this.checkBoxContinuation.TabIndex = 3;
            this.checkBoxContinuation.Text = "Continuation";
            this.checkBoxContinuation.UseVisualStyleBackColor = true;
            // 
            // labelItineraire
            // 
            this.labelItineraire.AutoSize = true;
            this.labelItineraire.Location = new System.Drawing.Point(7, 37);
            this.labelItineraire.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelItineraire.Name = "labelItineraire";
            this.labelItineraire.Size = new System.Drawing.Size(71, 20);
            this.labelItineraire.TabIndex = 10;
            this.labelItineraire.Text = "Itinéraire";
            // 
            // labelClasseBagage
            // 
            this.labelClasseBagage.AutoSize = true;
            this.labelClasseBagage.Location = new System.Drawing.Point(7, 83);
            this.labelClasseBagage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelClasseBagage.Name = "labelClasseBagage";
            this.labelClasseBagage.Size = new System.Drawing.Size(115, 20);
            this.labelClasseBagage.TabIndex = 11;
            this.labelClasseBagage.Text = "Classe bagage";
            // 
            // textBoxItineraire
            // 
            this.textBoxItineraire.Location = new System.Drawing.Point(149, 34);
            this.textBoxItineraire.Name = "textBoxItineraire";
            this.textBoxItineraire.ReadOnly = true;
            this.textBoxItineraire.Size = new System.Drawing.Size(199, 26);
            this.textBoxItineraire.TabIndex = 1;
            // 
            // textBoxClasseBagage
            // 
            this.textBoxClasseBagage.Location = new System.Drawing.Point(149, 80);
            this.textBoxClasseBagage.Name = "textBoxClasseBagage";
            this.textBoxClasseBagage.ReadOnly = true;
            this.textBoxClasseBagage.Size = new System.Drawing.Size(199, 26);
            this.textBoxClasseBagage.TabIndex = 2;
            // 
            // PIM
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(736, 420);
            this.Controls.Add(this.groupBoxInformationsBagage);
            this.Controls.Add(this.groupBoxInformationsVol);
            this.Controls.Add(this.groupBoxRecherche);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "PIM";
            this.Text = "MyAirport";
            this.groupBoxRecherche.ResumeLayout(false);
            this.groupBoxRecherche.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.groupBoxInformationsVol.ResumeLayout(false);
            this.groupBoxInformationsVol.PerformLayout();
            this.groupBoxInformationsBagage.ResumeLayout(false);
            this.groupBoxInformationsBagage.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxCodeIata;
        private System.Windows.Forms.Label labelCodeIata;
        private System.Windows.Forms.Button btnRechercher;
        // private System.Windows.Forms.Label labelResultatRecherche;
        private System.Windows.Forms.GroupBox groupBoxRecherche;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuCommandes;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuReinitialiser;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelMessages;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelEtat;
        private System.Windows.Forms.GroupBox groupBoxInformationsVol;
        private System.Windows.Forms.Label labelCompagnie;
        private System.Windows.Forms.TextBox textBoxDateVol;
        private System.Windows.Forms.Label labelDateVol;
        private System.Windows.Forms.Label labelLigne;
        private System.Windows.Forms.TextBox textBoxCompagnie;
        private System.Windows.Forms.TextBox textBoxLigne;
        private System.Windows.Forms.GroupBox groupBoxInformationsBagage;
        private System.Windows.Forms.Label labelItineraire;
        private System.Windows.Forms.Label labelClasseBagage;
        private System.Windows.Forms.TextBox textBoxItineraire;
        private System.Windows.Forms.TextBox textBoxClasseBagage;
        private System.Windows.Forms.CheckBox checkBoxRush;
        private System.Windows.Forms.CheckBox checkBoxContinuation;
        private System.Windows.Forms.TextBox textBoxAlpha;
        private System.Windows.Forms.Button btnCreer;
    }
}

