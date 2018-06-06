using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public void UGUI_HandleResetButtonClick()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}
