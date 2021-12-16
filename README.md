# Mosaic for Unity Spine
Key Word: Mosaic, Unity, Spine, Utage, Censor

中文請參閱[這裡](README_CHT.md)

## Usage
Attach SpineAniMosaicWithSlotNameKeyWord.cs to the GameObject which contain SkeletonAnimation Component, and pick the material. Recommend use "Material2"

There has bonus script, which is use for Utage Plugin.
so if you use Utage + Spine, and wanna do mosaic on it, you can use it.

if not. please delete all utage folder, or you will have compile error cuz you dont have Utage Plugin.

## Spine Resource Special Requirement

If you wanna use this script to mosaic spine, there's something you need to do on the spine raw resources.

You need add addition slot and cover it on the localtion that you wanna mosaic. and named it with contain a keyword. (e.g. slotA name: mosaic_a, slotB name: mosaic_b, this two name all contain keyword "mosaic")

The mosaic script here will according to the keyword you set to find all slot. if the slot name contain the keyworld, it will pick it up and repleace the material on it.

The mosaic's shape and range is basis on the addition slot you made in spine.

If the info is not clear enough, please read the script and you will figure it out.

## Notice

When you set mosaic minima on material, the spine should be the normal spine with uncensor.

If you find theres some odd on your spine, please set a backgorund object behind the spine, it should be normal again.

## More Info
About the odd on no backgroud. because the shader is find on internet and i modify it. but i'm not familiar with the shader, and have no time to figure it out. so just put this solution that might be acceptable.

Always welcom anyone to share some better solution.

## Reference
Article: 

http://ja.esotericsoftware.com/forum/Unity-Spine-12671

Mosaic Resources:

https://github.com/i-saint/Unity5Effects/tree/master/Assets/Ist

https://assetstore.unity.com/packages/vfx/shaders/censor-effect-111983


