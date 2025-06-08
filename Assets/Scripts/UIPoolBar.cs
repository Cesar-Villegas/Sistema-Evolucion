using UnityEngine;
using UnityEngine.UI;

public class UIPoolBar : MonoBehaviour{
    [SerializeField] Image bar;

    ValuePool targetPool;

    public void Show(ValuePool targetPool){
        gameObject.SetActive(true);
        this.targetPool = targetPool;
    }

    public void Clear(){
        targetPool = null;
        gameObject.SetActive(false);
    }

    private void Update(){
        if(targetPool == null){return;}
        bar.fillAmount = Mathf.InverseLerp(0f, targetPool.maxValue.value, targetPool.currentValue);
    }
}
