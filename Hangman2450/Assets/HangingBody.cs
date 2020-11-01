using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HangingBody : MonoBehaviour
{
    GameObject daveRagdoll;
    GameObject daveRegular;
    Animator daveAnimator;
    // Start is called before the first frame update
    void Start()
    {
        CustomGameEventSystem.onGameFinished += GameFinish;
        CustomGameEventSystem.onChangeLives += Wrong;

        daveRagdoll = transform.Find("DaveRagdoll").gameObject;
        daveRegular = transform.Find("DaveRegular").gameObject;
        daveAnimator = daveRegular.GetComponent<Animator>();

    }
    private void OnDestroy() {
        CustomGameEventSystem.onGameFinished -= GameFinish;
        CustomGameEventSystem.onChangeLives -= Wrong;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void GameFinish(bool gameWon) {

        if (!gameWon) {

            daveRegular.SetActive(false);
            daveRagdoll.SetActive(true);
        }
        if (gameWon) {
            transform.Find("Rope").gameObject.SetActive(false);
            daveAnimator.SetTrigger("GameWon");
        }
    }
    void Wrong(int lives) {
        daveAnimator.SetTrigger("Wrong");
    }
}
