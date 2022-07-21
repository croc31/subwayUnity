using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollision : MonoBehaviour
{
    private Rigidbody PlayerRigidbody;
    private void Start() {
        PlayerRigidbody = GetComponent<Rigidbody>();
    }
    void OnCollisionEnter(Collision collision){
       // Debug.Log("Bateu");
         if (collision.gameObject.layer == 6){//item
            if (collision.gameObject.tag == "coin"){
                GameManager.Instance.pontos++;
                GameObject.Destroy(collision.gameObject);
            }
        } else if (collision.gameObject.layer == 7){//modiffier
            if (collision.gameObject.tag == "boost"){
                GameManager.Instance.velocidade+=5;
            }else if (collision.gameObject.tag == "jump"){ 
                //Debug.Log( Player.GetComponent<Rigidbody>());
           
               PlayerRigidbody.AddForce(new Vector3(0, 1000, 0));
            }
        }else if (collision.gameObject.layer == 8){//obstacle
            GameManager.Instance.vidas -=1;
        }
        if (collision.gameObject.layer <= 8){//obstaculo
            GameManager.Instance.pulos = GameManager.Instance.pulosMax;

        }
    }
}
