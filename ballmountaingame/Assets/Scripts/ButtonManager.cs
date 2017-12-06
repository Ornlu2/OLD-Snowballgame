using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ButtonManager : MonoBehaviour {

   public bool CreditsActive = false;
    private GameObject Platforms;
    private GameObject Player;
    private GameObject CreditsText;
    private Text CreditsButtonText;

    void Start()
    {
        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            Platforms = GameObject.Find("Mountain Platforms");
            Player = GameObject.Find("PlayerBall-Menu");
            CreditsText = GameObject.Find("Credits");
            CreditsText.SetActive(false);
            CreditsButtonText = GameObject.Find("Credits Button").GetComponentInChildren<Text>();
        }
    }

    public void MainMenu()
	{
		SceneManager.LoadScene (0);
	}
	public void Level1()
	{
		SceneManager.LoadScene (1);
	}
	public void Level2()
	{
		SceneManager.LoadScene (2);
	}
	public void Instructions()
	{
		SceneManager.LoadScene (1);
	}
	public void Quit()
	{
		Application.Quit ();
	}
    public void Credits()
    {
        if (CreditsActive == false)
        {
            Platforms.SetActive(false);
            Player.SetActive(false);
            Player.GetComponent<MenuSnowBallController>().SnowBallSize = 1.5f;
            Player.transform.position = Player.GetComponent<MenuSnowBallController>().Respawn.transform.position;
            CreditsText.SetActive(true);
            CreditsButtonText.text = "Back";

            CreditsActive = true;

        }
        else if (CreditsActive == true)
        {
            Platforms.SetActive(true);
            Player.SetActive(true);
            CreditsText.SetActive(false);
            CreditsButtonText.text = "Credits";

            CreditsActive = false;

        }


    }
}
