namespace A22_Ex05
{
    internal class GameForm : Form
    {
        internal Guess[] m_Guesses;
        internal WinningGuess m_WinningGuess;
        private const int k_space = 15;
        private int m_GuessesAmount;
        private int m_GuessLength;

        internal GameForm(int i_GuessesAmount, int i_GuessLength)
        {
            m_GuessesAmount = i_GuessesAmount;
            m_GuessLength = i_GuessLength;
            initializeComponent();
        }

        private void initializeComponent()
        {
            initializeWinningGuess();
            initializeGuesses();
            initializeThisObject();
        }

        private void initializeWinningGuess()
        {
            m_WinningGuess = new WinningGuess(m_GuessLength);
            this.Controls.Add(m_WinningGuess);
        }

        private void initializeThisObject()
        {
            this.Text = "BullsEye";
            this.Size = new Size(m_Guesses[0].Width, m_Guesses[0].Height * (m_GuessesAmount + 1));
            this.Bounds = new Rectangle(0, 0, this.Size.Width + k_space, this.Size.Height + k_space * 3);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void initializeGuesses()
        {
            m_Guesses = new Guess[m_GuessesAmount];
            for (int i = 0; i < m_GuessesAmount; i++)
            {
                m_Guesses[i] = new Guess(m_GuessLength);
                m_Guesses[i].Location = new Point(0, (i + 1) * m_Guesses[0].Height);
                this.Controls.Add(m_Guesses[i]);
            }
        }
    }
}
