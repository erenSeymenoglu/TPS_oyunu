using UnityEngine;
using UnityEngine.UI;

public class ArayuzKontrol : MonoBehaviour
{

    public Text mermiText;
    public Text saglikText;
    public GameObject sahteMenu;

    bool OyunDurdu;
    GameObject oyuncu;

    void Start()
    {
        oyuncu = GameObject.Find("Ajan");
    }

    // Update is called once per frame
    void Update()
    {
        // Null kontrolleri - oyuncu bulunamazsa veya component'ler eksikse hata vermesin
        if (oyuncu != null)
        {
            AtesSistemi atesSistemi = oyuncu.GetComponent<AtesSistemi>();
            KarakrerKontrol karakterKontrol = oyuncu.GetComponent<KarakrerKontrol>();

            if (mermiText != null && atesSistemi != null)
            {
                mermiText.text = atesSistemi.GetSarjor().ToString() + "/" + atesSistemi.GetCephane().ToString();
            }

            if (saglikText != null && karakterKontrol != null)
            {
                saglikText.text = "Hp:" + karakterKontrol.GetSaglik();
            }
        }
        else
        {
            // Oyuncu bulunamadıysa tekrar dene
            oyuncu = GameObject.Find("Ajan");
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (OyunDurdu == true)
            {
                OyunuDevamEttir();
            }
            else if (OyunDurdu == false)
            {
                OyunuDurdu();
            }

        }
    }
    public void OyunuDevamEttir()
    {
        sahteMenu.SetActive(false);
        Time.timeScale = 1;
        OyunDurdu = false;
    }
    public void OyunuDurdu()
    {
        sahteMenu.SetActive(true);
        Time.timeScale = 0;
        OyunDurdu = true;
    }
}
