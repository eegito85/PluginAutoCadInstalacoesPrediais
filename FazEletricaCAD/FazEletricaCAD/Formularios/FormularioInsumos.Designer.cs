namespace FazEletricaCAD.Formularios
{
    partial class FormularioInsumos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormularioInsumos));
            this.BtInserirInsumosE = new System.Windows.Forms.Button();
            this.ListBoxInsumosE = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ComboBoxInsumosE = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PictureBoxEletrica = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxEletrica)).BeginInit();
            this.SuspendLayout();
            // 
            // BtInserirInsumosE
            // 
            this.BtInserirInsumosE.BackColor = System.Drawing.SystemColors.Control;
            this.BtInserirInsumosE.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtInserirInsumosE.Location = new System.Drawing.Point(13, 464);
            this.BtInserirInsumosE.Name = "BtInserirInsumosE";
            this.BtInserirInsumosE.Size = new System.Drawing.Size(200, 23);
            this.BtInserirInsumosE.TabIndex = 11;
            this.BtInserirInsumosE.Text = "Inserir";
            this.BtInserirInsumosE.UseVisualStyleBackColor = false;
            this.BtInserirInsumosE.Click += new System.EventHandler(this.BtInserirInsumosE_Click);
            // 
            // ListBoxInsumosE
            // 
            this.ListBoxInsumosE.FormattingEnabled = true;
            this.ListBoxInsumosE.Location = new System.Drawing.Point(13, 259);
            this.ListBoxInsumosE.Name = "ListBoxInsumosE";
            this.ListBoxInsumosE.Size = new System.Drawing.Size(200, 199);
            this.ListBoxInsumosE.TabIndex = 10;
            this.ListBoxInsumosE.SelectedIndexChanged += new System.EventHandler(this.ListBoxInsumosE_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 240);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 14);
            this.label2.TabIndex = 9;
            this.label2.Text = "Itens:";
            // 
            // ComboBoxInsumosE
            // 
            this.ComboBoxInsumosE.FormattingEnabled = true;
            this.ComboBoxInsumosE.Location = new System.Drawing.Point(13, 206);
            this.ComboBoxInsumosE.Name = "ComboBoxInsumosE";
            this.ComboBoxInsumosE.Size = new System.Drawing.Size(200, 21);
            this.ComboBoxInsumosE.TabIndex = 8;
            this.ComboBoxInsumosE.SelectedIndexChanged += new System.EventHandler(this.ComboBoxInsumosE_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 186);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 14);
            this.label1.TabIndex = 7;
            this.label1.Text = "Categoria:";
            // 
            // PictureBoxEletrica
            // 
            this.PictureBoxEletrica.Location = new System.Drawing.Point(13, 10);
            this.PictureBoxEletrica.Name = "PictureBoxEletrica";
            this.PictureBoxEletrica.Size = new System.Drawing.Size(200, 160);
            this.PictureBoxEletrica.TabIndex = 6;
            this.PictureBoxEletrica.TabStop = false;
            // 
            // FormularioInsumos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(226, 497);
            this.Controls.Add(this.BtInserirInsumosE);
            this.Controls.Add(this.ListBoxInsumosE);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ComboBoxInsumosE);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PictureBoxEletrica);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(242, 536);
            this.MinimumSize = new System.Drawing.Size(242, 536);
            this.Name = "FormularioInsumos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Insumos";
            this.Load += new System.EventHandler(this.FormularioInsumos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxEletrica)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtInserirInsumosE;
        private System.Windows.Forms.ListBox ListBoxInsumosE;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox ComboBoxInsumosE;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox PictureBoxEletrica;
    }
}