namespace A22_Ex05
{
    internal class GuessResult : UserControl
    {
        private Size m_ButtonSize = new Size(15, 15);
        private const int k_Space = 10;
        private int m_GuessesAmount;
        private Button[] m_ResultButtons;

        internal GuessResult(int i_GuessesAmount)
        {
            m_GuessesAmount = i_GuessesAmount;
            initializeComponent();
        }

        private void initializeComponent()
        {
            this.Size = new Size((m_ButtonSize.Width) * 2 + k_Space, (m_GuessesAmount / 2) * (m_ButtonSize.Height + k_Space) - k_Space);
            m_ResultButtons = new Button[m_GuessesAmount];
            for (int i = 0; i < m_GuessesAmount; i++)
            {
                m_ResultButtons[i] = new Button();
                m_ResultButtons[i].Size = m_ButtonSize;
                m_ResultButtons[i].Enabled = false;
                m_ResultButtons[i].Location = new Point((i % 2) * (this.Right - m_ButtonSize.Width), (i / 2) * (k_Space + m_ButtonSize.Height));
                this.Controls.Add(m_ResultButtons[i]);
            }
        }

        internal void GenerateResultView(int i_SamePosGuesses, int i_NotSamePosGuesses)
        {
            for (int i = 0; i < i_SamePosGuesses; i++)
            {
                m_ResultButtons[i].BackColor = Color.Black;
            }

            for (int i = i_SamePosGuesses; i < i_SamePosGuesses + i_NotSamePosGuesses; i++)
            {
                m_ResultButtons[i].BackColor = Color.Yellow;
            }
        }
    }
}
