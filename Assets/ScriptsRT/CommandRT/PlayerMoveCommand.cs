using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveCommand : Icommand
{
    // Start is called before the first frame update

    GameObject obj;
    Vector3 direction;



    public PlayerMoveCommand(GameObject obj, Vector3 direction)
    {
        this.obj = obj;
        this.direction = direction;

    }
   public void execute()
    {
       // throw new System.NotImplementedException();

        // Player
        PlayerMovement.PlayerMove(obj, direction);
    }


    public void Undo()
    {
        PlayerMovement.UndoPlayerMove(obj, direction);

       
    }


   

}
