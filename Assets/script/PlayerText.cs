using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerText : MonoBehaviour
{
     TMP_Text pontos;
     TMP_Text vidas;
    void Start()
    {
        pontos = gameObject.GetComponent<TMP_Text>();
        vidas = gameObject.GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        pontos.text = "Pontos: " + GameManager.Instance.pontos;
        vidas.text = "Vidas: " + GameManager.Instance.vidas;
    }
}
