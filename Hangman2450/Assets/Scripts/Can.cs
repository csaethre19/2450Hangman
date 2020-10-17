using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.EventSystems;

public class Can : MonoBehaviour
{
    public Rigidbody rb;
    public float thrust;
    public char letter;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Click()
    {
        rb.AddForce(transform.up * -thrust);
        Debug.Log("Clicked: " + letter);
        CustomGameEventSystem.BroadcastGuessLetter(letter);
    }
    
}
