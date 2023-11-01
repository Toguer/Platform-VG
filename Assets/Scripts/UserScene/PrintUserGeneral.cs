using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrintUserGeneral : MonoBehaviour
{
    [SerializeField] private UserPrint userPrint;
    [SerializeField] private GameObject content;

    void Awake()
    {
        userPrint.AddToList();
    }

    public void print()
    {
        userPrint.PrintList(content);
    }
/*
    public void Delete()
    {
        userPrint.DeleteUser(content);
    }

    public void Modify()
    {
        
    }*/
    private void Start()
    {
        print();
    }
}