using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moviment : MonoBehaviour
{
    //Moviments
    protected static float speed = 20f;
    protected virtual void moviment() { }
    protected virtual void rotation() { }

    //Animations
    protected static string currentState;
    protected static Animator anim;
    
    protected virtual void changeAnimationState(string newState) { }

}

public interface IAnimationCharacters
{

}
