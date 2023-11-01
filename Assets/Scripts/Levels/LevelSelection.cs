using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LevelSelection : MonoBehaviour
{
    [SerializeField] private bool unlocked;
    [SerializeField] private Image unlockImage;
    [SerializeField] private GameObject boton;
    [SerializeField] private GameObject panel;
    [SerializeField] private BBDDSelect selectBBDD;
    [SerializeField] private int worldNumber;
    [SerializeField] private List<GameObject> worldLvls;
    [SerializeField] private bool unlockAll;

    private void Start()
    {
        if (worldNumber != 0)
        {
            unlocked = selectBBDD.CheckFullWorld(worldNumber - 1);
            //  Debug.Log(unlocked);
        }
        else
        {
            //  unlocked = _xmlSelect.checkLvl(worldNumber, 1);
            unlocked = true;
        }

        if (!unlocked)
        {
            unlockImage.gameObject.GetComponent<Image>().color = new Color32(45, 45, 45, 255);
        }
        else
        {
            unlockImage.gameObject.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        }
    }

    public void DesbloquearLevel()
    {
        unlocked = true;
        unlockImage.gameObject.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
    }

    public void ChangeScene(int scena)
    {
        SceneManager.LoadScene(scena);
    }

    public void MostrarPanel()
    {
        if (unlockAll)
        {
            panel.SetActive(true);
            for (int i = 1; i < worldLvls.Count; i++)
            {
                Debug.Log("Mundo Pradera");
                worldLvls[i].SetActive(true);
            }
        }
        else
        {
            //If the World is unlocked, when someone click the selected world, we check what lvls are unlocked.
            if (unlocked)
            {
                panel.SetActive(true);
                for (int i = 1; i < worldLvls.Count; i++)
                {
                    Debug.Log("Mundo Pradera");
                    worldLvls[i].SetActive(selectBBDD.CheckLvl(worldNumber, i));
                }
            }
        }
    }
}