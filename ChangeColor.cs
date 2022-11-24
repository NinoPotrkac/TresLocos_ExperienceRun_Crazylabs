using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    [SerializeField]
    private Material materialFloor1; // First material that is going to be changed
    [SerializeField]
    private Material materialFloor2; // Second material that is going to be changed
    [SerializeField]
    private GameObject camera1; // First camera view
    [SerializeField]
    private GameObject camera2; // Second camera view
    [SerializeField]
    private GameObject camera3; // Third camera view
    
    public int colorPref; // Int that is going to track what color preset needs to be active
    public int cameraPreset; // Int that is tracking what camera needs to be active

    private void Start()
    {
       colorPref = PlayerPrefs.GetInt("color"); // Geting the int that is activating the right color preset
       cameraPreset = PlayerPrefs.GetInt("camera"); // Geting the int that is activating the right camera,

        if (colorPref == 1) // if the colorFref is 1 then it activates the first color preset, the other IFs work the same
        {
            ColorPreset1();
        }

        if(colorPref == 2)
        {
            ColorPreset2();
        }

        if (colorPref == 3)
        {
            ColorPreset3();
        }

        if(cameraPreset == 1) // If the cameraPreset is 1 then camera 1 will be active, other IFs work the same
        {
            Camera1();
        }

        if (cameraPreset == 2)
        {
            Camera2();
        }

        if (cameraPreset == 3)
        {
            Camera3();
        }
    }

    public void ColorPreset1() // Method that changes the colors to the first preset
    {
        materialFloor1.color = new Color32(156, 46, 46, 255); // Changing the first tile to a color that we chose
        materialFloor2.color = new Color32(71, 215, 228, 255); // Changing the second tile to a color we chose
        colorPref = 1; // changing the colorPref int to 1
        PlayerPrefs.SetInt("color", colorPref); // Seting the colorPref int to 1 so when we start the game it loads this preset
    }

    public void ColorPreset2()
    {
        materialFloor1.color = new Color32(10, 166, 5, 255);
        materialFloor2.color = new Color32(255, 240, 0, 255);
        colorPref = 2;
        PlayerPrefs.SetInt("color", colorPref);
    }
    
    public void ColorPreset3()
    {
        materialFloor1.color = new Color32(106, 102, 255, 255);
        materialFloor2.color = new Color32(255, 107, 225, 255);
        colorPref = 3;
        PlayerPrefs.SetInt("color", colorPref);
    }

    public void Camera1() // Method that changes the active camera
    {
        camera1.SetActive(true); // Seting the first camera to be active, and then seting all other cameras to be inactive
        camera2.SetActive(false);
        camera3.SetActive(false);
        cameraPreset = 1; // changing cameraPreset to 1 so in the start method when we turn on the game again it knoows wich camera needs to be active
        PlayerPrefs.SetInt("camera", cameraPreset); // seting the cameraPreset to 1
    }

    public void Camera2()
    {
        camera1.SetActive(false);
        camera2.SetActive(true);
        camera3.SetActive(false);
        cameraPreset = 2;
        PlayerPrefs.SetInt("camera", cameraPreset);
    }

    public void Camera3()
    {
        camera1.SetActive(false);
        camera2.SetActive(false);
        camera3.SetActive(true);
        cameraPreset = 3;
        PlayerPrefs.SetInt("camera", cameraPreset);
    }
}
