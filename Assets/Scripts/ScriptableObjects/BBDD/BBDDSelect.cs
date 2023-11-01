using UnityEngine;


public abstract class BBDDSelect : ScriptableObject
{
    [SerializeField] protected gameTemplate gameTemplate;
    [SerializeField] protected SelectedUser _selectedUser;

    public abstract bool CheckFullWorld(int worldNum);
    public abstract bool CheckLvl(int world, int lvl);
}