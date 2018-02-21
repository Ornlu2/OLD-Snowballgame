using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour {

    public bool IsGamePaused;

    private MountainRot enablecontrols;
    public Image DeathBackground;
    public Image WonBackground;

    public Text DeathUITitle;
    private Image DeathUIButton1;
    private Image DeathUIButton2;
    public Text WonUITitle;
    public Text WonUIScore;
    private Image WonUIButton1;
    private Image WonUIButton2;

    public GameObject PauseMenu;
    public List<GameObject> Clouds;
    public float fadespeed;
    private Avalanche AvalancheActive;
    public float PlayerScore;
    public GameObject Ground;

    // Use this for initialization
    void Start () {
        enablecontrols = GameObject.Find("Mountain").GetComponent<MountainRot>();
        AvalancheActive = GameObject.Find("AvalancheSpawner").GetComponent<Avalanche>();
        DeathUIButton1 = GameObject.Find("Death UI Restart Button").GetComponent<Image>();
        DeathUIButton2 = GameObject.Find("Death UI Main Menu Button").GetComponent<Image>();

        WonUIButton1 = GameObject.Find("Won UI Restart Button").GetComponent<Image>();
        WonUIButton2 = GameObject.Find("Won UI Main Menu Button").GetComponent<Image>();
        WonUIScore = GameObject.Find("Won UI Score").GetComponent<Text>();

        DeathBackground.gameObject.SetActive(false);
        WonBackground.gameObject.SetActive(false);
        PauseMenu.SetActive(false);

        Clouds = new List<GameObject>();

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
            DeathBackground.gameObject.SetActive(true);
            enablecontrols.isLeftkeyEnabled = false;
            enablecontrols.isRightkeyEnabled = false;
            enablecontrols.isAccelromInputEnabled = false;
            AvalancheActive.StopBlinking();
            AvalancheActive.AvalancheCanActivate = false;
            Ground.gameObject.SetActive(false);
            Camera.main.GetComponent<CameraLook>().enabled = false;

            if (DeathBackground.gameObject.activeSelf == true)
            {
                DeathBackground.color = new Color(1f, 1f, 1f, Mathf.Lerp(DeathBackground.color.a / 2, 100.0f, fadespeed));
                DeathUITitle.color = new Color(1f, 1f, 1f, Mathf.Lerp(DeathUITitle.color.a / 2, 100.0f, fadespeed));
                DeathUIButton1.color = new Color(1f, 1f, 1f, Mathf.Lerp(DeathUIButton1.color.a / 2, 100.0f, fadespeed));
                DeathUIButton2.color = new Color(1f, 1f, 1f, Mathf.Lerp(DeathUIButton2.color.a / 2, 100.0f, fadespeed));
            }
            else
            {
                yield break;

            }
        }

    }
    public IEnumerator StopSnowing()
    {
        PlayerScore = Mathf.Round( PlayerScore * 100);
        Debug.Log("Changed Score");

        foreach (GameObject Clouds in Clouds)
        {
            Clouds.GetComponent<SnowParticles>().StopSnowing = true;
            Debug.Log("Stopped Snowing");

        }
        yield break;

    }

    public IEnumerator PlayerWin()
    {
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            yield return new WaitForSecondsRealtime(5);

            Debug.Log("Player WON");
            WonBackground.gameObject.SetActive(true);
            enablecontrols.isLeftkeyEnabled = false;
            enablecontrols.isRightkeyEnabled = false;
            enablecontrols.isAccelromInputEnabled = false;
            AvalancheActive.AvalancheCanActivate = false;
            AvalancheActive.StopBlinking();


            WonUIScore.text = "Score: " + PlayerScore.ToString();


            if (WonBackground.gameObject.activeSelf == true)
            {

                WonBackground.color = new Color(1f, 1f, 1f, Mathf.Lerp(WonBackground.color.a / 2, 100.0f, fadespeed* Time.deltaTime));
                WonUITitle.color = new Color(1f, 1f, 1f, Mathf.Lerp(WonUITitle.color.a / 2, 100.0f, fadespeed * Time.deltaTime));
                WonUIButton1.color = new Color(1f, 1f, 1f, Mathf.Lerp(WonUIButton1.color.a / 2, 100.0f, fadespeed * Time.deltaTime));
                WonUIButton2.color = new Color(1f, 1f, 1f, Mathf.Lerp(WonUIButton2.color.a / 2, 100.0f, fadespeed * Time.deltaTime));
                WonUIScore.color = new Color(1f, 1f, 1f, Mathf.Lerp(WonUIScore.color.a / 2, 100.0f, fadespeed * Time.deltaTime));

            }
            else
            {
                yield break;

            }
        }

    }
    public void PauseGame()
    {
        Time.timeScale = 0f;
        IsGamePaused = true;

        Debug.LogWarning("Game Paused");
    }
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        IsGamePaused = false;
        Debug.LogWarning("Game Resumed");
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
