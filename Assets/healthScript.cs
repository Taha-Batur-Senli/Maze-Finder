using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthScript : MonoBehaviour
{
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

    IEnumerator movingUpDown()
    {
        var pos = transform.position;
        var newY = startY + height * Mathf.Sin(Time.time * speed);
        transform.position = new Vector3(pos.x, newY, pos.z);
        yield return new WaitForEndOfFrame();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<SimpleSampleCharacterControl>() && other.GetType() == typeof(BoxCollider))
        {
            other.gameObject.GetComponent<SimpleSampleCharacterControl>().incrementHealth();
            Destroy(gameObject);
        }
    }
}
