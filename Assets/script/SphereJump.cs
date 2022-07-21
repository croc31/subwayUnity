using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereJump : MonoBehaviour
{
    private bool isUp = false;

    private void Start() {
    }
    private void JumpUp()
    {
        
        GetComponent<Rigidbody>().AddForce(new Vector3(0, 10, 0));
    }
    private void OnCollisionEnter(Collision other) {
       // Debug.Log(isUp +" " +  other.gameObject.layer);
        if (!isUp && other.gameObject.layer != 0 )
        {
            isUp = true;    
            JumpUp();
            isUp = false;   
        }
    }
}
