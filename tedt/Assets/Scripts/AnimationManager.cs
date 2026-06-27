using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    public CardSceneManager cardSceneManager;

    public void PlayCardAudio(int index)
    {
        cardSceneManager.PlayOneShot(index);
    }
    public void TurnOnButton(int index)
    {
        cardSceneManager.TurnOnButton(index);
    }
}
