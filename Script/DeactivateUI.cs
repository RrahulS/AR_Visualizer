using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateUI : MonoBehaviour
{
    [SerializeField] GameObject[] UIComponents;
    bool Isactive = false;
    void Start()
    {
        
    }

    public void DeactivateUIAll()
    {
        Isactive = !Isactive;
        foreach(GameObject x in UIComponents)
        {
            x.SetActive(Isactive);
        }
    }
    void Update()
    {
        
    }
}
