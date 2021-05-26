//Script criado por Wellington F. Baldo
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneryController : MonoBehaviour
{
    private GameObject casa;
    private GameObject[] salas;
    
    // Start is called before the first frame update
    void Start()
    {
        //Guarda objetos na memória 
        casa = gameObject;

        int numSalas = gameObject.transform.GetChild(1).childCount;
        salas = new GameObject[numSalas];
        for (int i = 0; i < salas.Length; i++)
        {
            salas[i] = gameObject.transform.GetChild(1).GetChild(i).gameObject;
        }
    }

    public void ApagaSala(int num)
    {
       foreach(GameObject sala in salas)
       {
            string name = sala.name;
            name = name.Substring(name.Length - 1);
            int.TryParse(name, out int result);
            if(result != 0)
            {
                if(result == num)
                {
                    sala.SetActive(false);
                    Message.lightPoints -= (Message.lightPoints != 0) ? 1 : 0;
                    break;
                }
            }
            else
            {
                Debug.Log("Erro de conversão no valor do cômodo");
            }
       }
    }
}
