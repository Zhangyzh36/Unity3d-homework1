# Homework_1

## 简答题

- 解释 游戏对象（GameObjects） 和 资源（Assets）的区别与联系。

     -  游戏对象（GameObjects）是最基本的类,可以用它来表示人物和场景等。它们自己本身不会完成什么任务，而是作为组件的容器，由组件来完成具体的任务。
    
     - 资源（Assets）是游戏中会用到的具体资源，比如图形、声音、脚本文件等,资源可以实例化为游戏中具体的对象。
   
- 编写一个代码，使用 debug 语句来验证 MonoBehaviour 基本行为或事件触发的条件


```
using System.Collections;  
using System.Collections.Generic;  
using UnityEngine;  
   
public class NewBehaviourScript1  MonoBehaviour {  
   
    void Awake()  
    {  
        Debug.Log(Awake!);  
    }  
    
    void Start()  
    {  
        Debug.Log(Start!);  
    }  
   
    void Update()  
    {  
        Debug.Log(Update!);  
    }  
    
    void FixedUpdate()  
    {  
        Debug.Log(FixedUpdate!);  
    }  
    
    void LateUpdate()  
    {  
        Debug.Log(LateUpdate!);  
    }  
    
    void Reset()  
    {  
        Debug.Log(Reset!);  
    } 
    
    void OnGUI()  
    {  
        Debug.Log(onGUI!);  
    }  
    
    void OnDisable()  
    {  
        Debug.Log(onDisable!);  
    }  
    
    void OnDestroy()  
    {  
        Debug.Log(onDestroy!);  
    }  
   
}  
```

- 查找脚本手册，了解 GameObject，Transform，Component 对象
 - 分别翻译官方对三个对象的描述（Description）
  
  
       - GameObject
          -  GameObjects are the fundamental objects in Unity that represent characters, props and scenery. They do not accomplish much in themselves but they act as containers for Components, which implement the real functionality.
          - 游戏对象是最基本的类,可以用它来表示人物和场景等。它们自己本身不会完成什么任务，而是作为组件的容器，由组件来完成具体的任务。
    
       - Tarnsform
            - The Transform component determines the Position, Rotation, and Scale of each object in the scene. Every GameObject has a Transform.
           - Transform 组件决定了对象的位置、方向和大小。每一个对象都有一个Transform组件。

    
       - Component
          - Components are the nuts & bolts of objects and behaviors in a game. They are the functional pieces of every GameObject. 
          - 组件是游戏中对象和行为的具体细节，是每一个GameObject的零件。
 
 - 描述下图中 table 对象（实体）的属性、table 的 Transform 的属性、 table 的部件
    ![cd](httpspmlpml.github.iounity3d-learningimagesch02ch02-homework.png)
       - table的属性
            - Tag  Untagged
            - Layer  Default
       - table的Transform属性有
           - Position  X = 0，Y = 0，Z = 0
          - Rotation  X = 0，Y = 0，Z = 0
          - Scale  X = 1，Y = 1，Z = 1
       -  table 是一个 GameObject，右边Inspector视图中的部件
          - Transform
          - Mesh Filter
          - Box Collider
          - Mesh Renderer
    - 用 UML 图描述 三者的关系
    !()[]
     
- 整理相关学习资料，编写简单代码验证以下技术的实现：
  - 查找对象
  ```
  public static GameObject Find(string name);
  ```
  - 添加子对象
  ```
  public static GameObject CreatePrimitive(PrimitiveType type);
  ```
  - 遍历对象树
  ```
  foreach (Transform child in transform) {  
     Debug.Log(child.position);  
 } 
  ```  
  - 清除所有子对象
  ```
  foreach (Transform child in transform) {  
    Destroy(child.gameObject);  
}  
  ```
  
  
- 资源预设（Prefabs）与 对象克隆 (clone)
 - 预设（Prefabs）有什么好处？
  预设是一个非常容易复用的模板，我们能够快速创建大量相同属性的对象。操作简单，代码量少。
 - 预设与对象克隆 (clone or copy or Instantiate of Unity Object) 关系？
 使用预设复用时，当修改预设的某一个属性时，通过模板创建出来的对象的对应属性也会做出相应的改变，这样有利于代码的修改与维护。而通过克隆出的对象是独立于被克隆的原对象的，相应的属性改变均为独立的。
 - 制作 table 预制，写一段代码将 table 预制资源实例化成游戏对象
```
public GameObject obj;
void Start () {
    GameObject instance = (GameObject)Instantiate(obj.gameObject, transform.position, transform.rotation);
}
```
 - 尝试解释组合模式（Composite Pattern  一种设计模式),并 使用 BroadcastMessage() 方法向子对象发送消息
    - 组合模式是将对象组合成树形结构，以表示“部分整体”的层次结构，并使得用户对单个对象和组合对象的使用具有一致性。
    - 使用 BroadcastMessage() 方法向子对象发送消息
```
public class ParentBehaviourScript  MonoBehaviour {
    Use this for initialization
   void Start () {
       this.BroadcastMessage(Test);
   }
}
```