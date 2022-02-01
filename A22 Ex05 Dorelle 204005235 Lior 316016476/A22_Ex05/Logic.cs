namespace A22_Ex05
{
    internal class Logic
    {
        private const int k_GuessLength = 4;
        private int m_GuessesAmount;
        private Color[] m_GameColors = new Color[] { Color.Purple, Color.Red, Color.Green, Color.LightBlue,
                                                     Color.Blue, Color.Yellow, Color.Brown, Color.White };

        private Color[] m_WinningCombination;
        private Color[] m_CurrentGuessCombination;
        private readonly Dictionary<Color, bool> r_AvailableColors = new Dictionary<Color, bool>();
        private int m_ActiveGuessIndex = 0;
        private int m_AmountOfButtonsPickedOnCurrentIndex = 0;

        internal event EventHandler AllButtonsSelected;
        internal Logic()
        {
            m_WinningCombination = new Color[k_GuessLength];
            m_CurrentGuessCombination = new Color[k_GuessLength];
            intializeAvailableColorDictionary();
        }

        private void intializeAvailableColorDictionary()
        {
            foreach (Color color in m_GameColors)
            {
                r_AvailableColors.Add(color, true);
            }
        }

        internal Color[] WinningCombination
        {
            get { return m_WinningCombination; }
        }

        internal int ActiveGuessIndex
        {
            get { return m_ActiveGuessIndex; }
        }

        internal Dictionary<Color, bool> AvailableColors
        {
            get { return r_AvailableColors; }
        }

        internal int GuessLength
        {
            get { return k_GuessLength; }
        }

        internal int GuessesAmount
        {
            get { return m_GuessesAmount; }
            set { m_GuessesAmount = value; }
        }

        internal void UpdateIfAColorIsPicked(Color i_PreviousColor, Color i_SelctedColor, int i_ButtonIndex)
        {
            bool isPreviousColorSelcted = (i_PreviousColor != Color.Empty);

            if (isPreviousColorSelcted)
            {
                r_AvailableColors[i_PreviousColor] = true;
            }

            else
            {
                m_AmountOfButtonsPickedOnCurrentIndex++;
            }

            m_CurrentGuessCombination[i_ButtonIndex] = i_SelctedColor;
            r_AvailableColors[i_SelctedColor] = false;
            respondIfGuessesIsComplete();
        }

        private void respondIfGuessesIsComplete()
        {
            if (m_AmountOfButtonsPickedOnCurrentIndex == k_GuessLength)
            {
                OnAllButtonsSelected();
            }
        }

        protected virtual void OnAllButtonsSelected()
        {
            if (AllButtonsSelected != null)
            {
                AllButtonsSelected.Invoke(this, EventArgs.Empty);
            }
        }

        internal void GenerateResultsFromCurrentGuessAndCheckIfWon(out int o_SamePos, out int o_NotSamePos, out bool o_IsWinningPin)
        {
            o_SamePos = 0;
            o_NotSamePos = 0;

            for (int i = 0; i < m_CurrentGuessCombination.Length; i++)
            {
                for (int j = 0; j < m_WinningCombination.Length; j++)
                {
                    if (m_CurrentGuessCombination[j] == m_WinningCombination[i])
                    {
                        if (i == j)
                        {
                            o_SamePos++;
                            break;
                        }
                        else
                        {
                            o_NotSamePos++;
                            break;
                        }
                    }
                }
            }

            o_IsWinningPin = o_SamePos == k_GuessLength;
        }

        internal bool IsLastGuess()
        {
            return m_ActiveGuessIndex == m_GuessesAmount - 1;
        }

        internal void ResetGuess()
        {
            m_ActiveGuessIndex++;
            m_CurrentGuessCombination = new Color[k_GuessLength];
            m_AmountOfButtonsPickedOnCurrentIndex = 0;
            r_AvailableColors.Clear();
            intializeAvailableColorDictionary();
        }

        internal void GenerateWinningCombination()
        {
            Color[] gameColorsCopy = (Color[])m_GameColors.Clone();
            Random random = new Random();
            int randomIndex;
            int minIndex = 0;
            int maxIndex = gameColorsCopy.Length - 1;

            for (int i = 0; i < m_WinningCombination.Length; i++)
            {
                randomIndex = random.Next(minIndex, maxIndex);
                m_WinningCombination[i] = gameColorsCopy[randomIndex];
                swapColors(ref gameColorsCopy[minIndex], ref gameColorsCopy[randomIndex]);
                minIndex++;
            }
        }

        private void swapColors(ref Color io_Color1, ref Color io_Color2)
        {
            Color tempColor = io_Color1;
            io_Color1 = io_Color2;
            io_Color2 = tempColor;
        }
    }
}
