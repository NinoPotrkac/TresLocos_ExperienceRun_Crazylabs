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
    public int experienceRequired = 5000; // experience needed to pass the level
    public TextMeshProUGUI experienceReqText; // text that displays how much XP you need to pass
    public GateSpawner gateSpawner; // GateSpawner script

    

    private void Update()
    {
        if(playerScript.experience < experienceRequired) // if the XP is lower then the required XP
        {
            sad.SetActive(true); // sad sprite turns on
            smile.SetActive(false); // smile sprite turns off
            restart.SetActive(true); // restart button turns on
            nextLevel.SetActive(false); // next level button turns off
            endScreen.color = new Color32(186, 37, 37, 255); // endScreen gets the collor we set
            endGameText.color = new Color32(255, 241, 0, 255); // endGameText gets the collor we set
            endGameText.text = "You failed to collect enough experience to finish the level, you collected " + playerScript.experience + " experience, you needed to collect " + experienceRequired + " to pass. Try again."; // what will say in the end game text
        }

        if (playerScript.experience >= experienceRequired) // if the XP is higher then the required XP
        {
            sad.SetActive(false);
            smile.SetActive(true);
            restart.SetActive(false);
            nextLevel.SetActive(true);
            endScreen.color = new Color32(51, 159, 82, 255);
            endGameText.color = new Color32(0, 255, 233, 255);
            endGameText.text = "Congratulations, you made it to the next level, you collected " + playerScript.experience + " experience out of " + experienceRequired + " required";
        }

        experienceReqText.text = "XP needed for next Level = " + experienceRequired; // text that says how many XP you need for the next level
    }

    public void ResetGame() // method that will restert the game
    {
        gateSpawner.SpawnThings(); // we are calling SpawnTHings method from gateSpawner script 
        player.transform.localPosition = new Vector3(2.093f, 2.0678f, -4.877f); // playing the player to the starting position
        playerScript.level = 1; // level from the player script becomes 1
        experienceRequired = 5000; // XP required becomes 5000
        playerScript.experience = 100; // player XP becomes 100
    }

    public void NextLevel() // method that starts the new level
    {
        gateSpawner.SpawnThings(); // we are calling SpawnTHings method from gateSpawner script 
        player.transform.localPosition = new Vector3(2.093f, 2.0678f, -4.877f); // playing the player to the starting position
        playerScript.level++; // adding +1 to the level in the player script
        experienceRequired += 500; // adding +500 to the XP required
        playerScript.experience = 100; // player XP becomes 100
    }

}
