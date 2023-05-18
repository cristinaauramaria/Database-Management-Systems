namespace WF_App_222_2023
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            dataGridViewParent = new DataGridView();
            labelParent = new Label();
            dataGridViewChild = new DataGridView();
            labelChild = new Label();
            Delete = new Button();
            textNume = new TextBox();
            label1 = new Label();
            label2 = new Label();
            textCnp = new TextBox();
            Add = new Button();
            Update = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewParent).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewChild).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewParent
            // 
            dataGridViewParent.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewParent.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewParent.Location = new Point(101, 113);
            dataGridViewParent.Margin = new Padding(4);
            dataGridViewParent.Name = "dataGridViewParent";
            dataGridViewParent.RowHeadersWidth = 51;
            dataGridViewParent.RowTemplate.Height = 29;
            dataGridViewParent.Size = new Size(425, 421);
            dataGridViewParent.TabIndex = 0;
            dataGridViewParent.CellClick += dataGridViewParent_CellClick;
            // 
            // labelParent
            // 
            labelParent.AutoSize = true;
            labelParent.BackColor = Color.DarkSlateBlue;
            labelParent.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            labelParent.ForeColor = SystemColors.ButtonHighlight;
            labelParent.Location = new Point(221, 71);
            labelParent.Margin = new Padding(4, 0, 4, 0);
            labelParent.Name = "labelParent";
            labelParent.Size = new Size(208, 38);
            labelParent.TabIndex = 1;
            labelParent.Text = "Tabelul Functii";
            // 
            // dataGridViewChild
            // 
            dataGridViewChild.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewChild.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewChild.Location = new Point(633, 113);
            dataGridViewChild.Margin = new Padding(4);
            dataGridViewChild.Name = "dataGridViewChild";
            dataGridViewChild.RowHeadersWidth = 51;
            dataGridViewChild.RowTemplate.Height = 29;
            dataGridViewChild.Size = new Size(527, 247);
            dataGridViewChild.TabIndex = 2;
            // 
            // labelChild
            // 
            labelChild.AutoSize = true;
            labelChild.BackColor = Color.DarkSlateBlue;
            labelChild.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            labelChild.ForeColor = SystemColors.ButtonHighlight;
            labelChild.Location = new Point(834, 71);
            labelChild.Margin = new Padding(4, 0, 4, 0);
            labelChild.Name = "labelChild";
            labelChild.Size = new Size(230, 38);
            labelChild.TabIndex = 3;
            labelChild.Text = "Tabelul Angajati";
            // 
            // Delete
            // 
            Delete.BackColor = Color.DarkSlateBlue;
            Delete.FlatStyle = FlatStyle.Flat;
            Delete.ForeColor = SystemColors.ButtonHighlight;
            Delete.Location = new Point(894, 500);
            Delete.Name = "Delete";
            Delete.Size = new Size(112, 34);
            Delete.TabIndex = 5;
            Delete.Text = "Delete";
            Delete.UseVisualStyleBackColor = false;
            Delete.Click += Delete_Click;
            // 
            // textNume
            // 
            textNume.Location = new Point(834, 377);
            textNume.Name = "textNume";
            textNume.Size = new Size(262, 31);
            textNume.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.DarkSlateBlue;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(734, 383);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(73, 25);
            label1.TabIndex = 7;
            label1.Text = "Nume: ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.DarkSlateBlue;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = SystemColors.ButtonHighlight;
            label2.Location = new Point(734, 432);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(55, 25);
            label2.TabIndex = 9;
            label2.Text = "Cnp: ";
            // 
            // textCnp
            // 
            textCnp.Location = new Point(834, 426);
            textCnp.Name = "textCnp";
            textCnp.Size = new Size(262, 31);
            textCnp.TabIndex = 8;
            // 
            // Add
            // 
            Add.BackColor = Color.DarkSlateBlue;
            Add.FlatStyle = FlatStyle.Flat;
            Add.ForeColor = SystemColors.ButtonHighlight;
            Add.Location = new Point(734, 500);
            Add.Name = "Add";
            Add.Size = new Size(112, 34);
            Add.TabIndex = 10;
            Add.Text = "Add";
            Add.UseVisualStyleBackColor = false;
            Add.Click += Add_Click;
            // 
            // Update
            // 
            Update.BackColor = Color.DarkSlateBlue;
            Update.FlatStyle = FlatStyle.Flat;
            Update.ForeColor = SystemColors.ButtonHighlight;
            Update.Location = new Point(1048, 500);
            Update.Name = "Update";
            Update.Size = new Size(112, 34);
            Update.TabIndex = 11;
            Update.Text = "Update";
            Update.UseVisualStyleBackColor = false;
            Update.Click += Update_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Teal;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1265, 622);
            Controls.Add(Update);
            Controls.Add(Add);
            Controls.Add(label2);
            Controls.Add(textCnp);
            Controls.Add(label1);
            Controls.Add(textNume);
            Controls.Add(Delete);
            Controls.Add(labelChild);
            Controls.Add(dataGridViewChild);
            Controls.Add(labelParent);
            Controls.Add(dataGridViewParent);
            Margin = new Padding(4);
            Name = "Form1";
            Text = "Aplicatie Windows Forms 222";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewParent).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewChild).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewParent;
        private Label labelParent;
        private DataGridView dataGridViewChild;
        private Label labelChild;
        private Button Delete;
        private TextBox textNume;
        private Label label1;
        private Label label2;
        private TextBox textCnp;
        private Button Add;
        private Button Update;
    }
}