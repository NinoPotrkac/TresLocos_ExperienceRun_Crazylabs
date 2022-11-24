using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private bool moveByTouch; // Bool that is telling us if we are touching the screen
    private Vector3 direction; // Vector 3 that is telling us in wich direction is our finger moveing
    private Rigidbody rb; // rigidbody component
      
    [SerializeField]
    private float runSpeed, velocity, swipeSpeed; // seting 3 floats
    [SerializeField]
    private int speed; // int wich is seting the speed tht we want to move
    [SerializeField]
    private int coins; // coins that w collect

    public int experience = 500; // int that we are seting for some goal
    public int level = 1; // int that says witch level we are on
    public TextMeshProUGUI coinText; // number of coins that we have
    public TextMeshProUGUI speedText; // text that is saing what the speed is
    public TextMeshProUGUI levelText; // text that displays what level we are on
    public Slider speedSlider; // slider with wich you control the speed 
    public GameObject endScreen; // this is the end game panel that will be turned on
    public GameObject mainMenu; // our main menu game object
    public GameObject deathScreen; // screen that turns on when you die
    public GameObject clearGates; // gameobject that clears gates
    public Animator playerAnimator; // the animator which controles our animations    



    private void Start()
    {
        speedSlider.value = speed; // slider gets the value of the speed
        coins = PlayerPrefs.GetInt("coins"); // saved coins
        rb = GetComponent<Rigidbody>(); // geting the component rigidbody
    }


    private void Update()
    {

        levelText.text = "Level " + level; // seting what the levelText will say

        speed =(int) speedSlider.value; // speed tets the value of the slider when we change it
        speedText.text = "speed is = " + speed; // text that sais what the speed is

        coinText.text = "Gold = " + coins; // texst that sais how many coins you have
        
        if(Input.GetMouseButtonDown(0) && mainMenu.activeSelf == false && endScreen.activeSelf == false && deathScreen.activeSelf == false) // if that is looking if we are pressing the screen if mainMenu and endScreen are turned off
        {
            moveByTouch = true; // afret the screen is pressed the bool is true
            playerAnimator.SetBool("Runing", true); // Seting the bool in our animator to true so the runing animation starts           
        }

        if (moveByTouch) // if the bool is true
        {
            direction = new Vector3(Mathf.Lerp(direction.x, Input.GetAxis("Mouse X"), runSpeed * Time.deltaTime), 0f); // seting the direction in wich we will move

            direction = Vector3.ClampMagnitude(direction, 1f);

            rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ; //freezing the needed constraints
        }

        if(experience <= 0) // limiting the experience paramerats
        {
            experience = 0; // if experience is 0 or less then experience will be 0 so it doesn't go to negative
        }

        if(rb.velocity.magnitude > 0.5f) 
        {
            rb.rotation = Quaternion.Slerp(rb.rotation, Quaternion.LookRotation(rb.velocity, Vector3.up), Time.deltaTime * velocity); // rotating the character to the side we are runing to
        }
        else
        {
            rb.rotation = Quaternion.Slerp(rb.rotation, Quaternion.identity, Time.deltaTime * velocity); // returning the characters rotation to run forward
        }

    }


    private void FixedUpdate()
    {
        if(moveByTouch)
        {
            rb.velocity = new Vector3(direction.x * Time.fixedDeltaTime * swipeSpeed, 0f, 0f); // seting the velocity wich we will move
            rb.velocity += new Vector3(0, 0, speed); // seting the speed wich we will be movinf forward
        }
        else
        {
            rb.velocity = Vector3.zero; // if we lift the finger then we won't move left or right
        }

    }

    private void OnTriggerEnter(Collider other) // method that dies something when we enter a colider
    {
        if(other.gameObject.tag == "kill") // if you colide with a ovject with a tag kill
        {
            rb.constraints = RigidbodyConstraints.FreezeAll; // freeze all constraints
            moveByTouch = false; // set fool moveByTouch to false
            playerAnimator.SetBool("Dying", true);
            playerAnimator.SetBool("Runing", false); // set bool in animator to false
            deathScreen.SetActive(true); // set death sreen on
            clearGates.SetActive(true); // set clearGates object on
        }


        if(other.gameObject.tag == "stop") // if we enter a colider with a tag stop
        {
            rb.constraints = RigidbodyConstraints.FreezeAll; // all constraints are turned on and the player won't move
            endScreen.SetActive(true); // endscreen object turns onn
            moveByTouch = false; // bool moveByTouch becomes false
            playerAnimator.SetBool("Runing", false); // sets bool "Runing" in our animator to false so the animation stops
        }

        if(other.gameObject.tag == "-10") // what hapens if we go into a colider with a tag -10
        {
            experience -= 10; // experience is lowerd by 10
        } 

        if (other.gameObject.tag == "-40")
        {
            experience -= 40;            
        }

        if (other.gameObject.tag == "-75")
        {
            experience -= 75;            
        }

        if (other.gameObject.tag == "-100")
        {
            experience -= 100;           
        }

        if (other.gameObject.tag == "+10")
        {
            experience += 10;           
        }

        if (other.gameObject.tag == "+40")
        {
            experience += 40;           
        }

        if (other.gameObject.tag == "+75")
        {
            experience += 75;           
        }

        if (other.gameObject.tag == "+100")
        {
            experience += 100;           
        }

        if (other.gameObject.tag == "x0")
        {
            experience *= 0;            
        }

        if (other.gameObject.tag == "x2")
        {
            experience *= 2;
        }

        if (other.gameObject.tag == "x5")
        {
            experience *= 5;
        }

        if (other.gameObject.tag == "x10")
        {
            experience *= 10;
        }

        if (other.gameObject.tag == "x15")
        {
            experience *= 15;
        }

        if (other.gameObject.tag == "%2")
        {
            experience /= 2;
        }

        if (other.gameObject.tag == "%5")
        {
            experience /=(int) 5;
        }

        if (other.gameObject.tag == "%10")
        {
            experience /= (int)10;
        }

        if (other.gameObject.tag == "%15")
        {
            experience /= (int)15;
        }

        if(other.gameObject.tag == "coin") // if you go into a colider with a tag coin
        {
            coins++; // coin +1
            PlayerPrefs.SetInt("coins", coins); // saving coins in player prefs
            Destroy(other.gameObject); // deactivating coin object
        }
    }
}
