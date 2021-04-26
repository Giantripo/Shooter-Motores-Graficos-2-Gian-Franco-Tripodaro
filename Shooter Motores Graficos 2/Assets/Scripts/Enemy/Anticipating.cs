public class Anticipating : Controller_Enemy
{
    private void FixedUpdate()
    {
        AnticipatingBehaviour();
    }

    private void AnticipatingBehaviour()
    {
        //si player es true, el codigo accede al controller player y setea el siguiente movimiento en la posicion del player + ultimo angulo que se movio el player * 2, para que no sea instantaneo el seguimiento
        if (player != null)
        {
            Controller_Player p = player.GetComponent<Controller_Player>();
            agent.SetDestination(player.transform.position + p.GetLastAngle() * 2);
        }
    }
}
