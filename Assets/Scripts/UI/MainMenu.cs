using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	//TODO: Load player based on their Type info
	//TODO: Add PlayerTypes scriptables here
	 [SerializeField] private SessionDataUpdater sessionDataUpdater;

	public void ToGame()
	{
		SceneManager.LoadScene("Game");
	}

	public void SelectPlayer(int index)
	{
		//TODO: Change to load the types, not the index
		sessionDataUpdater.data.playerSelected = index;
	}
}
