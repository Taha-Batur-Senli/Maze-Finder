using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI healthAmount;
    [SerializeField] GameObject Camera;
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
        player = Instantiate(player);
        player.transform.position = startCoords;
        player.transform.SetParent(gameObject.transform);
        Camera.GetComponent<cameraScript>().playerPos = player.transform;
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
