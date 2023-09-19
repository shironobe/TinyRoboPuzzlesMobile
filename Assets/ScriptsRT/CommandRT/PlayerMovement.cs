using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerMovement 
{
    // Start is called before the first frame update

    static List<GameObject> objects;

    //static List<GameObject> Bats;
    public static void PlayerMove(GameObject obj, Vector3 direction)
    {
        obj.GetComponent<RoboControllerRt>().Destination = obj.transform.position + direction;

        GameObject.FindGameObjectWithTag("Invoker").GetComponent<CommandInvoker>().Undoing = false;

     //  PlayerController.instance.BatMove();

        if(objects == null)
        {
            objects = new List<GameObject>();
        }
        objects.Add(obj);
    }


    public static void UndoPlayerMove(GameObject obj, Vector3 direction)
    {
        obj.GetComponent<RoboControllerRt>().Destination = obj.transform.position - direction;
    //  PlayerController.instance.UndoBatMove();
    }
   


    //public static void batMove(GameObject obj, Vector3 direction)
    //{
    //   // obj.GetComponent<BatMove>().destination = obj.transform.position + direction;

    //    if (objects == null)
    //    {
    //        objects = new List<GameObject>();
    //    }
    //    objects.Add(obj);
    //}


    //public static void UndoBatMove(GameObject obj, Vector3 direction)
    //{
    //   // obj.GetComponent<BatMove>().destination = obj.transform.position - direction;
    //}



}
