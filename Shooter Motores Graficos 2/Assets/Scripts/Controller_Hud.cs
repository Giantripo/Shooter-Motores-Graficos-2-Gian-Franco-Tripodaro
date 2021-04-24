using UnityEngine;
using UnityEngine.UI;

public class Controller_Hud : MonoBehaviour
{
    public static bool gameOver;
    public static int points;
    private Ammo ammo;
    public Text gameOverText;
    public Text pointsText;
    public Text powerUpText;

    void Start()
    {
        //comienza y reset al ser positivo el juego funciona, y cuando se toque la R va a seguir siendo positivo, por lo tanto, cuando pierdas y le des a restart va a funcionar, y game over como el puntaje no se actualizaria porque no arranca al estar en el awake el restart decide cuando empezar antes que todos los scripts y queda el msj, aunque como esta true si se ejecuta bien y se borra todo
        Restart._Restart.OnRestart += Reset;
        //hace a gameover false en el start para que pueda re empezar el juego y abajo saca el new text
        gameOver = false;
        gameOverText.gameObject.SetActive(false);
        points = 0;
    }

    private void Reset()
    {
        //si este game over false no estaria no entraria al if de update y el juego no comenzaria cuando se pulsa la R despues del restart porque no entra
        gameOver = false;
        gameOverText.gameObject.SetActive(false);
        points = 0;
    }

    void Update()
    {
        //si gameOver es true el juego se pausa, se instancia un texto que dice game over y se activa.
        if (gameOver)
        {
            Time.timeScale = 0;
            gameOverText.text = "Game Over";
            gameOverText.gameObject.SetActive(true);
        }
        //segun que ammo tenga el personaje el case cambia para ejecutar un texto para decir el arma que agarro y su municion. 
        switch (Controller_Shooting.ammo)
        {
            case Ammo.Normal:
                powerUpText.text = "Gun: Normal - Ammo:∞";
                break;
            case Ammo.Shotgun:
                powerUpText.text = "Gun: Shotgun - Ammo:" + Controller_Shooting.ammunition.ToString();
                break;
            case Ammo.Cannon:
                powerUpText.text = "Gun: Cannon - Ammo:" + Controller_Shooting.ammunition.ToString();
                break;
            case Ammo.Bumeran:
                powerUpText.text = "Gun: Bumeran - Ammo:" + Controller_Shooting.ammunition.ToString();
                break;
        }
        //muestra en pantalla el puntaje
        pointsText.text = "Score: " + points.ToString();
    }

    private void OnDisable()
    {
        Restart._Restart.OnRestart -= Reset;
    }
}
