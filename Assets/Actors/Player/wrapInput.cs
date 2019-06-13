using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityStandardAssets.CrossPlatformInput;

public class WrapInput : MonoBehaviour
{
    public static int gunType = 0;
    public static bool timeSlowOn = false;

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

    public static bool TimeSlow(float time_slow_limit, bool over_limit)
    {
#if  UNITY_STANDALONE// || UNITY_WEBPLAYER
        return Input.GetKey(KeyCode.LeftShift) && time_slow_limit > 0 && over_limit == false;
#else
        if(CrossPlatformInputManager.GetButtonUp("TimeSlow"))
	{
		timeSlowOn = !timeSlowOn;
	}

	if(timeSlowOn)
	{
		if(time_slow_limit<=0 || over_limit == true)
		{
			timeSlowOn = false;
		}
	}

	return timeSlowOn;
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

	
	
    public static int switchGun()
    {
#if UNITY_STANDALONE// || UNITY_WEBPLAYER
	if(Input.GetKeyDown(KeyCode.Alpha1))
	{
		return 0;
	}
	if(Input.GetKeyDown(KeyCode.Alpha3))
	{
		return 2;
	}
	if(Input.GetKeyDown(KeyCode.Alpha2))
	{
		return 1;
	}

#else   
	if(CrossPlatformInputManager.GetButtonUp("Change Gun"))
	{
		gunType = gunType + 1;
		return gunType % 3;
	}
#endif	

	return -1;	
    }


}
