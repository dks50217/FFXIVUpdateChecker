# FFXIVUpdateChecker
FFXIV進版後簡易資料結構檢查

## 這個要做什麼

FFXIV每次進版後由SaintCoinach匯出資料，檢查當前匯出資料與目前漢化CSV比對用，快速改一份相容當前版本的漢化

## 執行步驟

* 先利用Saint Coinach中的 SaintCoinach.Cmd，將當前版本文本匯出，rawexd指令

    ```cmd
    SaintCoinach.Cmd.exe "{FFXIV Path}"
    Game version: 2023.XXXXXXXXX
    Definition version: 2023.XXXXXXXXX
    > lang Japanese
    > rawexd
    ```

* 執行本程式

    ```cmd
    dotnet run
    ```

* 輸入新路徑與舊路徑比較檔案欄位(UI待補)


