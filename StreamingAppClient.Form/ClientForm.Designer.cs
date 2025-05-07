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
        GetInfo = new Button();
        label8 = new Label();
        label7 = new Label();
        label6 = new Label();
        label5 = new Label();
        ActiveItemList = new ListBox();
        ItemList = new ListBox();
        ModelToggleList = new ListBox();
        ModelList = new ListBox();
        label4 = new Label();
        label3 = new Label();
        label2 = new Label();
        label1 = new Label();
        TestSend = new Button();
        setWindow = new Button();
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
        groupBox2.Controls.Add(GetInfo);
        groupBox2.Controls.Add(label8);
        groupBox2.Controls.Add(label7);
        groupBox2.Controls.Add(label6);
        groupBox2.Controls.Add(label5);
        groupBox2.Controls.Add(ActiveItemList);
        groupBox2.Controls.Add(ItemList);
        groupBox2.Controls.Add(ModelToggleList);
        groupBox2.Controls.Add(ModelList);
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
        groupBox2.Size = new Size(1174, 396);
        groupBox2.TabIndex = 9;
        groupBox2.TabStop = false;
        groupBox2.Text = "VTubeStudio";
        // 
        // GetInfo
        // 
        GetInfo.Location = new Point(947, 163);
        GetInfo.Name = "GetInfo";
        GetInfo.Size = new Size(94, 29);
        GetInfo.TabIndex = 26;
        GetInfo.Text = "GetInfo";
        GetInfo.UseVisualStyleBackColor = true;
        GetInfo.Click += GetInfo_Click;
        // 
        // label8
        // 
        label8.AutoSize = true;
        label8.Location = new Point(567, 203);
        label8.Name = "label8";
        label8.Size = new Size(90, 20);
        label8.TabIndex = 25;
        label8.Text = "Active Items";
        // 
        // label7
        // 
        label7.AutoSize = true;
        label7.Location = new Point(400, 203);
        label7.Name = "label7";
        label7.Size = new Size(45, 20);
        label7.TabIndex = 24;
        label7.Text = "Items";
        // 
        // label6
        // 
        label6.AutoSize = true;
        label6.Location = new Point(209, 203);
        label6.Name = "label6";
        label6.Size = new Size(108, 20);
        label6.TabIndex = 23;
        label6.Text = "Model Toggles";
        // 
        // label5
        // 
        label5.AutoSize = true;
        label5.Location = new Point(6, 203);
        label5.Name = "label5";
        label5.Size = new Size(58, 20);
        label5.TabIndex = 22;
        label5.Text = "Models";
        // 
        // ActiveItemList
        // 
        ActiveItemList.FormattingEnabled = true;
        ActiveItemList.Location = new Point(567, 226);
        ActiveItemList.Name = "ActiveItemList";
        ActiveItemList.Size = new Size(125, 104);
        ActiveItemList.TabIndex = 21;
        ActiveItemList.SelectedIndexChanged += ActiveItemList_SelectedIndexChanged;
        // 
        // ItemList
        // 
        ItemList.FormattingEnabled = true;
        ItemList.Location = new Point(400, 226);
        ItemList.Name = "ItemList";
        ItemList.Size = new Size(125, 104);
        ItemList.TabIndex = 19;
        ItemList.SelectedIndexChanged += ItemList_SelectedIndexChanged;
        // 
        // ModelToggleList
        // 
        ModelToggleList.FormattingEnabled = true;
        ModelToggleList.Location = new Point(209, 226);
        ModelToggleList.Name = "ModelToggleList";
        ModelToggleList.Size = new Size(150, 104);
        ModelToggleList.TabIndex = 17;
        ModelToggleList.SelectedIndexChanged += ModelToggleList_SelectedIndexChanged;
        // 
        // ModelList
        // 
        ModelList.FormattingEnabled = true;
        ModelList.Location = new Point(7, 226);
        ModelList.Name = "ModelList";
        ModelList.Size = new Size(150, 104);
        ModelList.TabIndex = 10;
        ModelList.SelectedIndexChanged += ModelList_SelectedIndexChanged;
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
        // TestSend
        // 
        TestSend.Location = new Point(322, 38);
        TestSend.Name = "TestSend";
        TestSend.Size = new Size(126, 29);
        TestSend.TabIndex = 1;
        TestSend.Text = "Send Text";
        TestSend.TextImageRelation = TextImageRelation.ImageAboveText;
        TestSend.UseVisualStyleBackColor = true;
        TestSend.Click += TestSend_Click;
        // 
        // setWindow
        // 
        setWindow.Location = new Point(492, 38);
        setWindow.Name = "setWindow";
        setWindow.Size = new Size(126, 29);
        setWindow.TabIndex = 10;
        setWindow.Text = "Set window";
        setWindow.TextImageRelation = TextImageRelation.ImageAboveText;
        setWindow.UseVisualStyleBackColor = true;
        setWindow.Click += setWindow_Click;
        // 
        // ClientForm
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1319, 593);
        Controls.Add(setWindow);
        Controls.Add(TestSend);
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
    private ListBox ModelList;
    private ListBox ModelToggleList;
    private ListBox ItemList;
    private ListBox ActiveItemList;
    private Label label8;
    private Label label7;
    private Label label6;
    private Label label5;
    private Button TestSend;
    private Button setWindow;
    private Button GetInfo;
}