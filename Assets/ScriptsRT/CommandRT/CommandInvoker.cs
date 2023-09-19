using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandInvoker : MonoBehaviour
{
    // Start is called before the first frame update

    public static CommandInvoker instance;
    static Queue<Icommand> commandBufffer;


    static List<Icommand> commandHistory;
    [SerializeField] public  int Counter;

   public bool Undoing;
    public GameObject Robo1;
    private void Awake()
    {
        instance = this;
       
        commandBufffer = new Queue<Icommand>();
        commandHistory = new List<Icommand>();
    }

    private void Start()
    {

        Robo1 = GameObject.FindGameObjectWithTag("Robo1");
    }
    public  void AddCommand(Icommand command)
    {
        if (Counter < commandHistory.Count)
        {

            while (commandHistory.Count > Counter)
            {
                commandHistory.RemoveAt(Counter);
            }
        }
            commandBufffer.Enqueue(command);
            // Debug.Log(commandHistory.Count);
            // Debug.Log(Counter);
        
    }

    // Update is called once per frame
    void Update()
    {
        

            if (commandBufffer.Count > 0)
            {
                Icommand c = commandBufffer.Dequeue();
                c.execute();
                commandHistory.Add(c);
                Counter++;
          
            //commandBufffer.Dequeue().execute();
        }
            else
            {


                if (Input.GetKeyDown(KeyCode.Z) && Robo1.GetComponent<PlayerControllerRt>().enabled == false )
                {


                //if (!Undoing)
                //{


                // //   BatMove.instance.UndoBool();
                //    Undoing = true;
                //}


                
                    if (Counter > 0)
                    {
                   
                    Counter--;
                    commandHistory[Counter].Undo();
                  
                   

                    }

                }
               



            }
                //else if (Input.GetKeyDown(KeyCode.R))
                //{
                //    if (Counter > 0)
                //    {
                //        Counter++;
                //        commandHistory[Counter].execute();
                //    }
                //}
    }

    public void undo()
    {
        if (Counter > 0)
        {

            Counter--;
            commandHistory[Counter].Undo();



        }
    }
   public void ResetCounter()
    {
        Counter = 0;
    }
        
    
}
