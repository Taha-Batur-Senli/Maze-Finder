using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundObstacle : MonoBehaviour
{
    [SerializeField] bool moveUpDown = false;
    [SerializeField] bool moveLeftRight = false;
    [SerializeField] float speed = 2f;
    [SerializeField] float height = 0.5f;
    float startY;
    float startX;

    // Start is called before the first frame update
    void Start()
    {
        startY = gameObject.transform.position.y;
        startX = gameObject.transform.position.x;   
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
    }

    IEnumerator movingUpDown()
    {
        var pos = transform.position;
        var newY = startY + height * Mathf.Sin(Time.time * speed);
        transform.position = new Vector3(pos.x, newY, pos.z);
        yield return new WaitForEndOfFrame();
    }

    IEnumerator movingLeftRight()
    {
        var pos = transform.position;
        var newX = startX + height * Mathf.Sin(Time.time * speed);
        transform.position = new Vector3(pos.x, newX, pos.z);
        yield return new WaitForEndOfFrame();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<SimpleSampleCharacterControl>() && other.GetType() == typeof(BoxCollider))
        {
            other.gameObject.GetComponent<SimpleSampleCharacterControl>().decrementHealth();
        }
    }
}
