using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class cameraScript : MonoBehaviour
{
    [SerializeField] public GameManager gameManager;
    [SerializeField] public Vector3 startPos;
    [SerializeField] public Quaternion startRot;
    [SerializeField] public Transform playerPos;
    [SerializeField] public Vector3 largePos = new Vector3(0, 85, 28.5f);
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
        if(Input.GetKey(KeyCode.M) && gameManager.isContinuing)
        {
            transform.position = largePos;
            transform.rotation = Quaternion.Euler(largeRotX, 0, 0);
        }
        else
        {
            transform.position = playerPos.localPosition + startPos;
            transform.rotation = startRot;
        }
    }
}
