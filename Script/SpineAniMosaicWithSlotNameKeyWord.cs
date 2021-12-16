using Spine;
using System.Collections.Generic;
using UnityEngine;

namespace L2
{
    /// <summary>
    /// 注意，一旦初始是設置了關閉馬賽克，就沒辦法再重新初始化前再次開啟馬賽克。
    /// 因為目前的做法不是把 Material 上的 Shader 的馬賽克格子調成最小。
    /// 而是將 Slot 上的 Attachment 關閉。
    /// </summary>
    public class SpineAniMosaicWithSlotNameKeyWord : SkeletonAnimationMosaicAbstract
    {
        public string SlotNameKeyWord = "mosaic";
        public Material MosaicMaterial;

        protected override void MosaicWithSkeletonAnimation()
        {
            try
            {
                var targetSlot = new List<Slot>();

                foreach (var slot in SkeletonAnimation.Skeleton.Slots)
                {
                    if (slot.Data.Name.ToLower().Contains(SlotNameKeyWord))
                    {
                        targetSlot.Add(slot);
                    }
                }

                foreach (var slot in targetSlot)
                {
                    ChangeSkeletonAnimationSlotMat(SkeletonAnimation, slot, MosaicMaterial);
                }
            }
            catch (System.Exception e)
            {
                Debug.LogError(e.Message);
            }
        }

        protected override void UndoMosaicWithSkeletonAnimation()
        {
            var targetSlot = new List<Spine.Slot>();

            foreach (var slot in SkeletonAnimation.Skeleton.Slots)
            {
                if (slot.Data.Name.ToLower().Contains(SlotNameKeyWord))
                {
                    targetSlot.Add(slot);
                }
            }

            foreach (var slot in targetSlot)
            {
                CloseSkeletonAnimationSlot(slot);
            }
        }

        private void CloseSkeletonAnimationSlot(Spine.Slot _slot)
        {
            try
            {
                _slot.Attachment = null;
            }
            catch (System.Exception e)
            {
                Debug.LogError(e.Message);
            }
        }
    }
}
