using UnityEngine;

public class death : MonoBehaviour
{

    public GameManager gameManager;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            GetComponent<PlayerMovement>().speed = 0;
            GetComponent<Animator>().SetTrigger("deathFlute");
            GetComponent<Animator>().SetTrigger("fluteSniperMort");

            gameManager.gameFinished();
        }
    }
}

