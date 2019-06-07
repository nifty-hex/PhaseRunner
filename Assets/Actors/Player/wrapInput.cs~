using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityStandardAssets.CrossPlatformInput;

public class WrapInput : MonoBehaviour
{
    public static bool ResetScene()
    {

        //#if  UNITY_STANDALONE || UNITY_WEBPLAYER
#if UNITY_STANDALONE //|| UNITY_WEBPLAYER
        return Input.GetKeyDown(KeyCode.R);

#else
        return CrossPlatformInputManager.GetButtonDown("Reset");
#endif
    }

    public static bool SpeedUp()
    {
#if  UNITY_STANDALONE //|| UNITY_WEBPLAYER
        return Input.GetKey("d");

#else
        return CrossPlatformInputManager.GetButton("SpeedUp");
#endif
    }

    public static bool SpeedDown()
    {      
#if  UNITY_STANDALONE //|| UNITY_WEBPLAYER
        return Input.GetKey("a");
#else
        return CrossPlatformInputManager.GetButton("SpeedDown");
#endif
    }

    public static bool Jump()
    {
        
#if  UNITY_STANDALONE //|| UNITY_WEBPLAYER
        return Input.GetKeyDown(KeyCode.Space);
#else
        return CrossPlatformInputManager.GetButtonDown("Jump");
#endif
    }

    public static bool Glide()
    {
#if  UNITY_STANDALONE// || UNITY_WEBPLAYER
        return Input.GetKey(KeyCode.Space);
#else
        return CrossPlatformInputManager.GetButton("Jump");
#endif
    }

    public static bool TimeSlow()
    {
#if  UNITY_STANDALONE// || UNITY_WEBPLAYER
        return Input.GetKey(KeyCode.LeftShift);
#else
        return CrossPlatformInputManager.GetButton("TimeSlow");
#endif
    }

    public static bool Fire()
    {

#if UNITY_STANDALONE// || UNITY_WEBPLAYER
        return Input.GetMouseButton(0);
#else
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase!=TouchPhase.Ended && !EventSystem.current.IsPointerOverGameObject(touch.fingerId))
            {
                return true;
            }
        }
        return false;
#endif
    }

    public static Vector3 GetInputPosition()
    {

#if  UNITY_STANDALONE// || UNITY_WEBPLAYER
        return Input.mousePosition;
#else
        return Input.mousePosition;
        /* foreach (Touch touch in Input.touches)
         {
             if (!EventSystem.current.IsPointerOverGameObject(touch.fingerId))
             {
                 return touch.position;
             }
         }
         return transform.position;*/
#endif
    }


}