namespace A22_Ex05
{
    internal class GuessCombination : UserControl
    {
        private int m_GuessesAmount;
        private const int k_Space = 10;
        private Size m_ButtonSize = new Size(40, 40);
        internal CombinationButton[] m_CombinationButtons;

        internal GuessCombination(int i_GuessesAmount)
        {
            m_GuessesAmount = i_GuessesAmount;
            initializeComponent();
        }

        private void initializeComponent()
        {
            this.Size = new Size((m_ButtonSize.Width + k_Space) * m_GuessesAmount - k_Space, m_ButtonSize.Height);
            m_CombinationButtons = new CombinationButton[m_GuessesAmount];
            for (int i = 0; i < m_CombinationButtons.Length; i++)
            {
                m_CombinationButtons[i] = new CombinationButton(i);
                m_CombinationButtons[i].Size = m_ButtonSize;
                m_CombinationButtons[i].Location = new Point((m_CombinationButtons[i].Width + k_Space) * i, 0);
                m_CombinationButtons[i].Enabled = false;
                this.Controls.Add(m_CombinationButtons[i]);
            }
        }
    }
}
