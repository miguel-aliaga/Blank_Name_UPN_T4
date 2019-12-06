using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Final : MonoBehaviour
{
    // Start is called before the first frame update
    public float velocidad = 0.2f;
    public GameObject puerta_02;
    public int vidas = 6;
    public bool muerto = false;
    public Text text;
    public GameObject obj;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {






        if (vidas >= 1)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x + velocidad, gameObject.transform.position.y, gameObject.transform.position.z);

        }
        else
        {
            text.text = "MORS AETQUAT.";
            Vector3 v = new Vector3(11.53f, -0.33f, -0.078125f);
            
            Destroy(gameObject);
            muerte();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "derecha")
        {
            var fli = gameObject.GetComponent<SpriteRenderer>();
            fli.flipX = false;
            velocidad = velocidad * -1;
            Debug.Log(velocidad);
        }
        if (collision.transform.tag == "izquierda")
        {
            var fli = gameObject.GetComponent<SpriteRenderer>();
            fli.flipX = true;
            velocidad = velocidad * -1;
            Debug.Log(velocidad);
        }
        if (collision.transform.name == "Player")
        {
            velocidad = 0;
            text.text = "GAME OVER";
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Disparo")
        {
            vidas = vidas - 1;
            Debug.Log(vidas);

        }

    }



    void muerte()
    {

        
       


    }
}
