using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticFunctions : MonoBehaviour
{
    internal static StaticFunctions instance;
    internal string name;
    // Start is called before the first frame update
    private void Awake()
    {

        //checking if there is isntance of this object, if not, create one
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);

        }
        //if there was already instance of the object, destroy it, to aovid multiple gameobject of this type
        else
        {
            Destroy(this.gameObject);
        }
    }
}
