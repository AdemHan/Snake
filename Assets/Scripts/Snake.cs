using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{

    private Vector2 _direction = Vector2.right;  //Yon adinda bir degisken atadik. Varsayilan yonu sag olarak atadik.
    private List<Transform> _segments = new List<Transform>();   // Segments adinda nesnenin transformunu tutan bir degisken olusturduk.
    public Transform segmentPrefab;      // Referans alabileceði bir Transform türünde deðiþken oluþtuduk.
    public int initialSize = 4;    // yilanin boyu ayarlabilir oldu

    void Start()
    {
        ResetState();
       // _segments = new List<Transform>();  //segments adinda yeni bir liste olusturduk.
       // _segments.Add(this.transform);      //Bu nesnenin transformunu segments listesine ekledik.
    }

    void Update()
    {
        // klavyeden alinan girdiye gore yönümüzü yeniden atadýk.

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))     
        {
            _direction = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            _direction = Vector2.down;
        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _direction = Vector2.left;
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            _direction = Vector2.right;
        }
    }
    //Her bilgisayarda kare hýzýný eþit tutmak için fixed içerisine hareket kodunuzu yazýyoruz.
    private void FixedUpdate()
    {
        //Burada segment dizisindeki her bir nesnenin konumunu bir önündekinin konumuna eþitledik
        for (int i = _segments.Count - 1; i > 0; i--)   
        {
            _segments[i].position = _segments[i - 1].position;  
        }

        //her bir eksendeki pozisyonu yönümüzle toplayarak hareket saðladýk.
        //yýlan her zaman tam sayýlar üzerindeki konumlarda hareket etsin diye Mathf.round kullandýk.
        this.transform.position = new Vector3(
            Mathf.Round(this.transform.position.x)  + _direction.x,  
            Mathf.Round(this.transform.position.y) + _direction.y,
            0.0f
        );
    }

    //Buyume fonksiyonu buraya yazilacak
    private void Grow()
    {
        // Segment adinda bir bir degisken olusturduk ve bu degiskene yeni bir prefab olusturduk
        Transform segment = Instantiate(this.segmentPrefab);
        segment.position = _segments[_segments.Count - 1].position;  // pozisyonunu segments dizisindeki son elemanin konumuna esitledik

        _segments.Add(segment);  //Segments dizisine segment objesini de ekledik
    }

    // Her seyi sifirlamayi yapiyoruz
    private void ResetState()
    {
        for (int i = 1; i < _segments.Count; i++)
        {
            Destroy(_segments[i].gameObject); // burada segments dizisinin 1. elemani ve sonrasindeki tüm elemanlari yok ettik. 0 da player oldugundan ona dokunmadik.
        }

        _segments.Clear();  // diziyi temizledik
        _segments.Add(this.transform); // diziye playeri ekledik

        for (int i = 1; i < initialSize; i++)  // belirledigimiz uzunluga erisene kadar dongu calisir
        {
            _segments.Add(Instantiate(this.segmentPrefab));  //segmentprefab objesi diziye eklenir 
        }

        this.transform.position = Vector3.zero;    //Pozisyonu sifirladik

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Food")
        {
            Grow();  // temas ettigin nesne food ise büyü
        }
        else if (other.tag == "Obstacle")
        {
            ResetState();  // temas ettigin nesnenin tagi sinirlar ise sifirla
        }
    }


}
