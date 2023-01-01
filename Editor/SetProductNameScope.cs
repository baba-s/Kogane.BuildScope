using System;
using UnityEditor;

namespace Kogane
{
    /// <summary>
    /// PlayerSettings.productName の設定と復元を行うスコープ
    /// </summary>
    public sealed class SetProductNameScope : IDisposable
    {
        //================================================================================
        // 変数(readonly)
        //================================================================================
        private readonly string m_oldValue;

        //================================================================================
        // 関数
        //================================================================================
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public SetProductNameScope( string value )
        {
            m_oldValue                 = PlayerSettings.productName;
            PlayerSettings.productName = value;
        }

        /// <summary>
        /// 破棄される時に呼び出されます
        /// </summary>
        public void Dispose()
        {
            PlayerSettings.productName = m_oldValue;
        }
    }
}