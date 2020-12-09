using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShot : MonoBehaviour
{

    AudioSource gunshotSound;

    public float minVolume;
    public float maxVolume;
    [Space(20)]
    public float minPitch;
    public float maxPitch;

    // Start is called before the first frame update
    void Start()
    {
        gunshotSound= gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
     void Update()
    { 
    // If the left mouse button is pressed down...
    if(Input.GetMouseButtonDown(0) == true)
    {

            gunshotSound.volume =  Random.Range(minVolume,maxVolume);
            gunshotSound.pitch = Random.Range(minPitch, maxPitch);
            gunshotSound.Play();

    } 

 }
    public void DisableGunShot()
    {
        this.enabled = !this.enabled;
    }



}
