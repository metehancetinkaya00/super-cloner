using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerascript : MonoBehaviour
{
    [SerializeField] public float camerarotationx;
    [SerializeField] public float camerarotationy;
    [SerializeField] public float camerarotationz;
    [SerializeField] public float followspeed;
  
    public GameObject target;
    public Vector3 distance;
    [SerializeField] public float turnspeed;
    // Start is called before the first frame update
    void Start()
    {
        gameeventsystem.onrockettriggerenter += camerafinish;

    }
    private void camerafinish()
    {
        // GetComponent<finishcamera>().enabled = true;
        camerarotationx = -3;
        camerarotationy = 0;
        camerarotationz=0;
        followspeed = 1;
        distance.x = 0;
        distance.y = 3.45f;
        distance.z = -7;
        turnspeed = 0.6f;

    }
        // Update is called once per frame
        void Update()
    {
       
           
        

        this.transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(camerarotationx, camerarotationy, camerarotationz), Time.deltaTime * turnspeed);
        this.transform.position = Vector3.Lerp(this.transform.position, target.transform.position + distance, Time.deltaTime*followspeed);
    }

}
