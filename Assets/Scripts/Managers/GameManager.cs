using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        if(GameManager.instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        SceneManager.sceneLoaded += LoadState;
        DontDestroyOnLoad(gameObject);
    }

    //Storage
    public List<Sprite> weaponSprites;

    //references
    public Player player;
    public Weapon weapon;
    public WeaponController weaponSwap;
    public PlayerSprite playerSprite;
    public FloatingTextManager floatingTextManager;
    public ScreenShakeController screenShake;

    //logic
    public int coin;
    public int experience;

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            weaponSwap.SwapWeapon(weaponSwap.Weapons[0]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            weaponSwap.SwapWeapon(weaponSwap.Weapons[1]);
        }
    }

    public void ShowText(string msg, int fontsize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        floatingTextManager.Show(msg, fontsize, color, position, motion, duration);
    }

    public void ScreenShake(float length, float power)
    {
        screenShake.StartShake(length, power);
    }


    //Save State
    public void SaveState()
    {
        string s = "";

        s += coin.ToString() + "|";
        s += experience.ToString() + "|";
        s += "0";

        PlayerPrefs.SetString("SaveState", s);
    }
    public void LoadState(Scene s, LoadSceneMode mode)
    {
        if(!PlayerPrefs.HasKey("SaveState"))
        {
            return;
        }
        string[] data = PlayerPrefs.GetString("SaveState").Split('|');

        coin = int.Parse(data[0]);
        experience = int.Parse(data[1]);


        Debug.Log("Load");
    }
    public void DeleteState()
    {
        PlayerPrefs.DeleteAll();
    }
}
