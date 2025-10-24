using System.Collections;
using UnityEngine;

public class Zombi : MonoBehaviour
{
    public float ZombiHP = 100;
    Animator zombiAnim;
    bool zombiOlu;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        zombiAnim = this.GetComponent<Animator>();
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

