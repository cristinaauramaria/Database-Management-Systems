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
            Add = new Button();
            Update = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
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
            dataGridViewChild.Location = new Point(734, 113);
            dataGridViewChild.Margin = new Padding(4);
            dataGridViewChild.Name = "dataGridViewChild";
            dataGridViewChild.RowHeadersWidth = 51;
            dataGridViewChild.RowTemplate.Height = 29;
            dataGridViewChild.Size = new Size(518, 247);
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
            Delete.Location = new Point(894, 550);
            Delete.Name = "Delete";
            Delete.Size = new Size(112, 34);
            Delete.TabIndex = 5;
            Delete.Text = "Delete";
            Delete.UseVisualStyleBackColor = false;
            Delete.Click += Delete_Click;
            // 
            // Add
            // 
            Add.BackColor = Color.DarkSlateBlue;
            Add.FlatStyle = FlatStyle.Flat;
            Add.ForeColor = SystemColors.ButtonHighlight;
            Add.Location = new Point(734, 550);
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
            Update.Location = new Point(1048, 550);
            Update.Name = "Update";
            Update.Size = new Size(112, 34);
            Update.TabIndex = 11;
            Update.Text = "Update";
            Update.UseVisualStyleBackColor = false;
            Update.Click += Update_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = Color.FromArgb(128, 128, 255);
            flowLayoutPanel1.Location = new Point(734, 367);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(301, 167);
            flowLayoutPanel1.TabIndex = 12;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Teal;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1265, 622);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(Update);
            Controls.Add(Add);
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
        private Button Add;
        private Button Update;
        private FlowLayoutPanel flowLayoutPanel1;
    }
}