using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Highscores : MonoBehaviour
{
	//const string privateCode = "aPh5CNZz2UKJgmyzEL4XeArWar8J_8oUCwN4bAk_B5QQw";
	const string publicCode = "62f262538f40bf84eca29727";
	const string webURL = "http://dreamlo.com/lb/";

	DisplayHightScore highscoreDisplay;
	public Highscore[] highscoresList;
	static Highscores instance;
	void Awake()
	{
		highscoreDisplay = GetComponent<DisplayHightScore>();
		instance = this;
	}

	/*public static void AddNewHighscore(string username, int score)
	{
		instance.StartCoroutine(instance.UploadNewHighscore(username, score));
	}

	IEnumerator UploadNewHighscore(string username, int score)
	{
		WWW www = new WWW(webURL + privateCode + "/add/" + WWW.EscapeURL(username) + "/" + score);
		yield return www;

		if (string.IsNullOrEmpty(www.error))
		{
			print("Upload Successful");
			DownloadHighscores();
		}
		else
		{
			print("Error uploading: " + www.error);
		}
	}*/

	public void DownloadHighscores()
	{
		StartCoroutine("DownloadHighscoresFromDatabase");
	}

	IEnumerator DownloadHighscoresFromDatabase()
	{
		UnityWebRequest www = UnityWebRequest.Get(webURL + publicCode + "/pipe/");
		yield return www.SendWebRequest();

		if (string.IsNullOrEmpty(www.error))
		{
			FormatHighscores(www.downloadHandler.text);
			highscoreDisplay.OnHighscoresDownloaded(highscoresList);
		}
		else
		{
			Debug.Log("Error Downloading: " + www.error);
		}
	}

	void FormatHighscores(string textStream)
	{
		string[] entries = textStream.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
		highscoresList = new Highscore[entries.Length];

		for (int i = 0; i < entries.Length; i++)
		{
			string[] entryInfo = entries[i].Split(new char[] { '|' });
			string username = entryInfo[0];
			int score = int.Parse(entryInfo[1]);
			highscoresList[i] = new Highscore(username, score);
		}
	}

}

public struct Highscore
{
	public string username;
	public int score;

	public Highscore(string _username, int _score)
	{
		username = _username;
		score = _score;
	}

}