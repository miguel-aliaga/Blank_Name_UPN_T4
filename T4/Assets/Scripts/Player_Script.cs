using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player_Script : MonoBehaviour
{
    public GameObject Disparo;
    bool saltando = false;
    bool salto = false;
    bool muerto = false;
    bool habilidadI = false;
    bool habilidadII = false;
    bool habilidadIII = false;
    bool ult = false;
    bool atacando = false;
    public GameObject Disparo2;
    public GameObject Bapho;
    int energia = 500;
    public AudioSource cancionMuerte;
    public AudioSource xdie;
    public Text LifeText;
    public Text EnergyText;

    int vidas = 3;
  
    // Start is called before the first frame update
    void Start()
    {
        xdie.mute = true;
        EnergyText.text = energia + "";
        LifeText.text = vidas + "";
        
    }


    

    // Update is called once per frame
    void Update()
    {
        if (!muerto)
        {
            if (Input.GetKey("left"))
            {
                
                izquierda();
            }
            if (Input.GetKey("right"))
            {
                
                derecha();
            }
            if (!Input.GetKey("right") && !Input.GetKey("left") && !saltando && !atacando && !Input.GetKey("x"))
            {
                gameObject.GetComponent<Animator>().SetInteger("Estado", 0);
            }

                saltar();
            habI();
            habII();
            habIII();
            ultimate();
        }
        else
        {
            cancionMuerte = gameObject.GetComponent<AudioSource>();
            cancionMuerte.SetScheduledEndTime(Time.deltaTime);
            xdie.mute = false;
            cancionMuerte = xdie;
        }


    }

    void izquierda()
    {
        var fli = gameObject.GetComponent<SpriteRenderer>();
        fli.flipX = true;
        gameObject.transform.position = new Vector3(gameObject.transform.position.x - 0.1f, gameObject.transform.position.y, gameObject.transform.position.z);
        if (!saltando && !muerto)
        {
            gameObject.GetComponent<Animator>().SetInteger("Estado", 1);
        }

    }




    void derecha()
    {
        var fli = gameObject.GetComponent<SpriteRenderer>();
        fli.flipX = false;
        gameObject.transform.position = new Vector3(gameObject.transform.position.x + 0.1f, gameObject.transform.position.y, gameObject.transform.position.z);
        if (!saltando && !muerto)
        {
            gameObject.GetComponent<Animator>().SetInteger("Estado", 1);
        }

    }


    void saltar()
    {

        if (salto && Input.GetKeyDown("up"))
        {
            saltando = true;
            salto = false;
            var rb = gameObject.GetComponent<Rigidbody2D>();
            rb.AddForce(new Vector2(0, 400));
            if (!muerto)
            {
                gameObject.GetComponent<Animator>().SetInteger("Estado", 2);
            }
        }
        
    }





    private void OnCollisionEnter2D(Collision2D collision)
    {


        if (collision.transform.tag == "Suelo")
        {
            salto = true;
            saltando = false;
        }

        if (collision.transform.tag == "Lava")
        {
            vidas = 0;
            LifeText.text = vidas+"";
            morir();
        }

        if (collision.transform.tag == "Boss")
        {
            vidas = 0;
            LifeText.text = vidas + "";
            morir();
        }

        if (collision.transform.tag == "Enemy")
        {
            vidas = vidas - 2;
            LifeText.text = vidas + "";
            if (vidas <= 0)
            {
                morir();
            }
        }

        var fli = gameObject.GetComponent<SpriteRenderer>();


    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Diamante")
        {
            energia = 10;
            EnergyText.text = energia + "";
        }

        if (collision.transform.tag == "Life")
        {

            vidas = vidas + 1;


            LifeText.text = vidas + "";
        }
        if (collision.transform.tag == "Energy")
        {
            if (energia <= 4)
            {
                energia = energia + 1;
            }

            EnergyText.text = energia+"";
        }

        if (collision.transform.tag == "Trampa")
        {

            vidas = vidas - 1;
            LifeText.text = vidas+"";
            if (vidas == 0)
            {
                morir();
            }
        }

        if (collision.transform.tag == "Lava")
        {

            vidas = vidas - vidas;
            LifeText.text = vidas + "";
            if (vidas == 0)
            {
                morir();
            }
        }

        if (collision.transform.tag == "Puerta1")
        {
            Debug.Log("2");
            SceneManager.LoadScene("Nivel_2", LoadSceneMode.Single);
        }
        if (collision.transform.tag == "Puerta2")
        {
            Debug.Log("3");
            SceneManager.LoadScene("Nivel_3", LoadSceneMode.Single);
        }
        if (collision.transform.tag == "Puerta3")
        {
            Debug.Log("4");
            SceneManager.LoadScene("Nivel_4", LoadSceneMode.Single);
        }
        if (collision.transform.tag == "Puerta4")
        {
            Debug.Log("5");
            SceneManager.LoadScene("Nivel_5", LoadSceneMode.Single);
        }
        

    }


    void morir()
    {
        
        muerto = true;
        gameObject.GetComponent<Animator>().SetInteger("Estado", 3);
       
        
    }
    public void habI()
    {
        if (!atacando && Input.GetKey("z")&& !habilidadI)
        {

            habilidadI = true;
            atacando = true;
            EnergyText.text = energia+"";
            gameObject.GetComponent<Animator>().SetInteger("Estado", 4);
            //enfriamiento
            habilidadI = false;
            atacando = false;
        }    

    }

    public void habII()
    {
        if (!atacando && Input.GetKeyUp("x")&& !habilidadII && energia>=2)
        {


            energia = energia - 2;
            habilidadII = true;
            atacando = true;

            if (gameObject.GetComponent<SpriteRenderer>().flipX)
            {
                gameObject.GetComponent<Animator>().SetInteger("Estado", 5);
                Instantiate(Disparo2, gameObject.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            }
            else
            {
                gameObject.GetComponent<Animator>().SetInteger("Estado", 5);
                Instantiate(Disparo, gameObject.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            }

            EnergyText.text = energia + "";
            //gameObject.GetComponent<Animator>().SetInteger("Estado", 5);
            //enfriamiento
            habilidadII = false;
            atacando = false;
        }

    }



    public void habIII()
    {
        if (!atacando && Input.GetKey("c")&&!habilidadIII && energia >=3)
        {
            energia = energia - 3;
            habilidadIII = true;
            atacando = true;
            EnergyText.text = energia + "";

            gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
            //gameObject.GetComponent<Animator>().SetInteger("Estado", 5);
            //enfriamiento
            habilidadIII = false;
            atacando = false;
        }

    }


    public void ultimate()
    {
        if (!atacando && Input.GetKeyUp("s") &&!ult && energia>=8)
        {
            energia = energia - 8;
           ult= true;
            atacando = true;
            EnergyText.text = energia + "";
            Instantiate(Bapho, new Vector2(gameObject.transform.position.x - 2f, gameObject.transform.position.y), Quaternion.Euler(new Vector3(0, 0, 0)));
            //gameObject.GetComponent<Animator>().SetInteger("Estado", 5);
            //enfriamiento
            ult = false;
            atacando = false;
        }

    }





}
