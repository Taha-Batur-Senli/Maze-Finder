using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject inGame;
    [SerializeField] GameObject win;
    [SerializeField] GameObject lose;
    [SerializeField] GameObject player;
    [SerializeField] GameObject restartButton;

    // Start is called before the first frame update
    void Start()
    {
        win.SetActive(false);
        lose.SetActive(false);
        restartButton.SetActive(false);
        inGame.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
