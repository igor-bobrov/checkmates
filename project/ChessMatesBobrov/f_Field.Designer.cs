
namespace ChessMatesBobrov
{
    partial class F_Chess
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
            this.components = new System.ComponentModel.Container();
            this.FrameTimer = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.новваяИграToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ктоХодитToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.правилаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.поддержатьАвтораToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quwiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сберToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.кастомизацияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.стандартToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.соцСтраницыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вкToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // FrameTimer
            // 
            this.FrameTimer.Interval = 10;
            this.FrameTimer.Tick += new System.EventHandler(this.FrameTimer_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1015, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.новваяИграToolStripMenuItem,
            this.настройкиToolStripMenuItem,
            this.ктоХодитToolStripMenuItem,
            this.правилаToolStripMenuItem,
            this.поддержатьАвтораToolStripMenuItem,
            this.выходToolStripMenuItem,
            this.соцСтраницыToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // новваяИграToolStripMenuItem
            // 
            this.новваяИграToolStripMenuItem.Name = "новваяИграToolStripMenuItem";
            this.новваяИграToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.новваяИграToolStripMenuItem.Text = "Новвая игра";
            this.новваяИграToolStripMenuItem.Click += new System.EventHandler(this.новваяИграToolStripMenuItem_Click);
            // 
            // настройкиToolStripMenuItem
            // 
            this.настройкиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.кастомизацияToolStripMenuItem});
            this.настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            this.настройкиToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.настройкиToolStripMenuItem.Text = "Настройки";
            // 
            // ктоХодитToolStripMenuItem
            // 
            this.ктоХодитToolStripMenuItem.Name = "ктоХодитToolStripMenuItem";
            this.ктоХодитToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.ктоХодитToolStripMenuItem.Text = "смена ходов";
            this.ктоХодитToolStripMenuItem.Click += new System.EventHandler(this.ктоХодитToolStripMenuItem_Click);
            // 
            // правилаToolStripMenuItem
            // 
            this.правилаToolStripMenuItem.Name = "правилаToolStripMenuItem";
            this.правилаToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.правилаToolStripMenuItem.Text = "Правила";
            this.правилаToolStripMenuItem.Click += new System.EventHandler(this.правилаToolStripMenuItem_Click);
            // 
            // поддержатьАвтораToolStripMenuItem
            // 
            this.поддержатьАвтораToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quwiToolStripMenuItem,
            this.сберToolStripMenuItem});
            this.поддержатьАвтораToolStripMenuItem.Name = "поддержатьАвтораToolStripMenuItem";
            this.поддержатьАвтораToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.поддержатьАвтораToolStripMenuItem.Text = "Поддержать автора";
            // 
            // quwiToolStripMenuItem
            // 
            this.quwiToolStripMenuItem.Name = "quwiToolStripMenuItem";
            this.quwiToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.quwiToolStripMenuItem.Text = "Quwi";
            this.quwiToolStripMenuItem.Click += new System.EventHandler(this.quwiToolStripMenuItem_Click);
            // 
            // сберToolStripMenuItem
            // 
            this.сберToolStripMenuItem.Name = "сберToolStripMenuItem";
            this.сберToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.сберToolStripMenuItem.Text = "Сбер";
            this.сберToolStripMenuItem.Click += new System.EventHandler(this.сберToolStripMenuItem_Click);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // кастомизацияToolStripMenuItem
            // 
            this.кастомизацияToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.стандартToolStripMenuItem});
            this.кастомизацияToolStripMenuItem.Name = "кастомизацияToolStripMenuItem";
            this.кастомизацияToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.кастомизацияToolStripMenuItem.Text = "кастомизация";
            // 
            // стандартToolStripMenuItem
            // 
            this.стандартToolStripMenuItem.Name = "стандартToolStripMenuItem";
            this.стандартToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.стандартToolStripMenuItem.Text = "стандарт";
            // 
            // соцСтраницыToolStripMenuItem
            // 
            this.соцСтраницыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.вкToolStripMenuItem});
            this.соцСтраницыToolStripMenuItem.Name = "соцСтраницыToolStripMenuItem";
            this.соцСтраницыToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.соцСтраницыToolStripMenuItem.Text = "Соц страницы";
            // 
            // вкToolStripMenuItem
            // 
            this.вкToolStripMenuItem.Name = "вкToolStripMenuItem";
            this.вкToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.вкToolStripMenuItem.Text = "вк";
            this.вкToolStripMenuItem.Click += new System.EventHandler(this.вкToolStripMenuItem_Click);
            // 
            // F_Chess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1015, 633);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "F_Chess";
            this.Text = "Chess";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.F_Chess_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.F_Chess_MouseClick);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.F_Chess_MouseMove);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer FrameTimer;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem новваяИграToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem настройкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ктоХодитToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem правилаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem поддержатьАвтораToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quwiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сберToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem кастомизацияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem стандартToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem соцСтраницыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вкToolStripMenuItem;
    }
}

