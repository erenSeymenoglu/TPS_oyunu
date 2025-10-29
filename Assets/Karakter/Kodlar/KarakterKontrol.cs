using UnityEngine;

public class KarakrerKontrol : MonoBehaviour
{
    Animator anim;

    [SerializeField]
    private float KarakterHiz;
    bool hayattaMi;
    private float saglik = 100;
    void Start()
    {
        anim = this.GetComponent<Animator>();
        hayattaMi = true;

    }

    void Update()
    {
        if (saglik <= 0)
        {
            hayattaMi = false;
            anim.SetBool("yasiyorMu", hayattaMi);
        }
        if (hayattaMi == true)
        {
            Hareket();
        }
    }

    public float GetSaglik()
    {
        return saglik;
    }
    public bool YasiyorMu()
    {
        return hayattaMi;
    }
    public void HasarAl()
    {
        saglik -= Random.Range(5, 10);
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

