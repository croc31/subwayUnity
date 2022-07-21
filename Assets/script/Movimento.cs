using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimento : MonoBehaviour
{
    private int viaAtual;
    public int espaco;
    private bool isMoving = false;
    private bool isColliding = false;
    private Vector3 startPosition;
    private Vector3 targetPosition;
    void Start(){
        //quando se move a direita a via aumenta
        //quando se moce a esquerda a via diminui
        viaAtual = 2;
        
    }
    void Update()
    {
        if (isMoving)
       {
            Debug.Log("movendo de "+ transform.position + " para "+ targetPosition);
            if (Vector3.Distance(startPosition, transform.position) > 8f)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, targetPosition.z);
                isMoving = false;
                isColliding = false;
                return;
            }

            transform.position += ((targetPosition - startPosition) * espaco * Time.deltaTime)/4;
            //this.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, espaco));
            return;
       }
        if (Input.GetAxis("Horizontal") > 0 && viaAtual < 3)
        {
            targetPosition = transform.position + new Vector3(0,0,espaco);
            startPosition = transform.position;
            isMoving = true;
            ++viaAtual;
            ///Debug.Log("d "+ viaAtual);
            //gameObject.transform.Translate(0,0,(espaco));
            //Debug.Log(viaAtual);
        }
        if (Input.GetAxis("Horizontal") < 0 && viaAtual > 1)
        {
            targetPosition = transform.position - new Vector3(0,0,espaco);
            startPosition = transform.position;
            isMoving = true;
            --viaAtual;
            //Debug.Log("a "+ viaAtual);
            //gameObject.transform.Translate(0,0,(-espaco));
            //Debug.Log(viaAtual);
        }
        if (Input.GetAxis("Jump") > 0 && GameManager.Instance.pulos>0)
        {
            GameManager.Instance.pulos -= 1;
            this.GetComponent<Rigidbody>().AddForce(new Vector3(0, 500, 0));
        }       
    }

    public void OnCollisionEnter(Collision collision){
        //Debug.Log("Impactou ");
       // Debug.Log("startPosition" + startPosition);
       // Debug.Log("targetPosition" + targetPosition);
        if (collision.gameObject.layer == 8 && !isColliding){
            Vector3 aux = targetPosition;
            targetPosition = startPosition;
            startPosition = aux;
            isColliding = true;
        }
    }

    void FixedUpdate(){
        transform.Translate((-GameManager.Instance.velocidade*Time.deltaTime),0,0);

    }
    
}
