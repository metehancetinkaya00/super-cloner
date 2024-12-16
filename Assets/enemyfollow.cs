using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class enemyfollow : MonoBehaviour
{
    //shoot
    public GameObject projectile;
    private float timebetweenattacks=2f;
    public Transform muzzleMain;
    bool alreadyattacked;
    //shoot
    public bool isplayerinarea;
    //enemy radius
    //public float lookradius = 10f;
    public float attackradius = 10f;
    public Animator animator;

    //public ParticleSystem deathparticle;

    public GameObject target;
   public NavMeshAgent agent;
 
   public enemyscript enemyy;
    // Start is called before the first frame update
    void Start()
    {
       
        agent = GetComponent<NavMeshAgent>();
        //  animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

        seeplayer();
    }
    private void seeplayer()
    { //agent.speed = enemyspeed;

        float distance = Vector3.Distance(transform.position, target.transform.position);
        if (enemyy.canSeePlayer == true)
        {

            agent.speed = 3.5f;

            Vector3 lookAtPosition = target.transform.position;
            lookAtPosition.y = transform.position.y;
            transform.LookAt(lookAtPosition);

            Vector3 toplayer = transform.position - target.transform.position;
            Vector3 newpos = transform.position - toplayer;
            agent.SetDestination(newpos);

            animator.SetBool("run", true);
            animator.SetBool("ıdle", false);

        }

        if (enemyy.canSeePlayer == false)
        {
            agent.speed = 0;
            animator.SetBool("run", false);
            animator.SetBool("ıdle", true);


        }
        if (distance <= attackradius)
        {
            if (enemyy.canSeePlayer == true)
            {
                attackplayer();
            }



            // isplayerinarea = true;
            agent.speed = 0;
            animator.SetBool("shoot", true);
            animator.SetBool("run", false);
            animator.SetBool("ıdle", false);
        }
        else
        {
            agent.speed = 3.5f;

            //  isplayerinarea = false;
            animator.SetBool("shoot", false);
            //   animator.SetBool("run", true);

        }

    }

    private void attackplayer()
    {
        agent.SetDestination(transform.position);
        if(!alreadyattacked)
        {

            Rigidbody rb = Instantiate(projectile, muzzleMain.transform.position,muzzleMain.rotation).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 10f, ForceMode.Impulse);
           // rb.transform.Translate(0, 0, 1 * 5 * Time.deltaTime);
            alreadyattacked = true;
            Invoke(nameof(resetattack), timebetweenattacks);
        }
    }

    private void resetattack()
    {
        alreadyattacked = false;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
       // Gizmos.DrawWireSphere(transform.position, lookradius);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, attackradius);
    }
    //enemy radius

    private void OnTriggerEnter(Collider other)
    {


        if (other.gameObject.tag=="Player")
        {
            Destroy(gameObject);
           // deathparticle.Play();
        }

    }
   

    IEnumerator waittostand()

    {
      
       
        //   animator.SetBool("ıdle", true);
        //   animator.SetBool("run", false);
        yield return new WaitForSeconds(5);
      

        GetComponent<enemyfollow>().enabled = false;

        //fieldofview
        GetComponent<enemyscript>().enabled = true;
        //fieldofview
    }


}
