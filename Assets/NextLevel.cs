using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public void ChangeLevel()
    {
        SceneManager.LoadScene("SampleScene");
    }
}