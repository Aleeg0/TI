namespace Lab2;

partial class Main
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
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        tb_lfsr = new System.Windows.Forms.TextBox();
        lb_info = new System.Windows.Forms.Label();
        btn_crypto = new System.Windows.Forms.Button();
        lb_key = new System.Windows.Forms.Label();
        tb_key = new System.Windows.Forms.TextBox();
        lb_sourceText = new System.Windows.Forms.Label();
        tb_sourceText = new System.Windows.Forms.TextBox();
        lb_cryptoText = new System.Windows.Forms.Label();
        tb_cryptoText = new System.Windows.Forms.TextBox();
        openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
        btn_openFile = new System.Windows.Forms.Button();
        btn_saveFile = new System.Windows.Forms.Button();
        saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
        tb_count = new System.Windows.Forms.TextBox();
        lb_count = new System.Windows.Forms.Label();
        SuspendLayout();
        // 
        // tb_lfsr
        // 
        tb_lfsr.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)204));
        tb_lfsr.Location = new System.Drawing.Point(12, 54);
        tb_lfsr.MaxLength = 4000;
        tb_lfsr.Name = "tb_lfsr";
        tb_lfsr.PlaceholderText = "1010101010101010101010101010101010101";
        tb_lfsr.Size = new System.Drawing.Size(358, 29);
        tb_lfsr.TabIndex = 0;
        tb_lfsr.TextChanged += tb_lfsr_TextChanged;
        // 
        // lb_info
        // 
        lb_info.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)204));
        lb_info.Location = new System.Drawing.Point(12, 20);
        lb_info.Name = "lb_info";
        lb_info.Size = new System.Drawing.Size(358, 31);
        lb_info.TabIndex = 1;
        lb_info.Text = "Введите начальное состояние LFSR";
        // 
        // btn_crypto
        // 
        btn_crypto.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)204));
        btn_crypto.Location = new System.Drawing.Point(12, 196);
        btn_crypto.Name = "btn_crypto";
        btn_crypto.Size = new System.Drawing.Size(160, 41);
        btn_crypto.TabIndex = 2;
        btn_crypto.Text = "Результат";
        btn_crypto.UseVisualStyleBackColor = true;
        btn_crypto.Click += btn_crypto_Click;
        // 
        // lb_key
        // 
        lb_key.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)204));
        lb_key.Location = new System.Drawing.Point(12, 240);
        lb_key.Name = "lb_key";
        lb_key.Size = new System.Drawing.Size(608, 24);
        lb_key.TabIndex = 3;
        lb_key.Text = "Полученный ключ";
        // 
        // tb_key
        // 
        tb_key.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)204));
        tb_key.Location = new System.Drawing.Point(12, 267);
        tb_key.MaxLength = 4000;
        tb_key.Multiline = true;
        tb_key.Name = "tb_key";
        tb_key.ReadOnly = true;
        tb_key.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        tb_key.Size = new System.Drawing.Size(608, 75);
        tb_key.TabIndex = 4;
        // 
        // lb_sourceText
        // 
        lb_sourceText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)204));
        lb_sourceText.Location = new System.Drawing.Point(12, 87);
        lb_sourceText.Name = "lb_sourceText";
        lb_sourceText.Size = new System.Drawing.Size(608, 24);
        lb_sourceText.TabIndex = 5;
        lb_sourceText.Text = "Исходный текст";
        // 
        // tb_sourceText
        // 
        tb_sourceText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)204));
        tb_sourceText.Location = new System.Drawing.Point(12, 114);
        tb_sourceText.MaxLength = 4000;
        tb_sourceText.Multiline = true;
        tb_sourceText.Name = "tb_sourceText";
        tb_sourceText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        tb_sourceText.Size = new System.Drawing.Size(608, 76);
        tb_sourceText.TabIndex = 6;
        // 
        // lb_cryptoText
        // 
        lb_cryptoText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)204));
        lb_cryptoText.Location = new System.Drawing.Point(12, 353);
        lb_cryptoText.Name = "lb_cryptoText";
        lb_cryptoText.Size = new System.Drawing.Size(608, 24);
        lb_cryptoText.TabIndex = 7;
        lb_cryptoText.Text = "Зашифрованный текст";
        // 
        // tb_cryptoText
        // 
        tb_cryptoText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)204));
        tb_cryptoText.Location = new System.Drawing.Point(12, 380);
        tb_cryptoText.MaxLength = 4000;
        tb_cryptoText.Multiline = true;
        tb_cryptoText.Name = "tb_cryptoText";
        tb_cryptoText.ReadOnly = true;
        tb_cryptoText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        tb_cryptoText.Size = new System.Drawing.Size(608, 76);
        tb_cryptoText.TabIndex = 8;
        // 
        // openFileDialog1
        // 
        openFileDialog1.Filter = "Text Files|*.txt|All Files|*.*";
        openFileDialog1.Title = "Открыть файл";
        // 
        // btn_openFile
        // 
        btn_openFile.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)204));
        btn_openFile.Location = new System.Drawing.Point(485, 40);
        btn_openFile.Name = "btn_openFile";
        btn_openFile.Size = new System.Drawing.Size(135, 43);
        btn_openFile.TabIndex = 9;
        btn_openFile.Text = "Открыть файл";
        btn_openFile.UseVisualStyleBackColor = true;
        btn_openFile.Click += btn_openFile_Click;
        // 
        // btn_saveFile
        // 
        btn_saveFile.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)204));
        btn_saveFile.Location = new System.Drawing.Point(12, 462);
        btn_saveFile.Name = "btn_saveFile";
        btn_saveFile.Size = new System.Drawing.Size(160, 41);
        btn_saveFile.TabIndex = 10;
        btn_saveFile.Text = "Сохранить в файл";
        btn_saveFile.UseVisualStyleBackColor = true;
        btn_saveFile.Click += button1_Click;
        // 
        // saveFileDialog1
        // 
        saveFileDialog1.FileName = "output.txt";
        saveFileDialog1.Filter = "Text Files|*.txt|All Files|*.*";
        saveFileDialog1.Title = "Сохранить файл";
        // 
        // tb_count
        // 
        tb_count.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)204));
        tb_count.Location = new System.Drawing.Point(400, 54);
        tb_count.Name = "tb_count";
        tb_count.Size = new System.Drawing.Size(38, 29);
        tb_count.TabIndex = 11;
        // 
        // lb_count
        // 
        lb_count.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)204));
        lb_count.Location = new System.Drawing.Point(376, 20);
        lb_count.Name = "lb_count";
        lb_count.Size = new System.Drawing.Size(103, 31);
        lb_count.TabIndex = 12;
        lb_count.Text = "количество";
        // 
        // Main
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(636, 510);
        Controls.Add(lb_count);
        Controls.Add(tb_count);
        Controls.Add(btn_saveFile);
        Controls.Add(btn_openFile);
        Controls.Add(tb_cryptoText);
        Controls.Add(lb_cryptoText);
        Controls.Add(tb_sourceText);
        Controls.Add(lb_sourceText);
        Controls.Add(tb_key);
        Controls.Add(lb_key);
        Controls.Add(btn_crypto);
        Controls.Add(lb_info);
        Controls.Add(tb_lfsr);
        Text = "Lab2";
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.Label lb_count;

    private System.Windows.Forms.TextBox tb_count;

    private System.Windows.Forms.SaveFileDialog saveFileDialog1;

    private System.Windows.Forms.Button btn_openFile;
    private System.Windows.Forms.Button btn_saveFile;

    private System.Windows.Forms.OpenFileDialog openFileDialog1;

    private System.Windows.Forms.Label lb_cryptoText;
    private System.Windows.Forms.TextBox tb_cryptoText;

    private System.Windows.Forms.TextBox tb_sourceText;

    private System.Windows.Forms.Label lb_sourceText;

    private System.Windows.Forms.TextBox tb_key;

    private System.Windows.Forms.Label lb_key;

    private System.Windows.Forms.Button btn_crypto;

    private System.Windows.Forms.Label lb_info;

    private System.Windows.Forms.TextBox tb_lfsr;

    #endregion
}