using UnityEngine;

public class KameraKontrol : MonoBehaviour
{


    public Transform hedef;
    public Vector3 hedefMesafe = new Vector3(-1.5f, 2.5f, -3.8f); // Görüntüdeki gibi TPS kamera açısı
    float fareX, fareY;
    [SerializeField]
    private float fareHassasiyet;

    Vector3 objRot;
    public Transform karakterVucut;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {

    }

    void LateUpdate()
    {
        this.transform.position = Vector3.Lerp(this.transform.position, hedef.position + hedefMesafe, Time.deltaTime * 10);
        fareX += Input.GetAxis("Mouse X") * fareHassasiyet;
        fareY -= Input.GetAxis("Mouse Y") * fareHassasiyet;

        // Y ekseni için sınırlar (yukarı-aşağı)
        if (fareY >= 25)
        {
            fareY = 25;
        }
        if (fareY <= -40)
        {
            fareY = -40;
        }




        this.transform.eulerAngles = new Vector3(fareY, fareX, 0);
        hedef.transform.eulerAngles = new Vector3(0, fareX, 0);



        Vector3 gecici = this.transform.localEulerAngles;
        gecici.z = 0;
        gecici.y = this.transform.localEulerAngles.y;
        gecici.x = this.transform.localEulerAngles.x + 10;
        objRot = gecici;
        karakterVucut.transform.eulerAngles = objRot;

    }
}
