using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamante_Script : MonoBehaviour
{
    // Start is called before the first frame update
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.name =="Player")
        {
            Destroy(gameObject);
            
        }
    }
}
