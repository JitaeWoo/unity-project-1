using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] public LoadingUIHandler Loading;
    [SerializeField] public GamePlayUIHandler GamePlay;
}
