using System;
using UnityEditor;

namespace Kogane
{
    /// <summary>
    /// PlayerSettings.SetScriptingBackend の設定と復元を行うスコープ
    /// </summary>
    public sealed class SetScriptingBackendScope : IDisposable
    {
        //================================================================================
        // 変数(readonly)
        //================================================================================
        private readonly BuildTargetGroup        m_targetGroup;
        private readonly ScriptingImplementation m_oldBackend;

        //================================================================================
        // 関数
        //================================================================================
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public SetScriptingBackendScope
        (
            BuildTargetGroup        targetGroup,
            ScriptingImplementation backend
        )
        {
            m_targetGroup = targetGroup;
            m_oldBackend  = PlayerSettings.GetScriptingBackend( m_targetGroup );

            PlayerSettings.SetScriptingBackend( m_targetGroup, backend );
        }

        /// <summary>
        /// 破棄される時に呼び出されます
        /// </summary>
        public void Dispose()
        {
            PlayerSettings.SetScriptingBackend( m_targetGroup, m_oldBackend );
        }
    }
}