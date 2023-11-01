using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class userSelection : MonoBehaviour
{
    private int userIndex;
    [SerializeField]private SelectedUser _selectedUser;

    public int UserIndex
    {
        get => userIndex;
        set => userIndex = value;
    }

    public void userSelected()
    {
        Debug.Log(GetComponentInChildren<TextMeshProUGUI>().text);
        _selectedUser.UserName = GetComponentInChildren<TextMeshProUGUI>().text;
        _selectedUser.UserIndex = userIndex;
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
