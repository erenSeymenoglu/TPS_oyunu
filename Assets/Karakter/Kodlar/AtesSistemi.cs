using Unity.Mathematics;
using UnityEngine;

public class AtesSistemi : MonoBehaviour
{



    Camera kamera;
    public LayerMask zombiKatman;
    KarakrerKontrol hpKontrol;
    public ParticleSystem muzzleFlash;
    Animator anim;


    void Start()
    {
        kamera = Camera.main;
        hpKontrol = this.gameObject.GetComponent<KarakrerKontrol>();
        anim = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hpKontrol.YasiyorMu() == true)
        {

            if (Input.GetMouseButton(0))
            {
                anim.SetBool("atesEt", true);
            }
            else if (Input.GetMouseButtonUp(0))
            {
                anim.SetBool("atesEt", false);
            }

        }
    }


    public void AtesEtme()
    {

        muzzleFlash.Play();

        // Crosshair'ın yeni pozisyonuna göre ışın yolla (Y değeri 0.7f = üst kısım)
        Ray ray = kamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, zombiKatman))
        {
            hit.collider.gameObject.GetComponent<Zombi>().HasarAl();
        }

    }
}
