
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Ennemy : MonoBehaviour
{

    public float speed;
    private Vector2 movementDirection;
    Rigidbody2D rb;
    


    public ScoreManager scoreManager;

    private AudioSource audioSource;

    public AudioClip[] audioClips;

    public int health;
    public int scoreValue;
    


    // Start is called before the first frame update
    void Start()
    {
           
        
        rb = GetComponent<Rigidbody2D>();

        audioSource = gameObject.AddComponent<AudioSource>();
        


        PlayRandomSound();
        // Donner une direction aléatoire lors de l'apparition
        SetRandomDirection();
        rb.freezeRotation = true;
    }


    // Update is called once per frame
    void Update()
    {
        rb.velocity = movementDirection * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        string tag = collision.gameObject.tag;
        if (tag.Equals("Wall"))
        {
            // Choisir une nouvelle direction aléatoire après avoir touché un mur
            SetRandomDirection();
        }

        if (tag.Equals("Ammo"))
        {
            // Détruire Ennemy
            health--;
            if (health == 0)
            {
                scoreManager.addScore(scoreValue);
                Destroy(gameObject.GetComponent<Collider2D>());

                GetComponent<Animator>().SetTrigger("onDead");
                
                //wait(1.15f);

                //
            } else
            {
                StartCoroutine(HideAndShowObject());
            }
            
        }

        if (tag.Equals("AmmoSniper"))
        {
            health--;
            health--;
            if (health <= 0)
            {
                scoreManager.addScore(scoreValue);
                Destroy(gameObject.GetComponent<Collider2D>());

                GetComponent<Animator>().SetTrigger("onDead");

                //wait(1.15f);

                //
            }
            else
            {
                StartCoroutine(HideAndShowObject());
            }
        }

        if (tag.Equals("Enemy"))
        {
            SetRandomDirection();
        }
    }

    public void PlayRandomSound()
    {
        if (audioClips.Length > 0)
        {
            int randomIndex = Random.Range(0, audioClips.Length); // Choisir un son aléatoire
            
            audioSource.clip = audioClips[randomIndex];            // Assigner le clip à l'AudioSource
            audioSource.Play();                                    // Jouer le son
        }
    }

    void destroyEnemy()
    {
        Destroy(transform.gameObject);
    }
    private IEnumerator HideAndShowObject()
    {
        GetComponent<Renderer>().enabled = false;

        // Attendre un certain temps
        yield return new WaitForSeconds(0.2f);

        // Réactiver le Renderer pour afficher l'objet à nouveau
        GetComponent<Renderer>().enabled = true;

        yield return new WaitForSeconds(0.2f);

        GetComponent<Renderer>().enabled = false;

        // Attendre un certain temps
        yield return new WaitForSeconds(0.2f);

        // Réactiver le Renderer pour afficher l'objet à nouveau
        GetComponent<Renderer>().enabled = true;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        string tag = collision.gameObject.tag;
        if (tag.Equals("Wall"))
        {
            // Choisir une nouvelle direction aléatoire après avoir touché un mur
            SetRandomDirection();
        }
    }

    private void SetRandomDirection()
    {
        float randomAngle = Random.Range(0f, 360f);
        movementDirection = new Vector2(Mathf.Cos(randomAngle), Mathf.Sin(randomAngle)).normalized;
        transform.rotation = Quaternion.Euler(0, 0, randomAngle);
    }

    private IEnumerator delay(float delay)
    {
        yield return new WaitForSeconds(delay);
    }


}
