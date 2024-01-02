using System.Windows.Forms;

namespace ColorPop
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBefore = new System.Windows.Forms.PictureBox();
            this.pictureAfter = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.threadsNumber = new System.Windows.Forms.TrackBar();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Cpp = new System.Windows.Forms.RadioButton();
            this.ASM = new System.Windows.Forms.RadioButton();
            this.loadButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.time = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBefore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureAfter)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.threadsNumber)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBefore
            // 
            this.pictureBefore.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBefore.Location = new System.Drawing.Point(48, 12);
            this.pictureBefore.Name = "pictureBefore";
            this.pictureBefore.Size = new System.Drawing.Size(500, 350);
            this.pictureBefore.TabIndex = 0;
            this.pictureBefore.TabStop = false;
            //this.pictureBefore.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            // 
            // pictureAfter
            // 
            this.pictureAfter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureAfter.Location = new System.Drawing.Point(923, 12);
            this.pictureAfter.Name = "pictureAfter";
            this.pictureAfter.Size = new System.Drawing.Size(500, 350);
            this.pictureAfter.TabIndex = 1;
            this.pictureAfter.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.threadsNumber);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupBox1.Location = new System.Drawing.Point(48, 368);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1375, 128);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Number Of Threads";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(685, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 29);
            this.label4.TabIndex = 1;
            this.label4.Text = this.threadsNumber.Value.ToString();
            // 
            // threadsNumber
            // 
            this.threadsNumber.Location = new System.Drawing.Point(6, 66);
            this.threadsNumber.Maximum = 64;
            this.threadsNumber.Minimum = 1;
            this.threadsNumber.Name = "threadsNumber";
            this.threadsNumber.Size = new System.Drawing.Size(1363, 56);
            this.threadsNumber.TabIndex = 0;
            this.threadsNumber.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.threadsNumber.Value = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Cpp);
            this.groupBox2.Controls.Add(this.ASM);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupBox2.Location = new System.Drawing.Point(48, 513);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(264, 207);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Implementation";
            // 
            // Cpp
            // 
            this.Cpp.AutoSize = true;
            this.Cpp.Location = new System.Drawing.Point(27, 130);
            this.Cpp.Name = "Cpp";
            this.Cpp.Size = new System.Drawing.Size(79, 33);
            this.Cpp.TabIndex = 1;
            this.Cpp.TabStop = true;
            this.Cpp.Text = "C++";
            this.Cpp.UseVisualStyleBackColor = true;
            // 
            // ASM
            // 
            this.ASM.AutoSize = true;
            this.ASM.Location = new System.Drawing.Point(27, 58);
            this.ASM.Name = "ASM";
            this.ASM.Size = new System.Drawing.Size(149, 33);
            this.ASM.TabIndex = 0;
            this.ASM.TabStop = true;
            this.ASM.Text = "Assembler";
            this.ASM.UseVisualStyleBackColor = true;
            // 
            // loadButton
            // 
            this.loadButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.loadButton.Location = new System.Drawing.Point(381, 549);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(167, 55);
            this.loadButton.TabIndex = 4;
            this.loadButton.Text = "Import BMP";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.LoadButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.saveButton.Location = new System.Drawing.Point(381, 643);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(167, 56);
            this.saveButton.TabIndex = 5;
            this.saveButton.Text = "Save Image";
            this.saveButton.UseVisualStyleBackColor = true;
            // 
            // startButton
            // 
            this.startButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.startButton.Location = new System.Drawing.Point(923, 643);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(132, 56);
            this.startButton.TabIndex = 6;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(923, 538);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 29);
            this.label1.TabIndex = 7;
            this.label1.Text = "Time:";
            // 
            // time
            // 
            this.time.AutoSize = true;
            this.time.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.time.Location = new System.Drawing.Point(1024, 538);
            this.time.Name = "time";
            this.time.Size = new System.Drawing.Size(31, 29);
            this.time.TabIndex = 8;
            this.time.Text = "...";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(661, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(174, 29);
            this.label3.TabIndex = 9;
            this.label3.Text = "Selected Color";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(641, 340);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(223, 22);
            this.textBox1.TabIndex = 10;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(688, 184);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(124, 65);
            this.panel1.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1482, 753);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.time);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureAfter);
            this.Controls.Add(this.pictureBefore);
            this.Name = "Form1";
            this.Text = "ColorPop";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBefore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureAfter)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.threadsNumber)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBefore;
        private System.Windows.Forms.PictureBox pictureAfter;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TrackBar threadsNumber;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton Cpp;
        private System.Windows.Forms.RadioButton ASM;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label time;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
    }
}

