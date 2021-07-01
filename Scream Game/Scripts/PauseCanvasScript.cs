using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class PauseCanvasScript : MonoBehaviour
{
    public GameObject pausePanel;
    public AudioSource[] allAudioSources;
    void Start()
    {
        pausePanel.SetActive(false);   
    }
    public void onPauseButtonClick()
    {
        pausePanel.SetActive(true);//show the pause canvas
        pauseAudio();
        EventSystem.current.currentSelectedGameObject.GetComponent<Button>().interactable = false;
        Time.timeScale = 0f;
    }
    public void onResumeButtonClick()
    {
        pausePanel.SetActive(false);
        resumeAudio();
        Time.timeScale = 1f;      
    }
    
    void pauseAudio()
    {
        allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        foreach (AudioSource audios in allAudioSources)
        {
            audios.Pause();
        }
    }
    void resumeAudio()
    {
        allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        foreach (AudioSource audios in allAudioSources)
        {
            audios.UnPause();
        }
    }
}
