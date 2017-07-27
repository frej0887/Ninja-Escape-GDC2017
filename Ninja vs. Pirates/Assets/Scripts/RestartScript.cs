using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartScript : MonoBehaviour {
    public Button retryBtn;

    // Use this for initialization
    void Start()
    {
        Button btn = retryBtn.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()    {
    }

    void TaskOnClick()    {
        SceneManager.LoadScene("MainMenu");
    }
}
