using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//The script of a simple healer object that increases the player's health on collision.
//Created by Taha Batur Senli
//Date: 14.12.2023

public class healthScript : MonoBehaviour
{
    //These values are for moving the health object up and down to create a sense of liveliness.
    [SerializeField] float speed = 2f;
    [SerializeField] float height = 0.5f;
    float startY;

    // Start is called before the first frame update
    void Start()
    {
        startY = gameObject.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(movingUpDown());
    }

    //The health object moves up and down just like a dangerous object.
    IEnumerator movingUpDown()
    {
        var pos = transform.position;
        var newY = startY + height * Mathf.Sin(Time.time * speed);
        transform.position = new Vector3(pos.x, newY, pos.z);
        yield return new WaitForEndOfFrame();
    }

    //If the player hits the health object, they "heal," i.e. their health increases.
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<SimpleSampleCharacterControl>() && other.GetType() == typeof(BoxCollider))
        {
            other.gameObject.GetComponent<SimpleSampleCharacterControl>().incrementHealth();
            Destroy(gameObject);
        }
    }
}
