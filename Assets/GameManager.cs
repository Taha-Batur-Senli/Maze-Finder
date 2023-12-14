using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI healthAmount;

    [SerializeField] GameObject CameraMain;
    [SerializeField] GameObject CameraBack;
    [SerializeField] GameObject CameraLeft;
    [SerializeField] GameObject CameraRight;

    [SerializeField] GameObject ArrowMain;
    [SerializeField] GameObject ArrowLeft;
    [SerializeField] GameObject ArrowRight;
    [SerializeField] GameObject ArrowBack;

    [SerializeField] GameObject inGame;
    [SerializeField] GameObject win;
    [SerializeField] GameObject lose;
    [SerializeField] GameObject player;
    [SerializeField] GameObject restartButton;
    [SerializeField] Vector3 startCoords;
    public bool isContinuing;

    // Start is called before the first frame update
    void Start()
    {
        //At start, the player looks at the front.
        //Thus, all cameras except the front are disabled.
        CameraBack.SetActive(false);
        CameraLeft.SetActive(false);
        CameraRight.SetActive(false);
        CameraMain.SetActive(true);

        //Similarly, all arrows except the front direction are disabled at start.
        ArrowBack.SetActive(false);
        ArrowLeft.SetActive(false);
        ArrowRight.SetActive(false);
        ArrowMain.SetActive(true);

        //This part creates the player from the prefab template and sets its parent.
        player = Instantiate(player);
        player.transform.position = startCoords;
        player.transform.SetParent(gameObject.transform);

        //This part sets the player's position in the camera post-creation.
        CameraMain.GetComponent<cameraScript>().playerPos = player.transform;
        CameraLeft.GetComponent<cameraScript>().playerPos = player.transform;
        CameraRight.GetComponent<cameraScript>().playerPos = player.transform;
        CameraBack.GetComponent<cameraScript>().playerPos = player.transform;

        //This part retrieves the game manager by accessing the player script.
        player.GetComponent<SimpleSampleCharacterControl>().man = this;
        player.GetComponent<SimpleSampleCharacterControl>().startPos = startCoords;
        healthAmount.text = player.GetComponent<SimpleSampleCharacterControl>().health.ToString();

        //This part disables the UI elements shown at the end of the game
        //The bool "isContinuing" affirms the game is still on.
        isContinuing = true;
        win.SetActive(false);
        lose.SetActive(false);
        restartButton.SetActive(false);
        inGame.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        //Depending on the pressed keyword to look from a specific angle,
        //the cameras and arrows are altered. R is for looking at the back, 
        //T for front, Q for right and E for looking at the left direction.
        if(Input.GetKey(KeyCode.Q))
        {
            CameraBack.SetActive(false);
            CameraLeft.SetActive(true);
            CameraRight.SetActive(false);
            CameraMain.SetActive(false);

            ArrowBack.SetActive(false);
            ArrowLeft.SetActive(true);
            ArrowRight.SetActive(false);
            ArrowMain.SetActive(false);
        }
        else if(Input.GetKey(KeyCode.E))
        {
            CameraBack.SetActive(false);
            CameraLeft.SetActive(false);
            CameraRight.SetActive(true);
            CameraMain.SetActive(false);

            ArrowBack.SetActive(false);
            ArrowLeft.SetActive(false);
            ArrowRight.SetActive(true);
            ArrowMain.SetActive(false);
        }
        else if(Input.GetKey(KeyCode.R))
        {
            CameraBack.SetActive(true);
            CameraLeft.SetActive(false);
            CameraRight.SetActive(false);
            CameraMain.SetActive(false);

            ArrowBack.SetActive(true);
            ArrowLeft.SetActive(false);
            ArrowRight.SetActive(false);
            ArrowMain.SetActive(false);
        }
        else if(Input.GetKey(KeyCode.T))
        {
            CameraBack.SetActive(false);
            CameraLeft.SetActive(false);
            CameraRight.SetActive(false);
            CameraMain.SetActive(true);

            ArrowBack.SetActive(false);
            ArrowLeft.SetActive(false);
            ArrowRight.SetActive(false);
            ArrowMain.SetActive(true);
        }
    }

    //This method restarts the game.
    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //This method is called to show the large ball around the player when
    //the bird's-eye view mode is activated.
    public void playerShowBall()
    {
        player.GetComponent<SimpleSampleCharacterControl>().ball.SetActive(true);
    }

    //This mode hides the ball around the player after the bird's-eye view is exited.
    public void playerHideBall()
    {
        player.GetComponent<SimpleSampleCharacterControl>().ball.SetActive(false);
    }

    //This method ends the game.
    //Bool won is used to see if the game ended with a victory or loss.
    public void endGame(bool won)
    {
        player.SetActive(false);
        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
        isContinuing = false;
        inGame.SetActive(false);
        restartButton.SetActive(true);
        player.GetComponent<SimpleSampleCharacterControl>().m_moveSpeed = 0;

        if(won)
        {
            win.SetActive(true);
        }
        else
        {
            lose.SetActive(true);
        }
    }
}
