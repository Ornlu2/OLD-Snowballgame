using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour {


    private MountainRot enablecontrols;
    public Image Background;
    public Text DeathUITitle;
    private Image DeathUIButton1;
    private Image DeathUIButton2;

    public float fadespeed;
    public bool AvalancheActive;

    // Use this for initialization
    void Start () {
        enablecontrols = GameObject.Find("Mountain").GetComponent<MountainRot>();
        AvalancheActive = GameObject.Find("AvalancheSpawner").GetComponent<Avalanche>().Avalanchestarter;
        Background.gameObject.SetActive(false);
        DeathUIButton1 = GameObject.Find("Restart Button").GetComponent<Image>();
        DeathUIButton2 = GameObject.Find("Main Menu Button").GetComponent<Image>();
        
    }

    // Update is called once per frame
    void Update () {
	
		if (Input.GetKey(KeyCode.R))
		{
			SceneManager.LoadScene (0);
		}

	}
   public  IEnumerator PlayerDeath ()
    {
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {


            Debug.Log("GAME LOSS");
            Background.gameObject.SetActive(true);
            enablecontrols.isLeftkeyEnabled = false;
            enablecontrols.isRightkeyEnabled = false;
            enablecontrols.isAccelromInputEnabled = false;
            AvalancheActive = false;
            if (Background.gameObject.activeSelf == true)
            {
                //for(int i = 0; i<100;)
                //{
                    Background.color = new Color(1f, 1f, 1f, Mathf.Lerp(Background.color.a / 2, 100.0f, fadespeed));
                    DeathUITitle.color = new Color(1f, 1f, 1f, Mathf.Lerp(DeathUITitle.color.a / 2, 100.0f, fadespeed));
                    DeathUIButton1.color = new Color(1f, 1f, 1f, Mathf.Lerp(Background.color.a / 2, 100.0f, fadespeed));
                    DeathUIButton2.color = new Color(1f, 1f, 1f, Mathf.Lerp(Background.color.a / 2, 100.0f, fadespeed));
                    Debug.Log(DeathUITitle.color);
                //}


            }
            else
            {
                yield break;

            }
        }

    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
