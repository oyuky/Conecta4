namespace Conecta4.WinForm
{
    partial class Inicio
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
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lkbContnuar = new System.Windows.Forms.LinkLabel();
            this.label5 = new System.Windows.Forms.Label();
            this.lblResult = new System.Windows.Forms.Label();
            this.lblDadosJugador2 = new System.Windows.Forms.Label();
            this.lblDadosJugador1 = new System.Windows.Forms.Label();
            this.btnJugador2 = new System.Windows.Forms.Button();
            this.btnJugador1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(424, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Para iniciar es necesario determinar quien tendra el primer turno..";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lkbContnuar);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lblResult);
            this.groupBox1.Controls.Add(this.lblDadosJugador2);
            this.groupBox1.Controls.Add(this.lblDadosJugador1);
            this.groupBox1.Controls.Add(this.btnJugador2);
            this.groupBox1.Controls.Add(this.btnJugador1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(435, 198);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bienvenid@s!";
            // 
            // lkbContnuar
            // 
            this.lkbContnuar.AutoSize = true;
            this.lkbContnuar.Location = new System.Drawing.Point(339, 166);
            this.lkbContnuar.Name = "lkbContnuar";
            this.lkbContnuar.Size = new System.Drawing.Size(69, 17);
            this.lkbContnuar.TabIndex = 10;
            this.lkbContnuar.TabStop = true;
            this.lkbContnuar.Text = "Continuar";
            this.lkbContnuar.Visible = false;
            this.lkbContnuar.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lkbContnuar_LinkClicked);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(338, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "De un clic sobre sobre cada boton para tirar dados..";
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(6, 166);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(0, 17);
            this.lblResult.TabIndex = 8;
            // 
            // lblDadosJugador2
            // 
            this.lblDadosJugador2.AutoSize = true;
            this.lblDadosJugador2.Location = new System.Drawing.Point(223, 129);
            this.lblDadosJugador2.Name = "lblDadosJugador2";
            this.lblDadosJugador2.Size = new System.Drawing.Size(0, 17);
            this.lblDadosJugador2.TabIndex = 5;
            this.lblDadosJugador2.TextChanged += new System.EventHandler(this.VerificarDados_TextChanged);
            // 
            // lblDadosJugador1
            // 
            this.lblDadosJugador1.AutoSize = true;
            this.lblDadosJugador1.Location = new System.Drawing.Point(66, 129);
            this.lblDadosJugador1.Name = "lblDadosJugador1";
            this.lblDadosJugador1.Size = new System.Drawing.Size(0, 17);
            this.lblDadosJugador1.TabIndex = 4;
            this.lblDadosJugador1.TextChanged += new System.EventHandler(this.VerificarDados_TextChanged);
            // 
            // btnJugador2
            // 
            this.btnJugador2.Location = new System.Drawing.Point(226, 89);
            this.btnJugador2.Name = "btnJugador2";
            this.btnJugador2.Size = new System.Drawing.Size(89, 37);
            this.btnJugador2.TabIndex = 3;
            this.btnJugador2.Text = "Jugador 2";
            this.btnJugador2.UseVisualStyleBackColor = true;
            this.btnJugador2.Click += new System.EventHandler(this.btnJugador2_Click);
            // 
            // btnJugador1
            // 
            this.btnJugador1.Location = new System.Drawing.Point(69, 89);
            this.btnJugador1.Name = "btnJugador1";
            this.btnJugador1.Size = new System.Drawing.Size(89, 37);
            this.btnJugador1.TabIndex = 2;
            this.btnJugador1.Text = "Jugador 1";
            this.btnJugador1.UseVisualStyleBackColor = true;
            this.btnJugador1.Click += new System.EventHandler(this.btnJugador1_Click);
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 223);
            this.Controls.Add(this.groupBox1);
            this.Name = "Inicio";
            this.Text = "Inicio";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.LinkLabel lkbContnuar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Label lblDadosJugador2;
        private System.Windows.Forms.Label lblDadosJugador1;
        private System.Windows.Forms.Button btnJugador2;
        private System.Windows.Forms.Button btnJugador1;
    }
}