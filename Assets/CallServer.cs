using System;

using System.IO;
using System.Net;
using UnityEngine;

public class CallServer : MonoBehaviour
{
    public static string ast;

    // Use this for initialization
    void Start()
    {
       // Debug.Log(requestLevelJSON(1));

    }

    // Update is called once per frame
    void Update()
    {
            
    }
    private const string URL = "https://invgame.azurewebsites.net/api";
    private const string REQ_LEVEL_DATA =
        "{{\"jsonrpc\":\"2.0\",\"method\":\"App.loadNextLvlAnonymous\",\"params\":[\"Anonymous\",[\"Anonymous\",null,\"facebook\"],{0}, false],\"id\":{1}}}";
    private static int requestCounter = 0;

    //Start request from level 1 (there are 62 levels in the server. When asked for an higher level the result will be null
    private static int requestedLevel = 1;

    //This function changes the request json string to request the level number in parameter
    private static string requestLevelJSON(int level)
    {
        return string.Format(REQ_LEVEL_DATA, level, requestCounter++);
    }

    //Function that call the server (you may want to change it to return the json string received instead to output it to the debug log
    public static string ExecuteServerCall()
    {
        try
        {
            //Creates the HTTP request
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
            request.Method = "POST"; 
            request.ContentType = "application/json";
            //Get the proper JSON string for the request (every time you call this method it will ask for the next level)
            string reqData = requestLevelJSON(requestedLevel++);
            request.ContentLength = reqData.Length;
            //This cookie simulated having logged in with facebook. If you really logged in the web browser would set the FBID to the facebook ID of the user
            CookieContainer cookies = new CookieContainer(1);
            cookies.Add(new Cookie("FBID", "Anonymous", "/api", "invgame.azurewebsites.net"));
            request.CookieContainer = cookies;
            //Write the request string to the network (basically sends the request to the server)
            StreamWriter requestWriter = new StreamWriter(request.GetRequestStream(), System.Text.Encoding.ASCII);
            requestWriter.Write(reqData);
            requestWriter.Close();

            //Read the response from the server (by simulating the Facebook login with the cooke we should not get errors
            WebResponse webResponse = request.GetResponse();
            Stream webStream = webResponse.GetResponseStream();
            StreamReader responseReader = new StreamReader(webStream);
            //Read the response body (a JSON string) to the response string. This is the string to parse for the level
            string response = responseReader.ReadToEnd();
            //Debug.Log(response);
            responseReader.Close();
            return response;
        }
        catch (Exception e)
        {
            Debug.Log("-----------------");
            Debug.Log(e.Message);
            return "";
        }
    }


    // I DONT KNOW HOW TO CALL IT 
    public static void IsTautology()
    {
        try
        {
            //Creates the HTTP request
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
            request.Method = "POST";
            request.ContentType = "application/json";
            //Get the proper JSON string for the request (every time you call this method it will ask for the next level)
            string reqData = requestLevelJSON(requestedLevel++);
            request.ContentLength = reqData.Length;
            //This cookie simulated having logged in with facebook. If you really logged in the web browser would set the FBID to the facebook ID of the user
            CookieContainer cookies = new CookieContainer(1);
            cookies.Add(new Cookie("FBID", "Anonymous", "/api", "invgame.azurewebsites.net"));
            request.CookieContainer = cookies;
            //Write the request string to the network (basically sends the request to the server)
            StreamWriter requestWriter = new StreamWriter(request.GetRequestStream(), System.Text.Encoding.ASCII);
            requestWriter.Write(reqData);
            requestWriter.Close();

            //Read the response from the server (by simulating the Facebook login with the cooke we should not get errors
            WebResponse webResponse = request.GetResponse();
            Stream webStream = webResponse.GetResponseStream();
            StreamReader responseReader = new StreamReader(webStream);
            //Read the response body (a JSON string) to the response string. This is the string to parse for the level
            string response = responseReader.ReadToEnd();
            //Debug.Log(response);
            responseReader.Close();
        }
        catch (Exception e)
        {
            Debug.Log("-----------------");
            Debug.Log(e.Message);
        }
    }
}
