using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public Transform target; // Player's transform
    public bool isShieldActive = false; // Variable to control shield visibility

    // Update is called once per frame
    void Update()
    {
        if (isShieldActive)
        {
            Vector3 newposition = new Vector3(target.position.x, target.position.y, target.position.z);
            transform.position = newposition;
            // Ensure the shield is visible by enabling its renderer or mesh, e.g.:
            GetComponent<Renderer>().enabled = true;
        }
        else
        {
            // Ensure the shield is hidden by disabling its renderer or mesh, e.g.:
            GetComponent<Renderer>().enabled = false;
        }
    }
}

