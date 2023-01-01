using System;
using UnityEditor;

namespace Kogane
{
    /// <summary>
    /// ビルドのために書き換えた設定を元に戻した後にディスクに保存するためのスコープ
    /// </summary>
    public sealed class SaveAssetsScope : IDisposable
    {
        //================================================================================
        // 関数
        //================================================================================
        /// <summary>
        /// ビルド終了時に呼び出されます
        /// </summary>
        public void Dispose()
        {
            AssetDatabase.SaveAssets();
        }
    }
}