using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField, Tooltip("虛擬搖桿")] Joystick myJoystick;
    #region 重置欄位
    private void Reset()
    {
        myJoystick = GameObject.Find("FixedJoystick").GetComponent<Joystick>();

    }
    [SerializeField,Tooltip("縮放限制")] Vector2 scaleLimit;
   
    #endregion

    //屬性 Property  與欄位類似,不顯示於面板,可被事件存取
    // 修飾詞 類型 名稱 {讀取 寫入}
    public Transform target { get; set; }



    // Update is called once per frame
    void Update()
    {
        CtrlTarget();
        if (target!=null)
        {
            target.localScale = new Vector3(Mathf.Clamp(target.localScale.x, scaleLimit.x, scaleLimit.y), Mathf.Clamp(target.localScale.y, scaleLimit.x, scaleLimit.y), Mathf.Clamp(target.localScale.z, scaleLimit.x, scaleLimit.y));
        }
       
    }    
    [SerializeField,Tooltip("旋轉速度")] float speed;
    /// <summary>控制目標物件 </summary>
    void CtrlTarget()
    {//如果目標存在
        if (target)
        {//目標放大
            target.localScale += myJoystick.Vertical * Time.deltaTime * Vector3.one;
         //目標旋轉
            target.Rotate(0f, myJoystick.Horizontal * Time.deltaTime*speed, 0f);
        }

    }
}
