using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor;
using UnityEngine.SceneManagement;

public class MainUIManager : MonoBehaviour
{

    public TMP_InputField _playernameInput;
    public Button CatButton;
    public Button DogButton;

    // Start is called before the first frame update
    void Start()
    {
        MainManager.Instance.LoadData();
        _playernameInput.text = MainManager.Instance._playerName;

    }

    #region Menu UI Inputs

    public void Cat()
    {
        if(MainManager.Instance.isDog == true)
        {
            MainManager.Instance.isDog = false;
        }

        MainManager.Instance.isCat = true;

        changeButtonColors(Color.white, Color.green);

    }

    public void Dog()
    {
        if(MainManager.Instance.isCat == true)
        {
            MainManager.Instance.isCat = false;
        }

        MainManager.Instance.isDog = true;

        changeButtonColors(Color.green, Color.white);
    }

    public void Play()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void Exit()
    {

        MainManager.Instance._playerName = _playernameInput.text;
        MainManager.Instance.SaveData();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }

    #endregion

    #region Calculations 

    void changeButtonColors(Color dogButtonColor, Color catButtonCollor)
    {
        #region Change Cat Button Color
        ColorBlock colorsC = CatButton.colors;
        colorsC.normalColor = catButtonCollor;
        CatButton.colors = colorsC;
        #endregion

        #region Change Dog Button Color
        ColorBlock colorsD = DogButton.colors;
        colorsD.normalColor = dogButtonColor;
        DogButton.colors = colorsD;
        #endregion
    }

    #endregion
}
