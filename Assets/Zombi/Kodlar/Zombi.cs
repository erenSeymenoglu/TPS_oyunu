using System.Collections;
using UnityEngine;
using UnityEngine.AI;
public class Zombi : MonoBehaviour
{
    public float ZombiHP = 100;
    Animator zombiAnim;
    bool zombiOlu;
    public float KovalamaMesafe;
    NavMeshAgent zombiNavMash;

    GameObject hedefOyuncu;
    void Start()
    {
        zombiAnim = this.GetComponent<Animator>();
        hedefOyuncu = GameObject.Find("Ajan");
        zombiNavMash = this.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ZombiHP <= 0)
        {
            zombiOlu = true;
        }
        if (zombiOlu == true)
        {
            zombiAnim.SetBool("oldu", true);
            StartCoroutine(YokOl());
        }
        else
        {
            //ileride hareket kodunu buraya yazacağız
            float mesafe = Vector3.Distance(this.transform.position, hedefOyuncu.transform.position);
            if (mesafe < KovalamaMesafe)
            {
                zombiNavMash.SetDestination(hedefOyuncu.transform.position);
            }

        }
    }

    IEnumerator YokOl()

    {
        yield return new WaitForSeconds(5);
        Destroy(this.gameObject);
    }
    public void HasarAl()
    {
        ZombiHP -= Random.Range(15, 25);
    }
}

