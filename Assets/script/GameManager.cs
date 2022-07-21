using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance{
        get {
            if (_instance == null)
            {   
                Debug.LogError("GameManager is null");
            }
            return _instance;
        }
    }
    private void Awake(){
        _instance = this;
    }
    
    public int velocidade;
    public int pontos;
    public int vidas;
    public int pulos;
    public int pulosMax;
    public ArrayList upgrades;
    void Start()
    {
        upgrades = new ArrayList();
        pontos = 0;
        pulos = 0;
        pulosMax = 1;
        vidas = 2;
    }

    
}
