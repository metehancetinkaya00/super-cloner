using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class healthbar : MonoBehaviour
{
    
    public Image healthbarr;
    [SerializeField] public float health, maxhealth = 5;
    float lerpspeed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        // IQtext.text = "" + IQ + "%";

        if (health > maxhealth) health = maxhealth;

        lerpspeed = 3f * Time.deltaTime;

        healthbarfiller();
        colorcchanger();
    }
    void healthbarfiller()
    {
        healthbarr.fillAmount = Mathf.Lerp(healthbarr.fillAmount, health / maxhealth, lerpspeed);
    }
    public void death(float healthpoints)
    {
        if (health > 0)

            health -= healthpoints;

    }

    void colorcchanger()
    {
        Color healthcolor = Color.Lerp(Color.red, Color.green, (health / maxhealth));
        healthbarr.color = healthcolor;
    }
    public void live(float cleveringpoints)
    {
        if (health < maxhealth)

            health += cleveringpoints;

    }
}
