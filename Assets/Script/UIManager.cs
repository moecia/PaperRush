using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour {

    public InputManager inputManager;

    public enum Localization { EN, SCN, TCN }
    public Localization selectedLocalization = Localization.EN;
    [Header("Option Panel UI")]
    public Text title_Language;
    public Text title_chooseInput;
    public Text title_TutorialVisibility;
    public Text button_toggleTutorial;
    public Text button_inputC;
    public Text button_touchpad;
    [Header("StartGame UI")]
    public Text touchScreenToStart;
    [Header("Tutorial UI")]
    public Text inputTutorial_0;
    public Text inputTutorial_1;
    [Header("CharacterStat")]
    public Text scoreTitle;
    public Text actualScore;
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

            title_Language.text = "Language";
            title_TutorialVisibility.text = "Show/Hide Tutorial";
            if (GameData.GetTutorialVisibility())
                button_toggleTutorial.text = "Hide Tutorial";
            else
                button_toggleTutorial.text = "Show Tutorial";
            title_chooseInput.text = "Control";
            button_inputC.text = "Swipe+Buttons";
            button_touchpad.text = "Only Buttons";

            scoreTitle.text = "Score:";

            if (inputManager.selectedControl == InputManager.ControlMethods.TouchScreen_C)
            {
                inputTutorial_0.text = "Swipe left: move left Swipe" + "\n" + "Right: move right" + "\n" + "Swipe Up: Jump";
                inputTutorial_1.text = "Tap to Making Pose";
            }
            else if (inputManager.selectedControl == InputManager.ControlMethods.TouchPad)
            {
                inputTutorial_0.text = "Tap to Move or Jump";
                inputTutorial_1.text = "Tap to Making Pose";
            }
        }
        else if (selectedLocalization == Localization.SCN)
        {
            touchScreenToStart.text = "点击屏幕开始游戏";

            title_Language.text = "语言";
            title_TutorialVisibility.text = "显示/关闭教程";
            if (GameData.GetTutorialVisibility())
                button_toggleTutorial.text = "隐藏教程";
            else
                button_toggleTutorial.text = "显示教程";
            title_chooseInput.text = "控制";
            button_inputC.text = "划屏+按键";
            button_touchpad.text = "仅用按键";

            scoreTitle.text = "分数:";

            if (inputManager.selectedControl == InputManager.ControlMethods.TouchScreen_C)
            {
                inputTutorial_0.text = "左划：向左移 右划：向右移" + "\n" + "上划：跳跃";
                inputTutorial_1.text = "点击按钮摆Pose";
            }
            else if (inputManager.selectedControl == InputManager.ControlMethods.TouchPad)
            {
                inputTutorial_0.text = "点击按钮移动或跳跃";
                inputTutorial_1.text = "点击按钮摆Pose";
            }        
        }
        else if(selectedLocalization == Localization.TCN)
        {
            touchScreenToStart.text = "點擊屏幕開始遊戲";

            title_Language.text = "語言";
            title_TutorialVisibility.text = "顯示/關閉教程";
            if (GameData.GetTutorialVisibility())
                button_toggleTutorial.text = "隱藏教程";
            else
                button_toggleTutorial.text = "顯示教程";
            title_chooseInput.text = "控制";
            button_inputC.text = "劃屏+按鍵";
            button_touchpad.text = "僅用按鍵";

            scoreTitle.text = "分數:";

            if (inputManager.selectedControl == InputManager.ControlMethods.TouchScreen_C)
            {
                inputTutorial_0.text = "左劃：向左移 右劃：向右移" + "\n" + "上劃：跳躍";
                inputTutorial_1.text = "點擊按鈕擺Pose";
            }
            else if (inputManager.selectedControl == InputManager.ControlMethods.TouchPad)
            {
                inputTutorial_0.text = "點擊屏幕移動或跳躍";
                inputTutorial_1.text = "點擊按鈕擺Pose";
            }
        }
        #endregion
    }

    public void ShowTutorial()
    {
        if (GameData.GetTutorialVisibility())
            tutorialPanel_C.GetComponent<Animator>().Play("TutorialInput");
    }

    public void ShowDeathMenu(int finalScore)
    {
        gameOverPanel.SetActive(true);
        pauseButton.SetActive(false);
        bool isNewRecord = GameData.SetHighestScore(finalScore);
        if (isNewRecord)
        {
            this.finalScore.text = finalScore.ToString();
            newRecordNote.SetActive(true);
        }
        else
            this.finalScore.text = finalScore.ToString();
        enabled = false;
    }

    public void UpdateScore(int score)
    {
        actualScore.text = score.ToString();
    }

    public void UpdateCombo(int combo)
    {
        if (combo > 0)
        {
            this.combo.gameObject.SetActive(true);
            this.combo.text = "Combo: " + combo.ToString();
            comboCounter = combo;
        }
        else
        {
            if (this.combo.gameObject.activeSelf)
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
}
