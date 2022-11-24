using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public AudioSource music; // Audio source that plays the music
    public Slider musicSlider; // slidet with which

    private void Awake()
    {
        musicSlider.value = PlayerPrefs.GetFloat("music"); // player preft that gets the value of the music and puts it to the right volume
    }
    private void Update()
    {
        music.volume = musicSlider.value; // audio source "music" gets the value od the slider value
        PlayerPrefs.SetFloat("music", music.volume); // player prefs that save the volume
    }
    private bool isPaused = false; // Bool that is going to tell us if the game is paused
   
    public void PauseGame() // Method of pausing the game
    {
        isPaused = !isPaused;
        if (isPaused)
        {
            Time.timeScale = 0; // if timeScale is 0 then the time is stoped and the game is paused
        }
        else if (!isPaused)
        {
            Time.timeScale = 1; // if timeScale is 1 then the time flows normali and the game is unpaused.
        }
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(0); // method that returns us to the begining state of sceen 0
    }


}
