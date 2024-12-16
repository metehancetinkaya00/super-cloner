using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mananimation : MonoBehaviour
{
    public Animator animator;
    public playermovement movement;
    public healthbar playerhealth;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerhealth.health==0)
        {
            animator.SetBool("death", true);
            animator.SetBool("run", false);
           
        }
           if(movement.speedmove==10)
            {
                animator.SetBool("run", true);
            }
       

        else
        {
            animator.SetBool("run", false);
        }
    }
}
