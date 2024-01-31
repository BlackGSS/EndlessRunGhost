using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	private SessionData sessionData;

	public void ToGame()
	{
		SceneManager.LoadScene("Game");
	}

	public void SelectPlayer(int index)
	{
		sessionData.playerSelected = index;
	}
}
