using System;
using System.Windows.Forms;

namespace BidirectionalLists
{
    public partial class HelloForm : Form
    {
        public HelloForm()
        {
            InitializeComponent();
        }

        // Открывает окно работы со списком, скрывает текущее
        public void StartButton_Click(object sender, EventArgs e)
        {
            HelloForm frmh = this;
            Form frm = new BidirectionalListsForm();
            frm.Show();
            Hide();
        }

        // Закрывает все окна
        private void ExitButton_Click(object sender, EventArgs e)
        {
            DialogResult ExitAnswer = MessageBox.Show("Вы действительно хотите завершить работу?",
                "Завершение работы", MessageBoxButtons.YesNo);
            if (ExitAnswer == DialogResult.Yes) //Если нажата “Да”
                Application.Exit(); // Закрыть приложение
            else
                MessageBox.Show("Мы благодарны Вам, за то, что Вы выбрали работу с нашим приложением.");
        }
    }
}
