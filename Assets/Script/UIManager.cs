using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour {

    public PlayerStatus playerStatus;
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

    private void Update()
    {
        if (playerStatus != null)
        {
            if (playerStatus.currentHealth <= 0)
                ShowDeathMenu();

            score.text = "Score: " + playerStatus.playerScore.ToString();
            UpdateCombo();
        }
    }

    public void ShowTutorial()
    {
        if (!PlayerPrefs.HasKey("highestScore"))
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
}
