using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//A simple bullet script that moves in a given x,y,z vector and hurts the player upon impact.
//Created by Taha Batur Senli
//Date: 14.12.2023

public class bulletScript : MonoBehaviour
{
    //These variables determine the bullet's velocity and direction and the wall material to recognize walls.
    [SerializeField] public float x;
    [SerializeField] public float y;
    [SerializeField] public float z;
    [SerializeField] Material walls;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //The bullet moves in the given directions specified during its creation.
        gameObject.transform.position += new Vector3(x,y,z);
    }

    private void OnTriggerEnter(Collider other)
    {
        //If the bullet hits a wall it is destroyed. If it hits the player, the player loses health.
        if (other.gameObject.GetComponent<SimpleSampleCharacterControl>() && other.GetType() == typeof(BoxCollider))
        {
            other.gameObject.GetComponent<SimpleSampleCharacterControl>().decrementHealth();
        }
        else if(other.gameObject.GetComponent<Renderer>().material.name.Equals(walls.name + " (Instance)"))
        {
            Destroy(gameObject);
        }
    }
}
