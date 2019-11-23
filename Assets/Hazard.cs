using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    public GameObject Spawn;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Floor")
            transform.position = new Vector3(0, 0, 0);
    }

    void Respawn()
    {
        transform.position = Spawn.transform.position;
    }

}
