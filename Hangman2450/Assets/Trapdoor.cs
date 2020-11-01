using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trapdoor : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        CustomGameEventSystem.onGameFinished += openDoors;
        
    }

    private void OnDestroy() {
        CustomGameEventSystem.onGameFinished -= openDoors;
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    void openDoors(bool gameWon) {

        if (!gameWon) {
            animator.SetTrigger("Open");


        }
    }
}
