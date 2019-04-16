using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    //public static int level = 1;
    public void ChangeSingleLevel()
    {
        //if (level == 1)
        //{
          //  level = 2;
            TableCreator.currentJson = CallServer.ExecuteServerCall(); //"{ \"id\":2, \"jsonrpc\":\"2.0\", \"result\":{ \"LevelNumber\":5,\"data\":[[[1,7,0],[2,7,1],[3,7,3],[4,7,6],[5,7,10],[6,7,15],[7,7,21]],[],[]],\"goal\":\"verify\",\"hint\":null,\"id\":\"s-gauss_sum_true-unreach-call-auto\",\"lvlSet\":\"fb\",\"startingInvs\":[],\"typeEnv\":{\"i\":\"int\",\"n\":\"int\",\"sum\":\"int\"},\"variables\":[\"i\",\"n\",\"sum\"]}}";
        //}
        //else if (level == 2)
        //{
          //  level = 1;
            //TableCreator.currentJson = CallServer.ExecuteServerCall();//"{\"id\":68,\"jsonrpc\":\"2.0\",\"result\":{\"LevelNumber\":6,\"ShowQuestionaire\":true,\"data\":[[[1,0,7,0],[2,1,7,1],[3,2,7,3],[4,3,7,6],[5,4,7,10],[6,5,7,15],[7,6,7,21]],[],[]],\"goal\":\"verify\",\"hint\":null,\"id\":\"m - sorin03 - auto\",\"lvlSet\":\"fb\",\"startingInvs\":[],\"typeEnv\":{\"i\":\"int\",\"j\":\"int\",\"n\":\"int\",\"s\":\"int\"},\"variables\":[\"i\",\"j\",\"n\",\"s\"]}}";
        //}
        TableCreator.counter = 0;
        TableCreator.score = 0;
        SceneManager.LoadScene("SinglePlayer");
    }

    public void ChangeMultiLevel()
    {
        TableCreator.currentJson = CallServer.ExecuteServerCall();
        TableCreator.counter = 0;
        TableCreator.score = 0;
        SceneManager.LoadScene("Multiplayer");
    }

    public void OpenMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}