using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{

    private Vector2 _direction = Vector2.right;  //Y�n ad�nda bir de�i�ken atad�k. Varsay�lan y�n� sa� olarak atad�k.
    void Start()
    {
        
    }

    void Update()
    {
        // klavyeden al�nan girdiye g�re y�n�m�z� yeniden atad�k.

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
    //Her bilgisayarda kare h�z�n� e�it tutmak i�in fixed i�erisine hareket kodunuzu yaz�yoruz.
    private void FixedUpdate()
    {
        //her bir eksendeki pozisyonu y�n�m�zle toplayarak hareket sa�lad�k.
        //y�lan her zaman tam say�lar �zerindeki konumlarda hareket etsin diye Mathf.round kulland�k.
        this.transform.position = new Vector3(
            Mathf.Round(this.transform.position.x)  + _direction.x,  
            Mathf.Round(this.transform.position.y) + _direction.y,
            0.0f
        );
    }
}
