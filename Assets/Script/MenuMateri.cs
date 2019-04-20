using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UI;

public class MenuMateri : MonoBehaviour
{
    public void DetailBakteri(){
		SceneManager.LoadScene("DetailBakteri");
	}
    public void DetailJamur(){
		SceneManager.LoadScene("DetailJamur");
	}
    public void DetailProtista(){
		SceneManager.LoadScene("DetailProtista");
	}
    public void DetailVirus(){
		SceneManager.LoadScene("DetailVirus");
	}
}
