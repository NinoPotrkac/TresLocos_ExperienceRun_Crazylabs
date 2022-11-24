using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public Player playerScript; // Player script
    public Image endScreen; // image taht is our endScreen
    public TextMeshProUGUI endGameText; // Text that will say on the endScreen
    public GameObject smile; // smile sprite
    public GameObject sad; // sad sprite
    public GameObject restart; // restart button
    public GameObject nextLevel; // next level button
    public GameObject player; // our character
    public GameObject obsticleTrap; // game object that spawns obsticle traps
    public GameObject spikeTrap;// game object that spawns spike traps
    public GameObject starTrap; // game object that spawns star traps
    public GameObject mainCamera;
    public GameObject danceCamera;
    public int experienceRequired = 500; // experience needed to pass the level
    public TextMeshProUGUI experienceReqText; // text that displays how much XP you need to pass
    public GateSpawner gateSpawner; // GateSpawner script
    private int trapNumber; // number that will pick what trap is active

    private void Start()
    {
        TrapPicker();
    }


    private void Update()
    {
        if (trapNumber == 1) // if trap number is 1 
        {
            obsticleTrap.SetActive(true); // obsticle trap is active
            spikeTrap.SetActive(false); // spike trap is 
            spikeTrap.SetActive(false); // spike trap is 
            spikeTrap.SetActive(false); // spike trap is deactivated
            starTrap.SetActive(false); // star trap is deactivater
        }
        else if (trapNumber == 2)
        {
            obsticleTrap.SetActive(false);
            spikeTrap.SetActive(true);
            starTrap.SetActive(false);
        }
        else if(trapNumber == 3)
        {
            obsticleTrap.SetActive(false);
            spikeTrap.SetActive(false);
            starTrap.SetActive(true);
        }


        if (playerScript.experience < experienceRequired) // if the XP is lower then the required XP
        {
            sad.SetActive(true); // sad sprite turns on
            smile.SetActive(false); // smile sprite turns off
            restart.SetActive(true); // restart button turns on
            nextLevel.SetActive(false); // next level button turns off
            endScreen.color = new Color32(186, 37, 37, 81); // endScreen gets the collor we set
            endGameText.color = new Color32(255, 241, 0, 255); // endGameText gets the collor we set
            endGameText.text = "You failed to collect enough experience to finish the level, you collected " + playerScript.experience + " experience, you needed to collect " + experienceRequired + " to pass. Try again."; // what will say in the end game text
            if (playerScript.endScreen.activeSelf == true)
            {
                playerScript.playerAnimator.SetBool("Sad", true);
                mainCamera.SetActive(false);
                danceCamera.SetActive(true);
            }
        }

        if (playerScript.experience >= experienceRequired) // if the XP is higher then the required XP
        {
            sad.SetActive(false);
            smile.SetActive(true);
            restart.SetActive(false);
            nextLevel.SetActive(true);
            endScreen.color = new Color32(51, 159, 82, 81);
            endGameText.color = new Color32(0, 255, 233, 255);
            endGameText.text = "Congratulations, you made it to the next level, you collected " + playerScript.experience + " experience out of " + experienceRequired + " required";
            
            if(playerScript.endScreen.activeSelf == true)
            {
                playerScript.playerAnimator.SetBool("Dance", true);
                mainCamera.SetActive(false);
                danceCamera.SetActive(true);
            }
        }

        experienceReqText.text = "XP: " + playerScript.experience + "/" + experienceRequired; // text that says how many XP you need for the next level
    }

    public void ResetGame() // method that will restert the game
    {
        gateSpawner.SpawnThings(); // we are calling SpawnTHings method from gateSpawner script 
        player.transform.localPosition = new Vector3(2.093f, 2.0678f, -4.877f); // playing the player to the starting position
        playerScript.level = 1; // level from the player script becomes 1
        experienceRequired = 500; // XP required becomes 5000
        playerScript.experience = 500; // player XP becomes 100
        trapNumber = 0; // trap number is set to 0
        obsticleTrap.SetActive(false); //
        spikeTrap.SetActive(false); // All traps are deactivated
        starTrap.SetActive(false); //
        TrapPicker();
        playerScript.playerAnimator.SetBool("Dying", false);
        playerScript.playerAnimator.SetBool("Sad", false);
        mainCamera.SetActive(true);
        danceCamera.SetActive(false);
    }

    public void NextLevel() // method that starts the new level
    {
        gateSpawner.SpawnThings(); // we are calling SpawnTHings method from gateSpawner script 
        player.transform.localPosition = new Vector3(2.093f, 2.0678f, -4.877f); // playing the player to the starting position
        playerScript.level++; // adding +1 to the level in the player script
        experienceRequired += 500; // adding +500 to the XP required
        playerScript.experience = 500; // player XP becomes 100
        TrapPicker();
        playerScript.playerAnimator.SetBool("Dying", false);
        playerScript.playerAnimator.SetBool("Dance", false);
        mainCamera.SetActive(true);
        danceCamera.SetActive(false);
    }

    private void TrapPicker() // trap picker method
    {
        trapNumber = Random.Range(1, 4); // trapNumber gets a random number between 1 and 3, 4 is excluded
        Debug.Log(trapNumber); // just for checking which number is picked
    }

}
