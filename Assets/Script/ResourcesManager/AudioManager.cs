using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Player Action SFXs")]
    public AudioClip poseUp;
    public AudioClip poseDown;
    public AudioClip poseLeft;
    public AudioClip poseRight;
    public AudioClip move;
    public AudioClip jump;
    public AudioClip getScore;
    public AudioClip getHit;
    public AudioClip dead;

    public AudioClip empty;

    void Awake()
    {
        poseUp = Resources.Load<AudioClip>("Ya");
        poseDown = Resources.Load<AudioClip>("WeYa");
        poseLeft = Resources.Load<AudioClip>("Hah");
        poseRight = Resources.Load<AudioClip>("Woo");        
        jump = Resources.Load<AudioClip>("JumpSound");
        getScore = Resources.Load<AudioClip>("Yes");
        getHit = Resources.Load<AudioClip>("GetHit");
        dead = Resources.Load<AudioClip>("GameOver");
    }

    private void Start()
    {
    }
}
