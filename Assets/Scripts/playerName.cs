using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerName : MonoBehaviour {

	private Camera camera;
	public string name;
	GameObject hero;
	float npcHeight;

	void Start ()
	{
		//得到主角对象
		hero = this.gameObject;
		camera = Camera.main;
		npcHeight = 1.2f;
		this.name = PlayerPrefs.GetString("Name");

	}

	void OnGUI()
	{
		//得到NPC在3D世界中的坐
		//默NPC坐点在脚底下，所以里加上npcHeight它模型的高度即可
		Vector3 worldPosition = new Vector3 (hero.transform.position.x , hero.transform.position.y + npcHeight,hero.transform.position.z);
		//根据NPC的3D坐算成它在2D屏幕中的坐
		Vector2 position = camera.WorldToScreenPoint(worldPosition);
		//得到真NPC的2D坐
		position = new Vector2 (position.x, Screen.height - position.y);

		//算NPC名称的高
		Vector2 nameSize = GUI.skin.label.CalcSize (new GUIContent(this.name));

		GUI.color = Color.green;
		GUI.skin.label.fontSize = 20;//字体大小

		//制NPC名称
		GUI.Label(new Rect(position.x - (nameSize.x/2),position.y - nameSize.y ,nameSize.x,nameSize.y), name);

	}
}

