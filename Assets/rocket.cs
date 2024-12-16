using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocket : MonoBehaviour
{  public GameObject finishimage;
    public float forwardspeed;
    public bool active;
    // Start is called before the first frame update
    void Start()
    {
        gameeventsystem.onrockettriggerenter += onrocketenter;
    }
    
  
    // Update is called once per frame
    void Update()
    {if(active==true)
        {
            moveforward();
        }
       
    }
    private void onrocketenter()
    {
        StartCoroutine(waitforup());
    }
    void moveforward()
    {
        transform.Translate(0, forwardspeed, 0  * Time.deltaTime);
    }
    IEnumerator waitforup()
    {
        yield return new WaitForSeconds(3);
        active = true;
        finishimage.SetActive(true);
    }
}
