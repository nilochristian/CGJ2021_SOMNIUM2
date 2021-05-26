using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Moviment, IAnimationCharacters
{
    private Rigidbody2D rb = new Rigidbody2D();

    private List<string> lGuri = new List<string>()
    {
        "_guri_idle",
        "_guri_walk_side",
        "_guri_walk_up",
        "_guri_walk_down",
        "_guri_action_up",
        "_guri_action_side"
    };
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Moviment.anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //rotation();
        pressedButtonInteraction();
        presssedButtonMoviment();
        moviment();
    }

    protected override void moviment()
    {
        Vector2 move = InputPlayer.move().normalized;
        float speedPenalty = 3;
        rb.velocity = (move * 200f * Time.fixedDeltaTime);
        base.moviment();
    }

    protected override void rotation()
    {
        Vector2 dir = InputPlayer.move().normalized;
        if(dir != Vector2.zero)
        {
            float targetRotation = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(targetRotation,Vector3.forward);
        };
        dir.Normalize();
        base.rotation();
    }

    protected override void changeAnimationState(string newStateGuri)
    {
        if (Moviment.currentState == newStateGuri) return;
        Moviment.anim.Play(newStateGuri);
        Moviment.currentState = newStateGuri;
        base.changeAnimationState(newStateGuri);
    }

    private void presssedButtonMoviment()
    {
        //DIRECTIONAL
        Vector2 dir = InputPlayer.move().normalized;
        if( dir != Vector2.zero )
        {
            //UP DOWN DIRECTION
            int value = 
                dir.x > 0 || dir.x < 0 ? 1 : (dir.y > 0 ? 2 : 3);
            //LATERAL DIRECTION
            int directionX = 
                dir.x < 0 ? 10 : (dir.x > 0 ? -10 : 10);
            //INVERT SPRITE
            transform.localScale = new Vector2(directionX, 10);
            changeAnimationState(lGuri[value]);
        }
        else
        {
            //Idle
            changeAnimationState(lGuri[0]);
        }
    }

    private void pressedButtonInteraction()
    {
        Vector2 dir = InputPlayer.move().normalized;
        if(dir == Vector2.zero)
        {
            if (Input.GetButtonDown("Interacao"))
            {
                changeAnimationState(lGuri[4]);
            }
        }
            
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Light":
                collision.gameObject.GetComponent<Renderer>().
                    material.color = Color.green;
                collision.gameObject.tag = "LightOff";
                //Message.lightPoints -= (Message.lightPoints != 0) ? 1 : 0;
                break;
            case "Bed":
                string msg = Message.lightPoints == 0 ? "Ganhou" : "Ainda não";
                Debug.Log(msg);
                break;
        }
    }
}