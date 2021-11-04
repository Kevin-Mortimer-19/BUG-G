using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MPButton : MonoBehaviour
{
    public Button startMP;

    void Start(){
        startMP = GetComponent<Button>();
        startMP.onClick.AddListener(SceneSwitch);
    }

    void SceneSwitch(){
        SceneManager.LoadScene("MultiPlayer");
    }
    
}
