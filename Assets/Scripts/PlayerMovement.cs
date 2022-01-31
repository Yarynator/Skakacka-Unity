using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Transform player;
    private bool isGrounded;

    void Start()
    {
        player = transform;
        isGrounded = true;
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        Vector3 position = player.position;
        position.x += horizontal * Time.deltaTime * 5f;
        player.position = position;

        if(Input.GetKeyDown(KeyCode.A)){
            player.GetComponent<SpriteRenderer>().flipX = true;
        } 
        else if (Input.GetKeyDown(KeyCode.D)){
            player.GetComponent<SpriteRenderer>().flipX = false;
        }

        Collider2D[] colls = Physics2D.OverlapBoxAll(player.position, player.localScale, 0f);
        foreach (var coll in colls)
        {
            if(coll.tag == "Ground"){
                isGrounded = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            player.GetComponent<Rigidbody2D>().AddForce(new Vector3(0, 300, 0));
            isGrounded = false; 
        }
    }
}
