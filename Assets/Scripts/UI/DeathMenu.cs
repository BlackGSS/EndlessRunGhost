using UnityEngine.UI;
using TMPro;
using Neisum.ScriptableUpdaters;

public class DeathMenu : CanvasGroupView, IScriptableUpdaterListener<SessionData>
{
	public TextMeshProUGUI scoreText;
	public Image backgroundImg;

	public void ToggleEndMenu(float score)
	{
		scoreText.text = ((int)score).ToString();
	}

	public void ScriptableResponse(SessionData data)
	{
		if (!data.playerAlive)
		{
			ShowAnimTo(1);
			//TODO: Send also the diffultLevel to show in which level player died
			ToggleEndMenu(data.currentScore);
		} 
	}
}