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
            this.btnAddTask = new System.Windows.Forms.Button();
            this.dateTimePicker_start = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_end = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.rtb_TaskDesc = new System.Windows.Forms.RichTextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.dataGridView_Task = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Début = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.is_completed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_ShowTasks = new System.Windows.Forms.Button();
            this.btn_CreateEvent = new System.Windows.Forms.Button();
            this.txtEventDescription = new System.Windows.Forms.RichTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.dateTimePicker_eventEnd = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_eventStart = new System.Windows.Forms.DateTimePicker();
            this.cbFollowerAssignation = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.btn_ShowEvents = new System.Windows.Forms.Button();
            this.dataGridView_events = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btn_pic = new System.Windows.Forms.Button();
            this.txtTaskID = new System.Windows.Forms.TextBox();
            this.btnCompletedTask = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dataGridView_next5events = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_messages)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Task)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_events)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_next5events)).BeginInit();
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
            this.label3.Location = new System.Drawing.Point(24, 154);
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
            this.dataGrid_messages.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
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
            this.btnDeleteFollower.Margin = new System.Windows.Forms.Padding(4);
            this.btnDeleteFollower.Name = "btnDeleteFollower";
            this.btnDeleteFollower.Size = new System.Drawing.Size(414, 46);
            this.btnDeleteFollower.TabIndex = 22;
            this.btnDeleteFollower.Text = "Remove a person from the group";
            this.btnDeleteFollower.UseVisualStyleBackColor = true;
            this.btnDeleteFollower.Click += new System.EventHandler(this.btnDeleteFollower_Click);
            // 
            // txtRemoveFollowerResult
            // 
            this.txtRemoveFollowerResult.Enabled = false;
            this.txtRemoveFollowerResult.Location = new System.Drawing.Point(744, 204);
            this.txtRemoveFollowerResult.Margin = new System.Windows.Forms.Padding(6);
            this.txtRemoveFollowerResult.Name = "txtRemoveFollowerResult";
            this.txtRemoveFollowerResult.Size = new System.Drawing.Size(414, 31);
            this.txtRemoveFollowerResult.TabIndex = 23;
            // 
            // btnCloseGroup
            // 
            this.btnCloseGroup.Location = new System.Drawing.Point(1184, 146);
            this.btnCloseGroup.Margin = new System.Windows.Forms.Padding(4);
            this.btnCloseGroup.Name = "btnCloseGroup";
            this.btnCloseGroup.Size = new System.Drawing.Size(414, 46);
            this.btnCloseGroup.TabIndex = 24;
            this.btnCloseGroup.Text = "Close this group";
            this.btnCloseGroup.UseVisualStyleBackColor = true;
            this.btnCloseGroup.Click += new System.EventHandler(this.btnCloseGroup_Click);
            // 
            // txtGroupCloseResult
            // 
            this.txtGroupCloseResult.Enabled = false;
            this.txtGroupCloseResult.Location = new System.Drawing.Point(1184, 204);
            this.txtGroupCloseResult.Margin = new System.Windows.Forms.Padding(6);
            this.txtGroupCloseResult.Name = "txtGroupCloseResult";
            this.txtGroupCloseResult.Size = new System.Drawing.Size(414, 31);
            this.txtGroupCloseResult.TabIndex = 25;
            // 
            // btnAddTask
            // 
            this.btnAddTask.Location = new System.Drawing.Point(1872, 33);
            this.btnAddTask.Margin = new System.Windows.Forms.Padding(6);
            this.btnAddTask.Name = "btnAddTask";
            this.btnAddTask.Size = new System.Drawing.Size(212, 56);
            this.btnAddTask.TabIndex = 26;
            this.btnAddTask.Text = "Add a task";
            this.btnAddTask.UseVisualStyleBackColor = true;
            this.btnAddTask.Click += new System.EventHandler(this.btnAddTask_Click);
            // 
            // dateTimePicker_start
            // 
            this.dateTimePicker_start.Location = new System.Drawing.Point(1810, 106);
            this.dateTimePicker_start.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePicker_start.Name = "dateTimePicker_start";
            this.dateTimePicker_start.ShowCheckBox = true;
            this.dateTimePicker_start.Size = new System.Drawing.Size(328, 31);
            this.dateTimePicker_start.TabIndex = 29;
            // 
            // dateTimePicker_end
            // 
            this.dateTimePicker_end.Location = new System.Drawing.Point(1810, 156);
            this.dateTimePicker_end.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePicker_end.Name = "dateTimePicker_end";
            this.dateTimePicker_end.ShowCheckBox = true;
            this.dateTimePicker_end.Size = new System.Drawing.Size(328, 31);
            this.dateTimePicker_end.TabIndex = 30;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(1716, 108);
            this.label11.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(81, 25);
            this.label11.TabIndex = 31;
            this.label11.Text = "Début :";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(1742, 156);
            this.label12.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(54, 25);
            this.label12.TabIndex = 32;
            this.label12.Text = "Fin :";
            // 
            // rtb_TaskDesc
            // 
            this.rtb_TaskDesc.Location = new System.Drawing.Point(1810, 213);
            this.rtb_TaskDesc.Margin = new System.Windows.Forms.Padding(6);
            this.rtb_TaskDesc.Name = "rtb_TaskDesc";
            this.rtb_TaskDesc.Size = new System.Drawing.Size(328, 119);
            this.rtb_TaskDesc.TabIndex = 33;
            this.rtb_TaskDesc.Text = "";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(1664, 219);
            this.label13.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(132, 25);
            this.label13.TabIndex = 34;
            this.label13.Text = "Description :";
            // 
            // dataGridView_Task
            // 
            this.dataGridView_Task.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_Task.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedHeaders;
            this.dataGridView_Task.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Task.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Description,
            this.Début,
            this.Fin,
            this.is_completed});
            this.dataGridView_Task.Location = new System.Drawing.Point(1668, 346);
            this.dataGridView_Task.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView_Task.Name = "dataGridView_Task";
            this.dataGridView_Task.RowTemplate.Height = 33;
            this.dataGridView_Task.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_Task.Size = new System.Drawing.Size(608, 406);
            this.dataGridView_Task.TabIndex = 35;
            this.dataGridView_Task.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Task_CellContentClick);
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.Visible = false;
            // 
            // Description
            // 
            this.Description.HeaderText = "Description";
            this.Description.Name = "Description";
            // 
            // Début
            // 
            this.Début.HeaderText = "Début";
            this.Début.Name = "Début";
            // 
            // Fin
            // 
            this.Fin.HeaderText = "Fin";
            this.Fin.Name = "Fin";
            // 
            // is_completed
            // 
            this.is_completed.HeaderText = "is_completed";
            this.is_completed.Name = "is_completed";
            // 
            // btn_ShowTasks
            // 
            this.btn_ShowTasks.Location = new System.Drawing.Point(1668, 762);
            this.btn_ShowTasks.Margin = new System.Windows.Forms.Padding(6);
            this.btn_ShowTasks.Name = "btn_ShowTasks";
            this.btn_ShowTasks.Size = new System.Drawing.Size(608, 40);
            this.btn_ShowTasks.TabIndex = 38;
            this.btn_ShowTasks.Text = "show";
            this.btn_ShowTasks.UseVisualStyleBackColor = true;
            this.btn_ShowTasks.Click += new System.EventHandler(this.btn_ShowTasks_Click);
            // 
            // btn_CreateEvent
            // 
            this.btn_CreateEvent.Location = new System.Drawing.Point(2490, 33);
            this.btn_CreateEvent.Margin = new System.Windows.Forms.Padding(6);
            this.btn_CreateEvent.Name = "btn_CreateEvent";
            this.btn_CreateEvent.Size = new System.Drawing.Size(212, 56);
            this.btn_CreateEvent.TabIndex = 39;
            this.btn_CreateEvent.Text = "Add an event";
            this.btn_CreateEvent.UseVisualStyleBackColor = true;
            this.btn_CreateEvent.Click += new System.EventHandler(this.button3_Click);
            // 
            // txtEventDescription
            // 
            this.txtEventDescription.Location = new System.Drawing.Point(2434, 104);
            this.txtEventDescription.Margin = new System.Windows.Forms.Padding(6);
            this.txtEventDescription.Name = "txtEventDescription";
            this.txtEventDescription.Size = new System.Drawing.Size(328, 216);
            this.txtEventDescription.TabIndex = 40;
            this.txtEventDescription.Text = "";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(2370, 383);
            this.label14.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(54, 25);
            this.label14.TabIndex = 44;
            this.label14.Text = "Fin :";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(2344, 335);
            this.label15.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(81, 25);
            this.label15.TabIndex = 43;
            this.label15.Text = "Début :";
            // 
            // dateTimePicker_eventEnd
            // 
            this.dateTimePicker_eventEnd.Location = new System.Drawing.Point(2438, 383);
            this.dateTimePicker_eventEnd.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePicker_eventEnd.Name = "dateTimePicker_eventEnd";
            this.dateTimePicker_eventEnd.ShowCheckBox = true;
            this.dateTimePicker_eventEnd.Size = new System.Drawing.Size(328, 31);
            this.dateTimePicker_eventEnd.TabIndex = 42;
            // 
            // dateTimePicker_eventStart
            // 
            this.dateTimePicker_eventStart.Location = new System.Drawing.Point(2438, 333);
            this.dateTimePicker_eventStart.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePicker_eventStart.Name = "dateTimePicker_eventStart";
            this.dateTimePicker_eventStart.ShowCheckBox = true;
            this.dateTimePicker_eventStart.Size = new System.Drawing.Size(328, 31);
            this.dateTimePicker_eventStart.TabIndex = 41;
            // 
            // cbFollowerAssignation
            // 
            this.cbFollowerAssignation.FormattingEnabled = true;
            this.cbFollowerAssignation.Location = new System.Drawing.Point(1910, 815);
            this.cbFollowerAssignation.Margin = new System.Windows.Forms.Padding(6);
            this.cbFollowerAssignation.Name = "cbFollowerAssignation";
            this.cbFollowerAssignation.Size = new System.Drawing.Size(228, 33);
            this.cbFollowerAssignation.TabIndex = 46;
            this.cbFollowerAssignation.SelectedIndexChanged += new System.EventHandler(this.cbFollowerAssignation_SelectedIndexChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(1786, 819);
            this.label16.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(113, 25);
            this.label16.TabIndex = 45;
            this.label16.Text = "Assign to :";
            // 
            // btn_ShowEvents
            // 
            this.btn_ShowEvents.Location = new System.Drawing.Point(2349, 645);
            this.btn_ShowEvents.Margin = new System.Windows.Forms.Padding(6);
            this.btn_ShowEvents.Name = "btn_ShowEvents";
            this.btn_ShowEvents.Size = new System.Drawing.Size(512, 40);
            this.btn_ShowEvents.TabIndex = 49;
            this.btn_ShowEvents.Text = "show";
            this.btn_ShowEvents.UseVisualStyleBackColor = true;
            this.btn_ShowEvents.Click += new System.EventHandler(this.btn_ShowEvents_Click);
            // 
            // dataGridView_events
            // 
            this.dataGridView_events.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_events.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedHeaders;
            this.dataGridView_events.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_events.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.dataGridView_events.Location = new System.Drawing.Point(2350, 438);
            this.dataGridView_events.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView_events.Name = "dataGridView_events";
            this.dataGridView_events.RowTemplate.Height = 33;
            this.dataGridView_events.Size = new System.Drawing.Size(512, 188);
            this.dataGridView_events.TabIndex = 48;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Description";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Début";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Fin";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btn_pic
            // 
            this.btn_pic.Location = new System.Drawing.Point(282, 931);
            this.btn_pic.Margin = new System.Windows.Forms.Padding(6);
            this.btn_pic.Name = "btn_pic";
            this.btn_pic.Size = new System.Drawing.Size(306, 44);
            this.btn_pic.TabIndex = 50;
            this.btn_pic.Text = "select picture";
            this.btn_pic.UseVisualStyleBackColor = true;
            this.btn_pic.Click += new System.EventHandler(this.btn_pic_Click);
            // 
            // txtTaskID
            // 
            this.txtTaskID.Enabled = false;
            this.txtTaskID.Location = new System.Drawing.Point(1672, 813);
            this.txtTaskID.Margin = new System.Windows.Forms.Padding(6);
            this.txtTaskID.Name = "txtTaskID";
            this.txtTaskID.Size = new System.Drawing.Size(98, 31);
            this.txtTaskID.TabIndex = 51;
            // 
            // btnCompletedTask
            // 
            this.btnCompletedTask.Location = new System.Drawing.Point(1670, 867);
            this.btnCompletedTask.Margin = new System.Windows.Forms.Padding(6);
            this.btnCompletedTask.Name = "btnCompletedTask";
            this.btnCompletedTask.Size = new System.Drawing.Size(598, 40);
            this.btnCompletedTask.TabIndex = 52;
            this.btnCompletedTask.Text = "Set task as completed";
            this.btnCompletedTask.UseVisualStyleBackColor = true;
            this.btnCompletedTask.Click += new System.EventHandler(this.btnCompletedTask_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(2154, 813);
            this.button2.Margin = new System.Windows.Forms.Padding(6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(112, 40);
            this.button2.TabIndex = 53;
            this.button2.Text = "Assign";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dataGridView_next5events
            // 
            this.dataGridView_next5events.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_next5events.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedHeaders;
            this.dataGridView_next5events.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_next5events.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6});
            this.dataGridView_next5events.Location = new System.Drawing.Point(2349, 719);
            this.dataGridView_next5events.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView_next5events.Name = "dataGridView_next5events";
            this.dataGridView_next5events.RowTemplate.Height = 33;
            this.dataGridView_next5events.Size = new System.Drawing.Size(512, 188);
            this.dataGridView_next5events.TabIndex = 54;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Description";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Début";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Fin";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(340, 190);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 31);
            this.dateTimePicker1.TabIndex = 55;
            // 
            // GroupView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2918, 998);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.dataGridView_next5events);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnCompletedTask);
            this.Controls.Add(this.txtTaskID);
            this.Controls.Add(this.btn_pic);
            this.Controls.Add(this.btn_ShowEvents);
            this.Controls.Add(this.dataGridView_events);
            this.Controls.Add(this.cbFollowerAssignation);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.dateTimePicker_eventEnd);
            this.Controls.Add(this.dateTimePicker_eventStart);
            this.Controls.Add(this.txtEventDescription);
            this.Controls.Add(this.btn_CreateEvent);
            this.Controls.Add(this.btn_ShowTasks);
            this.Controls.Add(this.dataGridView_Task);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.rtb_TaskDesc);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.dateTimePicker_end);
            this.Controls.Add(this.dateTimePicker_start);
            this.Controls.Add(this.btnAddTask);
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Task)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_events)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_next5events)).EndInit();
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
        private System.Windows.Forms.Button btnAddTask;
        private System.Windows.Forms.DateTimePicker dateTimePicker_start;
        private System.Windows.Forms.DateTimePicker dateTimePicker_end;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.RichTextBox rtb_TaskDesc;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DataGridView dataGridView_Task;
        private System.Windows.Forms.Button btn_ShowTasks;
        private System.Windows.Forms.Button btn_CreateEvent;
        private System.Windows.Forms.RichTextBox txtEventDescription;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DateTimePicker dateTimePicker_eventEnd;
        private System.Windows.Forms.DateTimePicker dateTimePicker_eventStart;
        private System.Windows.Forms.ComboBox cbFollowerAssignation;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button btn_ShowEvents;
        private System.Windows.Forms.DataGridView dataGridView_events;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btn_pic;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn Début;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fin;
        private System.Windows.Forms.DataGridViewTextBoxColumn is_completed;
        private System.Windows.Forms.TextBox txtTaskID;
        private System.Windows.Forms.Button btnCompletedTask;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dataGridView_next5events;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}