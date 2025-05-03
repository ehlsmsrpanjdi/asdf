using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;

public class GameInstance : MonoBehaviour
{
    private static GameInstance instance;

    Dictionary<string, WeaponInfo> weaponInfoDict = new Dictionary<string, WeaponInfo>();

    [SerializeField] List<WeaponInfo> weaponInfoList = new List<WeaponInfo>();

    public static GameInstance GetInst()
    {
        if(instance != null)
        {
            return instance;
        }
        else
        {
            GameObject obj = new GameObject("GameInstance");
            instance = obj.AddComponent<GameInstance>();
            DontDestroyOnLoad(obj);
            return instance;
        }
    }

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            SetDictionary();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void SetDictionary()
    {
        foreach (var weaponInfo in weaponInfoList)
        {
            if (!weaponInfoDict.ContainsKey(weaponInfo.weaponName))
            {
                weaponInfoDict.Add(weaponInfo.weaponName, weaponInfo);
            }
            else
            {
                Debug.LogError("Duplicate weapon name found: " + weaponInfo.weaponName);
            }
        }
    }

    public WeaponInfo GetWeaponInfo(string weaponName)
    {
        if (weaponInfoDict.ContainsKey(weaponName))
        {
            return weaponInfoDict[weaponName];
        }
        else
        {
            Debug.LogError("Weapon not found: " + weaponName);
            return null;
        }
    }

}
