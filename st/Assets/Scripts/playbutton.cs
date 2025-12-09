using UnityEngine;
using UnityEngine.SceneManagement;

public class playbutton : MonoBehaviour
{

    public void OnStartClick()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
