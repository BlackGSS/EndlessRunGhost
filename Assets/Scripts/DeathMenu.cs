using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using Neisum.ScriptableEvents;

public class DeathMenu : CanvasGroupView, IScriptableEventListener<SessionData>
{
	public TextMeshProUGUI scoreText;
	public Image backgroundImg;

	public void ToggleEndMenu(float score)
	{
		scoreText.text = ((int)score).ToString();
	}

	public void Restart()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void ReturnMenu()
	{
		SceneManager.LoadScene("Menu");
	}

	public void ScriptableResponse(SessionData data)
	{
		if (!data.playerAlive)
		{
			ShowAnimTo(1);
			ToggleEndMenu(data.score);
		} 
	}
}
