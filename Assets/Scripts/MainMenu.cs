using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	 [SerializeField] private SessionDataUpdater sessionDataUpdater;

	public void ToGame()
	{
		SceneManager.LoadScene("Game");
	}

	public void SelectPlayer(int index)
	{
		sessionDataUpdater.data.playerSelected = index;
	}
}
