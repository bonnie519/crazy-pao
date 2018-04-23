using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using System;
using System.Text;
public class Credit : MonoBehaviour {
	//public Score score;
	public Text scoreText;
	public Text title;
	public int currScore;
	public Text tops;
	void Start() {
		scoreText.text += PlayerPrefs.GetInt ("CUR").ToString();
		currScore = PlayerPrefs.GetInt ("CUR");
        //Debug.Log (FindObjectOfType<GameManager>().getScore());
		saveResult(currScore);
        loadRanking();
	}
	public void Quit() {
		Debug.Log ("QUIT");
		Application.Quit ();
	}
	public void Restart() {
		PlayerPrefs.SetInt ("CUR", 0);
		SceneManager.LoadScene (0);
		PlayerPrefs.SetInt ("LIFE", 3);
	}

	public static int[] findArry(int[] ar,int k)
	{
		//int len = k > ar.Length ? ar.Length : k;
		int[] res = new int[k];
		/*if (k > ar.Length)
		{
			res = null;
			Console.WriteLine("你给定的数组与你要查找的数不匹配");
		}*/

			int length = ar.Length;
			for (int i = 0; i < k;i++ )        //K次冒泡，每次冒泡后取出最大的数
			{                  
				for (int j = 0; j < length-1; j++)
				{
					if (ar[j] > ar[j+1])
					{
						int temp = ar[j];
						ar[j] = ar[j+1];
						ar[j + 1] = temp;
					}
				}
				res[k-1-i] = ar[length-1];
				length--;

			}


		return res;
	}

	private void saveResult(int grade) {
		PlayerPrefs.SetString ("Record", PlayerPrefs.GetString ("Record") + grade.ToString () + "#");
		/*string path = Application.dataPath + "//result.txt";
		DirectoryInfo myDirectortInfo = new DirectoryInfo(path);
		if (myDirectortInfo.Exists)
		{
			Debug.Log("the file has already existed");
		}
		else {
			Debug.Log("Successfully create the file!");
		}
		File.AppendAllText(path, "" + grade + "#",Encoding.Default);*/
	}
    private void loadRanking() {
        /*string path = Application.dataPath + "/result.txt";
        StreamReader str = new StreamReader(path);
        string result = str.ReadToEnd();*/
		String result = PlayerPrefs.GetString ("Record");
		string[] dataStr = result.Split('#');
        int[] dataInt = new int[dataStr.Length-1];
        for (int i = 0; i < dataStr.Length-1; i++) {
            dataInt[i] = int.Parse(dataStr[i]);
        }
	
        /*Array.Sort(dataInt);
        Array.Reverse(dataInt);
        for (int i = 0; i < dataInt.Length; i++) {
            Debug.Log(dataInt[i]);
        }*/
		
        int length = (dataInt.Length > 5) ? 5 : dataInt.Length;

		int[] top5 = findArry (dataInt, length);

		if (top5 != null && currScore >= top5[0]) {
			title.text = "YAY! YOU MADE THE TOP 5!";
		}
		else {
			title.text = "YOU CAN DO BETTER.";
		}
		//scoreText.text += "\n\n" + "Top 5 Scores";
		if (top5 == null) return;
		//Debug.Log ("xxx");
		for (int i = 0; i < length; i++) {
			Debug.Log(top5[i]);
		}
		for (int i = length - 1; i >= 0; i--) {
			tops.text += (length - i).ToString() + ".     "+ top5[i]+"\n";
			//Debug.Log(dataInt[i]);
		}
    }
}
