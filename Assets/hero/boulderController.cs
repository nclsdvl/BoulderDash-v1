using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boulderController : MonoBehaviour {


    [SerializeField] float speed = 2f;
    Rigidbody2D rb;
    Animator anim;
    Vector2 maPosition;
    private bool moving;
    RaycastHit2D hit;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Use this for initialization
    void Start () {
        maPosition = transform.position;

        InvokeRepeating("CheckInput", 1f, 0.15f);


    }

    void Update()
    {

        Debug.DrawRay(transform.position, 3*Vector2.right, Color.red, 0.2f);
        if (moving)
        {
            transform.position = maPosition;
            moving = false;
        }
    }


    void CheckInput()
    {

        if (Input.GetKey("right"))
        {
            maPosition += 3.731f * Vector2.right;
            Ray2D Rayon = new Ray2D(transform.position, 3*Vector2.right);

            if (Physics2D.Raycast(transform.position, 3 * Vector2.right))
            {
                Debug.DrawRay(transform.position, 3 * Vector2.right);
                Debug.Log("Objet : " + hit.collider + " distance : " + hit.distance);
                moving = false;
            }
            else { moving = true; }
            
            anim.SetBool("droite", true);
            anim.SetBool("gauche", false);
        }
        else if (Input.GetKey("left"))
         {
            maPosition -= 3.731f*Vector2.right;
            moving = true;
            anim.SetBool("gauche", true);
            anim.SetBool("droite", false);
        }
        else if (Input.GetKey("up"))
        {
            maPosition += 3.85314f * Vector2.up;
            moving = true;
            anim.SetBool("droite", true);
            anim.SetBool("gauche", false);
        }
        else if (Input.GetKey("down"))
        {
            maPosition -= 3.85314f*Vector2.up;
            moving = true;
            anim.SetBool("gauche", true);
            anim.SetBool("droite", false);
        }
        else
        {
            moving = false;
            anim.SetBool("droite", false);
            anim.SetBool("gauche", false);
        }
    }


}




