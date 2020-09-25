using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreakOutCan : MonoBehaviour
{
    public Rigidbody rb;
    public float thrust;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            rb.AddForce(transform.forward * thrust);
        }
    }
}
