using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
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

    public void endGame(bool won)
    {
        player.SetActive(false);
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
