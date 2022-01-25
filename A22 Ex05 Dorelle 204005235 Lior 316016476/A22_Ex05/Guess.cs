namespace A22_Ex05
{
    internal delegate void WinningPinEventHandler(List<Color> i_WinningColorCombination);

    internal class Guess : UserControl
    {
        internal GuessCombination m_GuessCombination;
        internal GuessResult m_GuessResult;
        internal Button m_GenerateResultButton;
        private const int k_Space = 10;
        private int m_GuessLength;

        internal Guess(int i_GuessLength)
        {
            m_GuessLength = i_GuessLength;
            initializeComponent();
        }

        private void initializeComponent()
        {
            initializeGuessCombination();
            initializeGuessResult();
            initializeGenerateResultButton();
            this.Size = new Size(m_GuessCombination.Width + m_GenerateResultButton.Width + m_GuessResult.Width + 4 * k_Space, m_GuessResult.Height + 2 * k_Space);
            m_GuessCombination.Location = new Point(k_Space, this.Height / 2 - m_GuessResult.Height / 2);
            m_GenerateResultButton.Location = new Point(m_GuessCombination.Right + k_Space, this.Height / 2 - m_GenerateResultButton.Height / 2);
            m_GuessResult.Location = new Point(m_GenerateResultButton.Right + k_Space, this.Height / 2 - m_GuessResult.Height / 2);
            this.Controls.Add(m_GuessCombination);
            this.Controls.Add(m_GuessResult);
            this.Controls.Add(m_GenerateResultButton);
        }

        private void initializeGenerateResultButton()
        {
            m_GenerateResultButton = new Button();
            m_GenerateResultButton.Size = new Size(40, 20);
            m_GenerateResultButton.Enabled = false;
            m_GenerateResultButton.Text = "-->>";
        }

        private void initializeGuessResult()
        {
            m_GuessResult = new GuessResult(m_GuessLength);
        }

        private void initializeGuessCombination()
        {
            m_GuessCombination = new GuessCombination(m_GuessLength);
        }
    }
}
