# よもぎメモ

## 新規作成したもの (alphabet 順)
- `Prefabs/GameManager.prefab`  
  グローバル変数を扱う。全 Scene においてください。  
  cf [ゲームマネージャーを作ってみよう【Unity 2Dアクション】【初心者入門講座】【ゲームの作り方】#48](https://youtu.be/JyrBl-06FAs?list=PLED8667EEZ9aB72WVMHfRHBd6oj9vplRy)  
- `Prefabs/Gem.prefab`  
  Gem (宝石) です。  
- `Scenes/TitleScene.unity`  
  Title 画面です。既に、背景・タイトル・Start ボタンを置いています。  
- `Scripts/Core/GameManager.cs`  
  グローバル変数置き場。singleton になっています。  
  cf [ゲームマネージャーを作ってみよう【Unity 2Dアクション】【初心者入門講座】【ゲームの作り方】#48](https://youtu.be/JyrBl-06FAs?list=PLED8667EEZ9aB72WVMHfRHBd6oj9vplRy)  
- `Scripts/Gems/GemCollision.cs`  
  Gem にあたると、`GameManager.instance.gemsNum++`。  
- `Scripts/SaveLoad/LoadManager.cs`  
  `%APPDATA%/LocalLow/DefaultCompany/Hackathon2022/save/data.dat` に保存されたセーブデータ (現在の `ClassicCharacter` の座標や `GameManager.instance.gemsNum`) をロード。  
  cf [SAVE & LOAD SYSTEM in Unity](https://youtu.be/XOjd_qU2Ido)  
- `Scripts/SaveLoad/SaveData.cs`  
  `Scripts/SaveLoad/LoadManager.cs` と `Scripts/SaveLoad/SaveManager.cs` 用のクラス。  
  cf [SAVE & LOAD SYSTEM in Unity](https://youtu.be/XOjd_qU2Ido)  
- `Scripts/SaveLoad/SaveManager.cs`  
  `%APPDATA%/LocalLow/DefaultCompany/Hackathon2022/save/data.dat` にセーブデータを保存。なお、デバッグ用に S キーセーブ機能が付いています。  
  cf [SAVE & LOAD SYSTEM in Unity](https://youtu.be/XOjd_qU2Ido)  
- `Scripts/UI/GameplayUIController.cs`  
  Gameplay 画面において、右上の `Gems: 0` の表示を司る。  
- `Scripts/UI/OnClickStart.cs`  
  Title 画面において、Start と書かれたボタンの押下時に、シーン `Assets/CharacterEditorPackage/Scenes/DemoScene2.unity` へ遷移する。  
- `Sunnyland/**`  
  (略)  
- `TextMesh Pro/**`  
  (略)  

## `Player` タグを付けてください
- 全 Scene において、 `ClassicCharacter` の Inspector にて、Tag を `Untagged` -> `Player` のようにタグ付けください。これは、セーブデータのセーブ・ロード時に `ClassicCharacter` の GameObject を取得するためです (x, y 座標を保存したい)。  

## TTF 形式のフォントを入れる方法
- Unity に TTF 形式のフォントを入れるには .ttf から .sdf に変更する必要があります。  
  今回使用したフォントは `TextMesh Pro/Fonts/x12y16pxMaruMonica.ttf` にあります。
  cf [How to Import Custom Fonts in Text Mesh Pro](https://youtu.be/W11uv7jf1e4)

## .exe にて、サイズをを指定する方法
`File > Build Settings...` を押すと、以下のような画面が出てくるので 960x540 と設定。  
cf [【Unity C#】ビルドの画面サイズ](https://futabazemi.net/notes/unity-aspect/)
![Project Settings](https://i.imgur.com/FH8ORSS.png)

## タイトル画面にて、十字キーでも選択できるようにした
cf [START MENU in Unity](https://youtu.be/zc8ac_qUXQY)

## `Test Mesh Pro` の方を使おう
- deprecated (非推奨) な `Text` ではなく、後発の `Test Mesh Pro` を使っています。

## 啓典
- ぜひ、[ゲームの作り方【Unity初心者入門講座】Renewal](https://youtu.be/q7hyt06gUJE?list=PLED8667EEZ9aB72WVMHfRHBd6oj9vplRy) を全て履修し、Unity への理解を深めましょう。
