using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class cameraScript : MonoBehaviour
{
    [SerializeField] public Vector3 startPos;
    [SerializeField] public Transform playerPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = playerPos.localPosition + startPos;
    }
}
