using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityStandardAssets.CrossPlatformInput;

public class InputManager : MonoBehaviour
{
    public  int gunType = 0;
    public  bool timeSlowOn = false;
    public Transform player;

    public  bool ResetScene()
    {

        //#if  UNITY_STANDALONE || UNITY_WEBPLAYER
#if UNITY_STANDALONE //|| UNITY_WEBPLAYER
        return Input.GetKeyDown(KeyCode.R);

#else
        return CrossPlatformInputManager.GetButtonDown("Reset");
#endif
    }

    public  bool SpeedUp()
    {
#if  UNITY_STANDALONE //|| UNITY_WEBPLAYER
        return Input.GetKey("d");

#else
        return CrossPlatformInputManager.GetButton("SpeedUp");
#endif
    }

    public  bool SpeedDown()
    {
#if UNITY_STANDALONE //|| UNITY_WEBPLAYER
        return Input.GetKey("a");
#else
        return CrossPlatformInputManager.GetButton("SpeedDown");
#endif
    }

    public  bool Jump()
    {

#if UNITY_STANDALONE //|| UNITY_WEBPLAYER
        return Input.GetKeyDown(KeyCode.Space);
#else
        return CrossPlatformInputManager.GetButtonDown("Jump");
#endif
    }

    public  bool Glide()
    {
#if  UNITY_STANDALONE// || UNITY_WEBPLAYER
        return Input.GetKey(KeyCode.Space);
#else
        return CrossPlatformInputManager.GetButton("Jump");
#endif
    }

    public  bool TimeSlow()
    {
#if  UNITY_STANDALONE// || UNITY_WEBPLAYER
        return Input.GetKey(KeyCode.LeftShift);
#else
        if (CrossPlatformInputManager.GetButtonUp("TimeSlow"))
        {
            timeSlowOn = !timeSlowOn;
        }

        return timeSlowOn;
#endif
    }

    public  bool Fire()
    {

#if UNITY_STANDALONE// || UNITY_WEBPLAYER
        return Input.GetMouseButton(0);
#else
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase != TouchPhase.Ended && !EventSystem.current.IsPointerOverGameObject(touch.fingerId))
            {
                return true;
            }
        }
        return false;
#endif
    }

    public  Vector3 GetInputPosition()
    {

#if  UNITY_STANDALONE// || UNITY_WEBPLAYER
        return Input.mousePosition;
#else
        //return Input.mousePosition;
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase != TouchPhase.Ended && !EventSystem.current.IsPointerOverGameObject(touch.fingerId))
            {
                Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                touchPosition.z = 0f;
                return touchPosition;
            }
        }
        return player.position;
#endif
    }

    public  int switchGun()
    {
#if UNITY_STANDALONE// || UNITY_WEBPLAYER
	if(Input.GetKeyDown(KeyCode.Alpha1))
	{
		return 0;
	}
	else if(Input.GetKeyDown(KeyCode.Alpha2))
	{
		return 1;
	}
	else if(Input.GetKeyDown(KeyCode.Alpha3))
	{
		return 2;
	}
    else if (Input.GetKeyDown(KeyCode.Alpha4))
    {
        return 3;
    }
#else
        if (CrossPlatformInputManager.GetButtonUp("Change Gun"))
        {
            gunType = gunType + 1;
            return gunType % 4;
        }
#endif

        return -1;
    }
}
