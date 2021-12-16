using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CharSelect: MonoBehaviour
{
    private GameObject[] characterList;
    private int index;



    private void Start()
    {
        index = PlayerPrefs.GetInt("CharacterSelected");

        characterList = new GameObject[transform.childCount];

        //fill the array with models 
        for (int i = 0; i < transform.childCount; i++)
            characterList[i] = transform.GetChild(i).gameObject;

        //we toggle off their renderer
        foreach (GameObject go in characterList)
            go.SetActive(false);

        //we toggle on the first index    //We toggle on selected character
        if (characterList[index])
            characterList[index].SetActive(true);

    }

    public void ToggleLeft()
    {
        //Toggle off the current model
        characterList[index].SetActive(false);

        index--; //index -= 1; index = index -1
        if (index < 0)
            index = characterList.Length - 1;

        //toggle new model
        characterList[index].SetActive(true);

    }

    public void ToggleRight()
    {
        //Toggle off the current model
        characterList[index].SetActive(false);

        index++; //index -= 1; index = index -1
        if (index == characterList.Length)
            index = 0;

        //toggle new model
        characterList[index].SetActive(true);

    }

    public void Confirm()
    {
        PlayerPrefs.SetInt("CharacterSelected", index);
        SceneManager.LoadScene("Stage 1");
    }
}
