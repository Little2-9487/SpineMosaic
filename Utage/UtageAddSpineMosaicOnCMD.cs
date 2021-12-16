using Spine.Unity;
using UnityEngine;
using Utage;

namespace L2
{
    public class UtageAddSpineMosaicOnCMD : MonoBehaviour
    {
        [Header("場景上的 Utage Engine")]
        public AdvEngine UtageEngine;

        [Header("專案內的馬賽克材質")]
        public Material MosaicMat;

        [Header("是否開啟馬賽克")]
        public bool IsMosaicOpen = true;

        private void Awake()
        {
            try
            {
                UtageEngine.ScenarioPlayer.OnBeginCommand.RemoveListener(OnBegainCMD);
                UtageEngine.ScenarioPlayer.OnBeginCommand.AddListener(OnBegainCMD);
            }
            catch (System.Exception e)
            {
                Debug.LogError(e.Message);
            }
        }

        public void OnBegainCMD(AdvCommand _cmd)
        {
            if (_cmd != null && _cmd.LoadFileList != null)
            {
                foreach (var lf in _cmd.LoadFileList)
                {
                    if (lf.FileType == AssetFileType.UnityObject && lf.UnityObject != null)
                    {
                        try
                        {
                            var go = (GameObject)lf.UnityObject;
                            if (go != null)
                            {
                                var spc = go.GetComponent<SkeletonAnimation>();
                                if (spc != null)
                                {
                                    var mosaicScript = spc.GetComponent<SpineAniMosaicWithSlotNameKeyWord>();
                                    if (mosaicScript == null)
                                        mosaicScript = spc.gameObject.AddComponent<SpineAniMosaicWithSlotNameKeyWord>();
                                    mosaicScript.MosaicMaterial = MosaicMat;
                                    mosaicScript.OpenMosaic = IsMosaicOpen;
                                }
                                else Debug.Log(lf.FileName + " is not spine object");
                            }
                            else Debug.LogError(lf.FileName + " cant convert to GameObject");
                        }
                        catch (System.Exception e)
                        {
                            Debug.LogError(e.Message);
                        }
                    }
                }
            }
        }

    }
}
