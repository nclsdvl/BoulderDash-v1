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
    private float originOffset = 1.8f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Use this for initialization
    void Start () {
        maPosition = transform.position;

        InvokeRepeating("CheckInput", 0f, 0.15f);


    }

    void Update()
    {
        Vector2 startingPosition = new Vector2(transform.position.x + originOffset, transform.position.y);

        Debug.DrawRay(startingPosition, 3 * Vector2.right, Color.red, 0.2f);
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


            Vector2 startingPosition = new Vector2(transform.position.x + originOffset, transform.position.y);

            RaycastHit2D hit = Physics2D.Raycast(startingPosition,  Vector2.right, 2f);


            if (hit != false && hit.transform.tag == "wallH") /*&& hit.transform.name != "monPerso")*/
            {
                Debug.Log("Objet : " + hit.transform.tag + " distance : " + hit.distance);
            }
            else {

                moving = true;
                maPosition += 3.731f * Vector2.right;
            }

           
            
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

    //private void OnCollisionEnter2D(Collision2D collision)
    //{

    //    RaycastHit2D hit = Physics2D.Raycast(transform.position, 5 * Vector2.right);
    //    Debug.Log("j'entre en collision Objet: " + hit.collider);
    //    if (hit.transform.tag == "wallH")
    //    {
    //        Destroy(this); /*collision.gameObject.GetComponent<BoxCollider2D>());*/
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("j'entre en collision OOOOOOOOOOOObjet: " + collision.tag);
        if (collision.transform.tag == "foin")
        {
            Destroy(collision.gameObject); /*collision.gameObject.GetComponent<BoxCollider2D>());*/
        }
    }

}




