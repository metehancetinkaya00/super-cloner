using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocketcontroller : MonoBehaviour
{
    public GameObject ball;
    public GameObject man;
    public GameObject bar;
    public playermovement movementplayer;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            movementplayer.joystickfalse();
            ball.SetActive(false);
            man.SetActive(false);
            bar.SetActive(false);
            movementplayer.rb.isKinematic = true;
            gameeventsystem.rockettriggerenter();
        }
    }
   
}
