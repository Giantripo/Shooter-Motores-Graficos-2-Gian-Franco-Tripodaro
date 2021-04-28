using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class star2 : MonoBehaviour
{
  public int  Cont =0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Cont++;
        }

            if (collision.gameObject.CompareTag("Wall"))
            {

            if (Cont ==3)
            {
                Cont = 0;
                Destroy(this.gameObject);
            }
           
            
            }
    }
}
