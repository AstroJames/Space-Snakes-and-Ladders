namespace GUI_Class
{
    partial class SpaceRaceForm
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
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.playersDataGridView = new System.Windows.Forms.DataGridView();
            this.playerTokenImageDataGridViewImageColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.positionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rocketFuelDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.playerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rollButton = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
            this.GroupBox = new System.Windows.Forms.GroupBox();
            this.noButton = new System.Windows.Forms.RadioButton();
            this.yesButton = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.numOfPlayersInput = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.titleLabel = new System.Windows.Forms.Label();
            this.exitButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.playersDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerBindingSource)).BeginInit();
            this.GroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.playersDataGridView);
            this.splitContainer1.Panel2.Controls.Add(this.rollButton);
            this.splitContainer1.Panel2.Controls.Add(this.resetButton);
            this.splitContainer1.Panel2.Controls.Add(this.GroupBox);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.numOfPlayersInput);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.titleLabel);
            this.splitContainer1.Panel2.Controls.Add(this.exitButton);
            this.splitContainer1.Size = new System.Drawing.Size(884, 661);
            this.splitContainer1.SplitterDistance = 661;
            this.splitContainer1.TabIndex = 0;
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.AutoSize = true;
            this.tableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel.ColumnCount = 8;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 7;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(661, 661);
            this.tableLayoutPanel.TabIndex = 0;
            this.tableLayoutPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel_Paint);
            // 
            // playersDataGridView
            // 
            this.playersDataGridView.AllowUserToAddRows = false;
            this.playersDataGridView.AllowUserToDeleteRows = false;
            this.playersDataGridView.AutoGenerateColumns = false;
            this.playersDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.playersDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.playerTokenImageDataGridViewImageColumn,
            this.nameDataGridViewTextBoxColumn,
            this.positionDataGridViewTextBoxColumn,
            this.rocketFuelDataGridViewTextBoxColumn});
            this.playersDataGridView.DataSource = this.playerBindingSource;
            this.playersDataGridView.Location = new System.Drawing.Point(3, 190);
            this.playersDataGridView.Name = "playersDataGridView";
            this.playersDataGridView.RowHeadersVisible = false;
            this.playersDataGridView.Size = new System.Drawing.Size(210, 174);
            this.playersDataGridView.TabIndex = 8;
            // 
            // playerTokenImageDataGridViewImageColumn
            // 
            this.playerTokenImageDataGridViewImageColumn.DataPropertyName = "PlayerTokenImage";
            this.playerTokenImageDataGridViewImageColumn.HeaderText = "";
            this.playerTokenImageDataGridViewImageColumn.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.playerTokenImageDataGridViewImageColumn.Name = "playerTokenImageDataGridViewImageColumn";
            this.playerTokenImageDataGridViewImageColumn.ReadOnly = true;
            this.playerTokenImageDataGridViewImageColumn.Width = 20;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // positionDataGridViewTextBoxColumn
            // 
            this.positionDataGridViewTextBoxColumn.DataPropertyName = "Position";
            this.positionDataGridViewTextBoxColumn.HeaderText = "Square";
            this.positionDataGridViewTextBoxColumn.Name = "positionDataGridViewTextBoxColumn";
            this.positionDataGridViewTextBoxColumn.Width = 50;
            // 
            // rocketFuelDataGridViewTextBoxColumn
            // 
            this.rocketFuelDataGridViewTextBoxColumn.DataPropertyName = "RocketFuel";
            this.rocketFuelDataGridViewTextBoxColumn.HeaderText = "Fuel";
            this.rocketFuelDataGridViewTextBoxColumn.Name = "rocketFuelDataGridViewTextBoxColumn";
            this.rocketFuelDataGridViewTextBoxColumn.Width = 50;
            // 
            // playerBindingSource
            // 
            this.playerBindingSource.DataSource = typeof(Object_Classes.Player);
            // 
            // rollButton
            // 
            this.rollButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rollButton.Enabled = false;
            this.rollButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rollButton.Location = new System.Drawing.Point(64, 572);
            this.rollButton.Name = "rollButton";
            this.rollButton.Size = new System.Drawing.Size(75, 23);
            this.rollButton.TabIndex = 7;
            this.rollButton.Text = "Roll Dice";
            this.rollButton.UseVisualStyleBackColor = true;
            this.rollButton.Click += new System.EventHandler(this.rollButton_Click);
            // 
            // resetButton
            // 
            this.resetButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.resetButton.Enabled = false;
            this.resetButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resetButton.Location = new System.Drawing.Point(10, 611);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(85, 23);
            this.resetButton.TabIndex = 6;
            this.resetButton.Text = "Game Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // GroupBox
            // 
            this.GroupBox.BackColor = System.Drawing.SystemColors.ControlDark;
            this.GroupBox.Controls.Add(this.noButton);
            this.GroupBox.Controls.Add(this.yesButton);
            this.GroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBox.Location = new System.Drawing.Point(39, 423);
            this.GroupBox.Name = "GroupBox";
            this.GroupBox.Size = new System.Drawing.Size(140, 55);
            this.GroupBox.TabIndex = 5;
            this.GroupBox.TabStop = false;
            this.GroupBox.Text = "Single Step?";
            // 
            // noButton
            // 
            this.noButton.AutoSize = true;
            this.noButton.Location = new System.Drawing.Point(84, 21);
            this.noButton.Name = "noButton";
            this.noButton.Size = new System.Drawing.Size(41, 17);
            this.noButton.TabIndex = 1;
            this.noButton.Text = "No";
            this.noButton.UseVisualStyleBackColor = true;
            this.noButton.Click += new System.EventHandler(this.noButton_Click);
            // 
            // yesButton
            // 
            this.yesButton.AutoSize = true;
            this.yesButton.Location = new System.Drawing.Point(32, 21);
            this.yesButton.Name = "yesButton";
            this.yesButton.Size = new System.Drawing.Size(46, 17);
            this.yesButton.TabIndex = 0;
            this.yesButton.Text = "Yes";
            this.yesButton.UseVisualStyleBackColor = true;
            this.yesButton.Click += new System.EventHandler(this.yesButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(58, 162);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Players";
            // 
            // numOfPlayersInput
            // 
            this.numOfPlayersInput.FormattingEnabled = true;
            this.numOfPlayersInput.Items.AddRange(new object[] {
            "2",
            "3",
            "4",
            "5",
            "6"});
            this.numOfPlayersInput.Location = new System.Drawing.Point(144, 94);
            this.numOfPlayersInput.Name = "numOfPlayersInput";
            this.numOfPlayersInput.Size = new System.Drawing.Size(35, 21);
            this.numOfPlayersInput.TabIndex = 3;
            this.numOfPlayersInput.Text = "6";
            this.numOfPlayersInput.SelectedIndexChanged += new System.EventHandler(this.numOfPlayersInput_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Number of Players:";
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(32, 27);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(139, 25);
            this.titleLabel.TabIndex = 1;
            this.titleLabel.Text = "Space Race";
            // 
            // exitButton
            // 
            this.exitButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.exitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitButton.Location = new System.Drawing.Point(109, 611);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(85, 23);
            this.exitButton.TabIndex = 0;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // SpaceRaceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 661);
            this.Controls.Add(this.splitContainer1);
            this.Name = "SpaceRaceForm";
            this.Text = "Space Race";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.playersDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerBindingSource)).EndInit();
            this.GroupBox.ResumeLayout(false);
            this.GroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.DataGridView playersDataGridView;
        private System.Windows.Forms.DataGridViewImageColumn playerTokenImageDataGridViewImageColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn positionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rocketFuelDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource playerBindingSource;
        private System.Windows.Forms.Button rollButton;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.GroupBox GroupBox;
        private System.Windows.Forms.RadioButton noButton;
        private System.Windows.Forms.RadioButton yesButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox numOfPlayersInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label titleLabel;
    }
}

