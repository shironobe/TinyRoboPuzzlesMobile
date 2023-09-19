using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushRockCommand : Icommand
{
    // Start is called before the first frame update
    GameObject obj;
    Vector3 direction;



    public PushRockCommand(GameObject obj, Vector3 direction)
    {
        this.obj = obj;
        this.direction = direction;

    }
    public void execute()
    {
        // throw new System.NotImplementedException();

        // Player
        PushRock.PushRocks(obj, direction);
       
    }


    public void Undo()
    {
        PushRock.UnPushRock(obj, direction);
    }

}
