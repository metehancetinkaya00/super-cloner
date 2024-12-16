using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{

   
    public ParticleSystem bulletparticle;
    //joystic for move
    public VariableJoystick movejoystick;
    //joystic for move
    //joystic for setactive false
    public Joystick joystick;
    //joystic for setactive false

    [SerializeField] public float moveH, moveV, speedmove = 7;
    public Rigidbody rb;
  
    public GameObject man;

    public GameObject ball;
    public bool ischanged;
    public healthbar barhealth;
    public int changehealthbar;
   
    public GameObject failimage;
   // public GameObject[] objects;
    // Start is called before the first frame update
    void Start()
    {
                                                                                                                                                                                                     
        rb = GetComponent<Rigidbody>();
        //finish
    }

    // Update is called once per frame

    private void FixedUpdate()
    {
        joystickupdate();
    }
    public void joystickfalse()
    {
        speedmove = 0;
        joystick.gameObject.SetActive(false);
    }
    private void joystickupdate()
    {
        if (barhealth.health == 0)
        {
            failimage.SetActive(true);
         
        }
       

        
            moveH = movejoystick.Horizontal;
        moveV = movejoystick.Vertical;

        Vector3 dir = new Vector3(moveH, 0, moveV);
        rb.velocity = new Vector3(moveH * speedmove, rb.velocity.y, moveV * speedmove);
        if (dir != Vector3.zero)
        {
            if (ischanged == false)
            {
                speedmove = 7;
            }
            if (ischanged == true)
            {
                speedmove = 10;

            }

            transform.LookAt(transform.position + dir);


            //animator.SetFloat("speed", dir.magnitude);
        }
        else
        {
            speedmove = 0;
        }
    }

        private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="enemy")
        {
           
            man.SetActive(true);
            ball.SetActive(false);
            ischanged = true;
            barhealth.health += 1;
        }
        if (other.gameObject.tag == "bullet")
        {
           // Destroy(other.gameObject);
            barhealth.health -= 1;
            bulletparticle.Play();
            changehealthbar -=1;
        }
       
           


    }
   
}
