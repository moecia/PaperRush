using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour {

    [Header("CharacterStat")]
    public Text speed;
    public Text health;
    public Text score;
    public Text combo;

    [Header("Game State")]
    public GameObject gameOverPanel;
    public Text gameOverText;
}
