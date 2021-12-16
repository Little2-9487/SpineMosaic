# Mosaic for Unity Spine
Key Word: Mosaic, Unity, Spine, Utage, Censor

## 使用方法
將 SpineAniMosaicWithSlotNameKeyWord.cs 掛在含有 SkeletonAnimation 的 GameObject 上，然後選擇想使用的材質球就可以了。這裡推薦使用 Material2 這顆材質球。

Script 內還附上使用 Utage + Spine 套件時，跟 Utage 套件媒合的方法。如果專案內沒有使用 Utage 套件，請刪除 Utage 整個資料夾就可以。

## Spine 資源特殊需求
需要在你想要打馬賽克的物件上面( 可能不只一個 )，額外製作一個 Slot 。並且取一個含有統一關鍵字的名稱。(例如部位A取名叫做 mosaic_a, 部位b 叫做 mosaic_b)

這裡的馬賽克腳本，會依據你設定關鍵字，去將含有關鍵字的 Slot 都抓取出來，然後置換上面的 Material。

馬賽克的形狀以及範圍，就是根據你額外製作的 Slot 的形狀來決定。

## 注意事項
當材質球上的馬賽克模糊度調成最低時，畫面應該會是顯示無修正的正常 Spine。

如果發現圖片顯示有異常( 通常是馬賽克範圍內的圖片會有位移的現象 )，請在 Spine 後面墊上一個背景。應該就會顯示正常了。

## 補充說明
關於後面需要墊上背景的異常的現象，因為馬賽克的 Shader 都是找網路上現成的來做修改的，但對 Unity Shader 不是很熟悉，也沒有額外的時間能研究。所以就只先弄一個實務上可以接受的結果。

如果有人有其他的想法以及 Shader 可以分享，也歡迎補充。

## 參考
文章: 

http://ja.esotericsoftware.com/forum/Unity-Spine-12671

馬賽克資源:

https://github.com/i-saint/Unity5Effects/tree/master/Assets/Ist

https://assetstore.unity.com/packages/vfx/shaders/censor-effect-111983


