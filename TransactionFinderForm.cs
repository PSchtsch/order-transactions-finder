using System.Windows.Forms;
using TransactionsFinder.Controllers;

namespace TransactionsFinder
{
    public partial class TransactionsFinderForm : Form
    {
        private readonly ITransactionController _transactionController = new TransactionController();

        public TransactionsFinderForm()
        {
            InitializeComponent();
        }

        private void searchBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;

            var entryNumber = searchBox.Text;
            dataGridView.DataSource = _transactionController.GetAllRelatedTransactions(entryNumber);
        }
    }
}
