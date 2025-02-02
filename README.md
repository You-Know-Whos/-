# 这是一个沙盒小游戏

## 操作指南

### 创造模式：
* **鼠标左键**：放置物体
* **鼠标右键**：摧毁物体
* **鼠标滚轮**：切换物体
* **上方向键/下方向键**：物体放置距离+/-

### 自由模式：
* **鼠标左键（按住）**：拖拽物体
* **鼠标右键**：开关特殊物体的功能

### 任何模式：
* **1**：切换创造模式
* **2**：切换自由模式
* **W/S/A/D**：控制镜头移动
* **Q/E**：控制镜头旋转
* **Z（+ Shift）**：控制镜头缩放
* **X**：切换重力方向
* **空格**：切换暂停/开始
* **Tab**：切换时间流速（快/慢）

## 如何添加可放置物品
> 1. 在Example下创建物体
> 2. 修改新的物体（必要：添加Rigidbody组件、Line Renderer组件）
> 3. 将物体拖拽到Prefab栏以创建预制体
> 4. 将预制体拖拽到Manager.CreativeMode.ObjectPrefabs中
> 5. 为你的新物体截图，放入Assets/Sprite文件夹
> 6. 在Inspector的Assets/Sprite文件夹中将图片的纹理类型改为（Sprite（2D和UI））
> 7. 在Inspector的Assets/SO文件夹中，将刚刚的图片拖拽到ObjectPreviewSO.Sprites中  
>
> *完成添加*
