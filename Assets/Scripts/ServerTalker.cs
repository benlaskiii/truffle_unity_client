using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;

public class ServerTalker : MonoBehaviour
{
    private string remote_url = "http://16.170.112.13:8000/";
    private string local_url = "http://localhost:8000/api/mushroom/location/";
    public double latitude = 48.15945;
    public double longitude = 11.56434;

    // Start is called before the first frame update
    
    void Start()
    {
        StartCoroutine( GetWebData(local_url) );

    }
    

    IEnumerator GetWebData( string address)
    {
        // UnityWebRequest www = UnityWebRequest.Get(address + GPS.Instance.latitude.ToString()+GPS.Instance.longitude.ToString());
        UnityWebRequest www = UnityWebRequest.Get(address + latitude.ToString()+"/"+longitude.ToString());
        yield return www.SendWebRequest();

        if(www.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("Something went wrong: " + www.error);
        }
        else
        {
            Debug.Log( www.downloadHandler.text );

            ProcessServerResponse(www.downloadHandler.text);

        }
    }

    void ProcessServerResponse( string rawResponse )
    {
       
        JSONNode node = JSON.Parse( rawResponse );
    }

    
}