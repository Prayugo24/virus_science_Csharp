using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.Networking;


public class DataController : MonoBehaviour
{
   private RoundData[] allRoundData;
	private PlayersProgres playersProgres;
    void Start ()  
	{
		DontDestroyOnLoad (gameObject);
		StartCoroutine(LoadGameData());
		LoadPlayerProgres();
	}
    public void GetSceneEvaluasi(){
        
        SceneManager.LoadScene("ScanEvaluasi");
    }
	
	public RoundData GetCurrentRoundData()
	{
		return allRoundData [0];
	}

	public void SubmitNewPlayerScore(int newScore){
		if(newScore > playersProgres.hightScore){
			playersProgres.hightScore=newScore;
			SavePlayersProgres();
		}
	}

	public int GetHightPlayerScore(){
		return playersProgres.hightScore;
	}
  

	private void LoadPlayerProgres(){
		playersProgres= new PlayersProgres();

		if(PlayerPrefs.HasKey("hightScore")){
			playersProgres.hightScore=PlayerPrefs.GetInt("hightScore");
		}
	}
	private void SavePlayersProgres(){
		PlayerPrefs.SetInt("hightScore",playersProgres.hightScore);
	}

	
	IEnumerator LoadGameData()
    {
        UnityWebRequest www = UnityWebRequest.Get("http://localhost/TA/Science/API/Content/TampilSoal");
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            string jsonResult = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
            GameData loadedData = JsonUtility.FromJson<GameData>(jsonResult);
            allRoundData = loadedData.allRoundData;
            Debug.Log(allRoundData[0]);
        }
    }
}
