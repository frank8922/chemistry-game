using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplicationSet : MonoBehaviour {

	/*
	This is where fields for various levels are stored
	 */
	void Awake () {
		Application.targetFrameRate = 60;
		Scene activeScene = SceneManager.GetActiveScene();
		if(activeScene.buildIndex == 1){
				DraggingObjects.gravity = -1.5f;
				DraggingObjects.maxSpeed = 3.0f;
			}else if(activeScene.buildIndex == 2){
				DraggingObjects.gravity = -2.5f;
				DraggingObjects.maxSpeed = 4.0f;
			}else if(activeScene.buildIndex == 3){
				DraggingObjects.gravity = -3.5f;
				DraggingObjects.maxSpeed = 6.0f;
			}else{
				DraggingObjects.gravity = -1.0f;
				DraggingObjects.maxSpeed = 1.5f;
			}

		Vector2 aspectRatio = AspectRatio.GetAspectRatio(Screen.width, Screen.height);
		if(aspectRatio.x == 16 && aspectRatio.y == 9){
			Debug.Log("The aspect ratio is 16:9");
			Spawner.spawnDomain = 6;
		}else if(aspectRatio.x == 18 && aspectRatio.y == 9){
			Debug.Log("The aspect ratio is 18:9");
			Spawner.spawnDomain = 7;
		}else if(aspectRatio.x == 4 && aspectRatio.y == 3){
			Debug.Log("The aspect ratio is 4:3");
			Spawner.spawnDomain = 4;
		}else if(aspectRatio.x == 3 && aspectRatio.y == 2){
			Debug.Log("The aspect ratio is 3:2");
			Spawner.spawnDomain = 5;
		}else if(aspectRatio.x == 16 && aspectRatio.y == 10){
			Debug.Log("The aspect ratio is 16:10");
			Spawner.spawnDomain = 5;
		}else{
			Debug.Log("The aspect ratio is undefined");
			Spawner.spawnDomain = 4;
		}
	}

	public class AspectRatio{
	public static Vector2 GetAspectRatio(int x, int y){
		float f = (float)x / (float)y;
		int i = 0;
		while(true){
			i++;
			if(System.Math.Round(f * i, 2) == Mathf.RoundToInt(f * i))
				break;
		}
		return new Vector2((float)System.Math.Round(f * i, 2), i);
	}
	public static Vector2 GetAspectRatio(Vector2 xy){
		float f = xy.x / xy.y;
		int i = 0;
		while(true){
			i++;
			if(System.Math.Round(f * i, 2) == Mathf.RoundToInt(f * i))
				break;
		}
		return new Vector2((float)System.Math.Round(f * i, 2), i);
	}
	public static Vector2 GetAspectRatio(int x, int y, bool debug){
		float f = (float)x / (float)y;
		int i = 0;
		while(true){
			i++;
			if(System.Math.Round(f * i, 2) == Mathf.RoundToInt(f * i))
				break;
		}
		if(debug)
			Debug.Log("Aspect ratio is "+ f * i +":"+ i +" (Resolution: "+ x +"x"+ y +")");
		return new Vector2((float)System.Math.Round(f * i, 2), i);
	}	
	public static Vector2 GetAspectRatio(Vector2 xy, bool debug){
		float f = xy.x / xy.y;
		int i = 0;
		while(true){
			i++;
			if(System.Math.Round(f * i, 2) == Mathf.RoundToInt(f*i))
				break;
		}
		if(debug)
			Debug.Log("Aspect ratio is "+ f * i+":"+ i +" (Resolution: "+ xy.x +"x"+ xy.y +")");
		return new Vector2((float)System.Math.Round(f * i, 2), i);
	}
}
	

}
