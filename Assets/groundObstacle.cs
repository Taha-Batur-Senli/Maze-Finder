using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundObstacle : MonoBehaviour
{
    [SerializeField] bool moveUpDown = false;
    [SerializeField] bool spin = false;
    [SerializeField] bool spinLeft = false;
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
        else if(spin)
        {
            StartCoroutine(spinObj());
        }
    }

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
        transform.position = new Vector3(newX, pos.y, pos.z);
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
