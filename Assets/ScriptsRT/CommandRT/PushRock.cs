using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PushRock 
{
    static List<GameObject> objects;
    public static void PushRocks(GameObject obj, Vector3 direction)
    {
        obj.GetComponent<PushableBlockRt>().destination = obj.transform.position + direction;
      //  AudioManager.instance.PlaySfx(1);
       RoboControllerRt.instance.MovePlayer(direction);
        if (objects == null)
        {
            objects = new List<GameObject>();
        }
        objects.Add(obj);


    }

    public static void UnPushRock(GameObject obj, Vector3 direction)
    {
        obj.GetComponent<PushableBlockRt>().destination = obj.transform.position - direction;

        RoboControllerRt.instance.UnMovePlayer(direction);
    }
}
