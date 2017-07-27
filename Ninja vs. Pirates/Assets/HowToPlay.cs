using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HowToPlay : MonoBehaviour {
    public Button HowToPlayBtn;

    // Use this for initialization
    void Start()
    {
        Button btnLvl1 = HowToPlayBtn.GetComponent<Button>();
        btnLvl1.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void TaskOnClick()
    {
        SceneManager.LoadScene("HowToPlay");
    }
}
