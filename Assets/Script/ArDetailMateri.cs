using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArDetailMateri : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bacteriofag;
    private int lengthDeskrip=0;
    public void btnShowDetailBakteriofag(){
        
        lengthDeskrip =lengthDeskrip+1;
        if(lengthDeskrip>1){
            lengthDeskrip=0;
        }
        if(lengthDeskrip==1){
            bacteriofag.SetActive(true);
        }       
        if (lengthDeskrip==0)
        {    bacteriofag.SetActive(false);
            
        }
    }
    
}
