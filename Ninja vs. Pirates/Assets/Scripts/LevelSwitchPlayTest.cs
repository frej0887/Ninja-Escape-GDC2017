using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSwitchPlayTest : MonoBehaviour {
    public Button PlayTBtn;

    // Use this for initialization
    void Start()
    {
        Button btnLvl1 = PlayTBtn.GetComponent<Button>();
        btnLvl1.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void TaskOnClick()
    {
        SceneManager.LoadScene("Level2_BACKUP");
    }
}
