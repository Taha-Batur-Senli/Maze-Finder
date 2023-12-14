using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//A shooter object that shoots bullets on a determined interval (and also determines their trajectory).
//Created by Taha Batur Senli
//Date: 14.12.2023

public class shooterScript : MonoBehaviour
{
    //These variables are assigned by the shooter and passed into the bullet to determine its movement vector.
    [SerializeField] public float bulletx;
    [SerializeField] public float bullety;
    [SerializeField] public float bulletz;

    //The time interval for each bullet being created.
    [SerializeField] public float shootInterval;

    //This variable is the bullet template from which the objects are created. Time keeps track of time.
    [SerializeField] GameObject bullet;
    float time;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        //When the time hits the interval, shoot.
        if(time >= shootInterval)
        {
            StartCoroutine(shoot());
        }
    }

    IEnumerator shoot()
    {
        time = 0;
        GameObject bul = Instantiate(bullet);
        bul.transform.SetParent(transform, false);
        bul.GetComponent<bulletScript>().x = bulletx;
        bul.GetComponent<bulletScript>().y = bullety;
        bul.GetComponent<bulletScript>().z = bulletz;
        yield return new WaitForEndOfFrame();
    }

    //These objects also decrement the player's health when hit.
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<SimpleSampleCharacterControl>() && other.GetType() == typeof(BoxCollider))
        {
            other.gameObject.GetComponent<SimpleSampleCharacterControl>().decrementHealth();
        }
    }
}
