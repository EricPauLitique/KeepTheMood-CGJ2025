using UnityEngine;

public class SelectNewWeapon : MonoBehaviour
{
    public GameObject targetWeapon;
    public GameManager gm;
    public KeyCode keycode;
    public GameObject keyHelp;

    private int nbScoreToUnlock = 1000;

    void Update()
    {
        
        if (gm.score < nbScoreToUnlock || gm.hasChangeWeapon)
        {
            hideGui();
        }
        else
        {
            showGui();
            if(Input.GetKeyDown(keycode)) {
                gm.hasChangeWeapon = true;
                changeCharacter();
            }
        }
    }

    void hideGui()
    {
        gameObject.GetComponent<CanvasRenderer>().SetAlpha(0f);
        keyHelp.GetComponent<CanvasRenderer>().SetAlpha(0f);
    }

    void showGui()
    {
        gameObject.GetComponent<CanvasRenderer>().SetAlpha(1f);
        keyHelp.GetComponent<CanvasRenderer>().SetAlpha(1f);
    }

    void changeCharacter()
    {
        GameObject player = GameObject.FindWithTag("Player");
        Camera cam = player.GetComponent<ImportShoot>().camera;

        GameObject newPlayer = Instantiate(targetWeapon);
        newPlayer.transform.position = player.transform.position;
        ImportShoot im = newPlayer.GetComponent<ImportShoot>();

        death d = newPlayer.GetComponent<death>();
        d.gameManager = gm;

        im.camera = cam;

        if(im.camera != null)
        {
            im.camera = cam;
        }

        if (d.gameObject != null)
        {
            d.gameManager = gm;
        }

        Destroy(player);
    }
}
