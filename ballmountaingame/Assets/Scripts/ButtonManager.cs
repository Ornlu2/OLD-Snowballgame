using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ButtonManager : MonoBehaviour {

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
		SceneManager.LoadScene (3);
	}
	public void Quit()
	{
		Application.Quit ();
	}
}
