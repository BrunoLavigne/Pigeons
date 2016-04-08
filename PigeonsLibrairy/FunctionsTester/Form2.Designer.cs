namespace FunctionsTester
{
    partial class Form2
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
            this.person_name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.person_email = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.person_password = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.person_passwordConfirmation = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.person_emailConfirmation = new System.Windows.Forms.TextBox();
            this.person_birthdate = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.person_phone = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.person_organization = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.person_position = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.person_description = new System.Windows.Forms.TextBox();
            this.btnInscription = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.loginUsername = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.loginPassword = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.active_person = new System.Windows.Forms.TextBox();
            this.DateGrid_ActivePersonGroups = new System.Windows.Forms.DataGridView();
            this.label14 = new System.Windows.Forms.Label();
            this.btnActivePersonGroups = new System.Windows.Forms.Button();
            this.btnCreateGroup = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.group_name = new System.Windows.Forms.TextBox();
            this.group_description = new System.Windows.Forms.TextBox();
            this.person_result = new System.Windows.Forms.TextBox();
            this.loginResult = new System.Windows.Forms.TextBox();
            this.active_personID = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.groupResult = new System.Windows.Forms.TextBox();
            this.cb_activePerson_groups = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.activeGroup_addPerson = new System.Windows.Forms.TextBox();
            this.lblactiveadd = new System.Windows.Forms.Label();
            this.btnActiveGroupFind = new System.Windows.Forms.Button();
            this.activeGroup_name = new System.Windows.Forms.TextBox();
            this.activeGroup_id = new System.Windows.Forms.TextBox();
            this.btnActiveGroup_Add = new System.Windows.Forms.Button();
            this.activeGroupResult = new System.Windows.Forms.TextBox();
            this.btnGoToGroup = new System.Windows.Forms.Button();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.cb_activeGroup_addPerson = new System.Windows.Forms.ComboBox();
            this.btnUpdateDesc = new System.Windows.Forms.Button();
            this.txtUpdateDesc = new System.Windows.Forms.TextBox();
            this.cb_LoginPerson = new System.Windows.Forms.ComboBox();
            this.cb_LoginFollowings = new System.Windows.Forms.ComboBox();
            this.cb_LoginGroups = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DateGrid_ActivePersonGroups)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // person_name
            // 
            this.person_name.Location = new System.Drawing.Point(176, 62);
            this.person_name.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.person_name.Name = "person_name";
            this.person_name.Size = new System.Drawing.Size(286, 31);
            this.person_name.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(78, 67);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(84, 117);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Email :";
            // 
            // person_email
            // 
            this.person_email.Location = new System.Drawing.Point(176, 112);
            this.person_email.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.person_email.Name = "person_email";
            this.person_email.Size = new System.Drawing.Size(286, 31);
            this.person_email.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(42, 217);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Password :";
            // 
            // person_password
            // 
            this.person_password.Location = new System.Drawing.Point(176, 212);
            this.person_password.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.person_password.Name = "person_password";
            this.person_password.Size = new System.Drawing.Size(286, 31);
            this.person_password.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(64, 267);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 25);
            this.label4.TabIndex = 7;
            this.label4.Text = "Confirm :";
            // 
            // person_passwordConfirmation
            // 
            this.person_passwordConfirmation.Location = new System.Drawing.Point(176, 262);
            this.person_passwordConfirmation.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.person_passwordConfirmation.Name = "person_passwordConfirmation";
            this.person_passwordConfirmation.Size = new System.Drawing.Size(286, 31);
            this.person_passwordConfirmation.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(64, 167);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 25);
            this.label5.TabIndex = 9;
            this.label5.Text = "Confirm :";
            // 
            // person_emailConfirmation
            // 
            this.person_emailConfirmation.Location = new System.Drawing.Point(176, 162);
            this.person_emailConfirmation.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.person_emailConfirmation.Name = "person_emailConfirmation";
            this.person_emailConfirmation.Size = new System.Drawing.Size(286, 31);
            this.person_emailConfirmation.TabIndex = 2;
            // 
            // person_birthdate
            // 
            this.person_birthdate.Location = new System.Drawing.Point(176, 312);
            this.person_birthdate.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.person_birthdate.Name = "person_birthdate";
            this.person_birthdate.Size = new System.Drawing.Size(286, 31);
            this.person_birthdate.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(50, 315);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 25);
            this.label6.TabIndex = 11;
            this.label6.Text = "Birthdate :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(72, 367);
            this.label7.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 25);
            this.label7.TabIndex = 13;
            this.label7.Text = "Phone :";
            // 
            // person_phone
            // 
            this.person_phone.Location = new System.Drawing.Point(176, 362);
            this.person_phone.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.person_phone.Name = "person_phone";
            this.person_phone.Size = new System.Drawing.Size(286, 31);
            this.person_phone.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 421);
            this.label8.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(146, 25);
            this.label8.TabIndex = 15;
            this.label8.Text = "Organization :";
            // 
            // person_organization
            // 
            this.person_organization.Location = new System.Drawing.Point(176, 415);
            this.person_organization.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.person_organization.Name = "person_organization";
            this.person_organization.Size = new System.Drawing.Size(286, 31);
            this.person_organization.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(62, 471);
            this.label9.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(99, 25);
            this.label9.TabIndex = 17;
            this.label9.Text = "position :";
            // 
            // person_position
            // 
            this.person_position.Location = new System.Drawing.Point(176, 465);
            this.person_position.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.person_position.Name = "person_position";
            this.person_position.Size = new System.Drawing.Size(286, 31);
            this.person_position.TabIndex = 8;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(28, 521);
            this.label10.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(132, 25);
            this.label10.TabIndex = 19;
            this.label10.Text = "Description :";
            // 
            // person_description
            // 
            this.person_description.Location = new System.Drawing.Point(176, 515);
            this.person_description.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.person_description.Name = "person_description";
            this.person_description.Size = new System.Drawing.Size(286, 31);
            this.person_description.TabIndex = 9;
            // 
            // btnInscription
            // 
            this.btnInscription.Location = new System.Drawing.Point(176, 567);
            this.btnInscription.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnInscription.Name = "btnInscription";
            this.btnInscription.Size = new System.Drawing.Size(290, 44);
            this.btnInscription.TabIndex = 10;
            this.btnInscription.Text = "Inscription";
            this.btnInscription.UseVisualStyleBackColor = true;
            this.btnInscription.Click += new System.EventHandler(this.btnInscription_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(570, 73);
            this.label11.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 25);
            this.label11.TabIndex = 22;
            this.label11.Text = "Email :";
            // 
            // loginUsername
            // 
            this.loginUsername.Location = new System.Drawing.Point(662, 67);
            this.loginUsername.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.loginUsername.Name = "loginUsername";
            this.loginUsername.Size = new System.Drawing.Size(286, 31);
            this.loginUsername.TabIndex = 11;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(528, 123);
            this.label12.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(118, 25);
            this.label12.TabIndex = 24;
            this.label12.Text = "Password :";
            // 
            // loginPassword
            // 
            this.loginPassword.Location = new System.Drawing.Point(662, 117);
            this.loginPassword.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.loginPassword.Name = "loginPassword";
            this.loginPassword.Size = new System.Drawing.Size(286, 31);
            this.loginPassword.TabIndex = 12;
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(662, 167);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(290, 44);
            this.btnLogin.TabIndex = 13;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(1012, 29);
            this.label13.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(69, 25);
            this.label13.TabIndex = 27;
            this.label13.Text = "User :";
            // 
            // active_person
            // 
            this.active_person.Enabled = false;
            this.active_person.Location = new System.Drawing.Point(1012, 67);
            this.active_person.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.active_person.Name = "active_person";
            this.active_person.Size = new System.Drawing.Size(338, 31);
            this.active_person.TabIndex = 14;
            // 
            // DateGrid_ActivePersonGroups
            // 
            this.DateGrid_ActivePersonGroups.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DateGrid_ActivePersonGroups.Location = new System.Drawing.Point(1012, 167);
            this.DateGrid_ActivePersonGroups.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.DateGrid_ActivePersonGroups.Name = "DateGrid_ActivePersonGroups";
            this.DateGrid_ActivePersonGroups.Size = new System.Drawing.Size(894, 387);
            this.DateGrid_ActivePersonGroups.TabIndex = 28;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(1012, 121);
            this.label14.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(129, 25);
            this.label14.TabIndex = 29;
            this.label14.Text = "User groups";
            // 
            // btnActivePersonGroups
            // 
            this.btnActivePersonGroups.Location = new System.Drawing.Point(1152, 113);
            this.btnActivePersonGroups.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnActivePersonGroups.Name = "btnActivePersonGroups";
            this.btnActivePersonGroups.Size = new System.Drawing.Size(202, 44);
            this.btnActivePersonGroups.TabIndex = 15;
            this.btnActivePersonGroups.Text = "Show my groups";
            this.btnActivePersonGroups.UseVisualStyleBackColor = true;
            this.btnActivePersonGroups.Click += new System.EventHandler(this.btnActivePersonGroups_Click);
            // 
            // btnCreateGroup
            // 
            this.btnCreateGroup.Location = new System.Drawing.Point(1622, 602);
            this.btnCreateGroup.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnCreateGroup.Name = "btnCreateGroup";
            this.btnCreateGroup.Size = new System.Drawing.Size(284, 44);
            this.btnCreateGroup.TabIndex = 18;
            this.btnCreateGroup.Text = "Create a new group";
            this.btnCreateGroup.UseVisualStyleBackColor = true;
            this.btnCreateGroup.Click += new System.EventHandler(this.btnCreateGroup_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(1322, 569);
            this.label15.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(132, 25);
            this.label15.TabIndex = 35;
            this.label15.Text = "Description :";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(1020, 569);
            this.label16.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(142, 25);
            this.label16.TabIndex = 33;
            this.label16.Text = "Group name :";
            // 
            // group_name
            // 
            this.group_name.Location = new System.Drawing.Point(1018, 606);
            this.group_name.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.group_name.Name = "group_name";
            this.group_name.Size = new System.Drawing.Size(286, 31);
            this.group_name.TabIndex = 16;
            // 
            // group_description
            // 
            this.group_description.Location = new System.Drawing.Point(1320, 608);
            this.group_description.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.group_description.Name = "group_description";
            this.group_description.Size = new System.Drawing.Size(286, 31);
            this.group_description.TabIndex = 17;
            // 
            // person_result
            // 
            this.person_result.Enabled = false;
            this.person_result.Location = new System.Drawing.Point(176, 623);
            this.person_result.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.person_result.Name = "person_result";
            this.person_result.Size = new System.Drawing.Size(286, 31);
            this.person_result.TabIndex = 37;
            // 
            // loginResult
            // 
            this.loginResult.Enabled = false;
            this.loginResult.Location = new System.Drawing.Point(662, 223);
            this.loginResult.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.loginResult.Name = "loginResult";
            this.loginResult.Size = new System.Drawing.Size(286, 31);
            this.loginResult.TabIndex = 38;
            // 
            // active_personID
            // 
            this.active_personID.Enabled = false;
            this.active_personID.Location = new System.Drawing.Point(1366, 67);
            this.active_personID.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.active_personID.Name = "active_personID";
            this.active_personID.Size = new System.Drawing.Size(84, 31);
            this.active_personID.TabIndex = 39;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(1364, 33);
            this.label17.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(44, 25);
            this.label17.TabIndex = 40;
            this.label17.Text = "ID :";
            // 
            // groupResult
            // 
            this.groupResult.Enabled = false;
            this.groupResult.Location = new System.Drawing.Point(1622, 658);
            this.groupResult.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupResult.Name = "groupResult";
            this.groupResult.Size = new System.Drawing.Size(280, 31);
            this.groupResult.TabIndex = 41;
            // 
            // cb_activePerson_groups
            // 
            this.cb_activePerson_groups.FormattingEnabled = true;
            this.cb_activePerson_groups.Location = new System.Drawing.Point(1012, 794);
            this.cb_activePerson_groups.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.cb_activePerson_groups.Name = "cb_activePerson_groups";
            this.cb_activePerson_groups.Size = new System.Drawing.Size(292, 33);
            this.cb_activePerson_groups.TabIndex = 42;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(1012, 763);
            this.label18.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(109, 25);
            this.label18.TabIndex = 43;
            this.label18.Text = "Group ID :";
            // 
            // activeGroup_addPerson
            // 
            this.activeGroup_addPerson.Location = new System.Drawing.Point(1018, 850);
            this.activeGroup_addPerson.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.activeGroup_addPerson.Name = "activeGroup_addPerson";
            this.activeGroup_addPerson.Size = new System.Drawing.Size(286, 31);
            this.activeGroup_addPerson.TabIndex = 44;
            // 
            // lblactiveadd
            // 
            this.lblactiveadd.AutoSize = true;
            this.lblactiveadd.Location = new System.Drawing.Point(1322, 763);
            this.lblactiveadd.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblactiveadd.Name = "lblactiveadd";
            this.lblactiveadd.Size = new System.Drawing.Size(198, 25);
            this.lblactiveadd.TabIndex = 45;
            this.lblactiveadd.Text = "Find a user to add :";
            // 
            // btnActiveGroupFind
            // 
            this.btnActiveGroupFind.Location = new System.Drawing.Point(1320, 846);
            this.btnActiveGroupFind.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnActiveGroupFind.Name = "btnActiveGroupFind";
            this.btnActiveGroupFind.Size = new System.Drawing.Size(290, 44);
            this.btnActiveGroupFind.TabIndex = 46;
            this.btnActiveGroupFind.Text = "Select the user";
            this.btnActiveGroupFind.UseVisualStyleBackColor = true;
            this.btnActiveGroupFind.Click += new System.EventHandler(this.btnActiveGroupFind_Click);
            // 
            // activeGroup_name
            // 
            this.activeGroup_name.Location = new System.Drawing.Point(1320, 902);
            this.activeGroup_name.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.activeGroup_name.Name = "activeGroup_name";
            this.activeGroup_name.Size = new System.Drawing.Size(194, 31);
            this.activeGroup_name.TabIndex = 47;
            // 
            // activeGroup_id
            // 
            this.activeGroup_id.Location = new System.Drawing.Point(1530, 902);
            this.activeGroup_id.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.activeGroup_id.Name = "activeGroup_id";
            this.activeGroup_id.Size = new System.Drawing.Size(76, 31);
            this.activeGroup_id.TabIndex = 48;
            // 
            // btnActiveGroup_Add
            // 
            this.btnActiveGroup_Add.Location = new System.Drawing.Point(1622, 792);
            this.btnActiveGroup_Add.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnActiveGroup_Add.Name = "btnActiveGroup_Add";
            this.btnActiveGroup_Add.Size = new System.Drawing.Size(284, 44);
            this.btnActiveGroup_Add.TabIndex = 49;
            this.btnActiveGroup_Add.Text = "Add to my group";
            this.btnActiveGroup_Add.UseVisualStyleBackColor = true;
            this.btnActiveGroup_Add.Click += new System.EventHandler(this.btnActiveGroup_Add_Click);
            // 
            // activeGroupResult
            // 
            this.activeGroupResult.Enabled = false;
            this.activeGroupResult.Location = new System.Drawing.Point(1622, 852);
            this.activeGroupResult.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.activeGroupResult.Name = "activeGroupResult";
            this.activeGroupResult.Size = new System.Drawing.Size(280, 31);
            this.activeGroupResult.TabIndex = 50;
            // 
            // btnGoToGroup
            // 
            this.btnGoToGroup.Location = new System.Drawing.Point(1012, 1000);
            this.btnGoToGroup.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnGoToGroup.Name = "btnGoToGroup";
            this.btnGoToGroup.Size = new System.Drawing.Size(894, 44);
            this.btnGoToGroup.TabIndex = 51;
            this.btnGoToGroup.Text = "Go in group ( select in cbBox )";
            this.btnGoToGroup.UseVisualStyleBackColor = true;
            this.btnGoToGroup.Click += new System.EventHandler(this.btnGoToGroup_Click);
            // 
            // cb_activeGroup_addPerson
            // 
            this.cb_activeGroup_addPerson.FormattingEnabled = true;
            this.cb_activeGroup_addPerson.Location = new System.Drawing.Point(1320, 796);
            this.cb_activeGroup_addPerson.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.cb_activeGroup_addPerson.Name = "cb_activeGroup_addPerson";
            this.cb_activeGroup_addPerson.Size = new System.Drawing.Size(286, 33);
            this.cb_activeGroup_addPerson.TabIndex = 52;
            this.cb_activeGroup_addPerson.SelectedIndexChanged += new System.EventHandler(this.cb_activeGroup_addPerson_SelectedIndexChanged);
            // 
            // btnUpdateDesc
            // 
            this.btnUpdateDesc.Location = new System.Drawing.Point(1616, 98);
            this.btnUpdateDesc.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnUpdateDesc.Name = "btnUpdateDesc";
            this.btnUpdateDesc.Size = new System.Drawing.Size(290, 44);
            this.btnUpdateDesc.TabIndex = 53;
            this.btnUpdateDesc.Text = "Update description";
            this.btnUpdateDesc.UseVisualStyleBackColor = true;
            this.btnUpdateDesc.Click += new System.EventHandler(this.btnUpdateDesc_Click);
            // 
            // txtUpdateDesc
            // 
            this.txtUpdateDesc.Location = new System.Drawing.Point(1616, 48);
            this.txtUpdateDesc.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtUpdateDesc.Name = "txtUpdateDesc";
            this.txtUpdateDesc.Size = new System.Drawing.Size(286, 31);
            this.txtUpdateDesc.TabIndex = 54;
            // 
            // cb_LoginPerson
            // 
            this.cb_LoginPerson.FormattingEnabled = true;
            this.cb_LoginPerson.Location = new System.Drawing.Point(662, 307);
            this.cb_LoginPerson.Name = "cb_LoginPerson";
            this.cb_LoginPerson.Size = new System.Drawing.Size(286, 33);
            this.cb_LoginPerson.TabIndex = 55;
            // 
            // cb_LoginFollowings
            // 
            this.cb_LoginFollowings.FormattingEnabled = true;
            this.cb_LoginFollowings.Location = new System.Drawing.Point(662, 359);
            this.cb_LoginFollowings.Name = "cb_LoginFollowings";
            this.cb_LoginFollowings.Size = new System.Drawing.Size(286, 33);
            this.cb_LoginFollowings.TabIndex = 56;
            // 
            // cb_LoginGroups
            // 
            this.cb_LoginGroups.FormattingEnabled = true;
            this.cb_LoginGroups.Location = new System.Drawing.Point(662, 413);
            this.cb_LoginGroups.Name = "cb_LoginGroups";
            this.cb_LoginGroups.Size = new System.Drawing.Size(286, 33);
            this.cb_LoginGroups.TabIndex = 57;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(564, 310);
            this.label19.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(92, 25);
            this.label19.TabIndex = 58;
            this.label19.Text = "Person :";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(541, 366);
            this.label20.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(115, 25);
            this.label20.TabIndex = 59;
            this.label20.Text = "Following :";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(562, 415);
            this.label21.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(94, 25);
            this.label21.TabIndex = 60;
            this.label21.Text = "Groups :";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1988, 1194);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.cb_LoginGroups);
            this.Controls.Add(this.cb_LoginFollowings);
            this.Controls.Add(this.cb_LoginPerson);
            this.Controls.Add(this.txtUpdateDesc);
            this.Controls.Add(this.btnUpdateDesc);
            this.Controls.Add(this.cb_activeGroup_addPerson);
            this.Controls.Add(this.btnGoToGroup);
            this.Controls.Add(this.activeGroupResult);
            this.Controls.Add(this.btnActiveGroup_Add);
            this.Controls.Add(this.activeGroup_id);
            this.Controls.Add(this.activeGroup_name);
            this.Controls.Add(this.btnActiveGroupFind);
            this.Controls.Add(this.lblactiveadd);
            this.Controls.Add(this.activeGroup_addPerson);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.cb_activePerson_groups);
            this.Controls.Add(this.groupResult);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.active_personID);
            this.Controls.Add(this.loginResult);
            this.Controls.Add(this.person_result);
            this.Controls.Add(this.group_description);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.group_name);
            this.Controls.Add(this.btnCreateGroup);
            this.Controls.Add(this.btnActivePersonGroups);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.DateGrid_ActivePersonGroups);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.active_person);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.loginPassword);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.loginUsername);
            this.Controls.Add(this.btnInscription);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.person_description);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.person_position);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.person_organization);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.person_phone);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.person_birthdate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.person_emailConfirmation);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.person_passwordConfirmation);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.person_password);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.person_email);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.person_name);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DateGrid_ActivePersonGroups)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox person_name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox person_email;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox person_password;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox person_passwordConfirmation;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox person_emailConfirmation;
        private System.Windows.Forms.DateTimePicker person_birthdate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox person_phone;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox person_organization;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox person_position;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox person_description;
        private System.Windows.Forms.Button btnInscription;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox loginUsername;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox loginPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox active_person;
        private System.Windows.Forms.DataGridView DateGrid_ActivePersonGroups;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnActivePersonGroups;
        private System.Windows.Forms.Button btnCreateGroup;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox group_name;
        private System.Windows.Forms.TextBox group_description;
        private System.Windows.Forms.TextBox person_result;
        private System.Windows.Forms.TextBox loginResult;
        private System.Windows.Forms.TextBox active_personID;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox groupResult;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.ComboBox cb_activePerson_groups;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox activeGroup_addPerson;
        private System.Windows.Forms.Label lblactiveadd;
        private System.Windows.Forms.Button btnActiveGroupFind;
        private System.Windows.Forms.TextBox activeGroup_name;
        private System.Windows.Forms.TextBox activeGroup_id;
        private System.Windows.Forms.Button btnActiveGroup_Add;
        private System.Windows.Forms.TextBox activeGroupResult;
        private System.Windows.Forms.Button btnGoToGroup;
        private System.Windows.Forms.ComboBox cb_activeGroup_addPerson;
        private System.Windows.Forms.Button btnUpdateDesc;
        private System.Windows.Forms.TextBox txtUpdateDesc;
        private System.Windows.Forms.ComboBox cb_LoginPerson;
        private System.Windows.Forms.ComboBox cb_LoginFollowings;
        private System.Windows.Forms.ComboBox cb_LoginGroups;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
    }
}