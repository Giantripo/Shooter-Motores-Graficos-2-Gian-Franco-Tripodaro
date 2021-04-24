using UnityEngine;

public class Projectile : MonoBehaviour
{
    //limites de distancia que recorre el proyectil para que se destruya
    public float xLimit = 30;
    public float yLimit = 20;

    private void Start()
    {
        Restart._Restart.OnRestart += Reset;
    }
    //cuando se recetea el juego se destruyen todas las balas
    private void Reset()
    {
        Destroy(this.gameObject);
    }

    virtual public void Update()
    {
        //activa el check limits
        CheckLimits();
    }

    internal virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("PowerUp"))
        {
            Destroy(this.gameObject);
        }
    }
    //se encarga de que los proyectiles se destruyan si superan los limites de distancia establecidos
    internal virtual void CheckLimits()
    {
        if (this.transform.position.x > xLimit)
        {
            Destroy(this.gameObject);
        }
        if (this.transform.position.x < -xLimit)
        {
            Destroy(this.gameObject);
        }
        if (this.transform.position.z > yLimit)
        {
            Destroy(this.gameObject);
        }
        if (this.transform.position.z < -yLimit)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnDisable()
    {
        Restart._Restart.OnRestart -= Reset;
    }
}
