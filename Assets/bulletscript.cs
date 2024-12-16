using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletscript : MonoBehaviour
{
    public float forwardspeed;
    public GameObject thisobject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, 1 * forwardspeed * Time.deltaTime);

    }
    private void OnCollisionEnter(Collision collision)
    {
        
            Destroy(gameObject);
        
    }
    private void OnTriggerEnter(Collider other)
    {
        
            Destroy(this.gameObject);
        
    }
}
