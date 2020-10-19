using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour
{
    public LayerMask clickableLayer;
    public GameObject gunSmokePrefab;
    public GameObject sparkPrefab;

    GameObject particleInstance;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit rayHit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out rayHit, Mathf.Infinity))
            {   if(rayHit.rigidbody != null) {

                    if (rayHit.rigidbody.tag == "Can") {
                        rayHit.collider.GetComponent<Can>().Click();
                        Instantiate(sparkPrefab, rayHit.point, Quaternion.identity);

                    }

                    /* Trying to make Dave react to raycast like he's getting shot
                    if (rayHit.rigidbody.gameObject.tag == "Dave") {
                        rayHit.rigidbody.AddForceAtPosition(Camera.main.transform.forward * 1000f, rayHit.point);
                        Debug.Log("booyah");

                    }
                    */

                    Instantiate(gunSmokePrefab, rayHit.point, Quaternion.identity);
                }
               


            }
        }
    }
}
