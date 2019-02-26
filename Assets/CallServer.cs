using System;
using System.IO;
using System.Net;
using UnityEngine;
using Jint.Parser.Ast;
using System.Collections;
using System.Collections.Generic;
public class CallServer : MonoBehaviour
{
    
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
    private const string REQ_TAUTOLOGY_DATA =
        "{{\"jsonrpc\":\"2.0\",\"method\":\"App.isTautology\",\"params\":[{0},{1},[\"Anonymous\",null,\"facebook\"]],\"id\":{2}}}";
    private static int requestCounter = 0;
    //Start request from level 1 (there are 62 levels in the server. When asked for an higher level the result will be null
    private static int requestedLevel = 1;
    //This function changes the request json string to request the level number in parameter
    private static string requestLevelJSON(int level)
    {
        return string.Format(REQ_LEVEL_DATA, level, requestCounter++);
    }
    private static string requestTautologyJSON(string insertJSON, string variablesJSON)
    {
        return string.Format(REQ_TAUTOLOGY_DATA, insertJSON, variablesJSON, requestCounter++);
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

    /*
     * should look like : {"jsonrpc":"2.0","method":"App.isTautology","params":[{"type":"Program","body":[{"type":"ExpressionStatement","expression":{"type":"BinaryExpression","operator":"==","left":{"type":"Literal","value":1,"raw":"1"},"right":{"type":"Literal","value":1,"raw":"1"}}}],"sourceType":"script"},{"n":"int","x":"int","y":"int"},["2211846132386603",null,"facebook"]],"id":8}
     */
    //Function that call the server (you may want to change it to return the json string received instead to output it to the debug log
    public static string CallServerOnTautology(string responseJSON, string variableJSON)
    {
        try
        {
            //Creates the HTTP request
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
            request.Method = "POST";
            request.ContentType = "application/json";
            //Get the proper JSON string for the request (every time you call this method it will ask for the next level)
            string reqData = requestTautologyJSON(responseJSON, variableJSON);
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

    public static string Sim(String exp, string variableJSON)
    {
        try
        {
            //Creates the HTTP request
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
            request.Method = "POST";
            request.ContentType = "application/json";
            string formatter = "{{\"jsonrpc\":\"2.0\",\"method\":\"App.simplifyInv\",\"params\":[{0},{1},[\"Anonymous\",null,\"facebook\"]],\"id\":{2}}}";
            string InvVal = variableJSON;
            string buffer = ExpToJS(exp);
            string reqData = string.Format(formatter, buffer, InvVal, requestCounter++);
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
    public static string ExpToJS(String exp)
    {
        string buffer = "";
        var parser = new Jint.Parser.JavaScriptParser();
        var program = parser.Parse(exp, new Jint.Parser.ParserOptions { Tokens = true });
        foreach (var ex in program.Body)
        {
            var expr = ex as ExpressionStatement;
            if (expr.Expression is BinaryExpression)
            {
                buffer = visitBinary(expr.Expression as BinaryExpression);
            }
            else if (expr.Expression is LogicalExpression)
            {
                buffer = visitLogical(expr.Expression as LogicalExpression);
            }
            else if (expr.Expression is UnaryExpression)
            {
                buffer = visitUnary(expr.Expression as UnaryExpression);
            }
            else if (expr.Expression is Literal)
            {
                buffer = visitLiteral(expr.Expression as Literal);
            }
            else if (expr.Expression is Identifier)
            {
                buffer = visitIdentifier(expr.Expression as Identifier);
            }
        }
        buffer = "{\"type\":\"Program\",\"body\":[{\"type\":\"ExpressionStatement\",\"expression\":{" + buffer + "}}],\"sourceType\":\"script\"}";
        return buffer;
    }
    private static string visitIdentifier(Identifier expr)
    {
        string buffer = "";
        buffer = "\"type\":\"Identifier\",\"name\":\"" + expr.Name + "\"";
        return buffer;
    }
    private static string visitLiteral(Literal expr)
    {
        string buffer = "";
        buffer = "\"type\":\"Literal\",\"value\":" + expr.Value + ",\"raw\":\"" + expr.Raw + "\"";
        return buffer;
    }
    private static string visitUnary(UnaryExpression expr)
    {
        string buffer = "";
        if (expr.Argument is BinaryExpression)
        {
            buffer = visitBinary(expr.Argument as BinaryExpression);
        }
        else if (expr.Argument is LogicalExpression)
        {
            buffer = visitLogical(expr.Argument as LogicalExpression);
        }
        else if (expr.Argument is UnaryExpression)
        {
            buffer = visitUnary(expr.Argument as UnaryExpression);
        }
        else if (expr.Argument is Literal)
        {
            buffer = visitLiteral(expr.Argument as Literal);
        }
        else if (expr.Argument is Identifier)
        {
            buffer = visitIdentifier(expr.Argument as Identifier);
        }
        string op = "";
        if (expr.Operator.ToString() == "Plus")
        {
            op = "+";
        }
        else if (expr.Operator.ToString() == "Minus")
        {
            op = "-";
        }
        else if (expr.Operator.ToString() == "LogicalNot")
        {
            op = "!";
        }
        buffer = "\"type\":\"UnaryExpression\",\"operator\":\"" + op + "\",\"argument\":{" + buffer + "},\"prefix\":" + expr.Prefix.ToString().ToLower();
        return buffer;
    }
    private static string visitLogical(LogicalExpression expr)
    {
        string arg1 = "";
        string arg2 = "";
        if (expr.Left is BinaryExpression)
        {
            arg1 = visitBinary(expr.Left as BinaryExpression);
        }
        else if (expr.Left is LogicalExpression)
        {
            arg1 = visitLogical(expr.Left as LogicalExpression);
        }
        else if (expr.Left is UnaryExpression)
        {
            arg1 = visitUnary(expr.Left as UnaryExpression);
        }
        else if (expr.Left is Literal)
        {
            arg1 = visitLiteral(expr.Left as Literal);
        }
        else if (expr.Left is Identifier)
        {
            arg1 = visitIdentifier(expr.Left as Identifier);
        }
        if (expr.Right is BinaryExpression)
        {
            arg2 = visitBinary(expr.Right as BinaryExpression);
        }
        else if (expr.Right is LogicalExpression)
        {
            arg2 = visitLogical(expr.Right as LogicalExpression);
        }
        else if (expr.Right is UnaryExpression)
        {
            arg2 = visitUnary(expr.Right as UnaryExpression);
        }
        else if (expr.Right is Literal)
        {
            arg2 = visitLiteral(expr.Right as Literal);
        }
        else if (expr.Right is Identifier)
        {
            arg2 = visitIdentifier(expr.Right as Identifier);
        }
        string op = "";
        if (expr.Operator.ToString() == "LogicalAnd")
        {
            op = "&&";
        }
        else if (expr.Operator.ToString() == "LogicalOr")
        {
            op = "||";
        }
        return "\"type\":\"LogicalExpression\",\"operator\":\"" + op + "\",\"left\":{" + arg1 + "},\"right\":{" + arg2 + "}";
    }
    private static string visitBinary(BinaryExpression expr)
    {
        string arg1 = "";
        string arg2 = "";
        if (expr.Left is BinaryExpression)
        {
            arg1 = visitBinary(expr.Left as BinaryExpression);
        }
        else if (expr.Left is LogicalExpression)
        {
            arg1 = visitLogical(expr.Left as LogicalExpression);
        }
        else if (expr.Left is UnaryExpression)
        {
            arg1 = visitUnary(expr.Left as UnaryExpression);
        }
        else if (expr.Left is Literal)
        {
            arg1 = visitLiteral(expr.Left as Literal);
        }
        else if (expr.Left is Identifier)
        {
            arg1 = visitIdentifier(expr.Left as Identifier);
        }
        if (expr.Right is BinaryExpression)
        {
            arg2 = visitBinary(expr.Right as BinaryExpression);
        }
        else if (expr.Right is LogicalExpression)
        {
            arg2 = visitLogical(expr.Right as LogicalExpression);
        }
        else if (expr.Right is UnaryExpression)
        {
            arg2 = visitUnary(expr.Right as UnaryExpression);
        }
        else if (expr.Right is Literal)
        {
            arg2 = visitLiteral(expr.Right as Literal);
        }
        else if (expr.Right is Identifier)
        {
            arg2 = visitIdentifier(expr.Right as Identifier);
        }
        string op = "";
        if (expr.Operator.ToString() == "Equal")
        {
            op = "==";
        }
        else if (expr.Operator.ToString() == "Plus")
        {
            op = "+";
        }
        else if (expr.Operator.ToString() == "Minus")
        {
            op = "-";
        }
        else if (expr.Operator.ToString() == "Times")
        {
            op = "*";
        }
        else if (expr.Operator.ToString() == "Divide")
        {
            op = "/";
        }
        else if (expr.Operator.ToString() == "Modulo")
        {
            op = "%";
        }
        else if (expr.Operator.ToString() == "LessOrEqual")
        {
            op = "<=";
        }
        else if (expr.Operator.ToString() == "GreaterOrEqual")
        {
            op = ">=";
        }
        else if (expr.Operator.ToString() == "Less")
        {
            op = "<";
        }
        else if (expr.Operator.ToString() == "Greater")
        {
            op = ">";
        }
        else if (expr.Operator.ToString() == "NotEqual")
        {
            op = "!=";
        }
        return "\"type\":\"BinaryExpression\",\"operator\":\"" + op + "\",\"left\":{" + arg1 + "},\"right\":{" + arg2 + "}";
    }
}
 