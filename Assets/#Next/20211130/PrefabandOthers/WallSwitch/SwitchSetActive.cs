using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SwitchSetActive : MonoBehaviour
{
    public GameObject unlockObj;
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (unlockObj.activeInHierarchy == true) // もしunlockObjのオブジェクトが表示されていたら
            {
                unlockObj.gameObject.SetActive(false); // unlockObjeを消します
                this.gameObject.SetActive(false); // このオブジェクトを消します
            }
            else if (unlockObj.activeInHierarchy == false) //では、もしunlockObjのオブジェクトが表示されてなければ
            {
                unlockObj.gameObject.SetActive(true); // unlockObjを表示します
                this.gameObject.SetActive(false); // このオブジェクトを消します
            }
        }
    }
}