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
    public AudioClip getHit;
    public AudioClip dead;
    [Space(10)]
    [Header("Background Music")]
    public AudioClip bgm;

    public AudioClip empty;

    public AudioSource bgmPlayer;
    void Awake()
    {
        poseUp = Resources.Load<AudioClip>("Ya");
        poseDown = Resources.Load<AudioClip>("WeYa");
        poseLeft = Resources.Load<AudioClip>("Hah");
        poseRight = Resources.Load<AudioClip>("Woo");
        
        jump = Resources.Load<AudioClip>("JumpSound");
        getHit = Resources.Load<AudioClip>("Hit");
        dead = Resources.Load<AudioClip>("GameOver");
        bgm = Resources.Load<AudioClip>("BGM");
    }

    private void Start()
    {
        
    }
}
