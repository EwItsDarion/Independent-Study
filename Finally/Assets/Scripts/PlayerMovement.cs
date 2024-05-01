using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    public Vector2 inputVec; //Input vector from player's movement controls (WASD or Arrow Keys)
    public float speed = 1f; //The speed at which the player moves
    SpriteRenderer spriter;
    Animator anim;

    private Rigidbody2D rb; //Reference to the player's rigidbody component

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); //Get reference to the player's rigidbody component on Awake
        spriter = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
   

    void FixedUpdate()
    {
        Vector2 nextVec = inputVec.normalized * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + nextVec);
    }

    void OnMove(InputValue value)
    {
        inputVec = value.Get<Vector2>();
    }
    void LateUpdate()
    {
        anim.SetFloat("Speed", inputVec.magnitude); 

        if (inputVec.x != 0){
            spriter.flipX = inputVec.x < 0;
        }
    }
}
