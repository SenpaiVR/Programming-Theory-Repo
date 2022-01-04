using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class GameUIManager : MonoBehaviour
{
    private GameObject AncorPoint;
    private TextMeshProUGUI _playerName;
    private Camera mCamera;

    // Start is called before the first frame update
    void Start()
    {
        AncorPoint = GameObject.Find("AncorPoint");
        _playerName = GameObject.Find("PlayerName Text (TMP)").GetComponent<TextMeshProUGUI>();
        mCamera = GameObject.Find("MCamera").GetComponent<Camera>();
        if(MainManager.Instance != null)
        {
            _playerName.text = MainManager.Instance._playerName;
        }
    }

    // Update is called once per frame
    void Update()
    {
        _playerName.transform.position = mCamera.WorldToScreenPoint(AncorPoint.transform.position);
    }

    public void EndGame()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
