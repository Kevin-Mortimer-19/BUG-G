using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SPButton : MonoBehaviour
{
    public Button startSP;

    void Start(){
        startSP = GetComponent<Button>();
        startSP.onClick.AddListener(SceneSwitch);
    }

    void SceneSwitch(){
        SceneManager.LoadScene("SinglePlayer");
    }
    
}
