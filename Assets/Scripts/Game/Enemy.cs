using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Moviment, IAnimationCharacters
{
    public Transform target;
    private Rigidbody2D rb;
    private Vector2 move;
    private float velocity = 10;

    private Animator animEnemy;
    private string currentStateEnemy;

    private GameObject game;

    /*
    const string IDLE = "_chupacu_idle";
    const string WALK_SIDE = "_chupacu_walk_side";
    const string WALK_UP = "_chupacu_walk_up";
    const string WALK_DOWN = "_chupacu_walk_down";
    */

    private List<string> lChupacu = new List<string>()
    {
        "_chupacu_walk_side","_chupacu_walk_up","_chupacu_walk_down"
    };

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animEnemy = GetComponent<Animator>();

        game = GameObject.Find("GameMaster");
    }

    // Update is called once per frame
    void Update()
    {
        //rotation();
        animationOfChupacu();
        moviment();
    }

    protected override void moviment()
    {
        Vector2 pos = Vector2.MoveTowards(
            transform.position,
            target.position,
            getVelocity() * Time.deltaTime
            );
        rb.MovePosition(pos);
        
        base.moviment();
    }

    protected override void rotation()
    {
        Vector2 dir = target.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        dir.Normalize();
        
        base.rotation();
    }

    protected override void changeAnimationState(string newStateChupacu)
    {
        if (currentStateEnemy == newStateChupacu) return;
        animEnemy.Play(newStateChupacu);
        currentStateEnemy = newStateChupacu;
        base.changeAnimationState(newStateChupacu);
    }

    private void animationOfChupacu()
    {
        Vector2 dir = transform.position - target.position;
        if(dir != Vector2.zero)
        {
            int val = getValueOfAnimation();
            int dirX = dir.x > 0 ? -10 : (dir.x < 0 ? 10 : -10);
            transform.localScale = new Vector2(dirX, 10);
            changeAnimationState(lChupacu[val]);
            //Debug.Log(dir);
        }
        
    }

    private int getValueOfAnimation()
    {
        Vector2 dir = transform.position - target.position;
        int valueOfThisShit = 0;

        float dirYPlus = Mathf.Abs(dir.y);
        float dirXPlus = Mathf.Abs(dir.x);

        //UP
        //Right, Left
        if (dir.y > 0)
        {
            if(dir.x > 0)
            {
                valueOfThisShit = 
                    dir.y > dir.x ? 2 : (
                    dir.y > dirXPlus ? 2 : 0
                    );
            }
        }
        else
        //DOWN
        //Right, Left
        {
            if (dir.x > 0)
            {
                valueOfThisShit = 
                    dirYPlus > dir.x ? 1 : (
                    dirYPlus > dirXPlus ? 1 : 0
                    );
            }
        }
        return valueOfThisShit;
    }

    private float getVelocity()
    {
        float inscreaseSpeed = 13;
        float remnantPoints = (Message.minutesLeft / 60) - Message.lightPoints;
        float totalVelocity = velocity - remnantPoints;
        return (Moviment.speed + inscreaseSpeed) / totalVelocity;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Player":
                game.GetComponent<GameController>().GameOver();
                break;
        }
    }

}
