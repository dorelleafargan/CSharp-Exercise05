namespace A22_Ex05
{
    internal class WinningGuess : UserControl
    {
        private const int k_Space = 10;
        private int m_GuessesAmount;
        private CombinationButton[] m_BlackButtonsOrWinningCombination;

        internal WinningGuess(int i_GuessesAmount)
        {
            m_GuessesAmount = i_GuessesAmount;
            initializeComponent();
        }

        private void initializeComponent()
        {
            m_BlackButtonsOrWinningCombination = new CombinationButton[m_GuessesAmount];
            for (int i = 0; i < m_BlackButtonsOrWinningCombination.Length; i++)
            {
                m_BlackButtonsOrWinningCombination[i] = new CombinationButton(i);
                m_BlackButtonsOrWinningCombination[i].BackColor = Color.Black;
                m_BlackButtonsOrWinningCombination[i].Enabled = false;
                m_BlackButtonsOrWinningCombination[i].Location = new Point(k_Space + (m_BlackButtonsOrWinningCombination[0].Size.Width + k_Space) * i, k_Space);
                this.Controls.Add(m_BlackButtonsOrWinningCombination[i]);
            }

            this.Size = new Size((m_BlackButtonsOrWinningCombination[0].Width + k_Space) * m_GuessesAmount, m_BlackButtonsOrWinningCombination[0].Height + 2 * k_Space);
        }

        internal void DisplayWinningGuess(Color[] i_WinningGuessCombination)
        {
            for (int i = 0; i < i_WinningGuessCombination.Length; i++)
            {
                m_BlackButtonsOrWinningCombination[i].BackColor = i_WinningGuessCombination[i];
            }
        }
    }
}
