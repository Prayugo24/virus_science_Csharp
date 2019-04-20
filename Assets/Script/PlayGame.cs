using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour {

	public void MenuMateri(){
		SceneManager.LoadScene ("ScanMenuMateri");
		
	}

	public void Evaluasi(){
		SceneManager.LoadScene("ScanEvaluasi");
	}
	public void Tentang(){
		SceneManager.LoadScene("ScanTentang");
	}
	public void Panduan(){
		SceneManager.LoadScene("ScanPanduan");
	}
	public void GamePlay(){
		SceneManager.LoadScene("ScanGamePlay");
	}
	public void MenuUtama(){
		SceneManager.LoadScene("PlayGame");
	}

}
