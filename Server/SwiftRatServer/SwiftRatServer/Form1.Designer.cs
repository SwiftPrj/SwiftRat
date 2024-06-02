
namespace SwiftRatServer
{
    partial class Server
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
            console = new RichTextBox();
            consoleInput = new TextBox();
            send = new Button();
            SuspendLayout();
            // 
            // console
            // 
            console.Location = new Point(0, 0);
            console.Name = "console";
            console.Size = new Size(1524, 827);
            console.TabIndex = 0;
            console.Text = "";
            console.TextChanged += console_TextChanged;
            // 
            // consoleInput
            // 
            consoleInput.Location = new Point(0, 833);
            consoleInput.Name = "consoleInput";
            consoleInput.Size = new Size(1524, 23);
            consoleInput.TabIndex = 1;
            // 
            // send
            // 
            send.Location = new Point(1530, 832);
            send.Name = "send";
            send.Size = new Size(52, 23);
            send.TabIndex = 2;
            send.Text = "Send";
            send.UseVisualStyleBackColor = true;
            // 
            // Server
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1584, 861);
            Controls.Add(send);
            Controls.Add(consoleInput);
            Controls.Add(console);
            Name = "Server";
            Text = "Swift Rat Server";
            Load += Server_Load;
            ResumeLayout(false);
            PerformLayout();
        }


        #endregion

        private RichTextBox console;
        private TextBox consoleInput;
        private Button send;
    }
}
