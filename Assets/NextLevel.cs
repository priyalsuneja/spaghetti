using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public void ChangeLevel()
    {
        if (TableCreator.level == 1)
        {
            TableCreator.level = 2;
        }
        else if (TableCreator.level == 2)
        {
            TableCreator.level = 1;
        }
        TableCreator.counter = 0;
        TableCreator.score = 0;
        SceneManager.LoadScene("SampleScene");
    }
}