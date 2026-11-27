using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restartgame : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }
    
}
