namespace renomeador
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonFolder_Click(object sender, EventArgs e)
        {
            var FolderDialog = new FolderBrowserDialog();
            DialogResult result = FolderDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                String folderPath = FolderDialog.SelectedPath;
                if (folderPath != null || folderPath != "")
                {
                    txtCaminho.Text = folderPath;
                    txtCaminho.Focus();
                    String[] files;
                    files = Directory.GetFiles(folderPath!);
                    int count = 0;
                    foreach (String file in files)
                    {
                        count++;
                    }
                    lblArquivos.Text = String.Format("{0} Arquivos encontrados", count);
                }
            }
        }

        private void btnRenomear_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Deseja continuar", "Confirmar", MessageBoxButtons.YesNo);
            if(result == DialogResult.Yes && txtNome.Text != null)
            {
                String nome = txtNome.Text;
                String newFolderPath = Path.Combine(txtCaminho.Text, "alterado");
                Directory.CreateDirectory(newFolderPath);
                String[] files;
                files = Directory.GetFiles(txtCaminho.Text!);
                int count = 1;
                foreach (String file in files)
                {
                    String nomeAntigo = Path.GetFileName(file);
                    String[] itens = nomeAntigo.Split(".");
                    String novoFileNome = $"{nome} ({count}).{itens[1]}";
                    if (count == 1)
                    {
                        novoFileNome = $"{nome}.{itens[1]}";
                    }
                    File.Move(file, Path.Combine(newFolderPath, novoFileNome));
                    count++;
                }
                MessageBox.Show("Operação concluida!","Sucesso", MessageBoxButtons.OK);
            }
        }
    }
}
