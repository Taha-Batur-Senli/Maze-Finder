using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class shooterScript : MonoBehaviour
{
    [SerializeField] public float bulletx;
    [SerializeField] public float bullety;
    [SerializeField] public float bulletz;
    [SerializeField] public float shootInterval;
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<SimpleSampleCharacterControl>() && other.GetType() == typeof(BoxCollider))
        {
            other.gameObject.GetComponent<SimpleSampleCharacterControl>().decrementHealth();
        }
    }
}
