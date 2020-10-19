using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.EventSystems;

public class Can : MonoBehaviour {
    public Rigidbody rb;
    public float minThrust;
    public float maxThrust;
    public char letter;

    //audio fields
    AudioSource pingSound;
    public float minVolume;
    public float maxVolume;
    [Space(20)]
    public float minPitch;
    public float maxPitch;


    // Start is called before the first frame update
    void Start() {
        rb = gameObject.GetComponent<Rigidbody>();
        pingSound = gameObject.GetComponent<AudioSource>();
    }

    public void Click() {
        rb.AddForce(transform.up * -Random.Range(minThrust, maxThrust));
        Debug.Log("Clicked: " + letter);
        CustomGameEventSystem.BroadcastGuessLetter(letter);

        pingSound.volume = Random.Range(minVolume, maxVolume);
        pingSound.pitch = Random.Range(minPitch, maxPitch);
        pingSound.Play();

    }
}
