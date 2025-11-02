using Unity.Mathematics;
using UnityEngine;

public class AtesSistemi : MonoBehaviour
{



    Camera kamera;
    public LayerMask zombiKatman;
    KarakrerKontrol hpKontrol;
    public ParticleSystem muzzleFlash;
    Animator anim;

    private float sarjor = 5;
    private float cephane = 10;
    private float sarjorKapasitesi = 5;

    AudioSource sesKaynagi;
    public AudioClip atesSes;
    public AudioClip reloadSes;


    void Start()
    {
        kamera = Camera.main;
        hpKontrol = this.gameObject.GetComponent<KarakrerKontrol>();
        anim = this.gameObject.GetComponent<Animator>();
        sesKaynagi = this.gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hpKontrol.YasiyorMu() == true)
        {

            if (Input.GetMouseButton(0))
            {
                if (sarjor > 0)
                {
                    anim.SetBool("atesEt", true);
                }
                if (sarjor < 0)
                {
                    anim.SetBool("atesEt", false);
                }
                if (sarjor <= 0 && cephane > 0)
                {

                    anim.SetBool("sarjorDegistirme", true);

                }
            }
            else if (Input.GetMouseButtonUp(0))
            {
                anim.SetBool("atesEt", false);
            }

        }
    }


    public void SarjorDegistirmeSes()
    {
        sesKaynagi.PlayOneShot(reloadSes);
    }
    public void SarjorDegistirme()
    {

        cephane -= sarjorKapasitesi - sarjor;
        sarjor = sarjorKapasitesi;
        anim.SetBool("sarjorDegistirme", false);
    }
    public void AtesEtme()
    {
        if (sarjor > 0)
        {
            sarjor--;
            muzzleFlash.Play();
            sesKaynagi.PlayOneShot(atesSes);

            // Crosshair'ın yeni pozisyonuna göre ışın yolla (Y değeri 0.7f = üst kısım)
            Ray ray = kamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, zombiKatman))
            {
                hit.collider.gameObject.GetComponent<Zombi>().HasarAl();
            }
        }


    }

    public float GetSarjor()
    {
        return sarjor;
    }
    public float GetCephane()
    {
        return cephane;
    }


}

