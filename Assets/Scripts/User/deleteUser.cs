using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deleteUser : MonoBehaviour
{
    [SerializeField] private userList _userList;
    
    public void RemoveUserList()
    {
        _userList.Remove();
    }
}
