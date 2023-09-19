using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Icommand
{
    // Start is called before the first frame update
    void execute();

    void Undo();
}
