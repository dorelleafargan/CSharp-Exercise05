namespace A22_Ex05
{
    internal class GameManager
    {
        private Logic m_Logic = new Logic();
        private GuessAmountSelectionWindow m_GuessAmountSelectionWindow = new GuessAmountSelectionWindow();
        private GameForm m_GameForm;

        internal void RunBullsEye()
        {
            initializeLogic();
            m_GuessAmountSelectionWindow.GuessNumSetByUser += m_GuessAmountSelectionWindow_GuessNumSetByUser;
            m_GuessAmountSelectionWindow.ShowDialog();
        }

        private void initializeLogic()
        {
            m_Logic.GenerateWinningCombination();
            m_Logic.AllButtonsSelected += m_Logic_AllButtonsSelected;
        }

        private void m_GuessAmountSelectionWindow_GuessNumSetByUser(int i_GuessesAmount)
        {
            m_Logic.GuessesAmount = i_GuessesAmount;
            startGameForm();
        }

        private void startGameForm()
        {
            m_GameForm = new GameForm(m_Logic.GuessesAmount, m_Logic.GuessLength);
            activateNextGuess();
            m_GameForm.ShowDialog();
        }

        private void activateNextGuess()
        {
            foreach (CombinationButton CombinationButton in m_GameForm.m_Guesses[m_Logic.ActiveGuessIndex].m_GuessCombination.m_CombinationButtons)
            {
                CombinationButton.Enabled = true;
                CombinationButton.Click += CombinationButton_Click;
                CombinationButton.UpdateAColorWasPicked += CombinationButton_UpdateAColorWasPicked;
            }
        }

        private void deactivateCurrentGuess()
        {
            m_GameForm.m_Guesses[m_Logic.ActiveGuessIndex].m_GenerateResultButton.Enabled = false;
            foreach (CombinationButton CombinationButton in m_GameForm.m_Guesses[m_Logic.ActiveGuessIndex].m_GuessCombination.m_CombinationButtons)
            {
                CombinationButton.Enabled = false;
                CombinationButton.Click -= CombinationButton_Click;
                CombinationButton.UpdateAColorWasPicked -= CombinationButton_UpdateAColorWasPicked;
            }
        }

        private void CombinationButton_UpdateAColorWasPicked(Color i_PreviousColor, Color i_SelectedColor, int i_ButtonIndex)
        {
            m_Logic.UpdateIfAColorIsPicked(i_PreviousColor, i_SelectedColor, i_ButtonIndex);
        }


        private void m_Logic_AllButtonsSelected(object sender, EventArgs e)
        {
            bool isGenerateResultButtonEnabled = m_GameForm.m_Guesses[m_Logic.ActiveGuessIndex].m_GenerateResultButton.Enabled == true;

            if (!isGenerateResultButtonEnabled)
            {
                m_GameForm.m_Guesses[m_Logic.ActiveGuessIndex].m_GenerateResultButton.Click += m_GenerateResultButton_Click;
            }

            m_GameForm.m_Guesses[m_Logic.ActiveGuessIndex].m_GenerateResultButton.Enabled = true;
        }

        private void m_GenerateResultButton_Click(object sender, EventArgs e)
        {
            deactivateCurrentGuess();
            m_Logic.GenerateResultsFromCurrentGuessAndCheckIfWon(out int samePos, out int notSamePos, out bool isWinningPin);
            m_GameForm.m_Guesses[m_Logic.ActiveGuessIndex].m_GuessResult.GenerateResultView(samePos, notSamePos);
            if (isWinningPin)
            {
                enteredPinIsCurrect();
            }
            else
            {
                enteredPinIsNotCurrect();
            }
        }

        private void enteredPinIsNotCurrect()
        {
            bool isLastGuess = m_Logic.IsLastGuess();

            if (isLastGuess)
            {
                printLosingMsg();
            }
            else
            {
                m_Logic.ResetGuess();
                activateNextGuess();
            }
        }

        private void printLosingMsg()
        {
            m_GameForm.m_WinningGuess.DisplayWinningGuess(m_Logic.WinningCombination);
            if (MessageBox.Show(
@"Game Finished, you lost
Restart Game?"
                , "You Lost"
                , MessageBoxButtons.YesNo
                , MessageBoxIcon.Question) == DialogResult.Yes)
            {
                restartGame();
            }
            else
            {
                m_GameForm.Close();
            }
        }

        private void enteredPinIsCurrect()
        {
            m_GameForm.m_WinningGuess.DisplayWinningGuess(m_Logic.WinningCombination);
            printWinningMsg();
        }

        private void printWinningMsg()
        {
            if (MessageBox.Show(
@"Game Finished, you guessed correctly
Restart Game?"
                , "You Won"
                , MessageBoxButtons.YesNo
                , MessageBoxIcon.Question) == DialogResult.Yes)
            {
                restartGame();
            }
            else
            {
                m_GameForm.Close();
            }
        }

        private void restartGame()
        {
            m_Logic = new Logic();
            m_GuessAmountSelectionWindow = new GuessAmountSelectionWindow();
            m_GameForm.Dispose();
            this.RunBullsEye();
        }

        private void CombinationButton_Click(object sender, EventArgs e)
        {
            ColorSelectionWindow colorSelectionWindow = new ColorSelectionWindow(m_Logic.AvailableColors);
            colorSelectionWindow.ClickedColorButton += (sender as CombinationButton).colorSelectionWindow_ClickedColorButton;
            colorSelectionWindow.ShowDialog();
        }
    }
}
