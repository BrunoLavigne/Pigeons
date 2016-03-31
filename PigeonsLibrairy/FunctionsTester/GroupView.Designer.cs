namespace FunctionsTester
{
    partial class GroupView
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtGroupID = new System.Windows.Forms.TextBox();
            this.txtgroupName = new System.Windows.Forms.TextBox();
            this.txtGroupDesc = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cb_followers = new System.Windows.Forms.ComboBox();
            this.followerNb = new System.Windows.Forms.TextBox();
            this.followerID = new System.Windows.Forms.TextBox();
            this.dataGrid_messages = new System.Windows.Forms.DataGridView();
            this.Auteur_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Author_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Content = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date_Created = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtMessageContent = new System.Windows.Forms.RichTextBox();
            this.btnCreateMessage = new System.Windows.Forms.Button();
            this.messageResult = new System.Windows.Forms.TextBox();
            this.btnDeleteFollower = new System.Windows.Forms.Button();
            this.txtRemoveFollowerResult = new System.Windows.Forms.TextBox();
            this.btnCloseGroup = new System.Windows.Forms.Button();
            this.txtGroupCloseResult = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_messages)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(74, 98);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Groupe name :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(104, 40);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Groupe ID :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 153);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(206, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Groupe description :";
            // 
            // txtGroupID
            // 
            this.txtGroupID.Enabled = false;
            this.txtGroupID.Location = new System.Drawing.Point(240, 33);
            this.txtGroupID.Margin = new System.Windows.Forms.Padding(6);
            this.txtGroupID.Name = "txtGroupID";
            this.txtGroupID.Size = new System.Drawing.Size(300, 31);
            this.txtGroupID.TabIndex = 3;
            // 
            // txtgroupName
            // 
            this.txtgroupName.Enabled = false;
            this.txtgroupName.Location = new System.Drawing.Point(240, 90);
            this.txtgroupName.Margin = new System.Windows.Forms.Padding(6);
            this.txtgroupName.Name = "txtgroupName";
            this.txtgroupName.Size = new System.Drawing.Size(300, 31);
            this.txtgroupName.TabIndex = 4;
            // 
            // txtGroupDesc
            // 
            this.txtGroupDesc.Enabled = false;
            this.txtGroupDesc.Location = new System.Drawing.Point(240, 150);
            this.txtGroupDesc.Margin = new System.Windows.Forms.Padding(6);
            this.txtGroupDesc.Name = "txtGroupDesc";
            this.txtGroupDesc.Size = new System.Drawing.Size(300, 31);
            this.txtGroupDesc.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(618, 40);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 25);
            this.label4.TabIndex = 6;
            this.label4.Text = "Followers :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(682, 98);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 25);
            this.label5.TabIndex = 7;
            this.label5.Text = "nb :";
            // 
            // cb_followers
            // 
            this.cb_followers.FormattingEnabled = true;
            this.cb_followers.Location = new System.Drawing.Point(744, 33);
            this.cb_followers.Margin = new System.Windows.Forms.Padding(6);
            this.cb_followers.Name = "cb_followers";
            this.cb_followers.Size = new System.Drawing.Size(328, 33);
            this.cb_followers.TabIndex = 8;
            this.cb_followers.SelectedIndexChanged += new System.EventHandler(this.cb_followers_SelectedIndexChanged);
            // 
            // followerNb
            // 
            this.followerNb.Enabled = false;
            this.followerNb.Location = new System.Drawing.Point(744, 90);
            this.followerNb.Margin = new System.Windows.Forms.Padding(6);
            this.followerNb.Name = "followerNb";
            this.followerNb.Size = new System.Drawing.Size(328, 31);
            this.followerNb.TabIndex = 9;
            // 
            // followerID
            // 
            this.followerID.Enabled = false;
            this.followerID.Location = new System.Drawing.Point(1088, 33);
            this.followerID.Margin = new System.Windows.Forms.Padding(6);
            this.followerID.Name = "followerID";
            this.followerID.Size = new System.Drawing.Size(70, 31);
            this.followerID.TabIndex = 10;
            // 
            // dataGrid_messages
            // 
            this.dataGrid_messages.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGrid_messages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid_messages.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Auteur_ID,
            this.Author_Name,
            this.Content,
            this.Date_Created});
            this.dataGrid_messages.Location = new System.Drawing.Point(30, 277);
            this.dataGrid_messages.Margin = new System.Windows.Forms.Padding(6);
            this.dataGrid_messages.Name = "dataGrid_messages";
            this.dataGrid_messages.Size = new System.Drawing.Size(1568, 475);
            this.dataGrid_messages.TabIndex = 11;
            // 
            // Auteur_ID
            // 
            this.Auteur_ID.HeaderText = "Auteur_ID";
            this.Auteur_ID.Name = "Auteur_ID";
            // 
            // Author_Name
            // 
            this.Author_Name.HeaderText = "Author_Name";
            this.Author_Name.Name = "Author_Name";
            // 
            // Content
            // 
            this.Content.HeaderText = "Content";
            this.Content.Name = "Content";
            // 
            // Date_Created
            // 
            this.Date_Created.HeaderText = "Date_Created";
            this.Date_Created.Name = "Date_Created";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(760, 246);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(111, 25);
            this.label6.TabIndex = 12;
            this.label6.Text = "Messages";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(30, 931);
            this.button1.Margin = new System.Windows.Forms.Padding(6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 44);
            this.button1.TabIndex = 13;
            this.button1.Text = "close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtUserID
            // 
            this.txtUserID.Enabled = false;
            this.txtUserID.Location = new System.Drawing.Point(1382, 33);
            this.txtUserID.Margin = new System.Windows.Forms.Padding(6);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(212, 31);
            this.txtUserID.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1286, 40);
            this.label7.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 25);
            this.label7.TabIndex = 15;
            this.label7.Text = "user ID :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1254, 90);
            this.label8.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(125, 25);
            this.label8.TabIndex = 17;
            this.label8.Text = "user name :";
            // 
            // txtUserName
            // 
            this.txtUserName.Enabled = false;
            this.txtUserName.Location = new System.Drawing.Point(1382, 83);
            this.txtUserName.Margin = new System.Windows.Forms.Padding(6);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(212, 31);
            this.txtUserName.TabIndex = 16;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(38, 779);
            this.label9.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(189, 25);
            this.label9.TabIndex = 18;
            this.label9.Text = "Message content :";
            // 
            // txtMessageContent
            // 
            this.txtMessageContent.Location = new System.Drawing.Point(240, 779);
            this.txtMessageContent.Margin = new System.Windows.Forms.Padding(6);
            this.txtMessageContent.Name = "txtMessageContent";
            this.txtMessageContent.Size = new System.Drawing.Size(522, 79);
            this.txtMessageContent.TabIndex = 19;
            this.txtMessageContent.Text = "";
            // 
            // btnCreateMessage
            // 
            this.btnCreateMessage.Location = new System.Drawing.Point(778, 779);
            this.btnCreateMessage.Margin = new System.Windows.Forms.Padding(6);
            this.btnCreateMessage.Name = "btnCreateMessage";
            this.btnCreateMessage.Size = new System.Drawing.Size(212, 83);
            this.btnCreateMessage.TabIndex = 20;
            this.btnCreateMessage.Text = "Create a mesage";
            this.btnCreateMessage.UseVisualStyleBackColor = true;
            this.btnCreateMessage.Click += new System.EventHandler(this.btnCreateMessage_Click);
            // 
            // messageResult
            // 
            this.messageResult.Enabled = false;
            this.messageResult.Location = new System.Drawing.Point(1002, 779);
            this.messageResult.Margin = new System.Windows.Forms.Padding(6);
            this.messageResult.Name = "messageResult";
            this.messageResult.Size = new System.Drawing.Size(212, 31);
            this.messageResult.TabIndex = 21;
            // 
            // btnDeleteFollower
            // 
            this.btnDeleteFollower.Location = new System.Drawing.Point(744, 148);
            this.btnDeleteFollower.Name = "btnDeleteFollower";
            this.btnDeleteFollower.Size = new System.Drawing.Size(414, 34);
            this.btnDeleteFollower.TabIndex = 22;
            this.btnDeleteFollower.Text = "Remove a person from the group";
            this.btnDeleteFollower.UseVisualStyleBackColor = true;
            this.btnDeleteFollower.Click += new System.EventHandler(this.btnDeleteFollower_Click);
            // 
            // txtRemoveFollowerResult
            // 
            this.txtRemoveFollowerResult.Enabled = false;
            this.txtRemoveFollowerResult.Location = new System.Drawing.Point(744, 191);
            this.txtRemoveFollowerResult.Margin = new System.Windows.Forms.Padding(6);
            this.txtRemoveFollowerResult.Name = "txtRemoveFollowerResult";
            this.txtRemoveFollowerResult.Size = new System.Drawing.Size(414, 31);
            this.txtRemoveFollowerResult.TabIndex = 23;
            // 
            // btnCloseGroup
            // 
            this.btnCloseGroup.Location = new System.Drawing.Point(1184, 147);
            this.btnCloseGroup.Name = "btnCloseGroup";
            this.btnCloseGroup.Size = new System.Drawing.Size(414, 34);
            this.btnCloseGroup.TabIndex = 24;
            this.btnCloseGroup.Text = "Close this group";
            this.btnCloseGroup.UseVisualStyleBackColor = true;
            this.btnCloseGroup.Click += new System.EventHandler(this.btnCloseGroup_Click);
            // 
            // txtGroupCloseResult
            // 
            this.txtGroupCloseResult.Enabled = false;
            this.txtGroupCloseResult.Location = new System.Drawing.Point(1184, 191);
            this.txtGroupCloseResult.Margin = new System.Windows.Forms.Padding(6);
            this.txtGroupCloseResult.Name = "txtGroupCloseResult";
            this.txtGroupCloseResult.Size = new System.Drawing.Size(414, 31);
            this.txtGroupCloseResult.TabIndex = 25;
            // 
            // GroupView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1622, 998);
            this.Controls.Add(this.txtGroupCloseResult);
            this.Controls.Add(this.btnCloseGroup);
            this.Controls.Add(this.txtRemoveFollowerResult);
            this.Controls.Add(this.btnDeleteFollower);
            this.Controls.Add(this.messageResult);
            this.Controls.Add(this.btnCreateMessage);
            this.Controls.Add(this.txtMessageContent);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtUserID);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dataGrid_messages);
            this.Controls.Add(this.followerID);
            this.Controls.Add(this.followerNb);
            this.Controls.Add(this.cb_followers);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtGroupDesc);
            this.Controls.Add(this.txtgroupName);
            this.Controls.Add(this.txtGroupID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "GroupView";
            this.Text = "GroupView";
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_messages)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtGroupID;
        private System.Windows.Forms.TextBox txtgroupName;
        private System.Windows.Forms.TextBox txtGroupDesc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cb_followers;
        private System.Windows.Forms.TextBox followerNb;
        private System.Windows.Forms.TextBox followerID;
        private System.Windows.Forms.DataGridView dataGrid_messages;
        private System.Windows.Forms.DataGridViewTextBoxColumn Auteur_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Author_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Content;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date_Created;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtUserID;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RichTextBox txtMessageContent;
        private System.Windows.Forms.Button btnCreateMessage;
        private System.Windows.Forms.TextBox messageResult;
        private System.Windows.Forms.Button btnDeleteFollower;
        private System.Windows.Forms.TextBox txtRemoveFollowerResult;
        private System.Windows.Forms.Button btnCloseGroup;
        private System.Windows.Forms.TextBox txtGroupCloseResult;
    }
}