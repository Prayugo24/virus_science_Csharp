using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UI;
using UnityEngine.Networking;

public class DetailBakteriController : MonoBehaviour
{
        private DeskripsiResponse[] deskripsii;
    private RootObject rootObject;
    public GameObject objek1,objek2;
    public Text textDeskripsi;
    public Text textJudul;
    
    private int questionIndex;
    private int lengthDeskrip=0;
    // private RootObject RootObject;
    // Start is called before the first frame update
    void Start()
    {
     DontDestroyOnLoad (gameObject);   
     StartCoroutine(LoadGameData());
     
     
    }
    public DeskripsiResponse GetCurrentRoundData()
	{
		return deskripsii [0];
	}

    // Update is called once per frame
    IEnumerator LoadGameData()
    {
        UnityWebRequest www = UnityWebRequest.Get("http://localhost/TA/Science/API/Content/TampilDeskripsi");
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            string jsonResult = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
            RootObject loadedData = JsonUtility.FromJson<RootObject>(jsonResult);
            deskripsii = loadedData.deskripsi;
            // Debug.Log(deskripsii[0].nama_materi);
            btnNext2();
            
        }
    }
    void ShowDeskripsi()
	{
		
        // Debug.Log("testing"+lengthDeskrip);
		DeskripsiResponse textDeskripsion = deskripsii[lengthDeskrip];							// Get the QuestionData for the current question
        // Debug.Log(textDeskripsion.deskripsi);
		textDeskripsi.text = textDeskripsion.deskripsi;										// Update questionText with the correct text
        textJudul.text=textDeskripsion.nama_materi;
	}
    public void btnNext2(){
         
        if(lengthDeskrip>=deskripsii.Length){
            lengthDeskrip=0;
            ShowDeskripsi();
        }
        
        ShowDeskripsi();
        lengthDeskrip =lengthDeskrip+1;       
    }
    public void btnPrevious2(){
        lengthDeskrip=lengthDeskrip-1;
        if(lengthDeskrip<0){
            lengthDeskrip=deskripsii.Length-1;
            ShowDeskripsi();
        }
        ShowDeskripsi();
        // Debug.Log("testing"+next);
    }

    public void showObjek1(){
        objek1.SetActive(true);
        objek2.SetActive(false);
    }

    public void showObjek2(){
        objek1.SetActive(false);
        objek2.SetActive(true);
    }

}
