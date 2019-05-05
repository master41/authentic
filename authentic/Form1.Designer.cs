namespace authentic
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ToolStripMenuItemUser = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemCreate = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItemChange = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItemLogIn = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemLogOut = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.listBoxUsers = new System.Windows.Forms.ListBox();
            this.buttonLogIn = new System.Windows.Forms.Button();
            this.buttonLogOut = new System.Windows.Forms.Button();
            this.ToolStripMenuItemBlock = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemUser,
            this.ToolStripMenuItemHelp});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(311, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ToolStripMenuItemUser
            // 
            this.ToolStripMenuItemUser.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemCreate,
            this.ToolStripMenuItemBlock,
            this.ToolStripMenuItemDelete,
            this.toolStripSeparator1,
            this.ToolStripMenuItemChange,
            this.toolStripSeparator2,
            this.ToolStripMenuItemLogIn,
            this.ToolStripMenuItemLogOut});
            this.ToolStripMenuItemUser.Name = "ToolStripMenuItemUser";
            this.ToolStripMenuItemUser.Size = new System.Drawing.Size(96, 20);
            this.ToolStripMenuItemUser.Text = "Пользователь";
            // 
            // ToolStripMenuItemCreate
            // 
            this.ToolStripMenuItemCreate.Name = "ToolStripMenuItemCreate";
            this.ToolStripMenuItemCreate.Size = new System.Drawing.Size(158, 22);
            this.ToolStripMenuItemCreate.Text = "Создать";
            this.ToolStripMenuItemCreate.Click += new System.EventHandler(this.ToolStripMenuItemCreate_Click);
            // 
            // ToolStripMenuItemDelete
            // 
            this.ToolStripMenuItemDelete.Name = "ToolStripMenuItemDelete";
            this.ToolStripMenuItemDelete.Size = new System.Drawing.Size(158, 22);
            this.ToolStripMenuItemDelete.Text = "Удалить";
            this.ToolStripMenuItemDelete.Click += new System.EventHandler(this.ToolStripMenuItemDelete_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(155, 6);
            // 
            // ToolStripMenuItemChange
            // 
            this.ToolStripMenuItemChange.Name = "ToolStripMenuItemChange";
            this.ToolStripMenuItemChange.Size = new System.Drawing.Size(158, 22);
            this.ToolStripMenuItemChange.Text = "Изменить";
            this.ToolStripMenuItemChange.Click += new System.EventHandler(this.ToolStripMenuItemChange_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(155, 6);
            // 
            // ToolStripMenuItemLogIn
            // 
            this.ToolStripMenuItemLogIn.Name = "ToolStripMenuItemLogIn";
            this.ToolStripMenuItemLogIn.Size = new System.Drawing.Size(158, 22);
            this.ToolStripMenuItemLogIn.Text = "Вход";
            // 
            // ToolStripMenuItemLogOut
            // 
            this.ToolStripMenuItemLogOut.Name = "ToolStripMenuItemLogOut";
            this.ToolStripMenuItemLogOut.Size = new System.Drawing.Size(158, 22);
            this.ToolStripMenuItemLogOut.Text = "Выход";
            // 
            // ToolStripMenuItemHelp
            // 
            this.ToolStripMenuItemHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemAbout});
            this.ToolStripMenuItemHelp.Name = "ToolStripMenuItemHelp";
            this.ToolStripMenuItemHelp.Size = new System.Drawing.Size(65, 20);
            this.ToolStripMenuItemHelp.Text = "Справка";
            // 
            // ToolStripMenuItemAbout
            // 
            this.ToolStripMenuItemAbout.Name = "ToolStripMenuItemAbout";
            this.ToolStripMenuItemAbout.Size = new System.Drawing.Size(149, 22);
            this.ToolStripMenuItemAbout.Text = "О программе";
            this.ToolStripMenuItemAbout.Click += new System.EventHandler(this.ToolStripMenuItemAbout_Click);
            // 
            // listBoxUsers
            // 
            this.listBoxUsers.FormattingEnabled = true;
            this.listBoxUsers.Location = new System.Drawing.Point(77, 46);
            this.listBoxUsers.Name = "listBoxUsers";
            this.listBoxUsers.Size = new System.Drawing.Size(149, 147);
            this.listBoxUsers.TabIndex = 1;
            this.listBoxUsers.SelectedIndexChanged += new System.EventHandler(this.listBoxUsers_SelectedIndexChanged);
            // 
            // buttonLogIn
            // 
            this.buttonLogIn.Location = new System.Drawing.Point(49, 227);
            this.buttonLogIn.Name = "buttonLogIn";
            this.buttonLogIn.Size = new System.Drawing.Size(75, 23);
            this.buttonLogIn.TabIndex = 2;
            this.buttonLogIn.Text = "Войти";
            this.buttonLogIn.UseVisualStyleBackColor = true;
            this.buttonLogIn.Click += new System.EventHandler(this.buttonLogIn_Click);
            // 
            // buttonLogOut
            // 
            this.buttonLogOut.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonLogOut.Location = new System.Drawing.Point(179, 227);
            this.buttonLogOut.Name = "buttonLogOut";
            this.buttonLogOut.Size = new System.Drawing.Size(75, 23);
            this.buttonLogOut.TabIndex = 3;
            this.buttonLogOut.Text = "Выйти";
            this.buttonLogOut.UseVisualStyleBackColor = true;
            // 
            // ToolStripMenuItemBlock
            // 
            this.ToolStripMenuItemBlock.Name = "ToolStripMenuItemBlock";
            this.ToolStripMenuItemBlock.Size = new System.Drawing.Size(158, 22);
            this.ToolStripMenuItemBlock.Text = "Заблокировать";
            this.ToolStripMenuItemBlock.Click += new System.EventHandler(this.ToolStripMenuItemBlock_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonLogOut;
            this.ClientSize = new System.Drawing.Size(311, 292);
            this.Controls.Add(this.buttonLogOut);
            this.Controls.Add(this.buttonLogIn);
            this.Controls.Add(this.listBoxUsers);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Лабораторна робота № 1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemUser;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemCreate;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemBlock;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemChange;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemLogIn;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemLogOut;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemHelp;
        private System.Windows.Forms.ListBox listBoxUsers;
        private System.Windows.Forms.Button buttonLogIn;
        private System.Windows.Forms.Button buttonLogOut;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemAbout;
    }
}

