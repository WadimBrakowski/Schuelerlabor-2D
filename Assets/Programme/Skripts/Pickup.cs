using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    //Animator animator;
    SpielSitzung ps;
    //Definiert die Punkte für den Apfel
    [SerializeField] int pointsForPickup = 100;

    bool wasCollected = false;
    private void Start()
    {
        //animator=GetComponent<Animator>();
        ps = FindObjectOfType<SpielSitzung>();
    }
    //Funktion, wenn Trigger ausgelöst wird.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Sammelt Apfel ein
        if(collision.tag=="Player"&&!wasCollected)
        {
            wasCollected = true;
            ps.AddToScore(pointsForPickup);
            //animator.SetTrigger("collect");
            Destroy(gameObject);
        }
    }
}
