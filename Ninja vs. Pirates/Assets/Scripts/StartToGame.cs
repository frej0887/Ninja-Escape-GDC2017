using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StartToGame : MonoBehaviour {
    public Button yourButton;

    // Use this for initialization
    void Start()    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update () {
    }

    void TaskOnClick()    {
        Application.LoadLevel("Deck");
    }

}
