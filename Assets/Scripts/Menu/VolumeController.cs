//Script criado por Wellington F. Baldo
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class VolumeController : MonoBehaviour, IDragHandler, IEndDragHandler
{
    private GameObject texto;
    private GameObject menu;

    private int result;

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = new Vector3(eventData.position.x, transform.position.y, transform.position.z);
        if(transform.localPosition.x > 50f)
        {
            transform.localPosition = new Vector3(50f, 0f, transform.localPosition.z);
        }else if(transform.localPosition.x < -50)
        {
            transform.localPosition = new Vector3(-50f, 0f, transform.localPosition.z);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        menu.GetComponent<MenuController>().setVolume(result);
    }

    // Start is called before the first frame update
    void Start()
    {
        //Guardando gameObject na memória
        texto = gameObject.transform.parent.parent.GetChild(2).gameObject;
        menu = gameObject.transform.parent.parent.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        result = (int)gameObject.transform.localPosition.x + 50;
        texto.GetComponent<UnityEngine.UI.Text>().text = result.ToString();
    }
}
