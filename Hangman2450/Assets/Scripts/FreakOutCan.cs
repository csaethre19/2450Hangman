using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.EventSystems;

public class FreakOutCan : MonoBehaviour
{
    public Rigidbody rb;
    public float thrust;
    public char letter;
    GameObject text;
    Clue clue;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        text = GameObject.Find("Text");
        clue = text.GetComponent<Clue>();
    }

    public void Click()
    {
        rb.AddForce(transform.forward * thrust);
        clue.CheckGuess(letter);
    }
}
