using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TextScroller : MonoBehaviour
{


    private IEnumerator ReturnToMenus (Animation animation)
    {
        SceneManager.LoadScene("Main_Menus");
        return null;
    }


}
