using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//A ground obstacle that can move on all axes and/or spin at will. Hurts the player on trigger hit.
//Created by Taha Batur Senli
//Date: 14.12.2023

public class groundObstacle : MonoBehaviour
{
    //These variables are used for determining the axis of movement for the object
    //as well as the direction it will spin towards.
    //moveUpDown moves the object on the y axis,
    //moveLeftRight moves the object on the x axis,
    //and moveinZ moves the object on the z axis.
    //The object moves on the specified height range with the given float speed.
    [SerializeField] bool moveUpDown = false;
    [SerializeField] bool spin = false;
    [SerializeField] bool spinLeft = false;
    [SerializeField] bool moveLeftRight = false;
    [SerializeField] bool moveinZ = false;
    [SerializeField] float speed = 2f;
    [SerializeField] float height = 0.5f;

    //Start coordinates of each type of this obstacle is needed to calculate movement.
    float startY;
    float startX;
    float startZ;

    // Start is called before the first frame update
    void Start()
    {
        startY = gameObject.transform.position.y;
        startX = gameObject.transform.position.x;
        startZ = gameObject.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        if(moveUpDown)
        {
            StartCoroutine(movingUpDown());
        }
        else if(moveLeftRight)
        {
            StartCoroutine(movingLeftRight());
        }
        else if (moveinZ)
        {
            StartCoroutine(movingInZ());
        }
        else if(spin)
        {
            StartCoroutine(spinObj());
        }
    }

    //This coroutine enables the object to spin, and its spin direction is determined by the spinLeft bool.
    //If spinLeft is true, it spins to the left, and if it is false it spins to the right.
    IEnumerator spinObj()
    {
        var rot = transform.rotation;

        if(spinLeft)
        {
            transform.rotation *= Quaternion.Euler(Vector3.left * Time.deltaTime * speed);
        }
        else
        {
            transform.rotation *= Quaternion.Euler(Vector3.right * Time.deltaTime * speed);
        }

        yield return new WaitForSeconds(0.2f);
    }

    //This coroutine is for moving the object on the z axis using a sin wave to
    //simulate decreasing speed at the ends.
    IEnumerator movingInZ()
    {
        var pos = transform.position;
        var newZ = startZ + height * Mathf.Sin(Time.time * speed);
        transform.position = new Vector3(pos.x, pos.y, newZ);
        yield return new WaitForEndOfFrame();
    }

    //This coroutine is for moving the object on the y axis using a sin wave to
    //simulate decreasing speed at the ends.
    IEnumerator movingUpDown()
    {
        var pos = transform.position;
        var newY = startY + height * Mathf.Sin(Time.time * speed);
        transform.position = new Vector3(pos.x, newY, pos.z);
        yield return new WaitForEndOfFrame();
    }

    //This coroutine is for moving the object on the x axis using a sin wave to
    //simulate decreasing speed at the ends.
    IEnumerator movingLeftRight()
    {
        var pos = transform.position;
        var newX = startX + height * Mathf.Sin(Time.time * speed);
        transform.position = new Vector3(newX, pos.y, pos.z);
        yield return new WaitForEndOfFrame();
    }
    
    //These objects are not destroyed and will decrement the player's health if they hit the player.
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<SimpleSampleCharacterControl>() && other.GetType() == typeof(BoxCollider))
        {
            other.gameObject.GetComponent<SimpleSampleCharacterControl>().decrementHealth();
        }
    }
}
