using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Modules : MonoBehaviour
{
    public List<Module> _modules;
    public Material LineMaterial;
    private GameObject myLine;

    public float destroyTimer;
    
    
    
    void Start()
    {
        myLine = new GameObject();
        
        LineRenderer lr = myLine.AddComponent<LineRenderer>();
        lr.material = LineMaterial;
        lr.SetWidth(0.1f, 0.1f);
        
    }

    // Update is called once per frame
    void Update()
    {
        ConnectToNextNode(0);

        destroyTimer -= Time.deltaTime;

        if (destroyTimer <= 0)
        {
            destroyTimer = Random.value * 30;
            
            System.Random rand = new System.Random();
            int destroyNode = rand.Next(_modules.Count - 1);

            _modules[destroyNode].isFunctional = false;
            
            
        }
    }


    void ConnectToNextNode(int index)
    {
        if (index > _modules.Count - 1) return;
        
        Module currentModule = _modules[index];

        if (currentModule.isFunctional)
        {
            myLine.GetComponent<LineRenderer>().SetVertexCount(_modules.Count);
            myLine.GetComponent<LineRenderer>().SetPosition(index, currentModule.gameObject.transform.position);
        }
        else
        {
            myLine.GetComponent<LineRenderer>().SetVertexCount(index + 1);
            myLine.GetComponent<LineRenderer>().SetPosition(index, currentModule.gameObject.transform.position);
            return;
        }

        index++;
        ConnectToNextNode(index);
    }
}
