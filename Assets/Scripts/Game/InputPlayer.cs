using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputPlayer : MonoBehaviour
{
    public static Vector2 move()
    {
        Vector2 movePlayer = new Vector2(
            Input.GetAxis("Horizontal"), 
            Input.GetAxis("Vertical")
        );

        return movePlayer;
    }
}
