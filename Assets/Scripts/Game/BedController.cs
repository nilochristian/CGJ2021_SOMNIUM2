using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedController : MonoBehaviour
{
    private GameObject game;

    void Start()
    {
        game = GameObject.Find("GameMaster");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if (Input.GetButton("Interacao"))
            {
                if (Message.lightPoints == 0)
                {
                    game.GetComponent<GameController>().EndGame();
                }
                //string msg = Message.lightPoints == 0 ? "Ganhou" : "Ainda não";
            }
        }
    }
}
