# VRCNotification

VRChat のインスタンスにユーザーが参加・退出したときに、通知音を鳴らす Windows 用のデスクトップアプリです。

インスタンスの種類（パブリック、フレンド、インバイトなど）ごとに、通知音を鳴らすかどうかを切り替えられます。<br/>
「パブリックではうるさいので鳴らさない」「フレンドインスタンスでは入室だけ鳴らす」といった使い分けができます。<br/>
あとは、キャストさんなどにもおすすめです。参加者が来たときに気づきやすくなります。<br/>

> **本ツールは VRChat Inc. とは関係のない非公式ツールです。**

<img width="786" height="443" alt="image" src="https://github.com/user-attachments/assets/62ea6289-de91-444f-8371-7b0eb03fc0b8" />

## 主な機能

- ユーザーの入室・退出時に通知音を再生
- インスタンスの種類ごとに、通知のしかたを3段階で設定
  - 通知音なし
  - 入室のみ
  - 入退室の両方
- 通知音の音量調整（「確認」ボタンで試聴できます）
- 現在いるインスタンスの種類を表示
- 通知の一時停止・再開
- 設定の自動保存（次回起動時に引き継がれます）

### 対応しているインスタンスの種類

| 表示名 | VRChat 上のインスタンス |
|---|---|
| パブリック | Public |
| グループパブリック | Group Public |
| グループ+ | Group+ |
| グループオンリー | Group |
| フレンド+ | Friends+ |
| フレンドオンリー | Friends |
| インバイト+ | Invite+ |
| インバイトオンリー | Invite |

## 動作環境

- Windows 10 / 11（64bit）
- VRChat（PC 版）

.NET のインストールは不要です（アプリに同梱されています）。

## インストール

1. [Releases](https://github.com/hrt05/VRCNotification/releases) から、最新版の `VRCNotification-win-Setup.exe` をダウンロードします。
2. ダウンロードした `VRCNotification-win-Setup.exe` を実行します。
3. インストールが終わると、スタートメニューとデスクトップにショートカットが作成されます。

管理者権限は不要です。

### 「Windows によって PC が保護されました」と表示された場合

コード署名をしていないため、初回起動時に Windows SmartScreen の警告が表示されることがあります。
「詳細情報」をクリックし、「実行」を押すと起動できます。

## 使い方

1. VRCNotification を起動します（VRChat より先に起動しても、後から起動しても動作します）。
2. 「インスタンス設定」で、各インスタンスの種類のボタンをクリックし、通知のしかたを選びます。
   - クリックするたびに「通知音無し」→「入室のみ」→「入退出含め」と切り替わります。
3. 音量スライダーで音量を調整します。「確認」ボタンで通知音を試聴できます。
4. あとは VRChat を遊ぶだけです。設定に合わせて通知音が鳴ります。
5. 一時的に通知を止めたいときは、右下のボタンで中断・再開を切り替えられます。

※ アプリは1つしか起動できません。すでに起動している場合はメッセージが表示されます。

## 仕組み

VRChat が PC 内に出力するログファイル（`%USERPROFILE%\AppData\LocalLow\VRChat\VRChat`）を読み取り、ユーザーの入退室とインスタンスの種類を判定しています。

- VRChat の API へのアクセスは行っておりません。
- VRChat 本体の改変も行いません。

## 設定ファイルの保存場所

```
%USERPROFILE%\Documents\VRCNotification\SelectingInstance.json
```

## アンインストール

Windows の「設定」→「アプリ」→「インストールされているアプリ」から **VRCNotification** を選び、「アンインストール」を押します。

設定ファイル（上記）はアンインストール後も残ります。不要な場合は手動で削除してください。

## よくある質問

**Q. 通知音が鳴りません。**
- インスタンス設定が「通知音無し」になっていないか確認してください。
- 右下のボタンが「中断」状態になっていないか確認してください。
- 音量が 0% になっていないか確認してください。

**Q. 現在のインスタンス種類が「VRChat停止中」のままです。**
- VRChat が起動しているか確認してください。

## 開発者向け

### 必要なもの
- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- Visual Studio 2022 以降（任意）

### ビルド

```
git clone https://github.com/hrt05/VRCNotification.git
cd VRCNotification
dotnet build VRCNotification.slnx
```

### インストーラーの作成

[Velopack](https://velopack.io/) を使っています。
※ `--packVersion` はリリースのたびに上げてください。

```
dotnet tool install -g vpk
dotnet publish VRCNotification/VRCNotification.csproj -c Release -r win-x64 --self-contained true -o publish
vpk pack --packId VRCNotification --packVersion 1.0.1 --runtime win-x64 --packDir publish --mainExe VRCNotification.exe --icon VRCNotification/Images/xamlIcon.ico
```

`Releases` フォルダに `VRCNotification-win-Setup.exe` が作成されます。

## 支援について

本ツールは無料でお使いいただけます。
開発を応援していただける方は、BOOTH の支援版をご購入いただけると励みになります（中身は無料版と同じです）。

【BOOTH の URL】

## ライセンス

[MIT License](LICENSE)

使用しているライブラリのライセンスは [THIRD-PARTY-NOTICES.md](THIRD-PARTY-NOTICES.md) をご覧ください。

## 作者

- Github https://github.com/hrt05
- X https://x.com/roko4649VR
