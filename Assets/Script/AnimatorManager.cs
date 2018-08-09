using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorManager : MonoBehaviour {

    public Animator uiEffectAnimator;

    public void PlayBloodScreen()
    {
        uiEffectAnimator.SetBool("playBloodScreen", true);
    }

}
