using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour {

	public SceneFader fader;

	public Button[] levelButtons;

	/*
	TODO look into loading the scenes async so you dont see the weird things inbetween the fade animations or how look how to fix those
	clean up audio find better sounds and jst clean up the flow from the menu to the levels etc
	make new levels and do more stuff with earls db
	eventually clean up the sphaghetti code and clean up the project structure
	 */

	void Start ()
	{
		
		//PlayerPrefs.DeleteAll();
		int levelReached = PlayerPrefs.GetInt("levelReached", 1);

		

		for (int i = 0; i < levelButtons.Length; i++)
		{
			if (i + 1 > levelReached)
				levelButtons[i].interactable = false;
		}
	}

	public void Select (string levelName)
	{
		fader.FadeTo(levelName);
	}
	

}
