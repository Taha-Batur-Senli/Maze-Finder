using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
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
        gameObject.transform.position += new Vector3(x,y,z);
    }

    private void OnTriggerEnter(Collider other)
    {
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
