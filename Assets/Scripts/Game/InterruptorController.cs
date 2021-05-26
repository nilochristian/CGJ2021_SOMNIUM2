//Script criado por Wellington F. Baldo
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterruptorController : MonoBehaviour
{

    public void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if (Input.GetButton("Interacao"))
            {
                string name = gameObject.name;
                name = name.Substring(name.Length - 1);
                int.TryParse(name, out int result);
                if(result != 0)
                {
                    gameObject.transform.parent.parent.GetComponent<SceneryController>().ApagaSala(result);
                    gameObject.SetActive(false);
                }
                else
                {
                    Debug.Log("Erro de conversão, valor interruptor");
                }
            }
        }
    }
}
