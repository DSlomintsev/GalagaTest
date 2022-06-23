using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowOnMobileComponent : MonoBehaviour
{
    private void Awake()
    {
        gameObject.SetActive(Application.isMobilePlatform);
    }
}
