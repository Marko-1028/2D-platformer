using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restartgame : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI restartButton;


    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }
    
}
