using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace SetTheGame.Resources
{
    public sealed class ResourcesManager
    {
        private string languagePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "language.xml");
        public bool isFrench { get; set; }
        private static ResourcesManager instance = null;
        public static ResourcesManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ResourcesManager();
                }
                return instance;
            }
        }

        private ResourcesManager()
        {
            try
            {
                using (FileStream fs = new FileStream(languagePath, FileMode.Open))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(bool));
                    isFrench = (bool)ser.Deserialize(fs);
                }
            }
            catch (Exception)
            {
                isFrench = true;
            }
        }

        public void Save()
        {
            using (TextWriter writer = new StreamWriter(languagePath))
            {
                XmlSerializer ser = new XmlSerializer(typeof(bool));
                ser.Serialize(writer, isFrench);
            }
        }

        public string GamemodeHelpButtonTitle { get { return isFrench ? Resources_fr.GamemodeHelpButtonTitle : Resource_en.GamemodeHelpButtonTitle; } }
        public string TutorialPageThreePartThree { get { return isFrench ? Resources_fr.TutorialPageThreePartThree : Resource_en.TutorialPageThreePartThree; } }
        public string HypersetTutorialPageTwoPartTwo { get { return isFrench ? Resources_fr.HypersetTutorialPageTwoPartTwo : Resource_en.HypersetTutorialPageTwoPartTwo; } }
        public string HypersetTutorialPageTwoPartOne { get { return isFrench ? Resources_fr.HypersetTutorialPageTwoPartOne : Resource_en.HypersetTutorialPageTwoPartOne; } }
        public string ScorePerMinute { get { return isFrench ? Resources_fr.ScorePerMinute : Resource_en.ScorePerMinute; } }
        public string TutorialPageTwoPartOne { get { return isFrench ? Resources_fr.TutorialPageTwoPartOne : Resource_en.TutorialPageTwoPartOne; } }
        public string TutorialPageTwoPartTwo { get { return isFrench ? Resources_fr.TutorialPageTwoPartTwo : Resource_en.TutorialPageTwoPartTwo; } }
        public string Previous { get { return isFrench ? Resources_fr.Previous : Resource_en.Previous; } }
        public string Seconds { get { return isFrench ? Resources_fr.Seconds : Resource_en.Seconds; } }
        public string ScoreLabelText { get { return isFrench ? Resources_fr.ScoreLabelText : Resource_en.ScoreLabelText; } }
        public string TutorialPageThreePartOne { get { return isFrench ? Resources_fr.TutorialPageThreePartOne : Resource_en.TutorialPageThreePartOne; } }
        public string TutorialPageThreePartTwo { get { return isFrench ? Resources_fr.TutorialPageThreePartTwo : Resource_en.TutorialPageThreePartTwo; } }
        public string RemainingTimeText { get { return isFrench ? Resources_fr.RemainingTimeText : Resource_en.RemainingTimeText; } }
        public string ChoseLeaderboard { get { return isFrench ? Resources_fr.ChoseLeaderboard : Resource_en.ChoseLeaderboard; } }
        public string NoScore { get { return isFrench ? Resources_fr.NoScore : Resource_en.NoScore; } }
        public string TutorialPageFourPartOne { get { return isFrench ? Resources_fr.TutorialPageFourPartOne : Resource_en.TutorialPageFourPartOne; } }
        public string Points { get { return isFrench ? Resources_fr.Points : Resource_en.Points; } }
        public string HypersetTutorialPageThreePartTwoRight { get { return isFrench ? Resources_fr.HypersetTutorialPageThreePartTwoRight : Resource_en.HypersetTutorialPageThreePartTwoRight; } }
        public string HypersetTutorialHypersetQuestion { get { return isFrench ? Resources_fr.HypersetTutorialHypersetQuestion : Resource_en.HypersetTutorialHypersetQuestion; } }
        public string TutorialPageFourMultipleParts { get { return isFrench ? Resources_fr.TutorialPageFourMultipleParts : Resource_en.TutorialPageFourMultipleParts; } }
        public string Tutorial { get { return isFrench ? Resources_fr.Tutorial : Resource_en.Tutorial; } }
        public string CloseRules { get { return isFrench ? Resources_fr.CloseRules : Resource_en.CloseRules; } }
        public string HypersetTutorialPageFourPartTwo { get { return isFrench ? Resources_fr.HypersetTutorialPageFourPartTwo : Resource_en.HypersetTutorialPageFourPartTwo; } }
        public string HypersetTutorialPageFourPartOne { get { return isFrench ? Resources_fr.HypersetTutorialPageFourPartOne : Resource_en.HypersetTutorialPageFourPartOne; } }
        public string StartGame { get { return isFrench ? Resources_fr.StartGame : Resource_en.StartGame; } }
        public string HypersetTutorialPageThreePartOneIncorrectRight { get { return isFrench ? Resources_fr.HypersetTutorialPageThreePartOneIncorrectRight : Resource_en.HypersetTutorialPageThreePartOneIncorrectRight; } }
        public string HypersetTutorialPageThreePartOneIncorrectWrong { get { return isFrench ? Resources_fr.HypersetTutorialPageThreePartOneIncorrectWrong : Resource_en.HypersetTutorialPageThreePartOneIncorrectWrong; } }
        public string HypersetTutorialPageThreePartOneRight { get { return isFrench ? Resources_fr.HypersetTutorialPageThreePartOneRight : Resource_en.HypersetTutorialPageThreePartOneRight; } }
        public string TutorialPageSixPartOne { get { return isFrench ? Resources_fr.TutorialPageSixPartOne : Resource_en.TutorialPageSixPartOne; } }
        public string NoMoreCardsText { get { return isFrench ? Resources_fr.NoMoreCardsText : Resource_en.NoMoreCardsText; } }
        public string WantATutorial { get { return isFrench ? Resources_fr.WantATutorial : Resource_en.WantATutorial; } }
        public string GamemodePickerAgainstTime { get { return isFrench ? Resources_fr.GamemodePickerAgainstTime : Resource_en.GamemodePickerAgainstTime; } }
        public string HypersetTutorialPageTwoPartThree { get { return isFrench ? Resources_fr.HypersetTutorialPageTwoPartThree : Resource_en.HypersetTutorialPageTwoPartThree; } }
        public string TutorialPageFourPartThreeWrong { get { return isFrench ? Resources_fr.TutorialPageFourPartThreeWrong : Resource_en.TutorialPageFourPartThreeWrong; } }
        public string TutorialPageFourPartThreeRight { get { return isFrench ? Resources_fr.TutorialPageFourPartThreeRight : Resource_en.TutorialPageFourPartThreeRight; } }
        public string In { get { return isFrench ? Resources_fr.In : Resource_en.In; } }
        public string No { get { return isFrench ? Resources_fr.No : Resource_en.No; } }
        public string CheatButtonText { get { return isFrench ? Resources_fr.CheatButtonText : Resource_en.CheatButtonText; } }
        public string ShowCard { get { return isFrench ? Resources_fr.ShowCard : Resource_en.ShowCard; } }
        public string Got { get { return isFrench ? Resources_fr.Got : Resource_en.Got; } }
        public string Yes { get { return isFrench ? Resources_fr.Yes : Resource_en.Yes; } }
        public string GameRulesAnnoncement { get { return isFrench ? Resources_fr.GameRulesAnnoncement : Resource_en.GameRulesAnnoncement; } }
        public string Retry { get { return isFrench ? Resources_fr.Retry : Resource_en.Retry; } }
        public string YourTimeText { get { return isFrench ? Resources_fr.YourTimeText : Resource_en.YourTimeText; } }
        public string Score { get { return isFrench ? Resources_fr.Score : Resource_en.Score; } }
        public string Username { get { return isFrench ? Resources_fr.Username : Resource_en.Username; } }
        public string GamemodeHelpButtonText { get { return isFrench ? Resources_fr.GamemodeHelpButtonText : Resource_en.GamemodeHelpButtonText; } }
        public string GamemodePickerAgainstScore { get { return isFrench ? Resources_fr.GamemodePickerAgainstScore : Resource_en.GamemodePickerAgainstScore; } }
        public string ErrorNoSelectedText { get { return isFrench ? Resources_fr.ErrorNoSelectedText : Resource_en.ErrorNoSelectedText; } }
        public string DefaultUsername { get { return isFrench ? Resources_fr.DefaultUsername : Resource_en.DefaultUsername; } }
        public string TutorialPageFivePartTwo { get { return isFrench ? Resources_fr.TutorialPageFivePartTwo : Resource_en.TutorialPageFivePartTwo; } }
        public string TutorialPageFivePartOne { get { return isFrench ? Resources_fr.TutorialPageFivePartOne : Resource_en.TutorialPageFivePartOne; } }
        public string Minutes { get { return isFrench ? Resources_fr.Minutes : Resource_en.Minutes; } }
        public string TimeFromBeginning { get { return isFrench ? Resources_fr.TimeFromBeginning : Resource_en.TimeFromBeginning; } }
        public string ClickHereButton { get { return isFrench ? Resources_fr.ClickHereButton : Resource_en.ClickHereButton; } }
        public string YourScoreText { get { return isFrench ? Resources_fr.YourScoreText : Resource_en.YourScoreText; } }
        public string TutorialPageFourPartTwoWrong { get { return isFrench ? Resources_fr.TutorialPageFourPartTwoWrong : Resource_en.TutorialPageFourPartTwoWrong; } }
        public string TutorialPageFourPartTwoRight { get { return isFrench ? Resources_fr.TutorialPageFourPartTwoRight : Resource_en.TutorialPageFourPartTwoRight; } }
        public string AskButtonText { get { return isFrench ? Resources_fr.AskButtonText : Resource_en.AskButtonText; } }
        public string TutorialPageOnePartOne { get { return isFrench ? Resources_fr.TutorialPageOnePartOne : Resource_en.TutorialPageOnePartOne; } }
        public string TutorialPageOnePartTwo { get { return isFrench ? Resources_fr.TutorialPageOnePartTwo : Resource_en.TutorialPageOnePartTwo; } }
        public string ChoseAGamemodeText { get { return isFrench ? Resources_fr.ChoseAGamemodeText : Resource_en.ChoseAGamemodeText; } }
        public string EnterUsernameText { get { return isFrench ? Resources_fr.EnterUsernameText : Resource_en.EnterUsernameText; } }
        public string HypersetTutorialPageFive { get { return isFrench ? Resources_fr.HypersetTutorialPageFive : Resource_en.HypersetTutorialPageFive; } }
        public string HypersetTutorialPageOnePartTwo { get { return isFrench ? Resources_fr.HypersetTutorialPageOnePartTwo : Resource_en.HypersetTutorialPageOnePartTwo; } }
        public string HypersetTutorialPageOnePartOne { get { return isFrench ? Resources_fr.HypersetTutorialPageOnePartOne : Resource_en.HypersetTutorialPageOnePartOne; } }
        public string LeaderboardAlertText { get { return isFrench ? Resources_fr.LeaderboardAlertText : Resource_en.LeaderboardAlertText; } }
        public string ErrorNoSelectedTitle { get { return isFrench ? Resources_fr.ErrorNoSelectedTitle : Resource_en.ErrorNoSelectedTitle; } }
        public string HypersetTutorialPageThreePartOneCorrectWrong { get { return isFrench ? Resources_fr.HypersetTutorialPageThreePartOneCorrectWrong : Resource_en.HypersetTutorialPageThreePartOneCorrectWrong; } }
        public string HypersetTutorialPageThreePartOneCorrectRight { get { return isFrench ? Resources_fr.HypersetTutorialPageThreePartOneCorrectRight : Resource_en.HypersetTutorialPageThreePartOneCorrectRight; } }
        public string NumberOfSetsAvailableText { get { return isFrench ? Resources_fr.NumberOfSetsAvailableText : Resource_en.NumberOfSetsAvailableText; } }
        public string AlreadyASet { get { return isFrench ? Resources_fr.AlreadyASet : Resource_en.AlreadyASet; } }
        public string Next { get { return isFrench ? Resources_fr.Next : Resource_en.Next; } }
        public string Time { get { return isFrench ? Resources_fr.Time : Resource_en.Time; } }
        public string Play { get { return isFrench ? Resources_fr.Play : Resource_en.Play; } }
        public string ShowScores { get { return isFrench ? Resources_fr.ShowScores : Resource_en.ShowScores; } }
        public string SetTutorial { get { return isFrench ? Resources_fr.SetTutorial : Resource_en.SetTutorial; } }
        public string HypersetTutorial { get { return isFrench ? Resources_fr.HypersetTutorial : Resource_en.HypersetTutorial; } }
        public string Player { get { return isFrench ? Resources_fr.Player : Resource_en.Player; } }
        public string Easy { get { return isFrench ? Resources_fr.Easy : Resource_en.Easy; } }
        public string Hard { get { return isFrench ? Resources_fr.Hard : Resource_en.Hard; } }
    }
}
