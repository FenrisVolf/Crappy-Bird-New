using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject PausePanel;
    public GameObject PauseButton;
    public Behaviour BirdScript;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pause()
    {
        BirdScript.enabled = false;
        PausePanel.SetActive(true);
        PauseButton.SetActive(false);
        Time.timeScale = 0;
        AudioSource[] audios = FindObjectsOfType<AudioSource>();
        foreach (AudioSource a in audios)
        {
            a.Pause();
        }
    }

    public void Continue()
    {
        BirdScript.enabled = true;
        PausePanel.SetActive(false);
        PauseButton.SetActive(true);
        Time.timeScale = 1;
        AudioSource[] audios = FindObjectsOfType<AudioSource>();
        foreach (AudioSource a in audios)
        {
            a.Play();
        }
    }
}
