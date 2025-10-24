using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    Animator anim;

    [SerializeField]
    private float KarakterHiz;

    void Start()
    {
        anim = this.GetComponent<Animator>();


    }

    void Update()
    {

        Hareket();
    }
    void Hareket()
    {

        float yatay = Input.GetAxis("Horizontal");
        float dikey = Input.GetAxis("Vertical");
        anim.SetFloat("Horizontal", yatay);
        anim.SetFloat("Vertical", dikey);
        this.gameObject.transform.Translate(yatay * KarakterHiz * Time.deltaTime, 0, dikey * KarakterHiz * Time.deltaTime);

    }
}

