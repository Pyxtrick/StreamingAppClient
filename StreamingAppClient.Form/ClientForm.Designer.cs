namespace StreamingAppClient.View;

partial class ClientForm
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
        hubconnect = new Button();
        button1 = new Button();
        button2 = new Button();
        PosX = new TextBox();
        PosY = new TextBox();
        PosR = new TextBox();
        PosSize = new TextBox();
        groupBox1 = new GroupBox();
        groupBox2 = new GroupBox();
        label4 = new Label();
        label3 = new Label();
        label2 = new Label();
        label1 = new Label();
        groupBox1.SuspendLayout();
        groupBox2.SuspendLayout();
        SuspendLayout();
        // 
        // hubconnect
        // 
        hubconnect.Location = new Point(6, 26);
        hubconnect.Name = "hubconnect";
        hubconnect.Size = new Size(126, 29);
        hubconnect.TabIndex = 0;
        hubconnect.Text = "Hub Connection";
        hubconnect.UseVisualStyleBackColor = true;
        hubconnect.Click += hubconnect_Click;
        // 
        // button1
        // 
        button1.Location = new Point(7, 26);
        button1.Name = "button1";
        button1.Size = new Size(155, 29);
        button1.TabIndex = 1;
        button1.Text = "initalize Vtube";
        button1.UseVisualStyleBackColor = true;
        button1.Click += button1_Click;
        // 
        // button2
        // 
        button2.Location = new Point(6, 73);
        button2.Name = "button2";
        button2.Size = new Size(155, 29);
        button2.TabIndex = 2;
        button2.Text = "Change Size";
        button2.UseVisualStyleBackColor = true;
        button2.Click += button2_Click;
        // 
        // PosX
        // 
        PosX.Location = new Point(7, 133);
        PosX.Name = "PosX";
        PosX.Size = new Size(125, 27);
        PosX.TabIndex = 3;
        PosX.KeyPress += PosX_KeyPress;
        // 
        // PosY
        // 
        PosY.Location = new Point(138, 133);
        PosY.Name = "PosY";
        PosY.Size = new Size(125, 27);
        PosY.TabIndex = 4;
        PosY.KeyPress += PosY_KeyPress;
        // 
        // PosR
        // 
        PosR.Location = new Point(269, 133);
        PosR.Name = "PosR";
        PosR.Size = new Size(125, 27);
        PosR.TabIndex = 5;
        PosR.KeyPress += PosR_KeyPress;
        // 
        // PosSize
        // 
        PosSize.Location = new Point(400, 133);
        PosSize.Name = "PosSize";
        PosSize.Size = new Size(125, 27);
        PosSize.TabIndex = 6;
        PosSize.KeyPress += PosSize_KeyPress;
        // 
        // groupBox1
        // 
        groupBox1.Controls.Add(hubconnect);
        groupBox1.Location = new Point(12, 12);
        groupBox1.Name = "groupBox1";
        groupBox1.Size = new Size(196, 72);
        groupBox1.TabIndex = 8;
        groupBox1.TabStop = false;
        groupBox1.Text = "SignalR";
        // 
        // groupBox2
        // 
        groupBox2.Controls.Add(label4);
        groupBox2.Controls.Add(label3);
        groupBox2.Controls.Add(PosSize);
        groupBox2.Controls.Add(label2);
        groupBox2.Controls.Add(PosR);
        groupBox2.Controls.Add(label1);
        groupBox2.Controls.Add(PosY);
        groupBox2.Controls.Add(button1);
        groupBox2.Controls.Add(button2);
        groupBox2.Controls.Add(PosX);
        groupBox2.Location = new Point(12, 90);
        groupBox2.Name = "groupBox2";
        groupBox2.Size = new Size(550, 198);
        groupBox2.TabIndex = 9;
        groupBox2.TabStop = false;
        groupBox2.Text = "VTubeStudio";
        // 
        // label4
        // 
        label4.AutoSize = true;
        label4.Location = new Point(400, 110);
        label4.Name = "label4";
        label4.Size = new Size(36, 20);
        label4.TabIndex = 13;
        label4.Text = "Size";
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Location = new Point(269, 110);
        label3.Name = "label3";
        label3.Size = new Size(66, 20);
        label3.TabIndex = 12;
        label3.Text = "Rotation";
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(138, 110);
        label2.Name = "label2";
        label2.Size = new Size(39, 20);
        label2.TabIndex = 11;
        label2.Text = "PosY";
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(7, 110);
        label1.Name = "label1";
        label1.Size = new Size(40, 20);
        label1.TabIndex = 10;
        label1.Text = "PosX";
        // 
        // ClientForm
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(716, 450);
        Controls.Add(groupBox2);
        Controls.Add(groupBox1);
        Name = "ClientForm";
        Text = "ClientForm";
        groupBox1.ResumeLayout(false);
        groupBox2.ResumeLayout(false);
        groupBox2.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private Button hubconnect;
    private Button button1;
    private Button button2;
    private TextBox PosX;
    private TextBox PosY;
    private TextBox PosR;
    private TextBox PosSize;
    private GroupBox groupBox1;
    private GroupBox groupBox2;
    private Label label1;
    private Label label4;
    private Label label3;
    private Label label2;
}