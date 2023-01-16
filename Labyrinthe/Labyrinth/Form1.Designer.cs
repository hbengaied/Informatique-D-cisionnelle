namespace Labyrinth
{
    partial class frmLabyrinth
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
            this.components = new System.ComponentModel.Container();
            this.picGameBoard = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox = new System.Windows.Forms.ComboBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.textBoxdeep = new System.Windows.Forms.TextBox();
            this.labeldeep = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labeltemps = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picGameBoard)).BeginInit();
            this.SuspendLayout();
            // 
            // picGameBoard
            // 
            this.picGameBoard.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.picGameBoard.Location = new System.Drawing.Point(315, 1);
            this.picGameBoard.Name = "picGameBoard";
            this.picGameBoard.Size = new System.Drawing.Size(620, 620);
            this.picGameBoard.TabIndex = 0;
            this.picGameBoard.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 37);
            this.label1.TabIndex = 1;
            this.label1.Text = "Labyrinthe";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(22, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(168, 31);
            this.label2.TabIndex = 2;
            this.label2.Text = "Algorithmes";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(53, 263);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 32);
            this.button1.TabIndex = 3;
            this.button1.Text = "Lancer";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Lunch_Button_Clicked);
            // 
            // comboBox
            // 
            this.comboBox.FormattingEnabled = true;
            this.comboBox.Items.AddRange(new object[] {
            "DFS",
            "Iterative Deepening",
            "Greedy Search",
            "Hill Climbing",
            "A*"});
            this.comboBox.Location = new System.Drawing.Point(23, 135);
            this.comboBox.Name = "comboBox";
            this.comboBox.Size = new System.Drawing.Size(162, 21);
            this.comboBox.TabIndex = 4;
            // 
            // timer
            // 
            this.timer.Interval = 10;
            this.timer.Tick += new System.EventHandler(this.Timer_tick_event);
            // 
            // textBoxdeep
            // 
            this.textBoxdeep.Location = new System.Drawing.Point(53, 221);
            this.textBoxdeep.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxdeep.Name = "textBoxdeep";
            this.textBoxdeep.Size = new System.Drawing.Size(98, 20);
            this.textBoxdeep.TabIndex = 5;
            // 
            // labeldeep
            // 
            this.labeldeep.AutoSize = true;
            this.labeldeep.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labeldeep.Location = new System.Drawing.Point(22, 178);
            this.labeldeep.Name = "labeldeep";
            this.labeldeep.Size = new System.Drawing.Size(158, 31);
            this.labeldeep.TabIndex = 6;
            this.labeldeep.Text = "Profondeur";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(17, 348);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 31);
            this.label3.TabIndex = 7;
            this.label3.Text = "Temps :";
            // 
            // labeltemps
            // 
            this.labeltemps.AutoSize = true;
            this.labeltemps.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labeltemps.Location = new System.Drawing.Point(17, 396);
            this.labeltemps.Name = "labeltemps";
            this.labeltemps.Size = new System.Drawing.Size(169, 31);
            this.labeltemps.TabIndex = 8;
            this.labeltemps.Text = "00.00.00.00";
            // 
            // frmLabyrinth
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1027, 549);
            this.Controls.Add(this.labeltemps);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labeldeep);
            this.Controls.Add(this.textBoxdeep);
            this.Controls.Add(this.comboBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picGameBoard);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmLabyrinth";
            this.Text = "Labyrinth";
            this.Load += new System.EventHandler(this.frmLabyrinth_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picGameBoard)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picGameBoard;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.TextBox textBoxdeep;
        private System.Windows.Forms.Label labeldeep;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labeltemps;
    }
}

