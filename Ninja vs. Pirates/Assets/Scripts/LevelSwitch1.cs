using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSwitch1 : MonoBehaviour  {
    public Button retryBtn;

    // Use this for initialization
    void Start()    {
        Button btnLvl1 = retryBtn.GetComponent<Button>();
        btnLvl1.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()    {
    }

    void TaskOnClick()    {
        SceneManager.LoadScene("Level_2");
    }
}
