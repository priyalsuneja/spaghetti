using UnityEngine;
using UnityEngine.SceneManagement;
 
public class PlayTransition : MonoBehaviour
{
    public void NextScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
}