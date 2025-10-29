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
        mermiText.text = oyuncu.GetComponent<AtesSistemi>().GetSarjor().ToString() + "/" + oyuncu.GetComponent<AtesSistemi>().GetCephane().ToString();

        saglikText.text = "Hp:" + oyuncu.GetComponent<KarakrerKontrol>().GetSaglik();
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
