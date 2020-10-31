using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPing : MonoBehaviour
{
    AudioSource pingSound;

    public float minVolume;
    public float maxVolume;
    [Space(20)]
    public float minPitch;
    public float maxPitch;

    // Start is called before the first frame update
    void Start() {
        pingSound = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void playPing() {

            pingSound.volume = Random.Range(minVolume, maxVolume);
            pingSound.pitch = Random.Range(minPitch, maxPitch);
            pingSound.Play();

       
    }
}
