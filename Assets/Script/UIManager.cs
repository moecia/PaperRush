using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour {

    public enum Localization { EN, SCN, TCN }
    public Localization selectedLocalization = Localization.EN;

    public PlayerStatus playerStatus;
    [Header("StartGame UI")]
    public Text touchScreenToStart;
    public Text toggleTutorial;
    [Header("Tutorial UI")]
    public Text Input_C_tutorial_0;
    public Text Input_C_tutorial_1;
    [Header("CharacterStat")]
    public Text score;
    public Text combo;
    public Image comboEndHighlighter;
    [Header("Game State")]
    public GameObject gameOverPanel;
    public Text finalScore;
    public GameObject newRecordNote;

    [Header("Tutorial")]
    public Animator tutorialPanel_C;

    [Header("In-Game buttons")]
    public GameObject pauseButton;

    private int comboCounter;

    private void Start()
    {
        InitializeLocalization();      
    }

    private void InitializeLocalization()
    {
        GameData.InitializeTutorialVisibility();
        GameData.InitializeLocalization();

        selectedLocalization = (Localization)GameData.GetLocalization();

        #region Initailize Start Menu
        if (selectedLocalization == Localization.EN)
        {
            touchScreenToStart.text = "Touch Screen To Start";

            Input_C_tutorial_0.text = "Swipe left: move left Swipe" + "\n" + "Right: move right" + "\n" + "Swipe Up: Jump";
            Input_C_tutorial_1.text = "Tap to Making Pose";

            if (GameData.GetTutorialVisibility())
                toggleTutorial.text = "Hide Tutorial";
            else
                toggleTutorial.text = "Show Tutorial";

        }
        else if (selectedLocalization == Localization.SCN)
        {
            touchScreenToStart.text = "点击屏幕开始游戏";

            Input_C_tutorial_0.text = "左划：向左移 右划：向右移" + "\n" + "上划：跳跃";
            Input_C_tutorial_1.text = "点击按钮摆Pose";

            if (GameData.GetTutorialVisibility())
                toggleTutorial.text = "隐藏教程";
            else
                toggleTutorial.text = "显示教程";
            
        }
        else if(selectedLocalization == Localization.TCN)
        {
            touchScreenToStart.text = "點擊屏幕開始遊戲";

            Input_C_tutorial_0.text = "左劃：向左移 右劃：向右移" + "\n" + "上劃：跳躍";
            Input_C_tutorial_1.text = "點擊按鈕擺Pose";

            if (GameData.GetTutorialVisibility())
                toggleTutorial.text = "隱藏教程";
            else
                toggleTutorial.text = "顯示教程";
        }
        #endregion
    }

    private void Update()
    {
        if (playerStatus != null)
        {
            if (playerStatus.currentHealth <= 0)
                ShowDeathMenu();

            if (selectedLocalization == Localization.EN)
            {
                score.text = "Score: " + playerStatus.playerScore.ToString();
            }
            else if (selectedLocalization == Localization.SCN)
            {
                score.text = "分数: " + playerStatus.playerScore.ToString();
            }
            else if (selectedLocalization == Localization.TCN)
            {
                score.text = "分數: " + playerStatus.playerScore.ToString();
            }
          
            UpdateCombo();
        }
    }

    public void ShowTutorial()
    {
        if (GameData.GetTutorialVisibility())
            tutorialPanel_C.GetComponent<Animator>().Play("TutorialInput_C");
    }

    private void ShowDeathMenu()
    {
        gameOverPanel.SetActive(true);
        pauseButton.SetActive(false);
        bool isNewRecord = GameData.SetHighestScore(playerStatus.playerScore);
        if (isNewRecord)
        {
            finalScore.text = playerStatus.playerScore.ToString();
            newRecordNote.SetActive(true);
        }
        else
            finalScore.text = playerStatus.playerScore.ToString();
        enabled = false;
    }

    private void UpdateCombo()
    {
        if (playerStatus.playerCombo > 0)
        {
            combo.gameObject.SetActive(true);
            combo.text = "Combo: " + playerStatus.playerCombo.ToString();
            comboCounter = playerStatus.playerCombo;
        }
        else
        {
            // Just end a combo.
            if (playerStatus.playerScore >= 0 && combo.gameObject.activeSelf)
                StartCoroutine(ShowFinalCombo());
        }
    }

    private IEnumerator ShowFinalCombo()
    {
        combo.text = "Combo: " + comboCounter;
        comboEndHighlighter.gameObject.SetActive(true);
        yield return new WaitForSeconds(3.0f);
        comboEndHighlighter.gameObject.SetActive(false);
        combo.gameObject.SetActive(false);      
    }

    public void SetLocalization_EN()
    {
        selectedLocalization = Localization.EN;
        GameData.SetLocalization((int)selectedLocalization);
        InitializeLocalization();
    }

    public void SetLocalization_SCN()
    {
        selectedLocalization = Localization.SCN;
        GameData.SetLocalization((int)selectedLocalization);
        InitializeLocalization();
    }

    public void SetLocalization_TCN()
    {
        selectedLocalization = Localization.TCN;
        GameData.SetLocalization((int)selectedLocalization);
        InitializeLocalization();
    }

    public void RefreshToggleTutorialText()
    {
        InitializeLocalization();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
