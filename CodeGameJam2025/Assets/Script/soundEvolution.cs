using UnityEngine;

public class soundEvolution: MonoBehaviour
{
    // Start is called before the first frame update
    public float pitchValue;
    public GameManager g;

    private AudioSource audioSource;

    private void Awake()
    {
        pitchValue = 1.0f;
        audioSource = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        
        if (g.nbEnemy >= 5)
        {
            audioSource.pitch = 1.2f;
        }
        if (g.nbEnemy >= 10)
        {
            audioSource.pitch = 1.5f;
        }
        if (g.nbEnemy >= 15)
        {
            audioSource.pitch = 1.7f;
        }
        if (g.nbEnemy >= 20)
        {
            audioSource.pitch = 2f;
        }

        /**
        pitchValue = (float)g.nbEnemy/5f;
        
        if (pitchValue <= 1)
        {
            audioSource.pitch = 1;
        }
        else if (pitchValue < high)
        {
            audioSource.pitch = pitchValue;
        }
         */
    }
}
