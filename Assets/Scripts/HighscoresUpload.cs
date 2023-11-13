using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class HighscoresUpload : MonoBehaviour
{
	const string privateCode = "aPh5CNZz2UKJgmyzEL4XeArWar8J_8oUCwN4bAk_B5QQ";
	//const string publicCode = "62f262538f40bf84eca29727";
	const string webURL = "http://dreamlo.com/lb/";



	/*void Awake()
	{
		DownloadHighscores();
	}*/


    public void AddNewHighscore(string username, long score)
	{
	
		StartCoroutine(UploadNewHighscore(username, score));
	}


    IEnumerator UploadNewHighscore(string username, long score)
	{
		UnityWebRequest www = new UnityWebRequest(webURL + privateCode + "/add/" + UnityWebRequest.EscapeURL(username) + "/" + score);	
		yield return www.SendWebRequest();

		if (string.IsNullOrEmpty(www.error))
			Debug.Log("Upload Successful");
		else
		{
			Debug.Log("Error uploading: " + www.error);
		}
	}

	/*public void DownloadHighscores()
	{
		StartCoroutine("DownloadHighscoresFromDatabase");
	}*/

	/*IEnumerator DownloadHighscoresFromDatabase()
	{
		WWW www = new WWW(webURL + publicCode + "/pipe/");
		yield return www;

		if (string.IsNullOrEmpty(www.error))
			FormatHighscores(www.text);
		else
		{
			Debug.Log("Error Downloading: " + www.error);
		}
	}*/

	/*void FormatHighscores(string textStream)
	{
		string[] entries = textStream.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);


		for (int i = 0; i < entries.Length; i++)
		{
			string[] entryInfo = entries[i].Split(new char[] { '|' });
			string username = entryInfo[0];
			long score = long.Parse(entryInfo[1]);
			
			
		}
	}*/

}

