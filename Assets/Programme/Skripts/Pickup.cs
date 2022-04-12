using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    //Animator animator;
    SpielSitzung ps;
    [SerializeField] int pointsForPickup = 100;

    bool wasCollected = false;
    private void Start()
    {
        //animator=GetComponent<Animator>();
        ps = FindObjectOfType<SpielSitzung>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player"&&!wasCollected)
        {
            wasCollected = true;
            ps.AddToScore(pointsForPickup);
            //animator.SetTrigger("collect");
            Destroy(gameObject);
        }
    }
}
