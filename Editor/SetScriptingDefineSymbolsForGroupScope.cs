using System;
using UnityEditor;

namespace Kogane
{
    /// <summary>
    /// PlayerSettings.SetScriptingDefineSymbolsForGroupScope の設定と復元を行うスコープ
    /// </summary>
    public sealed class SetScriptingDefineSymbolsForGroupScope : IDisposable
    {
        //================================================================================
        // 変数(readonly)
        //================================================================================
        private readonly bool             m_conditional;
        private readonly BuildTargetGroup m_targetGroup;
        private readonly string           m_oldDefines;

        //================================================================================
        // 関数
        //================================================================================
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public SetScriptingDefineSymbolsForGroupScope
        (
            BuildTargetGroup targetGroup,
            string           defines
        ) : this
        (
            conditional: true,
            targetGroup: targetGroup,
            defines: defines
        )
        {
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public SetScriptingDefineSymbolsForGroupScope
        (
            bool             conditional,
            BuildTargetGroup targetGroup,
            string           defines
        )
        {
            m_conditional = conditional;

            if ( !m_conditional ) return;

            m_targetGroup = targetGroup;
            m_oldDefines  = PlayerSettings.GetScriptingDefineSymbolsForGroup( m_targetGroup );

            PlayerSettings.SetScriptingDefineSymbolsForGroup( m_targetGroup, defines );
        }

        /// <summary>
        /// 破棄される時に呼び出されます
        /// </summary>
        public void Dispose()
        {
            if ( !m_conditional ) return;

            PlayerSettings.SetScriptingDefineSymbolsForGroup( m_targetGroup, m_oldDefines );
        }
    }
}