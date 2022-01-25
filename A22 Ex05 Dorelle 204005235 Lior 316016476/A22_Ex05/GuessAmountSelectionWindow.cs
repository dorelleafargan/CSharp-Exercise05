namespace A22_Ex05
{
    internal class GuessAmountSelectionWindow : Form
    {
        private Button m_GuessNumCounterButton = new Button();
        private Button m_StartButton = new Button();
        private const int k_Space = 30;
        private const int k_MaxGuessesAmount = 10;
        private const int k_MinGuessesAmount = 4;
        private int m_GuessCounter = k_MinGuessesAmount;
        internal event Action<int> GuessNumSetByUser;

        internal GuessAmountSelectionWindow()
        {
            initializeComponent();
        }

        private void initializeComponent()
        {
            initializeThisObject();
            initializeStartButton();
            initializeGuessNumCounterButton();
        }

        private void initializeThisObject()
        {
            this.Text = "BullsEye";
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.Size = new Size(k_Space * 10, k_Space * 6);
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void initializeStartButton()
        {
            m_StartButton.Size = new Size(2 * k_Space, k_Space);
            m_StartButton.Location = new Point(this.Width / 2 - m_StartButton.Width / 2, this.Height * 3 / 5);
            m_StartButton.Text = "Start";
            m_StartButton.Click += new EventHandler(m_StartButton_Click);
            this.Controls.Add(m_StartButton);
        }

        private void initializeGuessNumCounterButton()
        {

            m_GuessNumCounterButton.Size = new Size(k_Space * 6, k_Space);
            m_GuessNumCounterButton.Location = new Point(this.Width / 2 - m_GuessNumCounterButton.Width / 2, this.Height / 5);
            m_GuessNumCounterButton.Text = string.Format("Number of guesses : {0}", m_GuessCounter);
            m_GuessNumCounterButton.Click += new EventHandler(m_GuessNumCounterButton_Click);
            this.Controls.Add(m_GuessNumCounterButton);
        }

        private void m_StartButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            OnGuessNumSetByUser();
        }

        protected virtual void OnGuessNumSetByUser()
        {
            if (GuessNumSetByUser != null)
            {
                GuessNumSetByUser.Invoke(m_GuessCounter);
            }
        }

        private void m_GuessNumCounterButton_Click(object sender, EventArgs e)
        {
            if (m_GuessCounter < k_MaxGuessesAmount)
            {
                m_GuessCounter++;
                m_GuessNumCounterButton.Text = string.Format("Number of guesses : {0}", m_GuessCounter);
            }
            else
            {
                m_GuessCounter = 4;
                m_GuessNumCounterButton.Text = string.Format("Number of guesses : {0}", m_GuessCounter);
            }
        }
    }
}
