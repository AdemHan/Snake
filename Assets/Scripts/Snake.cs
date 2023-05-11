using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{

    private Vector2 _direction = Vector2.right;  //Yön adýnda bir deðiþken atadýk. Varsayýlan yönü sað olarak atadýk.
    void Start()
    {
        
    }

    void Update()
    {
        // klavyeden alýnan girdiye göre yönümüzü yeniden atadýk.

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
        //her bir eksendeki pozisyonu yönümüzle toplayarak hareket saðladýk.
        //yýlan her zaman tam sayýlar üzerindeki konumlarda hareket etsin diye Mathf.round kullandýk.
        this.transform.position = new Vector3(
            Mathf.Round(this.transform.position.x)  + _direction.x,  
            Mathf.Round(this.transform.position.y) + _direction.y,
            0.0f
        );
    }
}
