﻿namespace StreamingAppClient.View;

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
        SuspendLayout();
        // 
        // hubconnect
        // 
        hubconnect.Location = new Point(12, 12);
        hubconnect.Name = "hubconnect";
        hubconnect.Size = new Size(126, 29);
        hubconnect.TabIndex = 0;
        hubconnect.Text = "Hub Connection";
        hubconnect.UseVisualStyleBackColor = true;
        hubconnect.Click += hubconnect_Click;
        // 
        // ClientForm
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(hubconnect);
        Name = "ClientForm";
        Text = "ClientForm";
        ResumeLayout(false);
    }

    #endregion

    private Button hubconnect;
}