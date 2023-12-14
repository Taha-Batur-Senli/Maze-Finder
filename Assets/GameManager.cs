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
        CameraBack.SetActive(false);
        CameraLeft.SetActive(false);
        CameraRight.SetActive(false);
        CameraMain.SetActive(true);

        ArrowBack.SetActive(false);
        ArrowLeft.SetActive(false);
        ArrowRight.SetActive(false);
        ArrowMain.SetActive(true);

        player = Instantiate(player);
        player.transform.position = startCoords;
        player.transform.SetParent(gameObject.transform);

        CameraMain.GetComponent<cameraScript>().playerPos = player.transform;
        CameraLeft.GetComponent<cameraScript>().playerPos = player.transform;
        CameraRight.GetComponent<cameraScript>().playerPos = player.transform;
        CameraBack.GetComponent<cameraScript>().playerPos = player.transform;

        player.GetComponent<SimpleSampleCharacterControl>().man = this;
        player.GetComponent<SimpleSampleCharacterControl>().startPos = startCoords;
        healthAmount.text = player.GetComponent<SimpleSampleCharacterControl>().health.ToString();

        isContinuing = true;
        win.SetActive(false);
        lose.SetActive(false);
        restartButton.SetActive(false);
        inGame.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
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

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void playerShowBall()
    {
        player.GetComponent<SimpleSampleCharacterControl>().ball.SetActive(true);
    }

    public void playerHideBall()
    {
        player.GetComponent<SimpleSampleCharacterControl>().ball.SetActive(false);
    }

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
