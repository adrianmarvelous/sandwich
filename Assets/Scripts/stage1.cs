using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stage1 : MonoBehaviour
{
    public GameObject camera;
    private tesInput ScriptInput;
    public string box = "default";
    public string direction = "default";
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        ScriptInput = camera.GetComponent<tesInput>();
    }

    // Update is called once per frame
    void Update()
    {
        box = ScriptInput.active;
        direction = ScriptInput.direction;

        if(box == "" && direction == ""){

        }
        else if(box == "1" && direction == "up"){
            anim.SetTrigger("anim 1");
        }else{
            anim.SetTrigger("wrong");
            anim.ResetTrigger("wrong");
        }
    }
}
