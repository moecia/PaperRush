using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatement : MonoBehaviour {

    public enum m_myPose
    {
        Running,
        YogaUp, //Up
        Mickeal, //Right
        Wiifit, // Left
        SpiltFoot // Down
    }
    [SerializeField] private LevelLoader m_levelLoader = null;
    [SerializeField] private PlayerMovement m_playermovement = null;
    [SerializeField] private Text m_healthText = null;
    [SerializeField] private Text m_scoreText = null;
    [SerializeField] private Text m_comboText = null;
    [SerializeField] private Text m_GameOverText = null;
    [SerializeField] private GameObject m_GameOver = null;
    [SerializeField] private AudioSource m_audio = null;
    [SerializeField] private float m_ShakingSpeed = 10f;
    [SerializeField] private int m_health = 3;
    public float health
    { get { return m_health; } }
    [SerializeField] private int m_combo = 0;
    [SerializeField] private m_myPose myPose;
    [SerializeField] private SpriteRenderer m_spritePose = null;
    [SerializeField]private float m_timer = 30f;
    [SerializeField] private float m_canNotDamageTimer = 60f;
    [SerializeField] private bool m_canNotDamage = false;
    [SerializeField] private float m_StartTimer = 30f;
    private bool isPosing = false;
    [SerializeField] private int m_score = 0;
    public float Score
    { get { return m_score; } }
    private Character m_character = null;
    // Use this for initialization
    private void Start()
    {
        //m_GameOver.SetActive(true);

        isPosing = false;
        m_score = 0;
        myPose = m_myPose.Running;
        if (this.transform.GetChild(0).GetComponent<SpriteRenderer>() != null)
        {
            m_spritePose = this.transform.GetChild(0).GetComponent<SpriteRenderer>();
            print(m_spritePose.gameObject);
        }
        if (this.transform.parent.gameObject != null)
        {
            //m_splineController = this.transform.parent.gameObject.GetComponent<SplineController>();
            //m_splineInterpolator = this.transform.parent.gameObject.GetComponent<SplineInterpolator>();
            m_character = this.transform.parent.gameObject.GetComponent<Character>();

            print(this.transform.parent.gameObject);
        }
        m_levelLoader = GameObject.FindWithTag("LevelLoader").GetComponent<LevelLoader>();
        m_audio = this.GetComponent<AudioSource>();
        m_playermovement = this.GetComponent<PlayerMovement>();
        if (GameObject.FindWithTag("GameOverMenu") != null)
        { m_GameOver = GameObject.FindWithTag("GameOverMenu"); }
        m_healthText = GameObject.FindWithTag("HealthUI").GetComponent<Text>();
        m_scoreText = GameObject.FindWithTag("ScoreUI").GetComponent<Text>();
        m_comboText = GameObject.FindWithTag("ComboUI").GetComponent<Text>();
        m_GameOverText = GameObject.FindWithTag("GameOverText").GetComponent<Text>();

        m_healthText.text = ("Health: " + m_health);
        m_scoreText.text = ("Score: " + m_score);
        m_comboText.text = ("Combo: " + m_combo);

        m_GameOver.SetActive(false);
        m_timer = m_StartTimer;
    }

    public void Update ()
    {
        MakePose();
        if(isPosing)
        {
            m_timer--;
            if(m_timer <= 0)
            {
                myPose = m_myPose.Running;
                m_spritePose.sprite = Resources.Load<Sprite>("Pose_Run");
                isPosing = false; 
            }
        }
        if (m_canNotDamage)
        {
            m_canNotDamageTimer--;
            if (m_canNotDamageTimer <= 0)
            {
                m_canNotDamage = false;
            }
        }
        SpriteShaking();
    }
    public void MakePose()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            m_audio.PlayOneShot((Resources.Load<AudioClip>("Ya")), 1);
            myPose = m_myPose.YogaUp;
            DoPose();
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            m_audio.PlayOneShot((Resources.Load<AudioClip>("WeYa")), 1);
            myPose = m_myPose.SpiltFoot;
            DoPose();
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            m_audio.PlayOneShot((Resources.Load<AudioClip>("Hah")), 0.5f);
            myPose = m_myPose.Mickeal;
            DoPose();
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            m_audio.PlayOneShot((Resources.Load<AudioClip>("Woo")), 1);
            myPose = m_myPose.Wiifit;
            DoPose();

        }
    }
    public void DoPose()
    {
        m_timer = m_StartTimer;
        if (myPose == m_myPose.YogaUp)
        {
            m_spritePose.sprite = Resources.Load<Sprite>("Pose_Up");
        }
        if (myPose == m_myPose.SpiltFoot)
        {
            m_spritePose.sprite = Resources.Load<Sprite>("Pose_Low");
        }
        if (myPose == m_myPose.Mickeal)
        {
            m_spritePose.sprite = Resources.Load<Sprite>("Pose_Right");
        }
        if (myPose == m_myPose.Wiifit)
        {
            m_spritePose.sprite = Resources.Load<Sprite>("Pose_Left");
        }
        isPosing = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!m_canNotDamage)
        {
            if (other.tag == "wall")
            {
                if (other.GetComponent<WallPlane>() != null)
                {
                    WallPlane theWallObject = other.GetComponent<WallPlane>();
                    if (theWallObject.m_planeType == WallPlane.m_Plane.Block)
                    {
                        {
                            LoseHealth();
                        }
                    }
                    if (theWallObject.m_planeType == WallPlane.m_Plane.Running)
                    {
                        if (myPose == m_myPose.Running)
                        {
                            AddScore();
                        }
                        else
                        {
                            LoseHealth();
                        }
                    }
                    if (theWallObject.m_planeType == WallPlane.m_Plane.PoseUp)
                    {
                        if (myPose == m_myPose.YogaUp)
                        {
                            AddScore();
                        }
                        else
                        {
                            LoseHealth();
                        }
                    }
                    if (theWallObject.m_planeType == WallPlane.m_Plane.PoseDown)
                    {
                        if (myPose == m_myPose.SpiltFoot)
                        {
                            AddScore();
                        }
                        else
                        {
                            LoseHealth();
                        }
                    }
                    if (theWallObject.m_planeType == WallPlane.m_Plane.PoseRight)
                    {
                        if (myPose == m_myPose.Mickeal)
                        {
                            AddScore();
                        }
                        else
                        {
                            LoseHealth();
                        }
                    }
                    if (theWallObject.m_planeType == WallPlane.m_Plane.PoseLeft)
                    {
                        if (myPose == m_myPose.Wiifit)
                        {
                            AddScore();
                        }
                        else
                        {
                            LoseHealth();
                        }
                    }
                    //m_splineInterpolator.enabled = false;
                }
            }

            if (other.tag == "Jumpwall")
            {
                LoseHealth();
            }
        }
    }
    public void AddScore()
    {
        m_combo += 1 ;
        m_score += 20 * (m_combo + 1);
        m_character.SpeedUp();
        m_audio.PlayOneShot((Resources.Load<AudioClip>("Yes")), 1);
        m_scoreText.text = ("Score: " + m_score);
        m_comboText.text = ("Combo: " + m_combo);
    }
    public void LoseHealth()
    {
            m_canNotDamage = true;
            m_health--;
            m_combo = 0;
            m_character.ResetSpeed();
            m_audio.PlayOneShot((Resources.Load<AudioClip>("Hit")), 1);
            m_healthText.text = ("Health: " + m_health);
            m_comboText.text = ("Combo: " + m_combo);
        if (m_health <= 0)
        {
            m_playermovement.enabled = false;
            m_character.enabled = false;
            m_spritePose.color = Color.black;
            m_audio.PlayOneShot((Resources.Load<AudioClip>("GameOver")), 3);
            GameOver();
            this.enabled = false;
        }

    }
    public void SpriteShaking()
    {
        float AngleAmount = (Mathf.Cos(Time.time * m_ShakingSpeed * (m_combo/5 +1)) * 180) / Mathf.PI * 0.5f;
        AngleAmount = Mathf.Clamp(AngleAmount, -15, 0);
        m_spritePose.gameObject.transform.localRotation = Quaternion.Euler(0, 0, AngleAmount);
    }
    public void GameOver()
    {
        m_GameOver.SetActive(true);
        m_levelLoader.isGameOver = true;
        if (Score >= 1000000)
        {
            m_GameOverText.text = ("This is impossible! You are fabulious!");
        }
        if (Score >= 500000 && Score < 1000000)
        {
            m_GameOverText.text = ("You are fantastic! My Hero!");
        }
        if (Score >= 250000 && Score < 500000)
        {
            m_GameOverText.text = ("Well Done! you win my respect!");
        }
        if (Score >= 100000 && Score < 250000)
        {
            m_GameOverText.text = ("Not bad! Keep going!");
        }
        if (Score >= 50000 && Score < 100000)
        {
            m_GameOverText.text = ("You can make it! push more!");
        }
        if (Score >= 20000 && Score < 50000)
        {
            m_GameOverText.text = ("Not good enough! need practice!");
        }
        if (Score >= 10000 && Score < 20000)
        {
            m_GameOverText.text = ("Really? You just failed!");
        }
        if (Score >= 5000 && Score < 10000)
        {
            m_GameOverText.text = ("I know you Suck Don't Cry!");
        }
        if (Score >= 2000 && Score < 5000)
        {
            m_GameOverText.text = ("Game Over! Loser!");
        }
        if (Score >= 1000 && Score < 2000)
        {
            m_GameOverText.text = ("Game Over! Garbage!");
        }
        if (Score >= 0 && Score < 1000)
        {
            m_GameOverText.text = ("Goodbye! Garbage!");
        }
    }
}
