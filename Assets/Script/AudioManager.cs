using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip poseUp;
    public AudioClip poseDown;
    public AudioClip poseLeft;
    public AudioClip poseRight;

	void Start ()
    {
        poseUp = Resources.Load<AudioClip>("Ya");
        poseDown = Resources.Load<AudioClip>("WeYa");
        poseLeft = Resources.Load<AudioClip>("Hah");
        poseRight = Resources.Load<AudioClip>("Woo");
    }
	
}
