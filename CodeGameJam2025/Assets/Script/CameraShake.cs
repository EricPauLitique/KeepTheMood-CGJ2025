using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public Camera camera;
    public bool Enabled = true;

    private float shakeForce;
    private GameManager gm;
    private float timeSpend;
    private float shakeDirectionChange = 0.1f;
    private Vector3 cameraDefautlPosition;

    void Start()
    {
        gm = gameObject.GetComponent<GameManager>();
        cameraDefautlPosition = camera.transform.position;
    }

    void Update()
    {
        if (!enabled) return;

        if (gm.nbEnemy >= 20)
            shakeForce = 0.7f;
        else if (gm.nbEnemy >= 15)
            shakeForce = 0.5f;
        else if (gm.nbEnemy >= 10)
            shakeForce = 0.3f;
        else if (gm.nbEnemy >= 5)
            shakeForce = 0.1f;
        else
            shakeForce = 0;

        timeSpend += Time.deltaTime;
        if(timeSpend > shakeDirectionChange)
        {
            float delta = (timeSpend - shakeDirectionChange) / shakeDirectionChange;
            Vector3 shakeDirection = new Vector3(Random.value, Random.value, 0);
            
            Vector3 destination = cameraDefautlPosition + shakeDirection * shakeForce;
            Vector3 from = camera.transform.position;
            camera.transform.transform.position = Vector3.Lerp(from, destination, Mathf.Max(delta, 1));

            if(delta >= 1)
            {
                timeSpend = 0;
            }
        }
    }
}
