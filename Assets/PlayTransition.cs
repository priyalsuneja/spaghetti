using UnityEngine;
using UnityEngine.SceneManagement;
 
public class PlayTransition : MonoBehaviour
{
    public void RunSinglePlayer()
    {
        SceneManager.LoadScene("SinglePlayer");
    }

    public void RunMultiPlayer()
    {
        SceneManager.LoadScene("Multiplayer");
    }

    public void RunMultiLobby()
    {
        SceneManager.LoadScene("MultiLobby");
    }
}