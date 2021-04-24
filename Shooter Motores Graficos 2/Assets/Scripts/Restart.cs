using UnityEngine;

public class Restart : MonoBehaviour
{
    public static Restart _Restart;
    public delegate void Restarting();
    public event Restarting OnRestart; //reactiva todos los scripts, entrando siempre al awake
    
    private void Awake()
    {
       
        //1 milisegundo empiza el juego, restart es null, entonces entra en el if, pero despues, pasa a ser true, sin entrar al destroy(this)
        if (_Restart == null)
        {
            _Restart = this.gameObject.GetComponent<Restart>();
        }
        //en caso de que restart sea true se destruye este game object
        else
        {
            Destroy(this);
        }
    }

    void Update()
    {  
        //hace que funcione la variable 
        GetInput();
    }

    private void GetInput()
    { //si toco la R se ejecuta onrestarting
        if (Input.GetKeyDown(KeyCode.R))
        {
            OnRestarting();
        }
        
    }
    // para el juego, activa el control player, reacarga los eventos y vuelve a ponerle play al juego
    public void OnRestarting()
    {
        Time.timeScale = 0;
        Controller_Player._Player.gameObject.SetActive(true);
        OnRestart();
        Time.timeScale = 1;
    }
}
