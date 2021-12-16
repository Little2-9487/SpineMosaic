using Spine.Unity;
using UnityEngine;

namespace L2
{
    /// <summary>
    /// 如果需要由程式控制馬賽克的開啟時機，可以依賴這個抽象類別。
    /// </summary>
    [RequireComponent(typeof(SkeletonAnimation))]
    public abstract class SkeletonAnimationMosaicAbstract : MonoBehaviour
    {
        /// <summary>
        /// 舊版本的 Spine 需要將這個值打開，因為舊版本的 Spine 在 Start 之前還沒有初始化內容。
        /// </summary>
        public bool AutoOnStart = true; 

        public bool OpenMosaic = true;

        private SkeletonAnimation ska;

        public SkeletonAnimation SkeletonAnimation
        {
            get
            {
                if (ska == null)
                    ska = this.GetComponent<SkeletonAnimation>();
                return ska;
            }
        }

        void Start()
        {
            if (AutoOnStart)
            {
                if (OpenMosaic)
                    DoMosaic();
                else UndoMosaic();
            }
        }

        void Update()
        {
#if UNITY_EDITOR
            if (Input.GetKeyDown(KeyCode.A))
            {
                DoMosaic();
            }

            if (Input.GetKeyDown(KeyCode.B))
            {
                UndoMosaic();
            }
#endif
        }

        public void DoMosaic()
        {
            MosaicWithSkeletonAnimation();
        }

        public void UndoMosaic()
        {
            UndoMosaicWithSkeletonAnimation();
        }

        public void ChangeSkeletonAnimationSlotMat(SkeletonAnimation _ska, string _slotName, Material _mat)
        {
            try
            {
                var slot = _ska.Skeleton.FindSlot(_slotName);
                ChangeSkeletonAnimationSlotMat(_ska, slot, _mat);
            }
            catch (System.Exception e)
            {
                Debug.LogError(e.Message);
            }
        }

        public void ChangeSkeletonAnimationSlotMat(SkeletonAnimation _ska, Spine.Slot _slot, Material _mat)
        {
            _ska.CustomSlotMaterials[_slot] = _mat;
        }

        protected abstract void MosaicWithSkeletonAnimation();

        protected abstract void UndoMosaicWithSkeletonAnimation();


    }
}
