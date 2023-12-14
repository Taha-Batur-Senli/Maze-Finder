using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

//A simple camera script to track the player or switch to the bird's-eye view in-screen.
//Created by Taha Batur Senli
//Date: 14.12.2023

public class cameraScript : MonoBehaviour
{
    [SerializeField] public GameManager gameManager;
    [SerializeField] public Vector3 startPos;
    [SerializeField] public Quaternion startRot;
    [SerializeField] public Transform playerPos;
    [SerializeField] public Vector3 largePos = new Vector3(0, 85, 29);
    [SerializeField] public int largeRotX = 80;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.localPosition;
        startRot = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        //This enables the player to switch to the bird's-eye view as long as M is held down
        if(Input.GetKey(KeyCode.M) && gameManager.isContinuing)
        {
            gameManager.playerShowBall();
            transform.position = largePos;
            transform.rotation = Quaternion.Euler(largeRotX, 0, 0);
        }
        else
        {
            //If M is not held down, the camera will default to following the player.
            gameManager.playerHideBall();
            transform.position = playerPos.localPosition + startPos;
            transform.rotation = startRot;
        }
    }
}
