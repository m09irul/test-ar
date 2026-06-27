using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardSceneManager : MonoBehaviour
{
    public AudioClip[] audioClips;
    public AudioSource audioSource;
    public GameObject[] cardObjects; 
    public GameObject[] vfxObjects; 
    
    [Header("UI Elements")]
    public Button[] buttons; // Changed to an array for easy scalability
    
    private Animator animator; 

    void Start()
    {
        startScene();
    }
    public void startScene()
    {
        PlayAudioClip(0);
        
        if (cardObjects.Length > 0 && cardObjects[0] != null)
        {
            animator = cardObjects[0].GetComponent<Animator>();
        }
    }

    // Turns on a specific button by its array index (0-based)
    public void TurnOnButton(int index)
    {
        if (index >= 0 && index < buttons.Length && buttons[index] != null)
        {
            buttons[index].gameObject.SetActive(true);
        }
    }

    // Unified click handler: Pass the animation name directly from the Unity Inspector
    public void OnButtonClick(string animationName)
    {

        if (animator != null)
        {
            animator.Play(animationName);
        }
        SetAllButtonsActive(false);
    }

    // Helper method to eliminate duplicate code for toggling buttons
    private void SetAllButtonsActive(bool isActive)
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            if (buttons[i] != null)
            {
                buttons[i].gameObject.SetActive(isActive);
            }
        }
    }

    public void PlayAudioClip(int index)
    {
        if (index >= 0 && index < audioClips.Length)
        {
            audioSource.clip = audioClips[index];
            audioSource.Play();
            Debug.Log("Playing audio clip: " + audioClips[index].name);
        }
        else
        {
            Debug.LogWarning("Invalid audio clip index: " + index);
        }
    }

    public void StopAudio()
    {
        audioSource.Stop();
    }

    public void PlayOneShot(int index)
    {
        if (index >= 0 && index < audioClips.Length)
        {
            audioSource.PlayOneShot(audioClips[index]);
        }
        else
        {
            Debug.LogWarning("Invalid audio clip index: " + index);
        }
    }
}