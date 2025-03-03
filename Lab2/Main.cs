using System.Text;

namespace Lab2;

public partial class Main : Form
{
    private const int RegLen = 37;
    // x37 + x12 + x10 + x2 + 1
    private readonly byte[] _bits = [2,10,12,37];
    public Main()
    {
        InitializeComponent();
    }
    

    private void btn_crypto_Click(object sender, EventArgs e)
    {
        tb_lfsr.Text = CleanText(tb_lfsr.Text);
        string seed = tb_lfsr.Text;
        if (!ValidateSeed(seed)) return;

        tb_sourceText.Text = CleanText(tb_sourceText.Text);
        string sourceText = tb_sourceText.Text;
        string key = GetKey(seed, sourceText.Length);
        // вывод полученного ключа
        tb_key.Text = key;
        
        string cryptoText = Xor(sourceText, key);
        
        // вывод зашифрованного текста в бинарном виде (8 бит на символ)
        tb_cryptoText.Text = cryptoText;
    }
    
    private void btn_openFile_Click(object sender, EventArgs e)
    {
        if (openFileDialog1.ShowDialog() != DialogResult.OK) return;
        
        string data = File.ReadAllText(openFileDialog1.FileName);

        tb_sourceText.Text = CleanText(data);
    }

    private void button1_Click(object sender, EventArgs e)
    {
        if (saveFileDialog1.ShowDialog() != DialogResult.OK) return;
        
        File.WriteAllText(saveFileDialog1.FileName, tb_cryptoText.Text);
        MessageBox.Show($"Файл сохранён как {saveFileDialog1.FileName}");
    }
    
    private bool ValidateSeed(string seed)
    {
        if (seed.Length == RegLen) return true;
        MessageBox.Show("Размер начального состояния должен быть 37 символов!");
        return false;
    }

    private string GetKey(string seed, int lenght)
    {
        byte[] curState = seed.Select(bit => (byte)(bit - '0')).ToArray();
        StringBuilder sb = new StringBuilder(lenght);
        for (int i = 0; i < lenght; i++)
        {
            // добавляем старший бит в результат
            sb.Append(curState[0]);
            
            // получаем бит, которые будет задвигать в начало
            byte newBit = 0;
            foreach (var bit in _bits)
            {
                newBit ^= curState[^bit];
            }
            
            // сдвигаем все кроме первого бит
            Array.Copy(curState, 1, curState, 0, curState.Length - 1);
            
            // сдвигаем последний бит
            curState[^1] = newBit;
        }
        return sb.ToString();
    }

    private string Xor(string data, string key)
    {
        // инициализируем результат
        StringBuilder sb = new StringBuilder(data.Length);
        
        // оформляем xor
        for (int i = 0; i < data.Length; i++)
        {
            if ((data[i] - '0' + key[i] - '0') == 1)
                sb.Append('1');
            else
                sb.Append('0');
        }
        
        // выводим результат
        return sb.ToString();
    }

    private string CleanText(string text)
    {
        return string.Concat(text.Where(c => c == '0' || c == '1'));
    }

    private void tb_lfsr_TextChanged(object sender, EventArgs e)
    {
        tb_count.Text = tb_lfsr.Text.Length.ToString();
    }
}