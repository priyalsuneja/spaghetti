using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;

public class JSONParser {

    class Result
    {
        public int LevelNumber;
        public int[][][] data;
        public string id;
        public string[] variables;
    }

    class Message
    {
        public int id;
        public string jsonrpc;
        public Result result;
    }

	// Use this for initialization
	void Start () {
        string json = 
            "{\"id\":2,\"jsonrpc\":\"2.0\",\"result\":{\"LevelNumber\":5,\"data\":[[[1,7,0],[2,7,1],[3,7,3],[4,7,6],[5,7,10],[6,7,15],[7,7,21]],[],[]],\"goal\":\"verify\",\"hint\":null,\"id\":\"s - gauss_sum_true - unreach - call - auto\",\"lvlSet\":\"fb\",\"startingInvs\":[],\"typeEnv\":{\"i\":\"int\",\"n\":\"int\",\"sum\":\"int\"},\"variables\":[\"i\",\"n\",\"sum\"]}}";

        Message m = JsonConvert.DeserializeObject<Message>(json);

    }
	
}
