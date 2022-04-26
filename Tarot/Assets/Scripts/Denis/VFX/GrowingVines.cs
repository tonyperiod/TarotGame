using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//for this effect, it just needs to be enabled - it automatiically disables itsel after playing each time.
public class GrowingVines : MonoBehaviour
{

    public List<MeshRenderer> growVinesMeshes;
    public float timeToGrow = 5f;
    public float refreshRate = 0.05f;
    [Range(0, 1)]
    public float minGrow = 0.2f;
    [Range(0, 1)]
    public float maxGrow = 0.97f;
    private bool growing = true;
    private List<Material> growVinesMaterials = new List<Material>();
    private bool fullyGrown;

    // Start is called before the first frame update
    void Start()
    {
        for(int i=0; i<growVinesMeshes.Count; i++)
        {
            for(int j=0; j<growVinesMeshes[i].materials.Length; j++)
            {
                if(growVinesMeshes[i].materials[j].HasProperty("Grow_"))
                {
                    growVinesMeshes[i].materials[j].SetFloat("Grow_", minGrow);
                    growVinesMaterials.Add(growVinesMeshes[i].materials[j]);

                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
    //if(Input.GetKeyDown(KeyCode.Space))
        {
            for(int i=0; i<growVinesMaterials.Count; i++)
            {
                StartCoroutine(GrowVines(growVinesMaterials[i]));

            }
        }
    }

    IEnumerator GrowVines(Material mat)
    {
        float growValue = mat.GetFloat("Grow_");
        if (!fullyGrown)
        {
            while (growValue < maxGrow && growing == true)
            {
                growValue += 1 / (timeToGrow / refreshRate);
                mat.SetFloat("Grow_", growValue);
                yield return new WaitForSeconds(refreshRate);
                growing = true;

            }
        }
        else

            growing = false;

        {

            while (growValue > minGrow && growing == false)
            {
                growValue -= 1 / (timeToGrow / refreshRate);
                mat.SetFloat("Grow_", growValue);
                yield return new WaitForSeconds(refreshRate);
                growing = false;

            }
        }

        if (growValue < minGrow)
        {
            growValue = 0;
            growing = true;
            gameObject.SetActive(false);
        }
       

        if (growValue >= maxGrow)
            fullyGrown = true;
        else
            fullyGrown = false;
    }

}
