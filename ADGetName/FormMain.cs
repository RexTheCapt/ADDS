using System;
using System.DirectoryServices;
using System.DirectoryServices.ActiveDirectory;
using System.Windows.Forms;

namespace ADGetName
{
    public partial class FormMain : Form
    {
        private readonly SearchSettings _searchSettings = SearchSettings.Default;
        private int _lastSearchedNumber;

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            Update();

            textBoxComputerName.Text = _searchSettings.ComputerName;
            numericUpDownStartNumber.Value = _searchSettings.StartingNumber;
            numericUpDownNumberLength.Value = _searchSettings.NumberLength;
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            SearchForComputerName((int)numericUpDownStartNumber.Value);
        }

        private void SearchForComputerName(int startingNumber, bool clearList = true)
        {
            buttonSearch.Enabled = false;

            GlobalCatalog globalCatalog = Forest.GetCurrentForest().FindGlobalCatalog();
            DirectorySearcher directorySearcher = globalCatalog.GetDirectorySearcher();

            if(clearList)
                listBoxAvailableNames.Items.Clear();

            while (true)
            {
                string number = startingNumber.ToString();

                while (number.Length < numericUpDownNumberLength.Value)
                {
                    number = $"0{number}";
                }

                directorySearcher.Filter = $"(&(ObjectCategory=computer)(name={textBoxComputerName.Text}{number}))";

                SearchResultCollection searchResultCollection = directorySearcher.FindAll();

                if (searchResultCollection.Count == 0)
                {
                    listBoxAvailableNames.Items.Add($"{textBoxComputerName.Text}{number}");
                    Update();

                    if (listBoxAvailableNames.Items.Count == 10)
                    {
                        _lastSearchedNumber = startingNumber;
                        break;
                    }
                }

                startingNumber++;
            }

            buttonSearch.Enabled = true;
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            _searchSettings.ComputerName = textBoxComputerName.Text;
            _searchSettings.StartingNumber = numericUpDownStartNumber.Value;
            _searchSettings.NumberLength = numericUpDownNumberLength.Value;
            _searchSettings.Save();
        }

        private void listBoxAvailableNames_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && listBoxAvailableNames.SelectedItem != null)
            {
                listBoxAvailableNames.Items.RemoveAt(listBoxAvailableNames.SelectedIndex);

                SearchForComputerName(++_lastSearchedNumber, false);
            }
        }

        private void contextMenuStripComputerNameActions_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            contextMenuStripComputerNameActions.Items.Clear();

            if (listBoxAvailableNames.SelectedItem != null)
            {
                string selectedName = listBoxAvailableNames.Items[listBoxAvailableNames.SelectedIndex].ToString();

                ToolStripItem copy = contextMenuStripComputerNameActions.Items.Add($"Copy {selectedName}");
                ToolStripItem delete = contextMenuStripComputerNameActions.Items.Add($"Delete {selectedName}");

                copy.Click += ContextCopyComputerName;
                delete.Click += ContextDeleteComputerName;
            }
        }

        private void ContextDeleteComputerName(object sender, EventArgs e)
        {
            listBoxAvailableNames_KeyDown(listBoxAvailableNames, new KeyEventArgs(Keys.Delete));
        }

        private void ContextCopyComputerName(object sender, EventArgs e)
        {
            Clipboard.SetText(listBoxAvailableNames.Items[listBoxAvailableNames.SelectedIndex].ToString());
        }
    }
}
